namespace FPMyobAssistant
{
    partial class frmCopyItem
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
            this.lblSelectedAccount = new DevExpress.XtraEditors.LabelControl();
            this.lblDHLNumber = new DevExpress.XtraEditors.LabelControl();
            this.icbReport = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnHeadingChoose = new DevExpress.XtraEditors.SimpleButton();
            this.icbHeading = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.icbItem = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnItemChoose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.icbReport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbHeading.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbItem.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSelectedAccount
            // 
            this.lblSelectedAccount.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedAccount.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSelectedAccount.Appearance.Options.UseFont = true;
            this.lblSelectedAccount.Appearance.Options.UseForeColor = true;
            this.lblSelectedAccount.Location = new System.Drawing.Point(12, 31);
            this.lblSelectedAccount.Name = "lblSelectedAccount";
            this.lblSelectedAccount.Size = new System.Drawing.Size(79, 13);
            this.lblSelectedAccount.TabIndex = 15;
            this.lblSelectedAccount.Text = "lblSelectedItem";
            // 
            // lblDHLNumber
            // 
            this.lblDHLNumber.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDHLNumber.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDHLNumber.Appearance.Options.UseFont = true;
            this.lblDHLNumber.Appearance.Options.UseForeColor = true;
            this.lblDHLNumber.Location = new System.Drawing.Point(12, 12);
            this.lblDHLNumber.Name = "lblDHLNumber";
            this.lblDHLNumber.Size = new System.Drawing.Size(112, 13);
            this.lblDHLNumber.TabIndex = 14;
            this.lblDHLNumber.Text = "Select Parent Item for:";
            // 
            // icbReport
            // 
            this.icbReport.Location = new System.Drawing.Point(12, 125);
            this.icbReport.Name = "icbReport";
            this.icbReport.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icbReport.Properties.Appearance.Options.UseFont = true;
            this.icbReport.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbReport.Size = new System.Drawing.Size(543, 20);
            this.icbReport.TabIndex = 13;
            this.icbReport.SelectedIndexChanged += new System.EventHandler(this.icbReport_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(561, 244);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(55, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            // 
            // btnHeadingChoose
            // 
            this.btnHeadingChoose.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHeadingChoose.Appearance.Options.UseFont = true;
            this.btnHeadingChoose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnHeadingChoose.Location = new System.Drawing.Point(561, 164);
            this.btnHeadingChoose.Name = "btnHeadingChoose";
            this.btnHeadingChoose.Size = new System.Drawing.Size(55, 23);
            this.btnHeadingChoose.TabIndex = 11;
            this.btnHeadingChoose.Text = "Choose";
            this.btnHeadingChoose.Click += new System.EventHandler(this.btnHeadingChoose_Click);
            // 
            // icbHeading
            // 
            this.icbHeading.Location = new System.Drawing.Point(12, 166);
            this.icbHeading.Name = "icbHeading";
            this.icbHeading.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icbHeading.Properties.Appearance.Options.UseFont = true;
            this.icbHeading.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbHeading.Size = new System.Drawing.Size(543, 20);
            this.icbHeading.TabIndex = 16;
            this.icbHeading.SelectedIndexChanged += new System.EventHandler(this.icbHeading_SelectedIndexChanged);
            // 
            // icbItem
            // 
            this.icbItem.Location = new System.Drawing.Point(12, 206);
            this.icbItem.Name = "icbItem";
            this.icbItem.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icbItem.Properties.Appearance.Options.UseFont = true;
            this.icbItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbItem.Size = new System.Drawing.Size(543, 20);
            this.icbItem.TabIndex = 17;
            this.icbItem.SelectedIndexChanged += new System.EventHandler(this.icbItem_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 110);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(38, 13);
            this.labelControl1.TabIndex = 18;
            this.labelControl1.Text = "Report:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 151);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 13);
            this.labelControl2.TabIndex = 19;
            this.labelControl2.Text = "Heading:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(12, 192);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(26, 13);
            this.labelControl3.TabIndex = 20;
            this.labelControl3.Text = "Item:";
            // 
            // btnItemChoose
            // 
            this.btnItemChoose.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemChoose.Appearance.Options.UseFont = true;
            this.btnItemChoose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnItemChoose.Location = new System.Drawing.Point(561, 204);
            this.btnItemChoose.Name = "btnItemChoose";
            this.btnItemChoose.Size = new System.Drawing.Size(55, 23);
            this.btnItemChoose.TabIndex = 21;
            this.btnItemChoose.Text = "Choose";
            this.btnItemChoose.Click += new System.EventHandler(this.btnItemChoose_Click);
            // 
            // frmCopyItem
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 279);
            this.ControlBox = false;
            this.Controls.Add(this.btnItemChoose);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.icbItem);
            this.Controls.Add(this.icbHeading);
            this.Controls.Add(this.lblSelectedAccount);
            this.Controls.Add(this.lblDHLNumber);
            this.Controls.Add(this.icbReport);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnHeadingChoose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCopyItem";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choose Report Item";
            this.Shown += new System.EventHandler(this.frmCopyItem_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.icbReport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbHeading.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbItem.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblSelectedAccount;
        private DevExpress.XtraEditors.LabelControl lblDHLNumber;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbReport;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnHeadingChoose;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbHeading;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbItem;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnItemChoose;
    }
}