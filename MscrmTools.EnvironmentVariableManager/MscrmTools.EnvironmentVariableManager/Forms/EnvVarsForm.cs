using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using MscrmTools.EnvironmentVariableManager.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace MscrmTools.EnvironmentVariableManager.Forms
{
    public partial class EnvVarsForm : DockContent
    {
        private readonly List<int> _rowsIndexChanged = new List<int>();
        private int lastSelectedIndex = -1;
        private EntityCollection variables;

        public EnvVarsForm()
        {
            InitializeComponent();
        }

        public event EventHandler<EnvironmentVariableEventArgs> OnVariableSelected;

        public List<DataGridViewRow> ChangedRows => dataGridView1.Rows.Cast<DataGridViewRow>().Where(r => _rowsIndexChanged.Contains(r.Index)).ToList();
        public DataGridViewRow SelectedRow => dataGridView1.SelectedRows.Count < 1 ? null : dataGridView1.SelectedRows[0];
        public IOrganizationService Service { get; set; }

        public void DisplayRows(object filter = null)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (filter == null)
                        {
                            row.Visible = true;
                            continue;
                        }

                        var isVisible = row.Cells[0].Value.ToString().ToLower().IndexOf(filter.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0
                                     || row.Cells[1].Value.ToString().ToLower().IndexOf(filter.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0
                                     || row.Cells[2].Value.ToString().ToLower().IndexOf(filter.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0;

                        row.Visible = isVisible;
                    }
                }));

                return;
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (filter == null)
                {
                    row.Visible = true;
                    continue;
                }

                var isVisible = row.Cells[0].Value != null && row.Cells[0].Value.ToString().ToLower().IndexOf(filter.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0
                             || row.Cells[1].Value != null && row.Cells[1].Value.ToString().ToLower().IndexOf(filter.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0
                             || row.Cells[2].Value != null && row.Cells[2].Value.ToString().ToLower().IndexOf(filter.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0;

                row.Visible = isVisible;
            }
        }

        public void DisplayVariables()
        {
            dataGridView1.Rows.Clear();

            foreach (var variableGroup in variables.Entities.GroupBy(g => g.GetAttributeValue<string>("schemaname")))
            {
                var variable = variableGroup.First();
                var solutions = variableGroup.Where(vg => vg.GetAttributeValue<AliasedValue>("solution1.friendlyname") != null).ToList();
                var solutionsList = "";

                Guid id = Guid.Empty;
                if (variable.GetAttributeValue<AliasedValue>("val.environmentvariablevalueid") != null)
                {
                    id = (Guid)variable.GetAttributeValue<AliasedValue>("val.environmentvariablevalueid").Value;
                }

                string ttt = string.Empty;
                if (solutions.Count > 0)
                {
                    solutionsList = string.Join("\n- ", solutions.Select(vg => vg.GetAttributeValue<AliasedValue>("solution1.friendlyname").Value.ToString()).ToList());

                    ttt = $@"This environment variable value has been imported with a managed solution.

Be careful! If you import the same solution(s) using Upgrade method and you overwrite unmanaged customization, this could lead to a removal of this environment variable value.

The solution involved are the following:
- {solutionsList}
";
                }

                dataGridView1.Rows.Add(
                    new DataGridViewRow
                    {
                        Tag = variable,
                        Cells =
                        {
                            new TextAndImageCell{Value = variable.GetAttributeValue<string>("displayname"),DisplayWarningImage= solutions.Count > 0, ToolTipText = ttt},
                            new DataGridViewTextBoxCell{Value = variable.GetAttributeValue<string>("schemaname")},
                            new DataGridViewTextBoxCell{Value = variable.GetAttributeValue<AliasedValue>("val.value")?.Value?.ToString() ?? ""},
                            new DataGridViewTextBoxCell{Value = id.ToString()},
                            new DataGridViewTextBoxCell{Value = variable.Id.ToString()},
                            new DataGridViewTextBoxCell{Value = variable.FormattedValues["type"]},
                            new DataGridViewTextBoxCell{Value = variable.GetAttributeValue<OptionSetValue>("type").Value.ToString()}
                        }
                    }
                );
            }

            SetDatagridViewColumnsSettings();
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
        }

        public void LoadVariables()
        {
            variables = Service.RetrieveMultiple(new QueryExpression("environmentvariabledefinition")
            {
                NoLock = true,
                ColumnSet = new ColumnSet("displayname", "schemaname", "type", "description", "defaultvalue"),
                LinkEntities =
                {
                    new LinkEntity
                    {
                        JoinOperator = JoinOperator.LeftOuter,
                        LinkFromEntityName = "environmentvariabledefinition",
                        LinkFromAttributeName = "environmentvariabledefinitionid",
                        LinkToAttributeName = "environmentvariabledefinitionid",
                        LinkToEntityName = "environmentvariablevalue",
                        Columns = new ColumnSet("value","environmentvariablevalueid"),
                        EntityAlias = "val",
                        LinkEntities =
                        {
                            new LinkEntity
                            {
                                JoinOperator = JoinOperator.LeftOuter,
                                LinkFromEntityName = "environmentvariablevalue",
                                LinkFromAttributeName = "environmentvariablevalueid",
                                LinkToAttributeName = "objectid",
                                LinkToEntityName = "solutioncomponent",
                                Columns = new ColumnSet("solutioncomponentid"),
                                EntityAlias = "solutionComponent",
                                LinkEntities =
                                {
                                    new LinkEntity
                                    {
                                        JoinOperator = JoinOperator.LeftOuter,
                                        LinkFromEntityName = "solutioncomponent",
                                        LinkFromAttributeName = "solutionid",
                                        LinkToAttributeName = "solutionid",
                                        LinkToEntityName = "solution",
                                        Columns = new ColumnSet("friendlyname","uniquename"),
                                          LinkCriteria = new FilterExpression
                                          {
                                              Conditions =
                                              {
                                                  new ConditionExpression("uniquename", ConditionOperator.NotEqual, "Default"),
                                                  new ConditionExpression("uniquename", ConditionOperator.NotEqual, "Active"),
                                                  new ConditionExpression("ismanaged", ConditionOperator.Equal, true),
                                              }
                                          }
                                    }
                                }
                            }
                        }
                    }
                },
                Orders = { new OrderExpression("displayname", OrderType.Ascending) }
            });
        }

        public void SetNewId(int index, Guid id)
        {
            dataGridView1.Rows[index].Cells[3].Value = id.ToString();

            foreach (DataGridViewCell cell in dataGridView1.Rows[index].Cells)
            {
                cell.Style.BackColor = Color.LightGreen;
            }
        }

        public void SetSuccess(int index)
        {
            foreach (DataGridViewCell cell in dataGridView1.Rows[index].Cells)
            {
                cell.Style.BackColor = Color.LightGreen;
            }

            _rowsIndexChanged.Remove(index);
        }

        internal void ClearSelected()
        {
            dataGridView1.ClearSelection();
        }

        internal void ClearSuccess()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Style.BackColor == Color.LightGreen)
                        cell.Style.BackColor = Color.White;
                }

            }
        }

        private void cmsEnvs_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1) return;

            var row = dataGridView1.SelectedRows[0];

            if (e.ClickedItem == tsmiCopyName)
            {
                Clipboard.SetText(row.Cells[0].Value?.ToString() ?? "");
            }
            else if (e.ClickedItem == tsmiCopySchemaName)
            {
                Clipboard.SetText(row.Cells[1].Value?.ToString() ?? "");
            }
            else if (e.ClickedItem == tsmiCopyValue)
            {
                Clipboard.SetText(row.Cells[2].Value?.ToString() ?? "");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                if (row.Cells[5].Value.ToString() == "Secret")
                {
                    var dialog = new SecretForm(row.Cells[2].Value?.ToString() ?? "");
                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        row.Cells[2].Value = dialog.SecretPath;
                    }
                }
                else if (row.Cells[5].Value.ToString() == "JSON")
                {
                    var dialog = new JsonForm(row.Cells[2].Value?.ToString() ?? "");
                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        row.Cells[2].Value = dialog.Json;
                    }
                }
            }
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 2 || _rowsIndexChanged.Contains(e.RowIndex)) return;

            var changedCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var type = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
            if (type == 100000001)
            {
                if (!decimal.TryParse(changedCell.Value.ToString(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture.NumberFormat, out decimal _))
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
                if (!Validator.ValidateBoolean(changedCell.Value.ToString()))
                {
                    MessageBox.Show(this,
                        @"Provided value does not fit with data type Boolean.

Please correct the value: yes or no", @"Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            _rowsIndexChanged.Add(e.RowIndex);

            foreach (DataGridViewCell cell in dataGridView1.Rows[e.RowIndex].Cells)
            {
                cell.Style.BackColor = Color.Yellow;
            }

            dataGridView1.ClearSelection();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == lastSelectedIndex) return;
            lastSelectedIndex = e.RowIndex;

            var row = dataGridView1.Rows[e.RowIndex];
            var id = new Guid(row.Cells[3].Value?.ToString() ?? Guid.Empty.ToString());
            var defId = new Guid(row.Cells[4].Value?.ToString() ?? Guid.Empty.ToString());

            OnVariableSelected?.Invoke(this, new EnvironmentVariableEventArgs
            {
                DefinitionId = defId,
                VariableId = id,
                Definition = row.Tag as Entity
            });
        }

        private void SetDatagridViewColumnsSettings()
        {
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 600;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Visible = false;
        }
    }
}