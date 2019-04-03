namespace FPMyobAssistant
{
    partial class ucDHLImport
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
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.deStartDate = new DevExpress.XtraEditors.DateEdit();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.lstMessages = new DevExpress.XtraEditors.ListBoxControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.beMYOBFilename = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.beDHLFilename = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.beCheckFilename = new DevExpress.XtraEditors.ButtonEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chkUseExclusions = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.deStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beMYOBFilename.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beDHLFilename.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beCheckFilename.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkUseExclusions.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(5, 210);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(54, 13);
            this.labelControl3.TabIndex = 26;
            this.labelControl3.Text = "Start Date:";
            // 
            // deStartDate
            // 
            this.deStartDate.EditValue = null;
            this.deStartDate.Location = new System.Drawing.Point(5, 229);
            this.deStartDate.Name = "deStartDate";
            this.deStartDate.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deStartDate.Properties.Appearance.Options.UseFont = true;
            this.deStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deStartDate.Size = new System.Drawing.Size(100, 20);
            this.deStartDate.TabIndex = 25;
            // 
            // btnImport
            // 
            this.btnImport.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Appearance.Options.UseFont = true;
            this.btnImport.Location = new System.Drawing.Point(688, 253);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 24;
            this.btnImport.Text = "Import";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lstMessages
            // 
            this.lstMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstMessages.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMessages.Appearance.Options.UseFont = true;
            this.lstMessages.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstMessages.Location = new System.Drawing.Point(30, 358);
            this.lstMessages.Name = "lstMessages";
            this.lstMessages.Size = new System.Drawing.Size(758, 281);
            this.lstMessages.TabIndex = 23;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(5, 104);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(93, 13);
            this.labelControl2.TabIndex = 22;
            this.labelControl2.Text = "MYOB Import File:";
            // 
            // beMYOBFilename
            // 
            this.beMYOBFilename.Location = new System.Drawing.Point(5, 123);
            this.beMYOBFilename.Name = "beMYOBFilename";
            this.beMYOBFilename.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beMYOBFilename.Properties.Appearance.Options.UseFont = true;
            this.beMYOBFilename.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beMYOBFilename.Properties.ReadOnly = true;
            this.beMYOBFilename.Size = new System.Drawing.Size(758, 20);
            this.beMYOBFilename.TabIndex = 21;
            this.beMYOBFilename.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beMYOBFilename_ButtonClick);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(5, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 13);
            this.labelControl1.TabIndex = 20;
            this.labelControl1.Text = "DHL Data File:";
            // 
            // beDHLFilename
            // 
            this.beDHLFilename.Location = new System.Drawing.Point(5, 49);
            this.beDHLFilename.Name = "beDHLFilename";
            this.beDHLFilename.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beDHLFilename.Properties.Appearance.Options.UseFont = true;
            this.beDHLFilename.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beDHLFilename.Properties.ReadOnly = true;
            this.beDHLFilename.Size = new System.Drawing.Size(758, 20);
            this.beDHLFilename.TabIndex = 19;
            this.beDHLFilename.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beDHLFilename_ButtonClick);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(5, 158);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(115, 13);
            this.labelControl4.TabIndex = 29;
            this.labelControl4.Text = "Transaction Check File:";
            // 
            // beCheckFilename
            // 
            this.beCheckFilename.Location = new System.Drawing.Point(5, 177);
            this.beCheckFilename.Name = "beCheckFilename";
            this.beCheckFilename.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beCheckFilename.Properties.Appearance.Options.UseFont = true;
            this.beCheckFilename.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beCheckFilename.Properties.ReadOnly = true;
            this.beCheckFilename.Size = new System.Drawing.Size(758, 20);
            this.beCheckFilename.TabIndex = 28;
            this.beCheckFilename.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beCheckFilename_ButtonClick);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.chkUseExclusions);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.beDHLFilename);
            this.groupControl1.Controls.Add(this.beCheckFilename);
            this.groupControl1.Controls.Add(this.beMYOBFilename);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.btnImport);
            this.groupControl1.Controls.Add(this.deStartDate);
            this.groupControl1.Location = new System.Drawing.Point(30, 51);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(773, 287);
            this.groupControl1.TabIndex = 30;
            this.groupControl1.Text = "Myob-DHL Data Files";
            // 
            // chkUseExclusions
            // 
            this.chkUseExclusions.Location = new System.Drawing.Point(5, 75);
            this.chkUseExclusions.Name = "chkUseExclusions";
            this.chkUseExclusions.Properties.Caption = "Apply order exclusions";
            this.chkUseExclusions.Size = new System.Drawing.Size(142, 20);
            this.chkUseExclusions.TabIndex = 30;
            // 
            // ucDHLImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.lstMessages);
            this.Name = "ucDHLImport";
            this.Size = new System.Drawing.Size(1259, 695);
            ((System.ComponentModel.ISupportInitialize)(this.deStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beMYOBFilename.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beDHLFilename.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beCheckFilename.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkUseExclusions.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit deStartDate;
        private DevExpress.XtraEditors.SimpleButton btnImport;
        private DevExpress.XtraEditors.ListBoxControl lstMessages;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ButtonEdit beMYOBFilename;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ButtonEdit beDHLFilename;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ButtonEdit beCheckFilename;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit chkUseExclusions;
    }
}
