namespace FPMyobAssistant
{
    partial class eucPLBudgetImport
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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnPreImport = new DevExpress.XtraEditors.SimpleButton();
            this.icbStartPeriod = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.beBPLFilename = new DevExpress.XtraEditors.ButtonEdit();
            this.icbPeriod = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icbStartPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beBPLFilename.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbPeriod.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnPreImport);
            this.groupControl2.Controls.Add(this.icbStartPeriod);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Controls.Add(this.btnImport);
            this.groupControl2.Controls.Add(this.btnExport);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.beBPLFilename);
            this.groupControl2.Controls.Add(this.icbPeriod);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1048, 191);
            this.groupControl2.TabIndex = 31;
            this.groupControl2.Text = "P&&L Budget";
            // 
            // btnPreImport
            // 
            this.btnPreImport.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreImport.Appearance.Options.UseFont = true;
            this.btnPreImport.Location = new System.Drawing.Point(925, 114);
            this.btnPreImport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPreImport.Name = "btnPreImport";
            this.btnPreImport.Size = new System.Drawing.Size(100, 28);
            this.btnPreImport.TabIndex = 37;
            this.btnPreImport.Text = "Pre Import";
            this.btnPreImport.Click += new System.EventHandler(this.btnPreImport_Click);
            // 
            // icbStartPeriod
            // 
            this.icbStartPeriod.Location = new System.Drawing.Point(793, 154);
            this.icbStartPeriod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.icbStartPeriod.Name = "icbStartPeriod";
            this.icbStartPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbStartPeriod.Size = new System.Drawing.Size(112, 22);
            this.icbStartPeriod.TabIndex = 36;
            this.icbStartPeriod.SelectedIndexChanged += new System.EventHandler(this.icbStartPeriod_SelectedIndexChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(793, 130);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(77, 19);
            this.labelControl5.TabIndex = 35;
            this.labelControl5.Text = "Start Period:";
            // 
            // btnImport
            // 
            this.btnImport.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Appearance.Options.UseFont = true;
            this.btnImport.Location = new System.Drawing.Point(925, 151);
            this.btnImport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(100, 28);
            this.btnImport.TabIndex = 34;
            this.btnImport.Text = "Import";
            this.btnImport.Click += new System.EventHandler(this.btnBImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Location = new System.Drawing.Point(15, 151);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 28);
            this.btnExport.TabIndex = 33;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnBExport_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(15, 39);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(164, 19);
            this.labelControl4.TabIndex = 32;
            this.labelControl4.Text = "P&&L Budget Template File:";
            // 
            // beBPLFilename
            // 
            this.beBPLFilename.Location = new System.Drawing.Point(15, 63);
            this.beBPLFilename.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.beBPLFilename.Name = "beBPLFilename";
            this.beBPLFilename.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beBPLFilename.Properties.Appearance.Options.UseFont = true;
            this.beBPLFilename.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beBPLFilename.Properties.ReadOnly = true;
            this.beBPLFilename.Size = new System.Drawing.Size(1011, 26);
            this.beBPLFilename.TabIndex = 31;
            this.beBPLFilename.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beBPLFilename_ButtonClick);
            // 
            // icbPeriod
            // 
            this.icbPeriod.Location = new System.Drawing.Point(15, 118);
            this.icbPeriod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.icbPeriod.Name = "icbPeriod";
            this.icbPeriod.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icbPeriod.Properties.Appearance.Options.UseFont = true;
            this.icbPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbPeriod.Size = new System.Drawing.Size(213, 26);
            this.icbPeriod.TabIndex = 30;
            this.icbPeriod.SelectedIndexChanged += new System.EventHandler(this.icbBPeriod_SelectedIndexChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(15, 95);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(72, 19);
            this.labelControl3.TabIndex = 29;
            this.labelControl3.Text = "P&&L Period:";
            // 
            // eucPLBudgetImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "eucPLBudgetImport";
            this.Size = new System.Drawing.Size(1048, 191);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icbStartPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beBPLFilename.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbPeriod.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnPreImport;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbStartPeriod;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnImport;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ButtonEdit beBPLFilename;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbPeriod;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}
