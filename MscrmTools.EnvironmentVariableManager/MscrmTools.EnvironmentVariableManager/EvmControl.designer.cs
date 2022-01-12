
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.tsbUpdate = new System.Windows.Forms.ToolStripButton();
            this.tsbCreateNewVarEnvDef = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
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
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLoad,
            this.toolStripSeparator1,
            this.tsbUpdate,
            this.tsbCreateNewVarEnvDef,
            this.tsbDelete});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1352, 34);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "tsMain";
            this.toolStripMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripMenu_ItemClicked);
            // 
            // tsbLoad
            // 
            this.tsbLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbLoad.Name = "tsbLoad";
            this.tsbLoad.Size = new System.Drawing.Size(234, 41);
            this.tsbLoad.Text = "Load Environment variables";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 46);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(888, 757);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
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
            this.gbEnvVariable.Size = new System.Drawing.Size(460, 757);
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
            this.scMain.Location = new System.Drawing.Point(0, 34);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.dataGridView1);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.gbEnvVariable);
            this.scMain.Size = new System.Drawing.Size(1352, 757);
            this.scMain.SplitterDistance = 888;
            this.scMain.TabIndex = 7;
            // 
            // tsbUpdate
            // 
            this.tsbUpdate.Image = global::MscrmTools.EnvironmentVariableManager.Properties.Resources.Save_16;
            this.tsbUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdate.Name = "tsbUpdate";
            this.tsbUpdate.Size = new System.Drawing.Size(98, 41);
            this.tsbUpdate.Text = "Update";
            this.tsbUpdate.Click += new System.EventHandler(this.tsbUpdate_Click);
            // 
            // tsbCreateNewVarEnvDef
            // 
            this.tsbCreateNewVarEnvDef.Image = global::MscrmTools.EnvironmentVariableManager.Properties.Resources.add_hover_16_new;
            this.tsbCreateNewVarEnvDef.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCreateNewVarEnvDef.Name = "tsbCreateNewVarEnvDef";
            this.tsbCreateNewVarEnvDef.Size = new System.Drawing.Size(246, 41);
            this.tsbCreateNewVarEnvDef.Text = "New Environment variable";
            this.tsbCreateNewVarEnvDef.Click += new System.EventHandler(this.tsbCreateNewVarEnvDef_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = global::MscrmTools.EnvironmentVariableManager.Properties.Resources.Delete16;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(90, 41);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.ToolTipText = "Delete";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // EvmControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EvmControl";
            this.Size = new System.Drawing.Size(1352, 791);
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
    }
}
