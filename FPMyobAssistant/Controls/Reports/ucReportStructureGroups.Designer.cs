namespace FPMyobAssistant
{
    partial class ucReportStructureGroups
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
            this.btnExportStructure = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.beStructureFilename = new DevExpress.XtraEditors.ButtonEdit();
            this.gcItemAccounts = new DevExpress.XtraEditors.GroupControl();
            this.btnDefine = new DevExpress.XtraEditors.SimpleButton();
            this.tlGroups = new DevExpress.XtraTreeList.TreeList();
            this.colDescription1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.icbHeading = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.icbReport = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.gcItemSettings = new DevExpress.XtraEditors.GroupControl();
            this.btnFromPreviousReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnDown = new DevExpress.XtraEditors.SimpleButton();
            this.btnUp = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tlStructure = new DevExpress.XtraTreeList.TreeList();
            this.colDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAccountCount = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.beStructureFilename.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcItemAccounts)).BeginInit();
            this.gcItemAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbHeading.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbReport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcItemSettings)).BeginInit();
            this.gcItemSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlStructure)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExportStructure
            // 
            this.btnExportStructure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportStructure.Location = new System.Drawing.Point(626, 570);
            this.btnExportStructure.Name = "btnExportStructure";
            this.btnExportStructure.Size = new System.Drawing.Size(60, 23);
            this.btnExportStructure.TabIndex = 33;
            this.btnExportStructure.Text = "Export";
            this.btnExportStructure.Click += new System.EventHandler(this.btnExportStructure_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(14, 526);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(88, 13);
            this.labelControl2.TabIndex = 32;
            this.labelControl2.Text = "Report Structure:";
            // 
            // beStructureFilename
            // 
            this.beStructureFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.beStructureFilename.Location = new System.Drawing.Point(14, 545);
            this.beStructureFilename.Name = "beStructureFilename";
            this.beStructureFilename.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beStructureFilename.Properties.Appearance.Options.UseFont = true;
            this.beStructureFilename.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beStructureFilename.Properties.ReadOnly = true;
            this.beStructureFilename.Size = new System.Drawing.Size(672, 20);
            this.beStructureFilename.TabIndex = 31;
            this.beStructureFilename.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beStructureFilename_ButtonClick);
            // 
            // gcItemAccounts
            // 
            this.gcItemAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcItemAccounts.Controls.Add(this.btnDefine);
            this.gcItemAccounts.Controls.Add(this.tlGroups);
            this.gcItemAccounts.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            this.gcItemAccounts.Location = new System.Drawing.Point(701, 260);
            this.gcItemAccounts.Name = "gcItemAccounts";
            this.gcItemAccounts.Size = new System.Drawing.Size(537, 333);
            this.gcItemAccounts.TabIndex = 30;
            this.gcItemAccounts.Text = "Item Accounts";
            // 
            // btnDefine
            // 
            this.btnDefine.Location = new System.Drawing.Point(5, 30);
            this.btnDefine.Name = "btnDefine";
            this.btnDefine.Size = new System.Drawing.Size(60, 23);
            this.btnDefine.TabIndex = 14;
            this.btnDefine.Text = "Define";
            this.btnDefine.Click += new System.EventHandler(this.btnDefine_Click);
            // 
            // tlGroups
            // 
            this.tlGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlGroups.Appearance.Caption.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlGroups.Appearance.Caption.Options.UseFont = true;
            this.tlGroups.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlGroups.Appearance.HeaderPanel.Options.UseFont = true;
            this.tlGroups.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlGroups.Appearance.Row.Options.UseFont = true;
            this.tlGroups.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colDescription1,
            this.colId});
            this.tlGroups.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlGroups.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlGroups.KeyFieldName = "Id";
            this.tlGroups.Location = new System.Drawing.Point(5, 59);
            this.tlGroups.Name = "tlGroups";
            this.tlGroups.OptionsBehavior.Editable = false;
            this.tlGroups.OptionsView.CheckBoxStyle = DevExpress.XtraTreeList.DefaultNodeCheckBoxStyle.Check;
            this.tlGroups.OptionsView.ShowIndicator = false;
            this.tlGroups.ParentFieldName = "ParentId";
            this.tlGroups.Size = new System.Drawing.Size(525, 274);
            this.tlGroups.TabIndex = 9;
            // 
            // colDescription1
            // 
            this.colDescription1.FieldName = "Description";
            this.colDescription1.Name = "colDescription1";
            this.colDescription1.Visible = true;
            this.colDescription1.VisibleIndex = 0;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(14, 81);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(47, 13);
            this.labelControl4.TabIndex = 29;
            this.labelControl4.Text = "Heading:";
            // 
            // icbHeading
            // 
            this.icbHeading.Location = new System.Drawing.Point(14, 97);
            this.icbHeading.Name = "icbHeading";
            this.icbHeading.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbHeading.Size = new System.Drawing.Size(672, 20);
            this.icbHeading.TabIndex = 28;
            this.icbHeading.SelectedIndexChanged += new System.EventHandler(this.icbHeading_SelectedIndexChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(14, 40);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(38, 13);
            this.labelControl3.TabIndex = 27;
            this.labelControl3.Text = "Report:";
            // 
            // icbReport
            // 
            this.icbReport.Location = new System.Drawing.Point(14, 55);
            this.icbReport.Name = "icbReport";
            this.icbReport.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbReport.Size = new System.Drawing.Size(672, 20);
            this.icbReport.TabIndex = 26;
            this.icbReport.SelectedIndexChanged += new System.EventHandler(this.icbReport_SelectedIndexChanged);
            // 
            // gcItemSettings
            // 
            this.gcItemSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gcItemSettings.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.gcItemSettings.Appearance.Options.UseBackColor = true;
            this.gcItemSettings.Controls.Add(this.btnFromPreviousReport);
            this.gcItemSettings.Controls.Add(this.btnDelete);
            this.gcItemSettings.Controls.Add(this.btnDown);
            this.gcItemSettings.Controls.Add(this.btnUp);
            this.gcItemSettings.Controls.Add(this.btnCancel);
            this.gcItemSettings.Controls.Add(this.txtDescription);
            this.gcItemSettings.Controls.Add(this.btnUpdate);
            this.gcItemSettings.Controls.Add(this.labelControl1);
            this.gcItemSettings.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            this.gcItemSettings.Location = new System.Drawing.Point(701, 127);
            this.gcItemSettings.Name = "gcItemSettings";
            this.gcItemSettings.Size = new System.Drawing.Size(537, 127);
            this.gcItemSettings.TabIndex = 25;
            this.gcItemSettings.Text = "Report Item";
            // 
            // btnFromPreviousReport
            // 
            this.btnFromPreviousReport.Location = new System.Drawing.Point(167, 67);
            this.btnFromPreviousReport.Name = "btnFromPreviousReport";
            this.btnFromPreviousReport.Size = new System.Drawing.Size(125, 23);
            this.btnFromPreviousReport.TabIndex = 12;
            this.btnFromPreviousReport.Text = "From Previous Report";
            this.btnFromPreviousReport.Visible = false;
            this.btnFromPreviousReport.Click += new System.EventHandler(this.btnFromPreviousReport_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(463, 67);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(56, 67);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(40, 23);
            this.btnDown.TabIndex = 10;
            this.btnDown.Text = "Down";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(10, 67);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(40, 23);
            this.btnUp.TabIndex = 9;
            this.btnUp.Text = "Up";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(463, 96);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(10, 41);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(513, 20);
            this.txtDescription.TabIndex = 5;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(397, 67);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(60, 23);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Add";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(10, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(97, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Report Description";
            // 
            // tlStructure
            // 
            this.tlStructure.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlStructure.Appearance.Caption.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlStructure.Appearance.Caption.Options.UseFont = true;
            this.tlStructure.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlStructure.Appearance.HeaderPanel.Options.UseFont = true;
            this.tlStructure.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlStructure.Appearance.Row.Options.UseFont = true;
            this.tlStructure.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colDescription,
            this.colAccountCount});
            this.tlStructure.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlStructure.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlStructure.KeyFieldName = "Id";
            this.tlStructure.Location = new System.Drawing.Point(14, 127);
            this.tlStructure.Name = "tlStructure";
            this.tlStructure.OptionsBehavior.Editable = false;
            this.tlStructure.OptionsView.ShowIndicator = false;
            this.tlStructure.ParentFieldName = "ParentId";
            this.tlStructure.Size = new System.Drawing.Size(672, 392);
            this.tlStructure.TabIndex = 24;
            this.tlStructure.Click += new System.EventHandler(this.tlStructure_Click);
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 0;
            // 
            // colAccountCount
            // 
            this.colAccountCount.Caption = "Group Count";
            this.colAccountCount.FieldName = "AccountCount";
            this.colAccountCount.Name = "colAccountCount";
            this.colAccountCount.Visible = true;
            this.colAccountCount.VisibleIndex = 1;
            // 
            // ucReportStructureGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExportStructure);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.beStructureFilename);
            this.Controls.Add(this.gcItemAccounts);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.icbHeading);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.icbReport);
            this.Controls.Add(this.gcItemSettings);
            this.Controls.Add(this.tlStructure);
            this.Name = "ucReportStructureGroups";
            this.Size = new System.Drawing.Size(1253, 615);
            ((System.ComponentModel.ISupportInitialize)(this.beStructureFilename.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcItemAccounts)).EndInit();
            this.gcItemAccounts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbHeading.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbReport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcItemSettings)).EndInit();
            this.gcItemSettings.ResumeLayout(false);
            this.gcItemSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlStructure)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnExportStructure;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ButtonEdit beStructureFilename;
        private DevExpress.XtraEditors.GroupControl gcItemAccounts;
        private DevExpress.XtraEditors.SimpleButton btnDefine;
        private DevExpress.XtraTreeList.TreeList tlGroups;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDescription1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colId;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbHeading;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbReport;
        private DevExpress.XtraEditors.GroupControl gcItemSettings;
        private DevExpress.XtraEditors.SimpleButton btnFromPreviousReport;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnDown;
        private DevExpress.XtraEditors.SimpleButton btnUp;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraTreeList.TreeList tlStructure;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDescription;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAccountCount;
    }
}
