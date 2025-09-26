namespace MscrmTools.EnvironmentVariableManager.Forms
{
    partial class VariableForm
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnValidateEnv = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.cbbSolution = new System.Windows.Forms.ComboBox();
            this.lblSolution = new System.Windows.Forms.Label();
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
            this.pnlBottom.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(801, 71);
            this.pnlTop.TabIndex = 8;
            this.pnlTop.Visible = false;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnValidateEnv);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 1024);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBottom.Size = new System.Drawing.Size(801, 60);
            this.pnlBottom.TabIndex = 9;
            // 
            // btnValidateEnv
            // 
            this.btnValidateEnv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnValidateEnv.Location = new System.Drawing.Point(10, 10);
            this.btnValidateEnv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnValidateEnv.Name = "btnValidateEnv";
            this.btnValidateEnv.Size = new System.Drawing.Size(781, 40);
            this.btnValidateEnv.TabIndex = 11;
            this.btnValidateEnv.Text = "Save";
            this.btnValidateEnv.UseVisualStyleBackColor = true;
            this.btnValidateEnv.Click += new System.EventHandler(this.btnValidateEnv_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.cbbSolution);
            this.pnlMain.Controls.Add(this.lblSolution);
            this.pnlMain.Controls.Add(this.txtDefaultValue);
            this.pnlMain.Controls.Add(this.lblDefautValue);
            this.pnlMain.Controls.Add(this.cbbType);
            this.pnlMain.Controls.Add(this.lblType);
            this.pnlMain.Controls.Add(this.txtDescription);
            this.pnlMain.Controls.Add(this.lblDescription);
            this.pnlMain.Controls.Add(this.txtUniqueName);
            this.pnlMain.Controls.Add(this.lblUniqueName);
            this.pnlMain.Controls.Add(this.txtDisplayName);
            this.pnlMain.Controls.Add(this.lblDisplayName);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 71);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMain.Size = new System.Drawing.Size(801, 953);
            this.pnlMain.TabIndex = 10;
            // 
            // cbbSolution
            // 
            this.cbbSolution.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbbSolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSolution.FormattingEnabled = true;
            this.cbbSolution.Location = new System.Drawing.Point(10, 604);
            this.cbbSolution.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbSolution.Name = "cbbSolution";
            this.cbbSolution.Size = new System.Drawing.Size(781, 24);
            this.cbbSolution.TabIndex = 12;
            // 
            // lblSolution
            // 
            this.lblSolution.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSolution.Location = new System.Drawing.Point(10, 560);
            this.lblSolution.Name = "lblSolution";
            this.lblSolution.Size = new System.Drawing.Size(781, 44);
            this.lblSolution.TabIndex = 11;
            this.lblSolution.Text = "Solution";
            this.lblSolution.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDefaultValue
            // 
            this.txtDefaultValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDefaultValue.Location = new System.Drawing.Point(10, 431);
            this.txtDefaultValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDefaultValue.Multiline = true;
            this.txtDefaultValue.Name = "txtDefaultValue";
            this.txtDefaultValue.Size = new System.Drawing.Size(781, 129);
            this.txtDefaultValue.TabIndex = 10;
            // 
            // lblDefautValue
            // 
            this.lblDefautValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDefautValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefautValue.Location = new System.Drawing.Point(10, 387);
            this.lblDefautValue.Name = "lblDefautValue";
            this.lblDefautValue.Size = new System.Drawing.Size(781, 44);
            this.lblDefautValue.TabIndex = 9;
            this.lblDefautValue.Text = "Default value";
            this.lblDefautValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cbbType.Location = new System.Drawing.Point(10, 363);
            this.cbbType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbType.Name = "cbbType";
            this.cbbType.Size = new System.Drawing.Size(781, 24);
            this.cbbType.TabIndex = 8;
            // 
            // lblType
            // 
            this.lblType.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(10, 315);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(781, 48);
            this.lblType.TabIndex = 7;
            this.lblType.Text = "Type";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescription
            // 
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDescription.Location = new System.Drawing.Point(10, 186);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(781, 129);
            this.txtDescription.TabIndex = 6;
            // 
            // lblDescription
            // 
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(10, 142);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(781, 44);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Description";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUniqueName
            // 
            this.txtUniqueName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtUniqueName.Location = new System.Drawing.Point(10, 120);
            this.txtUniqueName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUniqueName.Name = "txtUniqueName";
            this.txtUniqueName.Size = new System.Drawing.Size(781, 22);
            this.txtUniqueName.TabIndex = 4;
            // 
            // lblUniqueName
            // 
            this.lblUniqueName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUniqueName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUniqueName.Location = new System.Drawing.Point(10, 76);
            this.lblUniqueName.Name = "lblUniqueName";
            this.lblUniqueName.Size = new System.Drawing.Size(781, 44);
            this.lblUniqueName.TabIndex = 3;
            this.lblUniqueName.Text = "Unique name";
            this.lblUniqueName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDisplayName.Location = new System.Drawing.Point(10, 54);
            this.txtDisplayName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(781, 22);
            this.txtDisplayName.TabIndex = 2;
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDisplayName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayName.Location = new System.Drawing.Point(10, 10);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(781, 44);
            this.lblDisplayName.TabIndex = 1;
            this.lblDisplayName.Text = "Display name";
            this.lblDisplayName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VariableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 1084);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "VariableForm";
            this.Text = "Variable";
            this.pnlBottom.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnValidateEnv;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TextBox txtDefaultValue;
        private System.Windows.Forms.Label lblDefautValue;
        private System.Windows.Forms.ComboBox cbbType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtUniqueName;
        private System.Windows.Forms.Label lblUniqueName;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.Label lblSolution;
        private System.Windows.Forms.ComboBox cbbSolution;
    }
}