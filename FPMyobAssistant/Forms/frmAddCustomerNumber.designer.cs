namespace FPMyobAssistant
{
    partial class frmAddCustomerNumber
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
            this.btnDefine = new DevExpress.XtraEditors.SimpleButton();
            this.lblDHLNumber = new DevExpress.XtraEditors.LabelControl();
            this.txtMYOBNumber = new DevExpress.XtraEditors.TextEdit();
            this.lblDHLCustomer = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtMYOBNumber.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDefine
            // 
            this.btnDefine.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDefine.Appearance.Options.UseFont = true;
            this.btnDefine.Enabled = false;
            this.btnDefine.Location = new System.Drawing.Point(332, 106);
            this.btnDefine.Name = "btnDefine";
            this.btnDefine.Size = new System.Drawing.Size(55, 23);
            this.btnDefine.TabIndex = 0;
            this.btnDefine.Text = "Define";
            this.btnDefine.Click += new System.EventHandler(this.btnDefine_Click);
            // 
            // lblDHLNumber
            // 
            this.lblDHLNumber.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDHLNumber.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDHLNumber.Appearance.Options.UseFont = true;
            this.lblDHLNumber.Appearance.Options.UseForeColor = true;
            this.lblDHLNumber.Location = new System.Drawing.Point(12, 12);
            this.lblDHLNumber.Name = "lblDHLNumber";
            this.lblDHLNumber.Size = new System.Drawing.Size(67, 13);
            this.lblDHLNumber.TabIndex = 1;
            this.lblDHLNumber.Text = "labelControl1";
            // 
            // txtMYOBNumber
            // 
            this.txtMYOBNumber.Location = new System.Drawing.Point(12, 71);
            this.txtMYOBNumber.Name = "txtMYOBNumber";
            this.txtMYOBNumber.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMYOBNumber.Properties.Appearance.Options.UseFont = true;
            this.txtMYOBNumber.Size = new System.Drawing.Size(100, 20);
            this.txtMYOBNumber.TabIndex = 2;
            this.txtMYOBNumber.TextChanged += new System.EventHandler(this.txtMYOBNumber_TextChanged);
            // 
            // lblDHLCustomer
            // 
            this.lblDHLCustomer.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDHLCustomer.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDHLCustomer.Appearance.Options.UseFont = true;
            this.lblDHLCustomer.Appearance.Options.UseForeColor = true;
            this.lblDHLCustomer.Location = new System.Drawing.Point(12, 31);
            this.lblDHLCustomer.Name = "lblDHLCustomer";
            this.lblDHLCustomer.Size = new System.Drawing.Size(70, 13);
            this.lblDHLCustomer.TabIndex = 3;
            this.lblDHLCustomer.Text = "labelControl2";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(12, 52);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(75, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "MYOB Card ID:";
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(393, 106);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(55, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmAddCustomerNumber
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 141);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lblDHLCustomer);
            this.Controls.Add(this.txtMYOBNumber);
            this.Controls.Add(this.lblDHLNumber);
            this.Controls.Add(this.btnDefine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddCustomerNumber";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Customer Number";
            ((System.ComponentModel.ISupportInitialize)(this.txtMYOBNumber.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnDefine;
        private DevExpress.XtraEditors.LabelControl lblDHLNumber;
        private DevExpress.XtraEditors.TextEdit txtMYOBNumber;
        private DevExpress.XtraEditors.LabelControl lblDHLCustomer;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}