namespace MscrmTools.EnvironmentVariableManager.Forms
{
    partial class EnvVarsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new MscrmTools.EnvironmentVariableManager.AppCode.TextAndImageColumn();
            this.SchemaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeInt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsEnvs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCopyName = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopySchemaName = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyValue = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.cmsEnvs.SuspendLayout();
            this.SuspendLayout();
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
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1070, 695);
            this.dataGridView1.TabIndex = 6;
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
            // cmsEnvs
            // 
            this.cmsEnvs.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsEnvs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCopyName,
            this.tsmiCopySchemaName,
            this.tsmiCopyValue});
            this.cmsEnvs.Name = "cmsEnvs";
            this.cmsEnvs.Size = new System.Drawing.Size(213, 76);
            // 
            // tsmiCopyName
            // 
            this.tsmiCopyName.Name = "tsmiCopyName";
            this.tsmiCopyName.Size = new System.Drawing.Size(212, 24);
            this.tsmiCopyName.Text = "Copy name";
            // 
            // tsmiCopySchemaName
            // 
            this.tsmiCopySchemaName.Name = "tsmiCopySchemaName";
            this.tsmiCopySchemaName.Size = new System.Drawing.Size(212, 24);
            this.tsmiCopySchemaName.Text = "Copy Schema Name";
            // 
            // tsmiCopyValue
            // 
            this.tsmiCopyValue.Name = "tsmiCopyValue";
            this.tsmiCopyValue.Size = new System.Drawing.Size(212, 24);
            this.tsmiCopyValue.Text = "Copy value";
            // 
            // EnvVarsForm
            // 
            this.AllowEndUserDocking = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 695);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.dataGridView1);
            this.Name = "EnvVarsForm";
            this.Text = "Environment Variables";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.cmsEnvs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private AppCode.TextAndImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SchemaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeInt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.ContextMenuStrip cmsEnvs;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyName;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopySchemaName;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyValue;
    }
}