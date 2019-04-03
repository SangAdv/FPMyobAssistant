namespace FPMyobAssistant
{
    partial class ucBoardReport
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
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.icbEndPeriod = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.chkIncludePLYTD = new DevExpress.XtraEditors.CheckEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chkShowSpaces = new DevExpress.XtraEditors.CheckEdit();
            this.chkIncludePLAdjustments = new DevExpress.XtraEditors.CheckEdit();
            this.beBoardReportFilename = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.chkMonth = new DevExpress.XtraEditors.CheckEdit();
            this.chkQuarter = new DevExpress.XtraEditors.CheckEdit();
            this.chkAnnual = new DevExpress.XtraEditors.CheckEdit();
            this.chkOpenReport = new DevExpress.XtraEditors.CheckEdit();
            this.chkHalfYear = new DevExpress.XtraEditors.CheckEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.chkIncludeBSheetBudget = new DevExpress.XtraEditors.CheckEdit();
            this.chkIncludeBSheetLastYear = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.icbEndPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludePLYTD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowSpaces.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludePLAdjustments.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beBoardReportFilename.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkQuarter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAnnual.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOpenReport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHalfYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeBSheetBudget.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeBSheetLastYear.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(30, 533);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(60, 23);
            this.btnExport.TabIndex = 12;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(30, 90);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(66, 13);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "Report Type:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(30, 230);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 13);
            this.labelControl1.TabIndex = 16;
            this.labelControl1.Text = "End Period:";
            // 
            // icbEndPeriod
            // 
            this.icbEndPeriod.Location = new System.Drawing.Point(30, 249);
            this.icbEndPeriod.Name = "icbEndPeriod";
            this.icbEndPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbEndPeriod.Size = new System.Drawing.Size(84, 20);
            this.icbEndPeriod.TabIndex = 17;
            // 
            // chkIncludePLYTD
            // 
            this.chkIncludePLYTD.EditValue = true;
            this.chkIncludePLYTD.Location = new System.Drawing.Point(5, 24);
            this.chkIncludePLYTD.Name = "chkIncludePLYTD";
            this.chkIncludePLYTD.Properties.Caption = "Include YTD";
            this.chkIncludePLYTD.Size = new System.Drawing.Size(89, 20);
            this.chkIncludePLYTD.TabIndex = 18;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.chkShowSpaces);
            this.groupControl1.Controls.Add(this.chkIncludePLAdjustments);
            this.groupControl1.Controls.Add(this.chkIncludePLYTD);
            this.groupControl1.Location = new System.Drawing.Point(30, 291);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(205, 100);
            this.groupControl1.TabIndex = 19;
            this.groupControl1.Text = "P&&L Report Settings";
            // 
            // chkShowSpaces
            // 
            this.chkShowSpaces.EditValue = true;
            this.chkShowSpaces.Location = new System.Drawing.Point(5, 74);
            this.chkShowSpaces.Name = "chkShowSpaces";
            this.chkShowSpaces.Properties.Caption = "Show Spaces (Off = Zero)";
            this.chkShowSpaces.Size = new System.Drawing.Size(148, 20);
            this.chkShowSpaces.TabIndex = 20;
            // 
            // chkIncludePLAdjustments
            // 
            this.chkIncludePLAdjustments.Location = new System.Drawing.Point(5, 49);
            this.chkIncludePLAdjustments.Name = "chkIncludePLAdjustments";
            this.chkIncludePLAdjustments.Properties.Caption = "Include Adjustments";
            this.chkIncludePLAdjustments.Size = new System.Drawing.Size(134, 20);
            this.chkIncludePLAdjustments.TabIndex = 19;
            // 
            // beBoardReportFilename
            // 
            this.beBoardReportFilename.Location = new System.Drawing.Point(30, 447);
            this.beBoardReportFilename.Name = "beBoardReportFilename";
            this.beBoardReportFilename.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beBoardReportFilename.Properties.Appearance.Options.UseFont = true;
            this.beBoardReportFilename.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beBoardReportFilename.Properties.ReadOnly = true;
            this.beBoardReportFilename.Size = new System.Drawing.Size(758, 20);
            this.beBoardReportFilename.TabIndex = 21;
            this.beBoardReportFilename.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beBoardReportFilename_ButtonClick);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(30, 428);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(87, 13);
            this.labelControl2.TabIndex = 23;
            this.labelControl2.Text = "Export Filename:";
            // 
            // chkMonth
            // 
            this.chkMonth.EditValue = true;
            this.chkMonth.Location = new System.Drawing.Point(30, 109);
            this.chkMonth.Name = "chkMonth";
            this.chkMonth.Properties.Caption = "Month";
            this.chkMonth.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkMonth.Properties.RadioGroupIndex = 1;
            this.chkMonth.Size = new System.Drawing.Size(89, 20);
            this.chkMonth.TabIndex = 24;
            this.chkMonth.CheckedChanged += new System.EventHandler(this.rptType_CheckedChanged);
            // 
            // chkQuarter
            // 
            this.chkQuarter.Location = new System.Drawing.Point(30, 134);
            this.chkQuarter.Name = "chkQuarter";
            this.chkQuarter.Properties.Caption = "Quarter";
            this.chkQuarter.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkQuarter.Properties.RadioGroupIndex = 1;
            this.chkQuarter.Size = new System.Drawing.Size(89, 20);
            this.chkQuarter.TabIndex = 25;
            this.chkQuarter.TabStop = false;
            this.chkQuarter.CheckedChanged += new System.EventHandler(this.rptType_CheckedChanged);
            // 
            // chkAnnual
            // 
            this.chkAnnual.Location = new System.Drawing.Point(30, 184);
            this.chkAnnual.Name = "chkAnnual";
            this.chkAnnual.Properties.Caption = "Full Year";
            this.chkAnnual.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkAnnual.Properties.RadioGroupIndex = 1;
            this.chkAnnual.Size = new System.Drawing.Size(89, 20);
            this.chkAnnual.TabIndex = 26;
            this.chkAnnual.TabStop = false;
            this.chkAnnual.CheckedChanged += new System.EventHandler(this.rptType_CheckedChanged);
            // 
            // chkOpenReport
            // 
            this.chkOpenReport.EditValue = true;
            this.chkOpenReport.Location = new System.Drawing.Point(30, 473);
            this.chkOpenReport.Name = "chkOpenReport";
            this.chkOpenReport.Properties.Caption = "Open report after export";
            this.chkOpenReport.Size = new System.Drawing.Size(163, 20);
            this.chkOpenReport.TabIndex = 27;
            // 
            // chkHalfYear
            // 
            this.chkHalfYear.Location = new System.Drawing.Point(30, 159);
            this.chkHalfYear.Name = "chkHalfYear";
            this.chkHalfYear.Properties.Caption = "Half Year";
            this.chkHalfYear.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkHalfYear.Properties.RadioGroupIndex = 1;
            this.chkHalfYear.Size = new System.Drawing.Size(89, 20);
            this.chkHalfYear.TabIndex = 28;
            this.chkHalfYear.TabStop = false;
            this.chkHalfYear.CheckedChanged += new System.EventHandler(this.rptType_CheckedChanged);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.chkIncludeBSheetBudget);
            this.groupControl2.Controls.Add(this.chkIncludeBSheetLastYear);
            this.groupControl2.Location = new System.Drawing.Point(271, 291);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(205, 100);
            this.groupControl2.TabIndex = 29;
            this.groupControl2.Text = "Balance Sheet Report Settings";
            // 
            // chkIncludeBSheetBudget
            // 
            this.chkIncludeBSheetBudget.EditValue = true;
            this.chkIncludeBSheetBudget.Location = new System.Drawing.Point(5, 49);
            this.chkIncludeBSheetBudget.Name = "chkIncludeBSheetBudget";
            this.chkIncludeBSheetBudget.Properties.Caption = "Include Budget";
            this.chkIncludeBSheetBudget.Size = new System.Drawing.Size(134, 20);
            this.chkIncludeBSheetBudget.TabIndex = 19;
            // 
            // chkIncludeBSheetLastYear
            // 
            this.chkIncludeBSheetLastYear.EditValue = true;
            this.chkIncludeBSheetLastYear.Location = new System.Drawing.Point(5, 24);
            this.chkIncludeBSheetLastYear.Name = "chkIncludeBSheetLastYear";
            this.chkIncludeBSheetLastYear.Properties.Caption = "Include Last Year";
            this.chkIncludeBSheetLastYear.Size = new System.Drawing.Size(134, 20);
            this.chkIncludeBSheetLastYear.TabIndex = 18;
            // 
            // ucBoardReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.chkHalfYear);
            this.Controls.Add(this.chkOpenReport);
            this.Controls.Add(this.chkAnnual);
            this.Controls.Add(this.chkQuarter);
            this.Controls.Add(this.chkMonth);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.beBoardReportFilename);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.icbEndPeriod);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.btnExport);
            this.Name = "ucBoardReport";
            this.Size = new System.Drawing.Size(1253, 620);
            ((System.ComponentModel.ISupportInitialize)(this.icbEndPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludePLYTD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkShowSpaces.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludePLAdjustments.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beBoardReportFilename.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkQuarter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAnnual.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOpenReport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHalfYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeBSheetBudget.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeBSheetLastYear.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbEndPeriod;
        private DevExpress.XtraEditors.CheckEdit chkIncludePLYTD;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ButtonEdit beBoardReportFilename;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckEdit chkMonth;
        private DevExpress.XtraEditors.CheckEdit chkQuarter;
        private DevExpress.XtraEditors.CheckEdit chkAnnual;
        private DevExpress.XtraEditors.CheckEdit chkOpenReport;
        private DevExpress.XtraEditors.CheckEdit chkIncludePLAdjustments;
        private DevExpress.XtraEditors.CheckEdit chkHalfYear;
        private DevExpress.XtraEditors.CheckEdit chkShowSpaces;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.CheckEdit chkIncludeBSheetBudget;
        private DevExpress.XtraEditors.CheckEdit chkIncludeBSheetLastYear;
    }
}
