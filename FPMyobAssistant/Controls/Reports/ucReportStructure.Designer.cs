﻿namespace FPMyobAssistant
{
    partial class ucReportStructure
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
            this.components = new System.ComponentModel.Container();
            this.tlStructure = new DevExpress.XtraTreeList.TreeList();
            this.colDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAccountCount = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.mATreeListItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gcItemSettings = new DevExpress.XtraEditors.GroupControl();
            this.btnFromPreviousReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnDown = new DevExpress.XtraEditors.SimpleButton();
            this.btnUp = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gcItemAccounts = new DevExpress.XtraEditors.GroupControl();
            this.btnDefine = new DevExpress.XtraEditors.SimpleButton();
            this.tlAccounts = new DevExpress.XtraTreeList.TreeList();
            this.colDescription1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.icbReport = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.icbHeading = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.beStructureFilename = new DevExpress.XtraEditors.ButtonEdit();
            this.btnExportStructure = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tlStructure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mATreeListItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcItemSettings)).BeginInit();
            this.gcItemSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcItemAccounts)).BeginInit();
            this.gcItemAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbReport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbHeading.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beStructureFilename.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.tlStructure.DataSource = this.mATreeListItemBindingSource;
            this.tlStructure.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlStructure.KeyFieldName = "Id";
            this.tlStructure.Location = new System.Drawing.Point(12, 129);
            this.tlStructure.Name = "tlStructure";
            this.tlStructure.OptionsBehavior.Editable = false;
            this.tlStructure.OptionsView.ShowIndicator = false;
            this.tlStructure.ParentFieldName = "ParentId";
            this.tlStructure.Size = new System.Drawing.Size(672, 392);
            this.tlStructure.TabIndex = 1;
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
            this.colAccountCount.FieldName = "AccountCount";
            this.colAccountCount.Name = "colAccountCount";
            this.colAccountCount.Visible = true;
            this.colAccountCount.VisibleIndex = 1;
            // 
            // mATreeListItemBindingSource
            // 
            this.mATreeListItemBindingSource.DataSource = typeof(FPMyobAssistant.MATreeListItem);
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
            this.gcItemSettings.Location = new System.Drawing.Point(699, 129);
            this.gcItemSettings.Name = "gcItemSettings";
            this.gcItemSettings.Size = new System.Drawing.Size(537, 127);
            this.gcItemSettings.TabIndex = 2;
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
            // gcItemAccounts
            // 
            this.gcItemAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcItemAccounts.Controls.Add(this.btnDefine);
            this.gcItemAccounts.Controls.Add(this.tlAccounts);
            this.gcItemAccounts.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            this.gcItemAccounts.Location = new System.Drawing.Point(699, 262);
            this.gcItemAccounts.Name = "gcItemAccounts";
            this.gcItemAccounts.Size = new System.Drawing.Size(537, 333);
            this.gcItemAccounts.TabIndex = 9;
            this.gcItemAccounts.Text = "Item Groups";
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
            // tlAccounts
            // 
            this.tlAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlAccounts.Appearance.Caption.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlAccounts.Appearance.Caption.Options.UseFont = true;
            this.tlAccounts.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlAccounts.Appearance.HeaderPanel.Options.UseFont = true;
            this.tlAccounts.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlAccounts.Appearance.Row.Options.UseFont = true;
            this.tlAccounts.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colDescription1,
            this.colId});
            this.tlAccounts.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlAccounts.DataSource = this.mATreeListItemBindingSource;
            this.tlAccounts.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlAccounts.KeyFieldName = "Id";
            this.tlAccounts.Location = new System.Drawing.Point(5, 59);
            this.tlAccounts.Name = "tlAccounts";
            this.tlAccounts.OptionsBehavior.Editable = false;
            this.tlAccounts.OptionsView.CheckBoxStyle = DevExpress.XtraTreeList.DefaultNodeCheckBoxStyle.Check;
            this.tlAccounts.OptionsView.ShowIndicator = false;
            this.tlAccounts.ParentFieldName = "ParentId";
            this.tlAccounts.Size = new System.Drawing.Size(525, 274);
            this.tlAccounts.TabIndex = 9;
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
            // icbReport
            // 
            this.icbReport.Location = new System.Drawing.Point(12, 57);
            this.icbReport.Name = "icbReport";
            this.icbReport.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbReport.Size = new System.Drawing.Size(672, 20);
            this.icbReport.TabIndex = 4;
            this.icbReport.SelectedIndexChanged += new System.EventHandler(this.icbReport_SelectedIndexChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(12, 42);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(38, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Report:";
            // 
            // icbHeading
            // 
            this.icbHeading.Location = new System.Drawing.Point(12, 99);
            this.icbHeading.Name = "icbHeading";
            this.icbHeading.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbHeading.Size = new System.Drawing.Size(672, 20);
            this.icbHeading.TabIndex = 6;
            this.icbHeading.SelectedIndexChanged += new System.EventHandler(this.icbHeading_SelectedIndexChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(12, 83);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(47, 13);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Heading:";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 528);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(88, 13);
            this.labelControl2.TabIndex = 22;
            this.labelControl2.Text = "Report Structure:";
            // 
            // beStructureFilename
            // 
            this.beStructureFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.beStructureFilename.Location = new System.Drawing.Point(12, 547);
            this.beStructureFilename.Name = "beStructureFilename";
            this.beStructureFilename.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beStructureFilename.Properties.Appearance.Options.UseFont = true;
            this.beStructureFilename.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beStructureFilename.Properties.ReadOnly = true;
            this.beStructureFilename.Size = new System.Drawing.Size(672, 20);
            this.beStructureFilename.TabIndex = 21;
            this.beStructureFilename.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beStructureFilename_ButtonClick);
            // 
            // btnExportStructure
            // 
            this.btnExportStructure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportStructure.Location = new System.Drawing.Point(624, 572);
            this.btnExportStructure.Name = "btnExportStructure";
            this.btnExportStructure.Size = new System.Drawing.Size(60, 23);
            this.btnExportStructure.TabIndex = 23;
            this.btnExportStructure.Text = "Export";
            this.btnExportStructure.Click += new System.EventHandler(this.btnExportStructure_Click);
            // 
            // ucReportStructure
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
            this.Name = "ucReportStructure";
            this.Size = new System.Drawing.Size(1253, 615);
            ((System.ComponentModel.ISupportInitialize)(this.tlStructure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mATreeListItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcItemSettings)).EndInit();
            this.gcItemSettings.ResumeLayout(false);
            this.gcItemSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcItemAccounts)).EndInit();
            this.gcItemAccounts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbReport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbHeading.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beStructureFilename.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList tlStructure;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDescription;
        private DevExpress.XtraEditors.GroupControl gcItemSettings;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbReport;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraTreeList.TreeList tlAccounts;
        private System.Windows.Forms.BindingSource mATreeListItemBindingSource;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDescription1;
        private DevExpress.XtraEditors.GroupControl gcItemAccounts;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAccountCount;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbHeading;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ButtonEdit beStructureFilename;
        private DevExpress.XtraEditors.SimpleButton btnExportStructure;
        private DevExpress.XtraEditors.SimpleButton btnDown;
        private DevExpress.XtraEditors.SimpleButton btnUp;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colId;
        private DevExpress.XtraEditors.SimpleButton btnFromPreviousReport;
        private DevExpress.XtraEditors.SimpleButton btnDefine;
    }
}
