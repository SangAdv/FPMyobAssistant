namespace FPMyobAssistant
{
    partial class eucPLImport
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chkUpdateDescription = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.icbPeriod = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.bePLFilename = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkUpdateDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bePLFilename.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.chkUpdateDescription);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.icbPeriod);
            this.groupControl1.Controls.Add(this.bePLFilename);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.btnImport);
            this.groupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1048, 171);
            this.groupControl1.TabIndex = 30;
            this.groupControl1.Text = "Myob Data";
            // 
            // chkUpdateDescription
            // 
            this.chkUpdateDescription.Location = new System.Drawing.Point(660, 132);
            this.chkUpdateDescription.Margin = new System.Windows.Forms.Padding(4);
            this.chkUpdateDescription.Name = "chkUpdateDescription";
            this.chkUpdateDescription.Properties.Caption = "Update account description";
            this.chkUpdateDescription.Size = new System.Drawing.Size(220, 24);
            this.chkUpdateDescription.TabIndex = 29;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(15, 41);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(87, 19);
            this.labelControl1.TabIndex = 22;
            this.labelControl1.Text = "P&&L Data File:";
            // 
            // icbPeriod
            // 
            this.icbPeriod.Location = new System.Drawing.Point(15, 132);
            this.icbPeriod.Margin = new System.Windows.Forms.Padding(4);
            this.icbPeriod.Name = "icbPeriod";
            this.icbPeriod.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icbPeriod.Properties.Appearance.Options.UseFont = true;
            this.icbPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbPeriod.Size = new System.Drawing.Size(213, 26);
            this.icbPeriod.TabIndex = 28;
            this.icbPeriod.SelectedIndexChanged += new System.EventHandler(this.icbPeriod_SelectedIndexChanged);
            // 
            // bePLFilename
            // 
            this.bePLFilename.Location = new System.Drawing.Point(15, 64);
            this.bePLFilename.Margin = new System.Windows.Forms.Padding(4);
            this.bePLFilename.Name = "bePLFilename";
            this.bePLFilename.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bePLFilename.Properties.Appearance.Options.UseFont = true;
            this.bePLFilename.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bePLFilename.Properties.ReadOnly = true;
            this.bePLFilename.Size = new System.Drawing.Size(1011, 26);
            this.bePLFilename.TabIndex = 21;
            this.bePLFilename.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bePLFilename_ButtonClick);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(15, 108);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 19);
            this.labelControl2.TabIndex = 27;
            this.labelControl2.Text = "P&&L Period:";
            // 
            // btnImport
            // 
            this.btnImport.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Appearance.Options.UseFont = true;
            this.btnImport.Location = new System.Drawing.Point(925, 129);
            this.btnImport.Margin = new System.Windows.Forms.Padding(4);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(100, 28);
            this.btnImport.TabIndex = 25;
            this.btnImport.Text = "Import";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // eucPLImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "eucPLImport";
            this.Size = new System.Drawing.Size(1048, 171);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkUpdateDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bePLFilename.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit chkUpdateDescription;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbPeriod;
        private DevExpress.XtraEditors.ButtonEdit bePLFilename;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnImport;
    }
}
