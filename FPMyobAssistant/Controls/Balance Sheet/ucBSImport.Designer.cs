namespace FPMyobAssistant
{
    partial class ucBSImport
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
            this.lstMessages = new DevExpress.XtraEditors.ListBoxControl();
            this.eucBSBudgetImport = new FPMyobAssistant.eucBSBudgetImport();
            this.eucBSImport = new FPMyobAssistant.eucBSImport();
            ((System.ComponentModel.ISupportInitialize)(this.lstMessages)).BeginInit();
            this.SuspendLayout();
            // 
            // lstMessages
            // 
            this.lstMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstMessages.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMessages.Appearance.Options.UseFont = true;
            this.lstMessages.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstMessages.Location = new System.Drawing.Point(31, 358);
            this.lstMessages.Name = "lstMessages";
            this.lstMessages.Size = new System.Drawing.Size(758, 203);
            this.lstMessages.TabIndex = 32;
            // 
            // eucBSBudgetImport
            // 
            this.eucBSBudgetImport.Location = new System.Drawing.Point(31, 197);
            this.eucBSBudgetImport.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.eucBSBudgetImport.Name = "eucBSBudgetImport";
            this.eucBSBudgetImport.Size = new System.Drawing.Size(788, 155);
            this.eucBSBudgetImport.TabIndex = 38;
            this.eucBSBudgetImport.MessageChanged += new SangAdv.Common.StringDelegate(this.eucBSBudgetImport_MessageChanged);
            this.eucBSBudgetImport.ClearMessages += new SangAdv.Common.EmptyDelegate(this.eucBSBudgetImport_ClearMessages);
            this.eucBSBudgetImport.DisableAll += new SangAdv.Common.EmptyDelegate(this.eucBSBudgetImport_DisableAll);
            this.eucBSBudgetImport.EnableAll += new SangAdv.Common.EmptyDelegate(this.eucBSBudgetImport_EnableAll);
            this.eucBSBudgetImport.AddMessage += new SangAdv.Common.StringDelegate(this.eucBSBudgetImport_AddMessage);
            // 
            // eucBSImport
            // 
            this.eucBSImport.Location = new System.Drawing.Point(31, 52);
            this.eucBSImport.Name = "eucBSImport";
            this.eucBSImport.Size = new System.Drawing.Size(788, 140);
            this.eucBSImport.TabIndex = 39;
            this.eucBSImport.MessageChanged += new SangAdv.Common.StringDelegate(this.eucBSImport_MessageChanged);
            this.eucBSImport.ClearMessages += new SangAdv.Common.EmptyDelegate(this.eucBSImport_ClearMessages);
            this.eucBSImport.DisableAll += new SangAdv.Common.EmptyDelegate(this.eucBSImport_DisableAll);
            this.eucBSImport.EnableAll += new SangAdv.Common.EmptyDelegate(this.eucBSImport_EnableAll);
            this.eucBSImport.AddMessage += new SangAdv.Common.StringDelegate(this.eucBSImport_AddMessage);
            // 
            // ucBSImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.eucBSImport);
            this.Controls.Add(this.eucBSBudgetImport);
            this.Controls.Add(this.lstMessages);
            this.Name = "ucBSImport";
            this.Size = new System.Drawing.Size(1087, 626);
            ((System.ComponentModel.ISupportInitialize)(this.lstMessages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.ListBoxControl lstMessages;
        private eucBSBudgetImport eucBSBudgetImport;
        private eucBSImport eucBSImport;
    }
}
