using Microsoft.Xrm.Sdk;
using MscrmTools.EnvironmentVariableManager.AppCode;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MscrmTools.EnvironmentVariableManager.UserControls
{
    public partial class ExcelImportDialog : UserControl
    {
        private ExcelManager excelManager;

        public ExcelImportDialog()
        {
            InitializeComponent();
        }

        public event EventHandler<UpdateEnvironmentVariablesEventArgs> OnImportRequested;

        public List<Entity> Solutions
        {
            set
            {
                cbbSolutions.Items.Clear();
                cbbSolutions.Items.AddRange(value.Select(v => new AppCode.SolutionInfo(v)).ToArray());
            }
        }

        public List<Entity> Variables { get; set; }

        internal void Reset()
        {
            txtExcelFilePath.Text = "";
            cbbSheets.Items.Clear();
            dataGridView1.DataSource = null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Visible = false;
            Reset();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OnImportRequested?.Invoke(this, new UpdateEnvironmentVariablesEventArgs
            {
                Variables = (from DataGridViewRow row in dataGridView1.Rows
                             where row.Cells[2].Style.BackColor != row.Cells[3].Style.BackColor
                             select new Entity
                             {
                                 LogicalName = "environmentvariabledefinition",
                                 Id = Variables.FirstOrDefault(v => v.GetAttributeValue<string>("schemaname") == row.Cells[1].Value.ToString())?.Id ?? Guid.Empty,
                                 Attributes = new AttributeCollection
                                 {
                                     new KeyValuePair<string, object>("schemaname", row.Cells[1].Value.ToString()),
                                     new KeyValuePair<string, object>("displayname", row.Cells[0].Value.ToString()),
                                     new KeyValuePair<string, object>("description", row.Cells[5].Value.ToString()),
                                     new KeyValuePair<string, object>("type", row.Cells[4].Value.ToString()),
                                     new KeyValuePair<string, object>("value", row.Cells[3].Value.ToString()),
                                      new KeyValuePair<string, object>("solutionuniquename", ((AppCode.SolutionInfo)cbbSolutions.SelectedItem)?.UniqueName)
                                 }
                             }).ToList()
            });
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog { AddExtension = true, DefaultExt = "xlsx", Filter = "Excel files|*.xlsx" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtExcelFilePath.Text = ofd.FileName;
                    btnReload_Click(sender, e);
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            excelManager = new ExcelManager(txtExcelFilePath.Text);

            cbbSheets.Items.Clear();
            foreach (var sheet in excelManager.Package.Workbook.Worksheets)
            {
                cbbSheets.Items.Add(sheet);
            }

            cbbSheets.SelectedIndex = 0;
        }

        private void cbbSheets_SelectedIndexChanged(object sender, EventArgs e)
        {
            var table = new DataTable();
            table.Columns.Add(new DataColumn("Variable name") { ReadOnly = true });
            table.Columns.Add(new DataColumn("Schema name") { ReadOnly = true });
            table.Columns.Add(new DataColumn("Current Value"));
            table.Columns.Add(new DataColumn("Value"));
            table.Columns.Add(new DataColumn("Type") { ReadOnly = true });
            table.Columns.Add(new DataColumn("Status") { ReadOnly = true });
            table.Columns.Add(new DataColumn("Description") { ReadOnly = true });

            var ws = ((ExcelWorksheet)cbbSheets.SelectedItem);

            for (int i = 2; i <= ws.Dimension.End.Row; i++)
            {
                var variable = Variables.FirstOrDefault(v => v.GetAttributeValue<string>("schemaname") == ws.GetValue<string>(i, 2));
                var isNew = variable == null;
                var isChange = variable != null && (variable.GetAttributeValue<AliasedValue>("val.value")?.Value?.ToString() ?? "") != ws.GetValue<string>(i, 4);

                table.Rows.Add(
                    ws.GetValue<string>(i, 1),
                    ws.GetValue<string>(i, 2),
                    variable != null ? variable.GetAttributeValue<AliasedValue>("val.value")?.Value : string.Empty,
                    ws.GetValue<string>(i, 4),
                    ws.GetValue<string>(i, 5),
                    isNew ? "New" : isChange ? "Update" : "Same",
                    ws.GetValue<string>(i, 3)
                    );
            }

            dataGridView1.DataSource = table;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!(row.Cells[2].Value?.ToString() ?? "").Equals(row.Cells[3].Value?.ToString() ?? ""))
                {
                    row.Cells[2].Style.BackColor = System.Drawing.Color.LightCoral;
                    row.Cells[3].Style.BackColor = System.Drawing.Color.LightGreen;
                }
                else
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Style.BackColor = System.Drawing.Color.LightGray;
                    }
                }
            }

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }

        private byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
    }
}