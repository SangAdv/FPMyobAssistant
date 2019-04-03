namespace FPMyobAssistant
{
    partial class frmChooseGroups
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
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tlSelected = new DevExpress.XtraTreeList.TreeList();
            this.colDescription1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAccountCode1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAccountCount1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIsActive1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlUnselected = new DevExpress.XtraTreeList.TreeList();
            this.colDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAccountCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAccountCount = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIsActive = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.icbHeading = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.icbReport = new DevExpress.XtraEditors.ImageComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tlSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlUnselected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbHeading.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbReport.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(726, 632);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(51, 23);
            this.btnRemove.TabIndex = 15;
            this.btnRemove.Text = "Remove";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(14, 632);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(51, 23);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(726, 13);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 13);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "Selected:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(14, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(66, 13);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "Unselected:";
            // 
            // tlSelected
            // 
            this.tlSelected.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colDescription1,
            this.colAccountCode1,
            this.colAccountCount1,
            this.colIsActive1});
            this.tlSelected.KeyFieldName = "Id";
            this.tlSelected.Location = new System.Drawing.Point(726, 32);
            this.tlSelected.Name = "tlSelected";
            this.tlSelected.OptionsBehavior.ReadOnly = true;
            this.tlSelected.OptionsView.CheckBoxStyle = DevExpress.XtraTreeList.DefaultNodeCheckBoxStyle.Check;
            this.tlSelected.OptionsView.ShowIndicator = false;
            this.tlSelected.ParentFieldName = "ParentId";
            this.tlSelected.Size = new System.Drawing.Size(693, 598);
            this.tlSelected.TabIndex = 11;
            this.tlSelected.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.tlSelected_AfterCheckNode);
            // 
            // colDescription1
            // 
            this.colDescription1.FieldName = "Description";
            this.colDescription1.Name = "colDescription1";
            this.colDescription1.Visible = true;
            this.colDescription1.VisibleIndex = 0;
            // 
            // colAccountCode1
            // 
            this.colAccountCode1.FieldName = "AccountCode";
            this.colAccountCode1.Name = "colAccountCode1";
            this.colAccountCode1.Visible = true;
            this.colAccountCode1.VisibleIndex = 1;
            // 
            // colAccountCount1
            // 
            this.colAccountCount1.FieldName = "AccountCount";
            this.colAccountCount1.Name = "colAccountCount1";
            // 
            // colIsActive1
            // 
            this.colIsActive1.FieldName = "IsActive";
            this.colIsActive1.Name = "colIsActive1";
            // 
            // tlUnselected
            // 
            this.tlUnselected.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colDescription,
            this.colAccountCode,
            this.colAccountCount,
            this.colIsActive});
            this.tlUnselected.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.tlUnselected.KeyFieldName = "Id";
            this.tlUnselected.Location = new System.Drawing.Point(14, 141);
            this.tlUnselected.Name = "tlUnselected";
            this.tlUnselected.OptionsBehavior.ReadOnly = true;
            this.tlUnselected.OptionsView.CheckBoxStyle = DevExpress.XtraTreeList.DefaultNodeCheckBoxStyle.Check;
            this.tlUnselected.OptionsView.ShowIndicator = false;
            this.tlUnselected.ParentFieldName = "ParentId";
            this.tlUnselected.Size = new System.Drawing.Size(693, 489);
            this.tlUnselected.TabIndex = 10;
            this.tlUnselected.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.tlUnselected_AfterCheckNode);
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 0;
            // 
            // colAccountCode
            // 
            this.colAccountCode.FieldName = "AccountCode";
            this.colAccountCode.Name = "colAccountCode";
            this.colAccountCode.Visible = true;
            this.colAccountCode.VisibleIndex = 1;
            // 
            // colAccountCount
            // 
            this.colAccountCount.FieldName = "AccountCount";
            this.colAccountCount.Name = "colAccountCount";
            // 
            // colIsActive
            // 
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.Name = "colIsActive";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(1263, 636);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(1344, 636);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(14, 83);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(47, 13);
            this.labelControl4.TabIndex = 19;
            this.labelControl4.Text = "Heading:";
            // 
            // icbHeading
            // 
            this.icbHeading.Location = new System.Drawing.Point(14, 99);
            this.icbHeading.Name = "icbHeading";
            this.icbHeading.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbHeading.Size = new System.Drawing.Size(693, 20);
            this.icbHeading.TabIndex = 18;
            this.icbHeading.SelectedIndexChanged += new System.EventHandler(this.icbHeading_SelectedIndexChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(14, 42);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(38, 13);
            this.labelControl3.TabIndex = 17;
            this.labelControl3.Text = "Report:";
            // 
            // icbReport
            // 
            this.icbReport.Location = new System.Drawing.Point(14, 57);
            this.icbReport.Name = "icbReport";
            this.icbReport.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbReport.Size = new System.Drawing.Size(693, 20);
            this.icbReport.TabIndex = 16;
            this.icbReport.SelectedIndexChanged += new System.EventHandler(this.icbReport_SelectedIndexChanged);
            // 
            // frmChooseGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1457, 697);
            this.ControlBox = false;
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.icbHeading);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.icbReport);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.tlSelected);
            this.Controls.Add(this.tlUnselected);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmChooseGroups";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Choose Groups ...";
            this.Shown += new System.EventHandler(this.frmChooseGroups_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.tlSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlUnselected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbHeading.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbReport.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraTreeList.TreeList tlSelected;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDescription1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAccountCode1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAccountCount1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsActive1;
        private DevExpress.XtraTreeList.TreeList tlUnselected;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDescription;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAccountCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAccountCount;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsActive;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbHeading;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbReport;
    }
}