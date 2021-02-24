using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace MscrmTools.EnvironmentVariableManager
{
    public partial class EvmControl : PluginControlBase, IGitHubPlugin, IPayPalPlugin
    {
        private readonly List<int> _rowsIndexChanged = new List<int>();

        public EvmControl()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (newService != null)
            {
                LoadVariables();
            }
        }

        private void toolStripMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == tsbLoad)
            {
                ExecuteMethod(LoadVariables);
            }
        }

        private void LoadVariables()
        {
            var variables = Service.RetrieveMultiple(new QueryExpression("environmentvariablevalue")
            {
                NoLock = true,
                ColumnSet = new ColumnSet("value"),
                LinkEntities =
                {
                    new LinkEntity
                    {
                        LinkFromEntityName = "environmentvariablevalue",
                        LinkFromAttributeName = "environmentvariabledefinitionid",
                        LinkToAttributeName = "environmentvariabledefinitionid",
                        LinkToEntityName = "environmentvariabledefinition",
                        Columns = new ColumnSet("displayname", "schemaname", "type"),
                        EntityAlias = "def",
                        Orders = { new OrderExpression("displayname", OrderType.Ascending) }
                    }
                }
            });

            var table = new DataTable();
            table.Columns.Add(new DataColumn("Variable name") { ReadOnly = true });
            table.Columns.Add(new DataColumn("Schema name") { ReadOnly = true });
            table.Columns.Add(new DataColumn("Value"));
            table.Columns.Add(new DataColumn("Id") { ReadOnly = true });
            table.Columns.Add(new DataColumn("Type") { ReadOnly = true });
            table.Columns.Add(new DataColumn("TypeInt") { ReadOnly = true });

            foreach (var variable in variables.Entities)
            {
                table.Rows.Add(
                    variable.GetAttributeValue<AliasedValue>("def.displayname").Value.ToString(),
                    variable.GetAttributeValue<AliasedValue>("def.schemaname").Value.ToString(),
                    variable.GetAttributeValue<string>("value"),
                    variable.Id,
                    variable.FormattedValues["def.type"],
                    ((OptionSetValue)variable.GetAttributeValue<AliasedValue>("def.type").Value).Value
                );
            }

            dataGridView1.DataSource = table;

            SetDatagridViewColumnsSettings();
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var changedCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var type = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
            if (type == 100000001)
            {
                if (!decimal.TryParse(changedCell.Value.ToString(), out decimal _))
                {
                    MessageBox.Show(this,
                        @"Provided value does not fit with data type Decimal.

Please correct the value", @"Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (type == 100000002)
            {
                if (!Boolean.TryParse(changedCell.Value.ToString(), out bool _))
                {
                    MessageBox.Show(this,
                        @"Provided value does not fit with data type Boolean.

Please correct the value: true or false", @"Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            _rowsIndexChanged.Add(e.RowIndex);

            foreach (DataGridViewCell cell in dataGridView1.Rows[e.RowIndex].Cells)
            {
                cell.Style.BackColor = Color.Yellow;
            }
        }

        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            if (_rowsIndexChanged.Count == 0)
            {
                MessageBox.Show(this, @"No variable was changed", @"Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(this, @"Are you sure you want to update these variables?", @"Question",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            var list = new List<Tuple<Guid, string, string, int>>();

            foreach (var index in _rowsIndexChanged)
            {
                var row = dataGridView1.Rows[index];
                var variable = row.Cells[0].Value.ToString();
                var id = new Guid(row.Cells[3].Value.ToString());
                var value = row.Cells[2].Value.ToString();

                list.Add(new Tuple<Guid, string, string, int>(id, variable, value, index));
            }

            WorkAsync(new WorkAsyncInfo
            {
                Work = (bw, evt) =>
                {
                    var errors = new Dictionary<string, string>();

                    foreach (var item in list)
                    {
                        bw.ReportProgress(0, $"Updating variable '{item.Item2}'");

                        try
                        {
                            Service.Update(new Entity("environmentvariablevalue")
                            {
                                Id = item.Item1,
                                Attributes =
                                {
                                    {"value", item.Item3}
                                }
                            });

                            _rowsIndexChanged.Remove(item.Item4);

                            Invoke(new Action(() =>
                            {
                                foreach (DataGridViewCell cell in dataGridView1.Rows[item.Item4].Cells)
                                {
                                    cell.Style.BackColor = Color.Green;
                                }
                            }));
                        }
                        catch (Exception error)
                        {
                            errors.Add(item.Item2, error.Message);
                        }
                    }

                    evt.Result = errors;
                },
                PostWorkCallBack = evt =>
                {
                    var errors = (Dictionary<string, string>)evt.Result;
                    if (errors.Count > 0)
                    {
                        MessageBox.Show(this, $@"The following error(s) occur(s):
{string.Join("\r\n- ", errors.Select(error => $"{error.Key}: {error.Value}"))}", @"Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }

                    foreach (DataGridViewRow row in dataGridView1.Rows)

                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Style.BackColor == Color.Green)
                                cell.Style.BackColor = Color.White;
                        }
                },
                ProgressChanged = evt =>
                {
                    SetWorkingMessage(evt.UserState.ToString());
                }
            });
        }

        private void SetDatagridViewColumnsSettings()
        {
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 600;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Visible = false;
        }

        #region Github

        public string RepositoryName => "MscrmTools.EnvironmentVariableManager";
        public string UserName => "MscrmTools";

        #endregion Github

        #region PayPal

        public string DonationDescription => "Donation for Environment Variable Manager (XrmToolBox)";
        public string EmailAccount => "tanguy92@hotmail.com";

        #endregion PayPal
    }
}