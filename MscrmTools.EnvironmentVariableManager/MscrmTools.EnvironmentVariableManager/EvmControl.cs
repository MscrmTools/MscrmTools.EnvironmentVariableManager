﻿using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using MscrmTools.EnvironmentVariableManager.Forms;
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

        private void btnValidateEnv_Click(object sender, EventArgs e)
        {
            var def = new Entity("environmentvariabledefinition")
            {
                Attributes =
                {
                    {"schemaname",txtUniqueName.Text},
                    {"displayname", txtDisplayName.Text},
                    {"description", txtDescription.Text},
                    {"defaultvalue", txtDefaultValue.Text},
                }
            };

            switch (cbbType.SelectedItem?.ToString())
            {
                case "String":
                    def["type"] = new OptionSetValue(100000000);
                    break;

                case "Number":
                    def["type"] = new OptionSetValue(100000001);
                    break;

                case "Boolean":
                    def["type"] = new OptionSetValue(100000002);
                    break;

                case "JSON":
                    def["type"] = new OptionSetValue(100000003);
                    break;

                case "Connection reference":
                    def["type"] = new OptionSetValue(100000004);
                    break;

                default:
                    MessageBox.Show(this, @"Please select a type for the environment variable", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            WorkAsync(new WorkAsyncInfo
            {
                Message = $"Creating environment variable {def.GetAttributeValue<string>("schema name")}",
                Work = (bw, evt) =>
                {
                    def.Id = Service.Create(def);
                },
                PostWorkCallBack = evt =>
                {
                    if (evt.Error != null)
                    {
                        MessageBox.Show(this, $@"An error occured when creating the environment variable: {evt.Error.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (MessageBox.Show(this, $@"Do you want to add variable {def.GetAttributeValue<string>("schema name")} in a solution?", @"Question",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        scMain.Panel2Collapsed = true;
                        LoadVariables();
                        return;
                    }

                    var dialog = new SolutionPicker(Service);
                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        WorkAsync(new WorkAsyncInfo
                        {
                            Message = $"Adding environment variable {def.GetAttributeValue<string>("schema name")} to solution {dialog.SelectedSolution.GetAttributeValue<string>("friendlyname")}",
                            Work = (bw, evt2) =>
                            {
                                Service.Execute(new AddSolutionComponentRequest
                                {
                                    ComponentId = def.Id,
                                    ComponentType = 380,
                                    SolutionUniqueName = dialog.SelectedSolution.GetAttributeValue<string>("uniquename")
                                });

                                def.Id = Service.Create(def);
                            },
                            PostWorkCallBack = evt2 =>
                            {
                                if (evt.Error != null)
                                {
                                    MessageBox.Show(this, $@"An error occured when adding environment variable to the solution: {evt.Error.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                scMain.Panel2Collapsed = true;
                                LoadVariables();
                            }
                        });
                    }
                }
            });
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 2 || _rowsIndexChanged.Contains(e.RowIndex)) return;

            var changedCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var type = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
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
                if (!bool.TryParse(changedCell.Value.ToString(), out bool _))
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

        private void LoadVariables()
        {
            var variables = Service.RetrieveMultiple(new QueryExpression("environmentvariabledefinition")
            {
                NoLock = true,
                ColumnSet = new ColumnSet("displayname", "schemaname", "type"),
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
                    }
                },
                Orders = { new OrderExpression("displayname", OrderType.Ascending) }
            });

            var table = new DataTable();
            table.Columns.Add(new DataColumn("Variable name") { ReadOnly = true });
            table.Columns.Add(new DataColumn("Schema name") { ReadOnly = true });
            table.Columns.Add(new DataColumn("Value"));
            table.Columns.Add(new DataColumn("ValueId"));
            table.Columns.Add(new DataColumn("DefId") { ReadOnly = true });
            table.Columns.Add(new DataColumn("Type") { ReadOnly = true });
            table.Columns.Add(new DataColumn("TypeInt") { ReadOnly = true });

            foreach (var variable in variables.Entities)
            {
                Guid id = Guid.Empty;
                if (variable.GetAttributeValue<AliasedValue>("val.environmentvariablevalueid") != null)
                {
                    id = (Guid)variable.GetAttributeValue<AliasedValue>("val.environmentvariablevalueid").Value;
                }

                table.Rows.Add(
                    variable.GetAttributeValue<string>("displayname"),
                    variable.GetAttributeValue<string>("schemaname"),
                    variable.GetAttributeValue<AliasedValue>("val.value")?.Value?.ToString() ?? "",
                    id.ToString(),
                    variable.Id,
                    variable.FormattedValues["type"],
                    variable.GetAttributeValue<OptionSetValue>("type").Value
                );
            }

            dataGridView1.DataSource = table;

            SetDatagridViewColumnsSettings();
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
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

        private void toolStripMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == tsbLoad)
            {
                ExecuteMethod(LoadVariables);
            }
        }

        private void tsbCreateNewVarEnvDef_Click(object sender, EventArgs e)
        {
            txtDisplayName.Text = "";
            txtUniqueName.Text = "";
            txtDescription.Text = "";
            txtDefaultValue.Text = "";
            cbbType.SelectedIndex = -1;

            scMain.Panel2Collapsed = false;
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView1.SelectedRows[0];

            var defId = new Guid(selectedRow.Cells[4].Value?.ToString() ?? Guid.Empty.ToString());
            if (defId == Guid.Empty)
            {
                MessageBox.Show(this, @"Unable to find environment variable definition ID", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var variable = selectedRow.Cells[0].Value.ToString();

            if (MessageBox.Show(this, $@"Are you sure you want to delete variable {variable}?", @"Question",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            WorkAsync(new WorkAsyncInfo
            {
                Message = $"Deleting environment variable {variable}...",
                Work = (bw, evt) =>
                {
                    Service.Delete("environmentvariabledefinition", defId);
                },
                PostWorkCallBack = evt =>
                {
                    if (evt.Error != null)
                    {
                        MessageBox.Show(this, $@"An error occured when deleting the environment variable: {evt.Error.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    LoadVariables();
                }
            });
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

            var list = new List<Tuple<Guid, Guid, string, string, int>>();

            foreach (var index in _rowsIndexChanged)
            {
                var row = dataGridView1.Rows[index];
                var variable = row.Cells[0].Value.ToString();
                var id = new Guid(row.Cells[3].Value?.ToString() ?? Guid.Empty.ToString());
                var defId = new Guid(row.Cells[4].Value?.ToString() ?? Guid.Empty.ToString());
                var value = row.Cells[2].Value.ToString();

                list.Add(new Tuple<Guid, Guid, string, string, int>(id, defId, variable, value, index));
            }

            WorkAsync(new WorkAsyncInfo
            {
                Work = (bw, evt) =>
                {
                    var errors = new Dictionary<string, string>();

                    foreach (var item in list)
                    {
                        bw.ReportProgress(0, $"Updating variable '{item.Item3}'");
                        Guid id = Guid.Empty;
                        try
                        {
                            if (item.Item1 == Guid.Empty)
                            {
                                id = Service.Create(new Entity("environmentvariablevalue")
                                {
                                    Attributes =
                                    {
                                        {"environmentvariabledefinitionid", new EntityReference("environmentvariabledefinition", item.Item2)},
                                        {"value", item.Item4 }
                                    }
                                });
                            }
                            else
                            {
                                Service.Update(new Entity("environmentvariablevalue")
                                {
                                    Id = item.Item1,
                                    Attributes =
                                    {
                                        {"value", item.Item4 }
                                    }
                                });
                            }

                            _rowsIndexChanged.Remove(item.Item5);

                            Invoke(new Action(() =>
                            {
                                if (id != Guid.Empty)
                                {
                                    dataGridView1.Rows[item.Item5].Cells[3].Value = id.ToString();
                                }

                                foreach (DataGridViewCell cell in dataGridView1.Rows[item.Item5].Cells)
                                {
                                    cell.Style.BackColor = Color.Green;
                                }
                            }));
                        }
                        catch (Exception error)
                        {
                            errors.Add(item.Item4, error.Message);
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