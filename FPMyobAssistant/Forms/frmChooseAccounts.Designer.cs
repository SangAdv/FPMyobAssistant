namespace FPMyobAssistant
{
    partial class frmChooseAccounts
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
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.tlUnselected = new DevExpress.XtraTreeList.TreeList();
            this.colDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAccountCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAccountCount = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIsActive = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.mATreeListItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tlSelected = new DevExpress.XtraTreeList.TreeList();
            this.colDescription1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAccountCode1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAccountCount1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIsActive1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tlUnselected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mATreeListItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlSelected)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(1562, 777);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 28);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(1468, 777);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 28);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            // 
            // tlUnselected
            // 
            this.tlUnselected.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colDescription,
            this.colAccountCode,
            this.colAccountCount,
            this.colIsActive});
            this.tlUnselected.DataSource = this.mATreeListItemBindingSource;
            this.tlUnselected.KeyFieldName = "Id";
            this.tlUnselected.Location = new System.Drawing.Point(10, 33);
            this.tlUnselected.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tlUnselected.MinWidth = 23;
            this.tlUnselected.Name = "tlUnselected";
            this.tlUnselected.OptionsBehavior.ReadOnly = true;
            this.tlUnselected.OptionsView.CheckBoxStyle = DevExpress.XtraTreeList.DefaultNodeCheckBoxStyle.Check;
            this.tlUnselected.OptionsView.ShowIndicator = false;
            this.tlUnselected.ParentFieldName = "ParentId";
            this.tlUnselected.Size = new System.Drawing.Size(808, 736);
            this.tlUnselected.TabIndex = 2;
            this.tlUnselected.TreeLevelWidth = 21;
            this.tlUnselected.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.tlUnselected_NodeCellStyle);
            this.tlUnselected.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.tlUnselected_AfterCheckNode);
            this.tlUnselected.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tlUnselected_FocusedNodeChanged);
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.MinWidth = 23;
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 0;
            this.colDescription.Width = 87;
            // 
            // colAccountCode
            // 
            this.colAccountCode.FieldName = "AccountCode";
            this.colAccountCode.MinWidth = 23;
            this.colAccountCode.Name = "colAccountCode";
            this.colAccountCode.Visible = true;
            this.colAccountCode.VisibleIndex = 1;
            this.colAccountCode.Width = 87;
            // 
            // colAccountCount
            // 
            this.colAccountCount.FieldName = "AccountCount";
            this.colAccountCount.MinWidth = 23;
            this.colAccountCount.Name = "colAccountCount";
            this.colAccountCount.Width = 87;
            // 
            // colIsActive
            // 
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.MinWidth = 23;
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.Width = 87;
            // 
            // mATreeListItemBindingSource
            // 
            this.mATreeListItemBindingSource.DataSource = typeof(FPMyobAssistant.MATreeListItem);
            // 
            // tlSelected
            // 
            this.tlSelected.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colDescription1,
            this.colAccountCode1,
            this.colAccountCount1,
            this.colIsActive1});
            this.tlSelected.DataSource = this.mATreeListItemBindingSource;
            this.tlSelected.KeyFieldName = "Id";
            this.tlSelected.Location = new System.Drawing.Point(841, 33);
            this.tlSelected.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tlSelected.MinWidth = 23;
            this.tlSelected.Name = "tlSelected";
            this.tlSelected.OptionsBehavior.ReadOnly = true;
            this.tlSelected.OptionsView.CheckBoxStyle = DevExpress.XtraTreeList.DefaultNodeCheckBoxStyle.Check;
            this.tlSelected.OptionsView.ShowIndicator = false;
            this.tlSelected.ParentFieldName = "ParentId";
            this.tlSelected.Size = new System.Drawing.Size(808, 736);
            this.tlSelected.TabIndex = 3;
            this.tlSelected.TreeLevelWidth = 21;
            this.tlSelected.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.tlSelected_AfterCheckNode);
            this.tlSelected.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tlSelected_FocusedNodeChanged);
            // 
            // colDescription1
            // 
            this.colDescription1.FieldName = "Description";
            this.colDescription1.MinWidth = 23;
            this.colDescription1.Name = "colDescription1";
            this.colDescription1.Visible = true;
            this.colDescription1.VisibleIndex = 0;
            this.colDescription1.Width = 87;
            // 
            // colAccountCode1
            // 
            this.colAccountCode1.FieldName = "AccountCode";
            this.colAccountCode1.MinWidth = 23;
            this.colAccountCode1.Name = "colAccountCode1";
            this.colAccountCode1.Visible = true;
            this.colAccountCode1.VisibleIndex = 1;
            this.colAccountCode1.Width = 87;
            // 
            // colAccountCount1
            // 
            this.colAccountCount1.FieldName = "AccountCount";
            this.colAccountCount1.MinWidth = 23;
            this.colAccountCount1.Name = "colAccountCount1";
            this.colAccountCount1.Width = 87;
            // 
            // colIsActive1
            // 
            this.colIsActive1.FieldName = "IsActive";
            this.colIsActive1.MinWidth = 23;
            this.colIsActive1.Name = "colIsActive1";
            this.colIsActive1.Width = 87;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(10, 10);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(80, 17);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Unselected:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(841, 10);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(63, 17);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Selected:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(10, 772);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(59, 28);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(841, 772);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(59, 28);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "Remove";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // frmChooseAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1666, 822);
            this.ControlBox = false;
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.tlSelected);
            this.Controls.Add(this.tlUnselected);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmChooseAccounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choose Accounts ...";
            this.Shown += new System.EventHandler(this.frmChooseAccounts_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.tlUnselected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mATreeListItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlSelected)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraTreeList.TreeList tlUnselected;
        private DevExpress.XtraTreeList.TreeList tlSelected;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDescription;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAccountCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAccountCount;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsActive;
        private System.Windows.Forms.BindingSource mATreeListItemBindingSource;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDescription1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAccountCode1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAccountCount1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsActive1;
    }
}