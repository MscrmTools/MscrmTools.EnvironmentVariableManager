namespace MscrmTools.EnvironmentVariableManager.UserControls
{
    partial class ExcelImportDialog
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
           
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.cbbSolutions = new System.Windows.Forms.ComboBox();
            this.lblSolution = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pnlMainSheet = new System.Windows.Forms.Panel();
            this.cbbSheets = new System.Windows.Forms.ComboBox();
            this.lblSheet = new System.Windows.Forms.Label();
            this.pnlMainFile = new System.Windows.Forms.Panel();
            this.txtExcelFilePath = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.visualStudioToolStripExtender1 = new WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender(this.components);
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlMainSheet.SuspendLayout();
            this.pnlMainFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblHeaderTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1920, 102);
            this.pnlTop.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI Light", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderTitle.Location = new System.Drawing.Point(27, 15);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(417, 45);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "Import Environment Variables";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.cbbSolutions);
            this.pnlBottom.Controls.Add(this.lblSolution);
            this.pnlBottom.Controls.Add(this.btnImport);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 995);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBottom.Size = new System.Drawing.Size(1920, 69);
            this.pnlBottom.TabIndex = 1;
            // 
            // cbbSolutions
            // 
            this.cbbSolutions.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbbSolutions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSolutions.FormattingEnabled = true;
            this.cbbSolutions.Location = new System.Drawing.Point(312, 10);
            this.cbbSolutions.Name = "cbbSolutions";
            this.cbbSolutions.Size = new System.Drawing.Size(381, 28);
            this.cbbSolutions.TabIndex = 8;
            // 
            // lblSolution
            // 
            this.lblSolution.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSolution.Location = new System.Drawing.Point(10, 10);
            this.lblSolution.Name = "lblSolution";
            this.lblSolution.Size = new System.Drawing.Size(302, 49);
            this.lblSolution.TabIndex = 6;
            this.lblSolution.Text = "Solution for new Environment variable :";
            this.lblSolution.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnImport
            // 
            this.btnImport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnImport.Location = new System.Drawing.Point(1606, 10);
            this.btnImport.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(152, 49);
            this.btnImport.TabIndex = 5;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(1758, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(152, 49);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dataGridView1);
            this.pnlMain.Controls.Add(this.pnlMainSheet);
            this.pnlMain.Controls.Add(this.pnlMainFile);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 102);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1920, 893);
            this.pnlMain.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 120);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1920, 773);
            this.dataGridView1.TabIndex = 2;
            // 
            // pnlMainSheet
            // 
            this.pnlMainSheet.Controls.Add(this.cbbSheets);
            this.pnlMainSheet.Controls.Add(this.lblSheet);
            this.pnlMainSheet.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMainSheet.Location = new System.Drawing.Point(0, 65);
            this.pnlMainSheet.Name = "pnlMainSheet";
            this.pnlMainSheet.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMainSheet.Size = new System.Drawing.Size(1920, 55);
            this.pnlMainSheet.TabIndex = 1;
            // 
            // cbbSheets
            // 
            this.cbbSheets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbSheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSheets.FormattingEnabled = true;
            this.cbbSheets.Location = new System.Drawing.Point(348, 10);
            this.cbbSheets.Name = "cbbSheets";
            this.cbbSheets.Size = new System.Drawing.Size(1562, 28);
            this.cbbSheets.TabIndex = 2;
            this.cbbSheets.SelectedIndexChanged += new System.EventHandler(this.cbbSheets_SelectedIndexChanged);
            // 
            // lblSheet
            // 
            this.lblSheet.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSheet.Location = new System.Drawing.Point(10, 10);
            this.lblSheet.Name = "lblSheet";
            this.lblSheet.Size = new System.Drawing.Size(338, 35);
            this.lblSheet.TabIndex = 1;
            this.lblSheet.Text = "Sheet : ";
            this.lblSheet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMainFile
            // 
            this.pnlMainFile.Controls.Add(this.txtExcelFilePath);
            this.pnlMainFile.Controls.Add(this.btnOpenFile);
            this.pnlMainFile.Controls.Add(this.btnReload);
            this.pnlMainFile.Controls.Add(this.lblFilePath);
            this.pnlMainFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMainFile.Location = new System.Drawing.Point(0, 0);
            this.pnlMainFile.Name = "pnlMainFile";
            this.pnlMainFile.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMainFile.Size = new System.Drawing.Size(1920, 65);
            this.pnlMainFile.TabIndex = 0;
            // 
            // txtExcelFilePath
            // 
            this.txtExcelFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtExcelFilePath.Location = new System.Drawing.Point(348, 10);
            this.txtExcelFilePath.Name = "txtExcelFilePath";
            this.txtExcelFilePath.Size = new System.Drawing.Size(1400, 26);
            this.txtExcelFilePath.TabIndex = 5;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOpenFile.Location = new System.Drawing.Point(1748, 10);
            this.btnOpenFile.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(61, 45);
            this.btnOpenFile.TabIndex = 4;
            this.btnOpenFile.Text = "...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnReload
            // 
            this.btnReload.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnReload.Location = new System.Drawing.Point(1809, 10);
            this.btnReload.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(101, 45);
            this.btnReload.TabIndex = 3;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // lblFilePath
            // 
            this.lblFilePath.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblFilePath.Location = new System.Drawing.Point(10, 10);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(338, 45);
            this.lblFilePath.TabIndex = 0;
            this.lblFilePath.Text = "File :";
            this.lblFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // visualStudioToolStripExtender1
            // 
            this.visualStudioToolStripExtender1.DefaultRenderer = null;
            // 
            // ExcelImportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "ExcelImportDialog";
            this.Size = new System.Drawing.Size(1920, 1064);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlMainSheet.ResumeLayout(false);
            this.pnlMainFile.ResumeLayout(false);
            this.pnlMainFile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlMainFile;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel pnlMainSheet;
        private System.Windows.Forms.ComboBox cbbSheets;
        private System.Windows.Forms.Label lblSheet;
        private System.Windows.Forms.TextBox txtExcelFilePath;
        private WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender visualStudioToolStripExtender1;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSolution;
        private System.Windows.Forms.ComboBox cbbSolutions;
    }
}
