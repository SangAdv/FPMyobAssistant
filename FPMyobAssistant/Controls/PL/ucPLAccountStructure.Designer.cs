namespace FPMyobAssistant
{
    partial class ucPLAccountStructure
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
            this.tlPLAccounts = new DevExpress.XtraTreeList.TreeList();
            this.colDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAccountCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.mATreeListItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.icbParentAccount = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblMyobDescription = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lstMessages = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.tlPLAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mATreeListItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icbParentAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstMessages)).BeginInit();
            this.SuspendLayout();
            // 
            // tlPLAccounts
            // 
            this.tlPLAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlPLAccounts.Appearance.Caption.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlPLAccounts.Appearance.Caption.Options.UseFont = true;
            this.tlPLAccounts.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlPLAccounts.Appearance.HeaderPanel.Options.UseFont = true;
            this.tlPLAccounts.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlPLAccounts.Appearance.Row.Options.UseFont = true;
            this.tlPLAccounts.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colDescription,
            this.colAccountCode});
            this.tlPLAccounts.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlPLAccounts.DataSource = this.mATreeListItemBindingSource;
            this.tlPLAccounts.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlPLAccounts.KeyFieldName = "Id";
            this.tlPLAccounts.Location = new System.Drawing.Point(12, 42);
            this.tlPLAccounts.Name = "tlPLAccounts";
            this.tlPLAccounts.OptionsBehavior.Editable = false;
            this.tlPLAccounts.OptionsView.ShowCheckBoxes = true;
            this.tlPLAccounts.OptionsView.ShowIndicator = false;
            this.tlPLAccounts.ParentFieldName = "ParentId";
            this.tlPLAccounts.Size = new System.Drawing.Size(672, 514);
            this.tlPLAccounts.TabIndex = 0;
            this.tlPLAccounts.Click += new System.EventHandler(this.tlPLAccounts_Click);
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
            // mATreeListItemBindingSource
            // 
            this.mATreeListItemBindingSource.DataSource = typeof(FPMyobAssistant.MATreeListItem);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Controls.Add(this.btnUpdate);
            this.groupControl1.Controls.Add(this.icbParentAccount);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.lblMyobDescription);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            this.groupControl1.Location = new System.Drawing.Point(699, 42);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(537, 141);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Account Settings";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(457, 112);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // icbParentAccount
            // 
            this.icbParentAccount.Location = new System.Drawing.Point(5, 86);
            this.icbParentAccount.Name = "icbParentAccount";
            this.icbParentAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbParentAccount.Size = new System.Drawing.Size(527, 20);
            this.icbParentAccount.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(5, 67);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(80, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Parent Account";
            // 
            // lblMyobDescription
            // 
            this.lblMyobDescription.Location = new System.Drawing.Point(5, 43);
            this.lblMyobDescription.Name = "lblMyobDescription";
            this.lblMyobDescription.Size = new System.Drawing.Size(89, 13);
            this.lblMyobDescription.TabIndex = 1;
            this.lblMyobDescription.Text = "lblMyobDescription";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(5, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(93, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Myob Description";
            // 
            // lstMessages
            // 
            this.lstMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMessages.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMessages.Appearance.Options.UseFont = true;
            this.lstMessages.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstMessages.Location = new System.Drawing.Point(699, 189);
            this.lstMessages.Name = "lstMessages";
            this.lstMessages.Size = new System.Drawing.Size(537, 367);
            this.lstMessages.TabIndex = 27;
            // 
            // ucPLAccountStructure
            // 
            this.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstMessages);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.tlPLAccounts);
            this.Name = "ucPLAccountStructure";
            this.Size = new System.Drawing.Size(1253, 615);
            ((System.ComponentModel.ISupportInitialize)(this.tlPLAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mATreeListItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icbParentAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstMessages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList tlPLAccounts;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDescription;
        private System.Windows.Forms.BindingSource mATreeListItemBindingSource;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAccountCode;
        private DevExpress.XtraEditors.ListBoxControl lstMessages;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblMyobDescription;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbParentAccount;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
    }
}
