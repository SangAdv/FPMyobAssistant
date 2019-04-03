namespace FPMyobAssistant
{
    partial class frmChooseParent
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
            this.btnDefine = new DevExpress.XtraEditors.SimpleButton();
            this.icbParentAccount = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.lblDHLNumber = new DevExpress.XtraEditors.LabelControl();
            this.lblSelectedAccount = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.icbParentAccount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(500, 84);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(55, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            // 
            // btnDefine
            // 
            this.btnDefine.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDefine.Appearance.Options.UseFont = true;
            this.btnDefine.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDefine.Location = new System.Drawing.Point(439, 84);
            this.btnDefine.Name = "btnDefine";
            this.btnDefine.Size = new System.Drawing.Size(55, 23);
            this.btnDefine.TabIndex = 6;
            this.btnDefine.Text = "Define";
            // 
            // icbParentAccount
            // 
            this.icbParentAccount.Location = new System.Drawing.Point(12, 58);
            this.icbParentAccount.Name = "icbParentAccount";
            this.icbParentAccount.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icbParentAccount.Properties.Appearance.Options.UseFont = true;
            this.icbParentAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbParentAccount.Size = new System.Drawing.Size(543, 20);
            this.icbParentAccount.TabIndex = 8;
            this.icbParentAccount.SelectedIndexChanged += new System.EventHandler(this.icbParentAccount_SelectedIndexChanged);
            // 
            // lblDHLNumber
            // 
            this.lblDHLNumber.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDHLNumber.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDHLNumber.Appearance.Options.UseFont = true;
            this.lblDHLNumber.Appearance.Options.UseForeColor = true;
            this.lblDHLNumber.Location = new System.Drawing.Point(12, 12);
            this.lblDHLNumber.Name = "lblDHLNumber";
            this.lblDHLNumber.Size = new System.Drawing.Size(129, 13);
            this.lblDHLNumber.TabIndex = 9;
            this.lblDHLNumber.Text = "Select Parent Account for:";
            // 
            // lblSelectedAccount
            // 
            this.lblSelectedAccount.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedAccount.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSelectedAccount.Appearance.Options.UseFont = true;
            this.lblSelectedAccount.Appearance.Options.UseForeColor = true;
            this.lblSelectedAccount.Location = new System.Drawing.Point(12, 31);
            this.lblSelectedAccount.Name = "lblSelectedAccount";
            this.lblSelectedAccount.Size = new System.Drawing.Size(96, 13);
            this.lblSelectedAccount.TabIndex = 10;
            this.lblSelectedAccount.Text = "lblSelectedAccount";
            // 
            // frmChooseParent
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 118);
            this.ControlBox = false;
            this.Controls.Add(this.lblSelectedAccount);
            this.Controls.Add(this.lblDHLNumber);
            this.Controls.Add(this.icbParentAccount);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDefine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmChooseParent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choose Parent AccountId...";
            ((System.ComponentModel.ISupportInitialize)(this.icbParentAccount.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnDefine;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbParentAccount;
        private DevExpress.XtraEditors.LabelControl lblDHLNumber;
        private DevExpress.XtraEditors.LabelControl lblSelectedAccount;
    }
}