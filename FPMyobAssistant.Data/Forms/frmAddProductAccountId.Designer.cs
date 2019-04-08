namespace FPMyobAssistant
{
    partial class frmAddProductAccountId
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
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblProduct = new DevExpress.XtraEditors.LabelControl();
            this.txtAccountNumber = new DevExpress.XtraEditors.TextEdit();
            this.lblProductPDE = new DevExpress.XtraEditors.LabelControl();
            this.btnDefine = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountNumber.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(393, 106);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(55, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(12, 52);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(99, 13);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "Product Account ID:";
            // 
            // lblProduct
            // 
            this.lblProduct.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProduct.Appearance.Options.UseFont = true;
            this.lblProduct.Appearance.Options.UseForeColor = true;
            this.lblProduct.Location = new System.Drawing.Point(12, 31);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(53, 13);
            this.lblProduct.TabIndex = 9;
            this.lblProduct.Text = "lblProduct";
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Location = new System.Drawing.Point(12, 71);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountNumber.Properties.Appearance.Options.UseFont = true;
            this.txtAccountNumber.Size = new System.Drawing.Size(100, 20);
            this.txtAccountNumber.TabIndex = 8;
            this.txtAccountNumber.TextChanged += new System.EventHandler(this.txtAccountNumber_TextChanged);
            // 
            // lblProductPDE
            // 
            this.lblProductPDE.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductPDE.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProductPDE.Appearance.Options.UseFont = true;
            this.lblProductPDE.Appearance.Options.UseForeColor = true;
            this.lblProductPDE.Location = new System.Drawing.Point(12, 12);
            this.lblProductPDE.Name = "lblProductPDE";
            this.lblProductPDE.Size = new System.Drawing.Size(72, 13);
            this.lblProductPDE.TabIndex = 7;
            this.lblProductPDE.Text = "lblProductPDE";
            // 
            // btnDefine
            // 
            this.btnDefine.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDefine.Appearance.Options.UseFont = true;
            this.btnDefine.Enabled = false;
            this.btnDefine.Location = new System.Drawing.Point(332, 106);
            this.btnDefine.Name = "btnDefine";
            this.btnDefine.Size = new System.Drawing.Size(55, 23);
            this.btnDefine.TabIndex = 6;
            this.btnDefine.Text = "Define";
            this.btnDefine.Click += new System.EventHandler(this.btnDefine_Click);
            // 
            // frmAddProductAccountId
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 151);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.txtAccountNumber);
            this.Controls.Add(this.lblProductPDE);
            this.Controls.Add(this.btnDefine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmAddProductAccountId";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Add Product AccountId";
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountNumber.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblProduct;
        private DevExpress.XtraEditors.TextEdit txtAccountNumber;
        private DevExpress.XtraEditors.LabelControl lblProductPDE;
        private DevExpress.XtraEditors.SimpleButton btnDefine;
    }
}