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
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace MscrmTools.EnvironmentVariableManager
{
    public partial class EvmControl : PluginControlBase, IGitHubPlugin, IPayPalPlugin
    {
        private readonly List<int> _rowsIndexChanged = new List<int>();
        private Guid currentDefinitionId;
        private EnvVarsForm evf;
        private Thread searchThread;
        private List<Entity> solutions;

        public EvmControl()
        {
            InitializeComponent();

            SetTheme();

            evf = new EnvVarsForm();
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (newService != null)
            {
                evf.Service = newService;
                evf.Show(dpMain, WeifenLuo.WinFormsUI.Docking.DockState.Document);

                LoadVariables();
                LoadSolutions();
            }
        }

        private void Evf_OnVariableSelected(object sender, EnvironmentVariableEventArgs e)
        {
            var existingContent = dpMain.Contents.OfType<VariableForm>().FirstOrDefault();
            if (existingContent != null) existingContent.Close();

            var variableForm = new VariableForm(solutions);
            variableForm.DisplayEnvironmentVariable(e.Definition);
            variableForm.OnVariableActionRequested += VariableForm_OnVariableActionRequested;
            variableForm.Show(dpMain, DockState.DockRight);
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

            solutions = Service.RetrieveMultiple(qe).Entities.ToList();
            excelImportDialog1.Solutions = solutions;
        }

        private void LoadVariables()
        {
            evf.OnVariableSelected -= Evf_OnVariableSelected;

            var existingContent = dpMain.Contents.OfType<VariableForm>().FirstOrDefault();
            if (existingContent != null) existingContent.Close();

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading environment variables...",
                Work = (bw, evt) =>
                {
                    evf.LoadVariables();
                },
                PostWorkCallBack = evt =>
                {
                    if (evt.Error != null)
                    {
                        MessageBox.Show(this, "An error occured when loading Environment Variables: " + evt.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    evf.DisplayVariables();
                    evf.OnVariableSelected += Evf_OnVariableSelected;
                }
            });
        }

        private void SetTheme()
        {
            if (XrmToolBox.Options.Instance.Theme != null)
            {
                switch (XrmToolBox.Options.Instance.Theme)
                {
                    case "Blue theme":
                        {
                            var theme = new VS2015BlueTheme();
                            dpMain.Theme = theme;
                        }
                        break;

                    case "Light theme":
                        {
                            var theme = new VS2015LightTheme();
                            dpMain.Theme = theme;
                        }
                        break;

                    case "Dark theme":
                        {
                            var theme = new VS2015DarkTheme();
                            dpMain.Theme = theme;
                        }
                        break;
                }
            }
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
            var existingContent = dpMain.Contents.OfType<VariableForm>().FirstOrDefault();
            if (existingContent != null) existingContent.Close();

            var variableForm = new VariableForm(solutions);
            variableForm.OnVariableActionRequested += VariableForm_OnVariableActionRequested;
            variableForm.Show(dpMain, DockState.DockRight);
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            var selectedRow = evf.SelectedRow;
            if (selectedRow == null) return;

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
            using (var sfd = new SaveFileDialog { AddExtension = true, DefaultExt = "xlsx", Filter = "Excel files|*.xlsx", FileName = "EnvironmentVariables.xlsx", Title = "You can use the same file to store values from different environments. One sheet will be created for each environment." })
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
            excelImportDialog1.BringToFront();
            excelImportDialog1.Visible = true;
            excelImportDialog1.Variables = GetVariables().Entities.ToList();
            excelImportDialog1.OnImportRequested -= ExcelImportDialog1_OnImportRequested;
            excelImportDialog1.OnImportRequested += ExcelImportDialog1_OnImportRequested;
        }

        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            if (evf.ChangedRows.Count == 0)
            {
                MessageBox.Show(this, @"No variable was changed", @"Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(this, @"Are you sure you want to update these variables?", @"Question",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            var list = new List<Tuple<Guid, Guid, string, string, int>>();

            foreach (var row in evf.ChangedRows)
            {
                var variable = row.Cells[0].Value.ToString();
                var id = new Guid(row.Cells[3].Value?.ToString() ?? Guid.Empty.ToString());
                var defId = new Guid(row.Cells[4].Value?.ToString() ?? Guid.Empty.ToString());
                var value = row.Cells[2].Value.ToString();

                list.Add(new Tuple<Guid, Guid, string, string, int>(id, defId, variable, value, row.Index));
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
                                    evf.SetNewId(item.Item5, id);
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

                    evf.ClearSuccess();
                },
                ProgressChanged = evt =>
                {
                    SetWorkingMessage(evt.UserState.ToString());
                }
            });
        }

        private void tstxtSearch_TextChanged(object sender, EventArgs e)
        {
            searchThread?.Abort();
            searchThread = new Thread(evf.DisplayRows);
            searchThread.Start(tstxtSearch.Text);
        }

        private void VariableForm_OnVariableActionRequested(object sender, EnvironmentVariableActionEventArgs e)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = $"{(e.Definition.Id == Guid.Empty ? "Creating" : "Updating")} environment variable definition {e.Definition.GetAttributeValue<string>("schema name")}",
                Work = (bw, evt) =>
                {
                    if (e.Definition.Id == Guid.Empty)
                    {
                        e.Definition.Id = Service.Create(e.Definition);
                    }
                    else
                    {
                        Service.Update(e.Definition);
                    }
                },
                PostWorkCallBack = evt =>
                {
                    if (evt.Error != null)
                    {
                        MessageBox.Show(this, $@"An error occured when processing environment variable definition: {evt.Error.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (e.Solution != null)
                    {
                        WorkAsync(new WorkAsyncInfo
                        {
                            Message = $"Adding environment variable definition {e.Definition.GetAttributeValue<string>("schema name")} to solution {e.Solution.GetAttributeValue<string>("friendlyname")}",
                            Work = (bw, evt2) =>
                            {
                                Service.Execute(new AddSolutionComponentRequest
                                {
                                    ComponentId = e.Definition.Id,
                                    ComponentType = 380,
                                    SolutionUniqueName = e.Solution.GetAttributeValue<string>("uniquename")
                                });
                            },
                            PostWorkCallBack = evt2 =>
                            {
                                if (evt.Error != null)
                                {
                                    MessageBox.Show(this, $@"An error occured when adding environment variable to the solution: {evt.Error.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                LoadVariables();
                            }
                        });
                    }
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