namespace FPMyobAssistant
{
    partial class eucExcludedAccountNumbers
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lstAccountNumbers = new DevExpress.XtraEditors.ListBoxControl();
            this.txtAccountNumber = new DevExpress.XtraEditors.TextEdit();
            this.btnAddExcludedAccount = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteExcludedAccount = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.lstAccountNumbers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountNumber.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(3, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(141, 13);
            this.labelControl2.TabIndex = 30;
            this.labelControl2.Text = "Excluded Account Numbers:";
            // 
            // lstAccountNumbers
            // 
            this.lstAccountNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAccountNumbers.Location = new System.Drawing.Point(0, 22);
            this.lstAccountNumbers.Name = "lstAccountNumbers";
            this.lstAccountNumbers.Size = new System.Drawing.Size(206, 310);
            this.lstAccountNumbers.TabIndex = 31;
            this.lstAccountNumbers.Click += new System.EventHandler(this.lstAccountNumbers_Click);
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccountNumber.Location = new System.Drawing.Point(0, 338);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(125, 20);
            this.txtAccountNumber.TabIndex = 32;
            this.txtAccountNumber.TextChanged += new System.EventHandler(this.txtAccountNumber_TextChanged);
            // 
            // btnAddExcludedAccount
            // 
            this.btnAddExcludedAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddExcludedAccount.Location = new System.Drawing.Point(131, 338);
            this.btnAddExcludedAccount.Name = "btnAddExcludedAccount";
            this.btnAddExcludedAccount.Size = new System.Drawing.Size(75, 23);
            this.btnAddExcludedAccount.TabIndex = 33;
            this.btnAddExcludedAccount.Text = "Add";
            this.btnAddExcludedAccount.Click += new System.EventHandler(this.btnAddExcludedAccount_Click);
            // 
            // btnDeleteExcludedAccount
            // 
            this.btnDeleteExcludedAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteExcludedAccount.Location = new System.Drawing.Point(131, 367);
            this.btnDeleteExcludedAccount.Name = "btnDeleteExcludedAccount";
            this.btnDeleteExcludedAccount.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteExcludedAccount.TabIndex = 34;
            this.btnDeleteExcludedAccount.Text = "Delete";
            this.btnDeleteExcludedAccount.Click += new System.EventHandler(this.btnDeleteExcludedAccount_Click);
            // 
            // eucExcludedAccountNumbers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDeleteExcludedAccount);
            this.Controls.Add(this.btnAddExcludedAccount);
            this.Controls.Add(this.txtAccountNumber);
            this.Controls.Add(this.lstAccountNumbers);
            this.Controls.Add(this.labelControl2);
            this.Name = "eucExcludedAccountNumbers";
            this.Size = new System.Drawing.Size(206, 391);
            ((System.ComponentModel.ISupportInitialize)(this.lstAccountNumbers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountNumber.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ListBoxControl lstAccountNumbers;
        private DevExpress.XtraEditors.TextEdit txtAccountNumber;
        private DevExpress.XtraEditors.SimpleButton btnAddExcludedAccount;
        private DevExpress.XtraEditors.SimpleButton btnDeleteExcludedAccount;
    }
}
