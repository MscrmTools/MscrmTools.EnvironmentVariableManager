
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
            this.excelImportDialog1 = new MscrmTools.EnvironmentVariableManager.UserControls.ExcelImportDialog();
            this.dpMain = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.toolStripMenu.SuspendLayout();
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
            this.toolStripMenu.Size = new System.Drawing.Size(1572, 39);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "tsMain";
            this.toolStripMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripMenu_ItemClicked);
            // 
            // tsbLoad
            // 
            this.tsbLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbLoad.Name = "tsbLoad";
            this.tsbLoad.Size = new System.Drawing.Size(196, 36);
            this.tsbLoad.Text = "Load Environment variables";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tslSearch
            // 
            this.tslSearch.Name = "tslSearch";
            this.tslSearch.Size = new System.Drawing.Size(51, 36);
            this.tslSearch.Text = "search";
            // 
            // tstxtSearch
            // 
            this.tstxtSearch.AutoToolTip = true;
            this.tstxtSearch.Name = "tstxtSearch";
            this.tstxtSearch.Size = new System.Drawing.Size(256, 39);
            this.tstxtSearch.ToolTipText = "Search an environment variable";
            this.tstxtSearch.TextChanged += new System.EventHandler(this.tstxtSearch_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbUpdate
            // 
            this.tsbUpdate.Image = global::MscrmTools.EnvironmentVariableManager.Properties.Resources.save;
            this.tsbUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdate.Name = "tsbUpdate";
            this.tsbUpdate.Size = new System.Drawing.Size(94, 36);
            this.tsbUpdate.Text = "Update";
            this.tsbUpdate.Click += new System.EventHandler(this.tsbUpdate_Click);
            // 
            // tsbCreateNewVarEnvDef
            // 
            this.tsbCreateNewVarEnvDef.Image = global::MscrmTools.EnvironmentVariableManager.Properties.Resources.plus;
            this.tsbCreateNewVarEnvDef.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCreateNewVarEnvDef.Name = "tsbCreateNewVarEnvDef";
            this.tsbCreateNewVarEnvDef.Size = new System.Drawing.Size(219, 36);
            this.tsbCreateNewVarEnvDef.Text = "New Environment variable";
            this.tsbCreateNewVarEnvDef.Click += new System.EventHandler(this.tsbCreateNewVarEnvDef_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = global::MscrmTools.EnvironmentVariableManager.Properties.Resources.delete;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(89, 36);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.ToolTipText = "Delete";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbExportExcel
            // 
            this.tsbExportExcel.Image = global::MscrmTools.EnvironmentVariableManager.Properties.Resources.export;
            this.tsbExportExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportExcel.Name = "tsbExportExcel";
            this.tsbExportExcel.Size = new System.Drawing.Size(88, 36);
            this.tsbExportExcel.Text = "Export";
            this.tsbExportExcel.Click += new System.EventHandler(this.tsbExportExcel_Click);
            // 
            // tsbImportFromExcel
            // 
            this.tsbImportFromExcel.Image = global::MscrmTools.EnvironmentVariableManager.Properties.Resources.import;
            this.tsbImportFromExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImportFromExcel.Name = "tsbImportFromExcel";
            this.tsbImportFromExcel.Size = new System.Drawing.Size(90, 36);
            this.tsbImportFromExcel.Text = "Import";
            this.tsbImportFromExcel.Click += new System.EventHandler(this.tsbImportFromExcel_Click);
            // 
            // excelImportDialog1
            // 
            this.excelImportDialog1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.excelImportDialog1.Location = new System.Drawing.Point(188, 273);
            this.excelImportDialog1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.excelImportDialog1.Name = "excelImportDialog1";
            this.excelImportDialog1.Size = new System.Drawing.Size(1257, 57);
            this.excelImportDialog1.TabIndex = 8;
            this.excelImportDialog1.Variables = null;
            this.excelImportDialog1.Visible = false;
            // 
            // dpMain
            // 
            this.dpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dpMain.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.dpMain.Location = new System.Drawing.Point(0, 39);
            this.dpMain.Name = "dpMain";
            this.dpMain.Size = new System.Drawing.Size(1572, 1055);
            this.dpMain.TabIndex = 9;
            // 
            // EvmControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dpMain);
            this.Controls.Add(this.excelImportDialog1);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EvmControl";
            this.Size = new System.Drawing.Size(1572, 1094);
            this.Resize += new System.EventHandler(this.EvmControl_Resize);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbLoad;
        private System.Windows.Forms.ToolStripButton tsbUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbCreateNewVarEnvDef;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripLabel tslSearch;
        private System.Windows.Forms.ToolStripTextBox tstxtSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbExportExcel;
        private System.Windows.Forms.ToolStripButton tsbImportFromExcel;
        private UserControls.ExcelImportDialog excelImportDialog1;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dpMain;
    }
}
