using Microsoft.Xrm.Sdk;
using MscrmTools.EnvironmentVariableManager.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace MscrmTools.EnvironmentVariableManager.Forms
{
    public partial class VariableForm : DockContent
    {
        private Entity currentVar;

        public VariableForm(List<Entity> solutions)
        {
            InitializeComponent();

            cbbSolution.Items.Add("-- Select a solution --");
            cbbSolution.Items.AddRange(solutions.Select(e => new AppCode.SolutionInfo(e)).ToArray());
            cbbSolution.SelectedIndex = 0;

            cbbType.SelectedIndex = 0;
        }

        public event EventHandler<EnvironmentVariableActionEventArgs> OnVariableActionRequested;

        public void DisplayEnvironmentVariable(Entity record)
        {
            currentVar = record;

            txtDisplayName.Text = record.GetAttributeValue<string>("displayname")?.ToString();
            txtUniqueName.Text = record.GetAttributeValue<string>("schemaname")?.ToString();
            txtDescription.Text = record.GetAttributeValue<string>("description")?.ToString();
            txtDefaultValue.Text = record.GetAttributeValue<string>("defaultvalue")?.ToString();
            cbbType.SelectedItem = record.FormattedValues["type"];

            txtUniqueName.Enabled = false;
            cbbType.Enabled = false;
        }

        private void btnValidateEnv_Click(object sender, System.EventArgs e)
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

            if ((currentVar?.GetAttributeValue<Guid?>("environmentvariabledefinitionid") ?? Guid.Empty) != Guid.Empty)
            {
                def.Id = currentVar.GetAttributeValue<Guid>("environmentvariabledefinitionid");
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

            OnVariableActionRequested?.Invoke(this, new EnvironmentVariableActionEventArgs
            {
                Definition = def,
                Solution = cbbSolution.SelectedIndex == 0 ? null : ((AppCode.SolutionInfo)cbbSolution.SelectedItem).Entity
            });
        }
    }
}