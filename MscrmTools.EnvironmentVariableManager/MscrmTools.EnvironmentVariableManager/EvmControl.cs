using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using MscrmTools.EnvironmentVariableManager.AppCode;
using MscrmTools.EnvironmentVariableManager.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace MscrmTools.EnvironmentVariableManager
{
    public partial class EvmControl : PluginControlBase, IGitHubPlugin, IPayPalPlugin
    {
        private readonly List<int> _rowsIndexChanged = new List<int>();
        private Guid currentDefinitionId;

        private Thread searchThread;

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
                LoadSolutions();
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

            if (currentDefinitionId != Guid.Empty)
            {
                def.Id = currentDefinitionId;
            }

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

                case "Secret":
                    def["type"] = new OptionSetValue(100000005);
                    break;

                default:
                    MessageBox.Show(this, @"Please select a type for the environment variable", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            WorkAsync(new WorkAsyncInfo
            {
                Message = $"{(def.Id == Guid.Empty ? "Creating" : "Updating")} environment variable definition {def.GetAttributeValue<string>("schema name")}",
                Work = (bw, evt) =>
                {
                    if (def.Id == Guid.Empty)
                    {
                        def.Id = Service.Create(def);
                    }
                    else
                    {
                        Service.Update(def);
                    }
                },
                PostWorkCallBack = evt =>
                {
                    if (evt.Error != null)
                    {
                        MessageBox.Show(this, $@"An error occured when processing environment variable definition: {evt.Error.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (currentDefinitionId == Guid.Empty)
                    {
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
                                Message = $"Adding environment variable definition {def.GetAttributeValue<string>("schema name")} to solution {dialog.SelectedSolution.GetAttributeValue<string>("friendlyname")}",
                                Work = (bw, evt2) =>
                                {
                                    Service.Execute(new AddSolutionComponentRequest
                                    {
                                        ComponentId = def.Id,
                                        ComponentType = 380,
                                        SolutionUniqueName = dialog.SelectedSolution.GetAttributeValue<string>("uniquename")
                                    });
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
                }
            });
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
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            var id = new Guid(row.Cells[3].Value?.ToString() ?? Guid.Empty.ToString());
            var defId = new Guid(row.Cells[4].Value?.ToString() ?? Guid.Empty.ToString());
            currentDefinitionId = defId;

            if (id != Guid.Empty)
            {
                var variable = Service.RetrieveMultiple(new QueryExpression("environmentvariablevalue")
                {
                    NoLock = true,
                    ColumnSet = new ColumnSet(true),
                    Criteria = new FilterExpression
                    {
                        Conditions =
                       {
                           new ConditionExpression("environmentvariablevalueid", ConditionOperator.Equal, id)
                       }
                    },
                    LinkEntities =
                    {
                        new LinkEntity
                        {
                            LinkFromEntityName = "environmentvariablevalue",
                            LinkFromAttributeName = "environmentvariabledefinitionid",
                            LinkToAttributeName = "environmentvariabledefinitionid",
                            LinkToEntityName = "environmentvariabledefinition",
                            Columns = new ColumnSet("displayname","schemaname","description","defaultvalue", "type"),
                            EntityAlias = "def"
                        }
                    }
                }).Entities.First();

                txtDisplayName.Text = variable.GetAttributeValue<AliasedValue>("def.displayname")?.Value.ToString();
                txtUniqueName.Text = variable.GetAttributeValue<AliasedValue>("def.schemaname")?.Value.ToString();
                txtDescription.Text = variable.GetAttributeValue<AliasedValue>("def.description")?.Value.ToString();
                txtDefaultValue.Text = variable.GetAttributeValue<AliasedValue>("def.defaultvalue")?.Value.ToString();
                cbbType.SelectedItem = variable.FormattedValues["def.type"];
                scMain.Panel2Collapsed = false;
            }
            else
            {
                var def = Service.RetrieveMultiple(new QueryExpression("environmentvariabledefinition")
                {
                    NoLock = true,
                    ColumnSet = new ColumnSet("displayname", "schemaname", "description", "defaultvalue", "type"),
                    Criteria = new FilterExpression
                    {
                        Conditions =
                       {
                           new ConditionExpression("environmentvariabledefinitionid", ConditionOperator.Equal, defId)
                       }
                    }
                }).Entities.FirstOrDefault();

                if (def != null)
                {
                    txtDisplayName.Text = def.GetAttributeValue<string>("displayname");
                    txtUniqueName.Text = def.GetAttributeValue<string>("schemaname");
                    txtDescription.Text = def.GetAttributeValue<string>("description");
                    txtDefaultValue.Text = def.GetAttributeValue<string>("defaultvalue");
                    cbbType.SelectedItem = def.FormattedValues["type"];
                    scMain.Panel2Collapsed = false;
                }
            }

            txtUniqueName.Enabled = false;
            cbbType.Enabled = false;
            gbEnvVariable.Text = "Environment Variable definition";
        }

        private void DisplayRows(object filter = null)
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

        private void EvmControl_Resize(object sender, EventArgs e)
        {
            excelImportDialog1.Width = Convert.ToInt32(Width * 0.9);
            excelImportDialog1.Height = Convert.ToInt32(Height * 0.9);
            excelImportDialog1.Location = new Point(Width / 2 - excelImportDialog1.Width / 2, Height / 2 - excelImportDialog1.Height / 2);
        }

        private void ExcelImportDialog1_OnImportRequested(object sender, UpdateEnvironmentVariablesEventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show(this, $"Are you sure you want to import {e.Variables.Count} environment variables?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                WorkAsync(new WorkAsyncInfo
                {
                    Message = "Importing environment variables...",
                    Work = (bw, evt) =>
                    {
                        foreach (var variable in e.Variables)
                        {
                            if (variable.Id == Guid.Empty)
                            {
                                bw.ReportProgress(0, $"Creating variable '{variable.GetAttributeValue<string>("schemaname")}'...");

                                // Creating the new Environment Variable definition
                                var def = new Entity("environmentvariabledefinition")
                                {
                                    Attributes =
                                    {
                                        {"schemaname",variable.GetAttributeValue<string>("schemaname")},
                                        {"displayname", variable.GetAttributeValue<string>("displayname")},
                                        {"description", variable.GetAttributeValue<string>("description")},
                                    }
                                };

                                switch (variable.GetAttributeValue<string>("type"))
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

                                    case "Secret":
                                        def["type"] = new OptionSetValue(100000005);
                                        break;

                                    default:
                                        MessageBox.Show(this, @"Please select a type for the environment variable", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                }

                                def.Id = Service.Create(def);
                                variable.Id = def.Id;

                                if (!string.IsNullOrEmpty(variable.GetAttributeValue<string>("solutionuniquename")))
                                {
                                    bw.ReportProgress(0, $"Adding variable '{variable.GetAttributeValue<string>("schemaname")}' to selected solution...");

                                    Service.Execute(new AddSolutionComponentRequest
                                    {
                                        ComponentId = def.Id,
                                        ComponentType = 380,
                                        SolutionUniqueName = variable.GetAttributeValue<string>("solutionuniquename")
                                    });
                                }

                                Service.Create(new Entity("environmentvariablevalue")
                                {
                                    Attributes =
                                    {
                                        {"environmentvariabledefinitionid",def.ToEntityReference()},
                                        {"value", variable.GetAttributeValue<string>("value") }
                                    }
                                });
                            }

                            bw.ReportProgress(0, $"Udpating variable '{variable.GetAttributeValue<string>("schemaname")}'...");

                            var varToUpdate = Service.RetrieveMultiple(new QueryExpression("environmentvariablevalue")
                            {
                                Criteria =
                                {
                                    Conditions =
                                    {
                                        new ConditionExpression("environmentvariabledefinitionid", ConditionOperator.Equal, variable.Id)
                                    }
                                }
                            }).Entities.First();

                            varToUpdate["value"] = variable.GetAttributeValue<string>("value");

                            Service.Update(varToUpdate);
                        }
                    },
                    ProgressChanged = evt =>
                    {
                        SetWorkingMessage(evt.UserState.ToString());
                    },
                    PostWorkCallBack = evt =>
                    {
                        if (evt.Error != null)
                        {
                            MessageBox.Show(this, "An error occured when importing Environment Variables: " + evt.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        excelImportDialog1.Visible = false;
                        excelImportDialog1.Reset();
                        LoadVariables();
                    }
                });
            }
        }

        private EntityCollection GetVariables()
        {
            return Service.RetrieveMultiple(new QueryExpression("environmentvariabledefinition")
            {
                NoLock = true,
                ColumnSet = new ColumnSet("displayname", "schemaname", "type", "description"),
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
        }

        private void LoadSolutions()
        {
            QueryExpression qe = new QueryExpression("solution");
            qe.Distinct = true;
            qe.ColumnSet = Solution.Columns;
            qe.Criteria = new FilterExpression();
            qe.Criteria.AddCondition(new ConditionExpression("ismanaged", ConditionOperator.Equal, false));
            qe.Criteria.AddCondition(new ConditionExpression("isvisible", ConditionOperator.Equal, true));
            qe.Criteria.AddCondition(new ConditionExpression("uniquename", ConditionOperator.NotEqual, "Default"));

            excelImportDialog1.Solutions = Service.RetrieveMultiple(qe).Entities.ToList();
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

            DisplayRows(tstxtSearch.Text);

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
                LoadSolutions();
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
            currentDefinitionId = Guid.Empty;
            txtUniqueName.Enabled = true;
            cbbType.Enabled = true;
            gbEnvVariable.Text = "New Environment Variable definition";
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

        private void tsbExportExcel_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog { AddExtension = true, DefaultExt = "xlsx", Filter = "Excel files|*.xlsx", FileName = "EnvironmentVariables.xlsx" })
            {
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    WorkAsync(new WorkAsyncInfo
                    {
                        Message = "Exporting environment variables to Excel...",
                        Work = (bw, evt) =>
                        {
                            EntityCollection variables = GetVariables();

                            var excelManager = new ExcelManager(sfd.FileName);
                            excelManager.ExportToExcel(variables.Entities.ToList(), ConnectionDetail.OrganizationFriendlyName);
                        },
                        PostWorkCallBack = evt =>
                        {
                            if (evt.Error != null)
                            {
                                MessageBox.Show(this, $"An error occured when exporting the environment variables: {evt.Error.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (DialogResult.Yes == MessageBox.Show(this, "Environment variables have been exported to Excel.\n\nWould you like to open the file now?", @"Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                            {
                                Process.Start(sfd.FileName);
                            }
                        },
                        ProgressChanged = evt =>
                        {
                            SetWorkingMessage(evt.UserState.ToString());
                        }
                    });
                }
            }
        }

        private void tsbImportFromExcel_Click(object sender, EventArgs e)
        {
            excelImportDialog1.Visible = true;
            excelImportDialog1.Variables = GetVariables().Entities.ToList();
            excelImportDialog1.OnImportRequested -= ExcelImportDialog1_OnImportRequested;
            excelImportDialog1.OnImportRequested += ExcelImportDialog1_OnImportRequested;
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

        private void tstxtSearch_TextChanged(object sender, EventArgs e)
        {
            searchThread?.Abort();
            searchThread = new Thread(DisplayRows);
            searchThread.Start(tstxtSearch.Text);
        }
    }
}