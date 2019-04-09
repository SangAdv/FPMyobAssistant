namespace FPMyobAssistant
{
    partial class ucProductMyobAccountId
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
            this.LabelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.icbDistributor = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.lstImport = new DevExpress.XtraEditors.ListBoxControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtMYOBNumber = new DevExpress.XtraEditors.TextEdit();
            this.btnDefine = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.icbDistributor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMYOBNumber.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelControl1
            // 
            this.LabelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelControl1.Appearance.Options.UseFont = true;
            this.LabelControl1.Location = new System.Drawing.Point(29, 48);
            this.LabelControl1.Name = "LabelControl1";
            this.LabelControl1.Size = new System.Drawing.Size(64, 13);
            this.LabelControl1.TabIndex = 130;
            this.LabelControl1.Text = "Distributor:";
            // 
            // icbDistributor
            // 
            this.icbDistributor.Location = new System.Drawing.Point(29, 67);
            this.icbDistributor.Name = "icbDistributor";
            this.icbDistributor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbDistributor.Size = new System.Drawing.Size(310, 20);
            this.icbDistributor.TabIndex = 129;
            this.icbDistributor.SelectedIndexChanged += new System.EventHandler(this.IcbDistributor_SelectedIndexChanged);
            // 
            // lstImport
            // 
            this.lstImport.Location = new System.Drawing.Point(29, 105);
            this.lstImport.Name = "lstImport";
            this.lstImport.Size = new System.Drawing.Size(735, 388);
            this.lstImport.TabIndex = 131;
            this.lstImport.Click += new System.EventHandler(this.LstImport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(90, 561);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(55, 23);
            this.btnCancel.TabIndex = 135;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(29, 516);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(130, 13);
            this.labelControl3.TabIndex = 134;
            this.labelControl3.Text = "MYOB Reptos Account ID:";
            // 
            // txtMYOBNumber
            // 
            this.txtMYOBNumber.Location = new System.Drawing.Point(29, 535);
            this.txtMYOBNumber.Name = "txtMYOBNumber";
            this.txtMYOBNumber.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMYOBNumber.Properties.Appearance.Options.UseFont = true;
            this.txtMYOBNumber.Size = new System.Drawing.Size(100, 20);
            this.txtMYOBNumber.TabIndex = 133;
            // 
            // btnDefine
            // 
            this.btnDefine.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDefine.Appearance.Options.UseFont = true;
            this.btnDefine.Enabled = false;
            this.btnDefine.Location = new System.Drawing.Point(29, 561);
            this.btnDefine.Name = "btnDefine";
            this.btnDefine.Size = new System.Drawing.Size(55, 23);
            this.btnDefine.TabIndex = 132;
            this.btnDefine.Text = "Define";
            this.btnDefine.Click += new System.EventHandler(this.BtnDefine_Click);
            // 
            // ucProductMyobAccountId
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtMYOBNumber);
            this.Controls.Add(this.btnDefine);
            this.Controls.Add(this.lstImport);
            this.Controls.Add(this.LabelControl1);
            this.Controls.Add(this.icbDistributor);
            this.Name = "ucProductMyobAccountId";
            this.Size = new System.Drawing.Size(1066, 742);
            ((System.ComponentModel.ISupportInitialize)(this.icbDistributor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMYOBNumber.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal DevExpress.XtraEditors.LabelControl LabelControl1;
        internal DevExpress.XtraEditors.ImageComboBoxEdit icbDistributor;
        internal DevExpress.XtraEditors.ListBoxControl lstImport;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtMYOBNumber;
        private DevExpress.XtraEditors.SimpleButton btnDefine;
    }
}
