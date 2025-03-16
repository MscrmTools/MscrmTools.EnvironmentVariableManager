
namespace MscrmTools.EnvironmentVariableManager
{
    partial class EvmControl
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
            excelImportDialog1.Dispose();

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
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbLoad = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tslSearch = new System.Windows.Forms.ToolStripLabel();
            this.tstxtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbUpdate = new System.Windows.Forms.ToolStripButton();
            this.tsbCreateNewVarEnvDef = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExportExcel = new System.Windows.Forms.ToolStripButton();
            this.tsbImportFromExcel = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new MscrmTools.EnvironmentVariableManager.AppCode.TextAndImageColumn();
            this.SchemaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeInt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbEnvVariable = new System.Windows.Forms.GroupBox();
            this.btnValidateEnv = new System.Windows.Forms.Button();
            this.txtDefaultValue = new System.Windows.Forms.TextBox();
            this.lblDefautValue = new System.Windows.Forms.Label();
            this.cbbType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtUniqueName = new System.Windows.Forms.TextBox();
            this.lblUniqueName = new System.Windows.Forms.Label();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.excelImportDialog1 = new MscrmTools.EnvironmentVariableManager.UserControls.ExcelImportDialog();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbEnvVariable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLoad,
            this.toolStripSeparator1,
            this.tslSearch,
            this.tstxtSearch,
            this.toolStripSeparator2,
            this.tsbUpdate,
            this.tsbCreateNewVarEnvDef,
            this.tsbDelete,
            this.toolStripSeparator3,
            this.tsbExportExcel,
            this.tsbImportFromExcel});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1352, 41);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "tsMain";
            this.toolStripMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripMenu_ItemClicked);
            // 
            // tsbLoad
            // 
            this.tsbLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbLoad.Name = "tsbLoad";
            this.tsbLoad.Size = new System.Drawing.Size(234, 36);
            this.tsbLoad.Text = "Load Environment variables";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 41);
            // 
            // tslSearch
            // 
            this.tslSearch.Name = "tslSearch";
            this.tslSearch.Size = new System.Drawing.Size(62, 36);
            this.tslSearch.Text = "search";
            // 
            // tstxtSearch
            // 
            this.tstxtSearch.AutoToolTip = true;
            this.tstxtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tstxtSearch.Name = "tstxtSearch";
            this.tstxtSearch.Size = new System.Drawing.Size(288, 41);
            this.tstxtSearch.ToolTipText = "Search an environment variable";
            this.tstxtSearch.TextChanged += new System.EventHandler(this.tstxtSearch_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 41);
            // 
            // tsbUpdate
            // 
            this.tsbUpdate.Image = global::MscrmTools.EnvironmentVariableManager.Properties.Resources.save;
            this.tsbUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdate.Name = "tsbUpdate";
            this.tsbUpdate.Size = new System.Drawing.Size(106, 36);
            this.tsbUpdate.Text = "Update";
            this.tsbUpdate.Click += new System.EventHandler(this.tsbUpdate_Click);
            // 
            // tsbCreateNewVarEnvDef
            // 
            this.tsbCreateNewVarEnvDef.Image = global::MscrmTools.EnvironmentVariableManager.Properties.Resources.plus;
            this.tsbCreateNewVarEnvDef.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCreateNewVarEnvDef.Name = "tsbCreateNewVarEnvDef";
            this.tsbCreateNewVarEnvDef.Size = new System.Drawing.Size(254, 36);
            this.tsbCreateNewVarEnvDef.Text = "New Environment variable";
            this.tsbCreateNewVarEnvDef.Click += new System.EventHandler(this.tsbCreateNewVarEnvDef_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = global::MscrmTools.EnvironmentVariableManager.Properties.Resources.delete;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(98, 36);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.ToolTipText = "Delete";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 41);
            // 
            // tsbExportExcel
            // 
            this.tsbExportExcel.Image = global::MscrmTools.EnvironmentVariableManager.Properties.Resources.export;
            this.tsbExportExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportExcel.Name = "tsbExportExcel";
            this.tsbExportExcel.Size = new System.Drawing.Size(99, 36);
            this.tsbExportExcel.Text = "Export";
            this.tsbExportExcel.Click += new System.EventHandler(this.tsbExportExcel_Click);
            // 
            // tsbImportFromExcel
            // 
            this.tsbImportFromExcel.Image = global::MscrmTools.EnvironmentVariableManager.Properties.Resources.import;
            this.tsbImportFromExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImportFromExcel.Name = "tsbImportFromExcel";
            this.tsbImportFromExcel.Size = new System.Drawing.Size(103, 36);
            this.tsbImportFromExcel.Text = "Import";
            this.tsbImportFromExcel.Click += new System.EventHandler(this.tsbImportFromExcel_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.SchemaName,
            this.Value,
            this.Id1,
            this.Id2,
            this.TypeInt,
            this.Type});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(888, 750);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Variable name";
            this.Column1.Image = null;
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // SchemaName
            // 
            this.SchemaName.HeaderText = "Schema name";
            this.SchemaName.MinimumWidth = 8;
            this.SchemaName.Name = "SchemaName";
            this.SchemaName.ReadOnly = true;
            this.SchemaName.Width = 150;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.MinimumWidth = 8;
            this.Value.Name = "Value";
            this.Value.Width = 150;
            // 
            // Id1
            // 
            this.Id1.HeaderText = "Id1";
            this.Id1.MinimumWidth = 8;
            this.Id1.Name = "Id1";
            this.Id1.Visible = false;
            this.Id1.Width = 150;
            // 
            // Id2
            // 
            this.Id2.HeaderText = "Id2";
            this.Id2.MinimumWidth = 8;
            this.Id2.Name = "Id2";
            this.Id2.Visible = false;
            this.Id2.Width = 150;
            // 
            // TypeInt
            // 
            this.TypeInt.HeaderText = "TypeInt";
            this.TypeInt.MinimumWidth = 8;
            this.TypeInt.Name = "TypeInt";
            this.TypeInt.Visible = false;
            this.TypeInt.Width = 150;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.MinimumWidth = 8;
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 150;
            // 
            // gbEnvVariable
            // 
            this.gbEnvVariable.Controls.Add(this.btnValidateEnv);
            this.gbEnvVariable.Controls.Add(this.txtDefaultValue);
            this.gbEnvVariable.Controls.Add(this.lblDefautValue);
            this.gbEnvVariable.Controls.Add(this.cbbType);
            this.gbEnvVariable.Controls.Add(this.lblType);
            this.gbEnvVariable.Controls.Add(this.txtDescription);
            this.gbEnvVariable.Controls.Add(this.lblDescription);
            this.gbEnvVariable.Controls.Add(this.txtUniqueName);
            this.gbEnvVariable.Controls.Add(this.lblUniqueName);
            this.gbEnvVariable.Controls.Add(this.txtDisplayName);
            this.gbEnvVariable.Controls.Add(this.lblDisplayName);
            this.gbEnvVariable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbEnvVariable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbEnvVariable.Location = new System.Drawing.Point(0, 0);
            this.gbEnvVariable.Name = "gbEnvVariable";
            this.gbEnvVariable.Size = new System.Drawing.Size(460, 750);
            this.gbEnvVariable.TabIndex = 6;
            this.gbEnvVariable.TabStop = false;
            this.gbEnvVariable.Text = "New environment variable ";
            // 
            // btnValidateEnv
            // 
            this.btnValidateEnv.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnValidateEnv.Location = new System.Drawing.Point(3, 483);
            this.btnValidateEnv.Name = "btnValidateEnv";
            this.btnValidateEnv.Size = new System.Drawing.Size(454, 55);
            this.btnValidateEnv.TabIndex = 10;
            this.btnValidateEnv.Text = "Save";
            this.btnValidateEnv.UseVisualStyleBackColor = true;
            this.btnValidateEnv.Click += new System.EventHandler(this.btnValidateEnv_Click);
            // 
            // txtDefaultValue
            // 
            this.txtDefaultValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDefaultValue.Location = new System.Drawing.Point(3, 381);
            this.txtDefaultValue.Multiline = true;
            this.txtDefaultValue.Name = "txtDefaultValue";
            this.txtDefaultValue.Size = new System.Drawing.Size(454, 102);
            this.txtDefaultValue.TabIndex = 9;
            // 
            // lblDefautValue
            // 
            this.lblDefautValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDefautValue.Location = new System.Drawing.Point(3, 346);
            this.lblDefautValue.Name = "lblDefautValue";
            this.lblDefautValue.Size = new System.Drawing.Size(454, 35);
            this.lblDefautValue.TabIndex = 8;
            this.lblDefautValue.Text = "Default value";
            this.lblDefautValue.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cbbType
            // 
            this.cbbType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbType.FormattingEnabled = true;
            this.cbbType.Items.AddRange(new object[] {
            "String",
            "Number",
            "Boolean",
            "JSON",
            "Connection reference",
            "Secret"});
            this.cbbType.Location = new System.Drawing.Point(3, 318);
            this.cbbType.Name = "cbbType";
            this.cbbType.Size = new System.Drawing.Size(454, 28);
            this.cbbType.TabIndex = 7;
            // 
            // lblType
            // 
            this.lblType.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblType.Location = new System.Drawing.Point(3, 281);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(454, 37);
            this.lblType.TabIndex = 6;
            this.lblType.Text = "Type";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtDescription
            // 
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDescription.Location = new System.Drawing.Point(3, 179);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(454, 102);
            this.txtDescription.TabIndex = 5;
            // 
            // lblDescription
            // 
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDescription.Location = new System.Drawing.Point(3, 144);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(454, 35);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtUniqueName
            // 
            this.txtUniqueName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtUniqueName.Location = new System.Drawing.Point(3, 118);
            this.txtUniqueName.Name = "txtUniqueName";
            this.txtUniqueName.Size = new System.Drawing.Size(454, 26);
            this.txtUniqueName.TabIndex = 3;
            // 
            // lblUniqueName
            // 
            this.lblUniqueName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUniqueName.Location = new System.Drawing.Point(3, 83);
            this.lblUniqueName.Name = "lblUniqueName";
            this.lblUniqueName.Size = new System.Drawing.Size(454, 35);
            this.lblUniqueName.TabIndex = 2;
            this.lblUniqueName.Text = "Unique name";
            this.lblUniqueName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDisplayName.Location = new System.Drawing.Point(3, 57);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(454, 26);
            this.txtDisplayName.TabIndex = 1;
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDisplayName.Location = new System.Drawing.Point(3, 22);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(454, 35);
            this.lblDisplayName.TabIndex = 0;
            this.lblDisplayName.Text = "Display name";
            this.lblDisplayName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 41);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.dataGridView1);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.gbEnvVariable);
            this.scMain.Size = new System.Drawing.Size(1352, 750);
            this.scMain.SplitterDistance = 888;
            this.scMain.TabIndex = 7;
            // 
            // excelImportDialog1
            // 
            this.excelImportDialog1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.excelImportDialog1.Location = new System.Drawing.Point(-7, 70);
            this.excelImportDialog1.Name = "excelImportDialog1";
            this.excelImportDialog1.Size = new System.Drawing.Size(1414, 71);
            this.excelImportDialog1.TabIndex = 8;
            this.excelImportDialog1.Variables = null;
            this.excelImportDialog1.Visible = false;
            // 
            // EvmControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.excelImportDialog1);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EvmControl";
            this.Size = new System.Drawing.Size(1352, 791);
            this.Resize += new System.EventHandler(this.EvmControl_Resize);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbEnvVariable.ResumeLayout(false);
            this.gbEnvVariable.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbLoad;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripButton tsbUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.GroupBox gbEnvVariable;
        private System.Windows.Forms.ComboBox cbbType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtUniqueName;
        private System.Windows.Forms.Label lblUniqueName;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.TextBox txtDefaultValue;
        private System.Windows.Forms.Label lblDefautValue;
        private System.Windows.Forms.Button btnValidateEnv;
        private System.Windows.Forms.ToolStripButton tsbCreateNewVarEnvDef;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.ToolStripLabel tslSearch;
        private System.Windows.Forms.ToolStripTextBox tstxtSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbExportExcel;
        private System.Windows.Forms.ToolStripButton tsbImportFromExcel;
        private UserControls.ExcelImportDialog excelImportDialog1;
        private AppCode.TextAndImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SchemaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeInt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
    }
}
