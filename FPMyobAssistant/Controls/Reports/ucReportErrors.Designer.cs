namespace FPMyobAssistant
{
    partial class ucReportErrors
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
            this.icbReport = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.lbErrors = new DevExpress.XtraEditors.ListBoxControl();
            this.btnCheck = new DevExpress.XtraEditors.SimpleButton();
            this.txtAccountCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnRemoveAll = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.icbReport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbErrors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(14, 52);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(50, 19);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Report:";
            // 
            // icbReport
            // 
            this.icbReport.Location = new System.Drawing.Point(14, 79);
            this.icbReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.icbReport.Name = "icbReport";
            this.icbReport.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbReport.Size = new System.Drawing.Size(784, 22);
            this.icbReport.TabIndex = 6;
            this.icbReport.SelectedIndexChanged += new System.EventHandler(this.icbReport_SelectedIndexChanged);
            // 
            // lbErrors
            // 
            this.lbErrors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbErrors.Location = new System.Drawing.Point(14, 121);
            this.lbErrors.Name = "lbErrors";
            this.lbErrors.Size = new System.Drawing.Size(784, 559);
            this.lbErrors.TabIndex = 8;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(819, 75);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(94, 29);
            this.btnCheck.TabIndex = 9;
            this.btnCheck.Text = "Check";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // txtAccountCode
            // 
            this.txtAccountCode.Location = new System.Drawing.Point(819, 188);
            this.txtAccountCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAccountCode.Name = "txtAccountCode";
            this.txtAccountCode.Size = new System.Drawing.Size(116, 22);
            this.txtAccountCode.TabIndex = 10;
            this.txtAccountCode.TextChanged += new System.EventHandler(this.txtAccountCode_TextChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(819, 165);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(97, 19);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "Account Code:";
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(819, 221);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(94, 29);
            this.btnRemoveAll.TabIndex = 12;
            this.btnRemoveAll.Text = "Remove All";
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // ucReportErrors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtAccountCode);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.lbErrors);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.icbReport);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucReportErrors";
            this.Size = new System.Drawing.Size(1332, 786);
            ((System.ComponentModel.ISupportInitialize)(this.icbReport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbErrors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountCode.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbReport;
        private DevExpress.XtraEditors.ListBoxControl lbErrors;
        private DevExpress.XtraEditors.SimpleButton btnCheck;
        private DevExpress.XtraEditors.TextEdit txtAccountCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnRemoveAll;
    }
}
