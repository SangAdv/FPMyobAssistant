namespace FPMyobAssistant
{
    partial class eucBSImport
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chkUpdateDescription = new DevExpress.XtraEditors.CheckEdit();
            this.beBSFilename = new DevExpress.XtraEditors.ButtonEdit();
            this.icbPeriod = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkUpdateDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beBSFilename.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbPeriod.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.chkUpdateDescription);
            this.groupControl1.Controls.Add(this.beBSFilename);
            this.groupControl1.Controls.Add(this.icbPeriod);
            this.groupControl1.Controls.Add(this.btnImport);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(788, 139);
            this.groupControl1.TabIndex = 38;
            this.groupControl1.Text = "Myob Data";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(11, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(121, 13);
            this.labelControl1.TabIndex = 30;
            this.labelControl1.Text = "Balance Sheet Data File:";
            // 
            // chkUpdateDescription
            // 
            this.chkUpdateDescription.Location = new System.Drawing.Point(466, 106);
            this.chkUpdateDescription.Name = "chkUpdateDescription";
            this.chkUpdateDescription.Properties.Caption = "Update account description";
            this.chkUpdateDescription.Size = new System.Drawing.Size(155, 20);
            this.chkUpdateDescription.TabIndex = 36;
            // 
            // beBSFilename
            // 
            this.beBSFilename.Location = new System.Drawing.Point(11, 52);
            this.beBSFilename.Name = "beBSFilename";
            this.beBSFilename.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beBSFilename.Properties.Appearance.Options.UseFont = true;
            this.beBSFilename.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beBSFilename.Properties.ReadOnly = true;
            this.beBSFilename.Size = new System.Drawing.Size(758, 20);
            this.beBSFilename.TabIndex = 29;
            this.beBSFilename.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beBSFilename_ButtonClick);
            // 
            // icbPeriod
            // 
            this.icbPeriod.Location = new System.Drawing.Point(11, 106);
            this.icbPeriod.Name = "icbPeriod";
            this.icbPeriod.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icbPeriod.Properties.Appearance.Options.UseFont = true;
            this.icbPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbPeriod.Size = new System.Drawing.Size(160, 20);
            this.icbPeriod.TabIndex = 34;
            this.icbPeriod.SelectedIndexChanged += new System.EventHandler(this.icbPeriod_SelectedIndexChanged);
            // 
            // btnImport
            // 
            this.btnImport.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Appearance.Options.UseFont = true;
            this.btnImport.Location = new System.Drawing.Point(694, 104);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 31;
            this.btnImport.Text = "Import";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(11, 87);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(109, 13);
            this.labelControl2.TabIndex = 33;
            this.labelControl2.Text = "Balance Sheet Period:";
            // 
            // eucBSImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Name = "eucBSImport";
            this.Size = new System.Drawing.Size(789, 139);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkUpdateDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beBSFilename.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbPeriod.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit chkUpdateDescription;
        private DevExpress.XtraEditors.ButtonEdit beBSFilename;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbPeriod;
        private DevExpress.XtraEditors.SimpleButton btnImport;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}
