namespace FPMyobAssistant
{
    partial class ucPLImport
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
            this.eucPLBudgetImport = new FPMyobAssistant.eucPLBudgetImport();
            this.eucPLImport = new FPMyobAssistant.eucPLImport();
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
            this.lstMessages.TabIndex = 26;
            // 
            // eucPLBudgetImport
            // 
            this.eucPLBudgetImport.Location = new System.Drawing.Point(31, 197);
            this.eucPLBudgetImport.Name = "eucPLBudgetImport";
            this.eucPLBudgetImport.Size = new System.Drawing.Size(786, 155);
            this.eucPLBudgetImport.TabIndex = 32;
            this.eucPLBudgetImport.MessageChanged += new SangAdv.Common.StringDelegate(this.eucPLBudgetImport_MessageChanged);
            this.eucPLBudgetImport.ClearMessages += new SangAdv.Common.EmptyDelegate(this.eucPLBudgetImport_ClearMessages);
            this.eucPLBudgetImport.DisableAll += new SangAdv.Common.EmptyDelegate(this.eucPLBudgetImport_DisableAll);
            this.eucPLBudgetImport.EnableAll += new SangAdv.Common.EmptyDelegate(this.eucPLBudgetImport_EnableAll);
            this.eucPLBudgetImport.AddMessage += new SangAdv.Common.StringDelegate(this.eucPLBudgetImport_AddMessage);
            // 
            // eucPLImport
            // 
            this.eucPLImport.Location = new System.Drawing.Point(31, 52);
            this.eucPLImport.Name = "eucPLImport";
            this.eucPLImport.Size = new System.Drawing.Size(786, 139);
            this.eucPLImport.TabIndex = 31;
            this.eucPLImport.MessageChanged += new SangAdv.Common.StringDelegate(this.eucPLImport_MessageChanged);
            this.eucPLImport.ClearMessages += new SangAdv.Common.EmptyDelegate(this.eucPLImport_ClearMessages);
            this.eucPLImport.DisableAll += new SangAdv.Common.EmptyDelegate(this.eucPLImport_DisableAll);
            this.eucPLImport.EnableAll += new SangAdv.Common.EmptyDelegate(this.eucPLImport_EnableAll);
            this.eucPLImport.AddMessage += new SangAdv.Common.StringDelegate(this.eucPLImport_AddMessage);
            // 
            // ucPLImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.eucPLBudgetImport);
            this.Controls.Add(this.eucPLImport);
            this.Controls.Add(this.lstMessages);
            this.Name = "ucPLImport";
            this.Size = new System.Drawing.Size(1087, 626);
            ((System.ComponentModel.ISupportInitialize)(this.lstMessages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.ListBoxControl lstMessages;
        private eucPLImport eucPLImport;
        private eucPLBudgetImport eucPLBudgetImport;
    }
}
