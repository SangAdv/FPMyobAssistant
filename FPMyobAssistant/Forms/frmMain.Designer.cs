namespace FPMyobAssistant
{
    partial class frmMain
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
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, null, true, true);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.cntMain = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.hmMain = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement2 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceDHLImportPreparation = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceDHLImport = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acePLImport = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceBSImport = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceDataSync = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement3 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceBoardReport = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement9 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceWelcome = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement5 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement7 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceMyobCardIds = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement10 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acePLAccountStructure = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceBSAccountStructure = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement8 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceReportStructure = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceReportStructureGroups = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceReportErrors = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acAdmin = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceUsers = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceExit = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.accordionControlElement4 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement6 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceReptosImport = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ((System.ComponentModel.ISupportInitialize)(this.hmMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            splashScreenManager1.ClosingDelay = 500;
            // 
            // cntMain
            // 
            this.cntMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cntMain.Location = new System.Drawing.Point(260, 30);
            this.cntMain.Name = "cntMain";
            this.cntMain.Size = new System.Drawing.Size(802, 564);
            this.cntMain.TabIndex = 0;
            // 
            // hmMain
            // 
            this.hmMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.hmMain.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement1,
            this.accordionControlElement5,
            this.aceExit});
            this.hmMain.Location = new System.Drawing.Point(0, 30);
            this.hmMain.Name = "hmMain";
            this.hmMain.OptionsMinimizing.NormalWidth = 260;
            this.hmMain.RootDisplayMode = DevExpress.XtraBars.Navigation.AccordionControlRootDisplayMode.Footer;
            this.hmMain.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.hmMain.Size = new System.Drawing.Size(260, 564);
            this.hmMain.TabIndex = 1;
            this.hmMain.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement2,
            this.accordionControlElement3,
            this.accordionControlElement9});
            this.accordionControlElement1.Expanded = true;
            this.accordionControlElement1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement1.ImageOptions.Image")));
            this.accordionControlElement1.ImageOptions.ImageLayoutMode = DevExpress.XtraBars.Navigation.ImageLayoutMode.Squeeze;
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Text = "Element1";
            // 
            // accordionControlElement2
            // 
            this.accordionControlElement2.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceDHLImportPreparation,
            this.aceDHLImport,
            this.acePLImport,
            this.aceBSImport,
            this.aceReptosImport,
            this.aceDataSync});
            this.accordionControlElement2.Expanded = true;
            this.accordionControlElement2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement2.ImageOptions.Image")));
            this.accordionControlElement2.Name = "accordionControlElement2";
            this.accordionControlElement2.Text = "Data";
            // 
            // aceDHLImportPreparation
            // 
            this.aceDHLImportPreparation.Name = "aceDHLImportPreparation";
            this.aceDHLImportPreparation.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceDHLImportPreparation.Text = "DHL Import Preparation";
            this.aceDHLImportPreparation.Click += new System.EventHandler(this.aceDHLImportPreparation_Click);
            // 
            // aceDHLImport
            // 
            this.aceDHLImport.Name = "aceDHLImport";
            this.aceDHLImport.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceDHLImport.Text = "Import DHL Data";
            this.aceDHLImport.Click += new System.EventHandler(this.aceDHLImport_Click);
            // 
            // acePLImport
            // 
            this.acePLImport.Name = "acePLImport";
            this.acePLImport.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.acePLImport.Text = "Import Myob P&L";
            this.acePLImport.Click += new System.EventHandler(this.acePLImport_Click);
            // 
            // aceBSImport
            // 
            this.aceBSImport.Name = "aceBSImport";
            this.aceBSImport.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceBSImport.Text = "Import Myob Balance Sheet";
            this.aceBSImport.Click += new System.EventHandler(this.aceBSImport_Click);
            // 
            // aceDataSync
            // 
            this.aceDataSync.Name = "aceDataSync";
            this.aceDataSync.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceDataSync.Text = "Cloud Sync";
            this.aceDataSync.Click += new System.EventHandler(this.aceDataSync_Click);
            // 
            // accordionControlElement3
            // 
            this.accordionControlElement3.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceBoardReport});
            this.accordionControlElement3.Expanded = true;
            this.accordionControlElement3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement3.ImageOptions.Image")));
            this.accordionControlElement3.Name = "accordionControlElement3";
            this.accordionControlElement3.Text = "Reports";
            // 
            // aceBoardReport
            // 
            this.aceBoardReport.Name = "aceBoardReport";
            this.aceBoardReport.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceBoardReport.Text = "Export Board Pack";
            this.aceBoardReport.Click += new System.EventHandler(this.aceBoardReport_Click);
            // 
            // accordionControlElement9
            // 
            this.accordionControlElement9.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceWelcome});
            this.accordionControlElement9.Expanded = true;
            this.accordionControlElement9.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement9.ImageOptions.Image")));
            this.accordionControlElement9.Name = "accordionControlElement9";
            this.accordionControlElement9.Text = "About";
            // 
            // aceWelcome
            // 
            this.aceWelcome.Name = "aceWelcome";
            this.aceWelcome.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceWelcome.Text = "Not logged in";
            this.aceWelcome.Click += new System.EventHandler(this.aceWelcome_Click);
            // 
            // accordionControlElement5
            // 
            this.accordionControlElement5.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement7,
            this.accordionControlElement10,
            this.accordionControlElement8,
            this.acAdmin});
            this.accordionControlElement5.Expanded = true;
            this.accordionControlElement5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement5.ImageOptions.Image")));
            this.accordionControlElement5.ImageOptions.ImageLayoutMode = DevExpress.XtraBars.Navigation.ImageLayoutMode.Squeeze;
            this.accordionControlElement5.Name = "accordionControlElement5";
            this.accordionControlElement5.Text = "Element5";
            // 
            // accordionControlElement7
            // 
            this.accordionControlElement7.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceMyobCardIds});
            this.accordionControlElement7.Expanded = true;
            this.accordionControlElement7.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement7.ImageOptions.Image")));
            this.accordionControlElement7.Name = "accordionControlElement7";
            this.accordionControlElement7.Text = "Master Data";
            // 
            // aceMyobCardIds
            // 
            this.aceMyobCardIds.Name = "aceMyobCardIds";
            this.aceMyobCardIds.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceMyobCardIds.Text = "DHL Account > Myob CardId";
            this.aceMyobCardIds.Click += new System.EventHandler(this.aceMyobCardIds_Click);
            // 
            // accordionControlElement10
            // 
            this.accordionControlElement10.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.acePLAccountStructure,
            this.aceBSAccountStructure});
            this.accordionControlElement10.Expanded = true;
            this.accordionControlElement10.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement10.ImageOptions.Image")));
            this.accordionControlElement10.Name = "accordionControlElement10";
            this.accordionControlElement10.Text = "Structures";
            // 
            // acePLAccountStructure
            // 
            this.acePLAccountStructure.Name = "acePLAccountStructure";
            this.acePLAccountStructure.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.acePLAccountStructure.Text = "Manage P&L Account Structure";
            this.acePLAccountStructure.Click += new System.EventHandler(this.acePLAccountStructure_Click);
            // 
            // aceBSAccountStructure
            // 
            this.aceBSAccountStructure.Name = "aceBSAccountStructure";
            this.aceBSAccountStructure.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceBSAccountStructure.Text = "Manage Balance Sheet Account Structure";
            this.aceBSAccountStructure.Click += new System.EventHandler(this.aceBSAccountStructure_Click);
            // 
            // accordionControlElement8
            // 
            this.accordionControlElement8.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceReportStructure,
            this.aceReportStructureGroups,
            this.aceReportErrors});
            this.accordionControlElement8.Expanded = true;
            this.accordionControlElement8.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement8.ImageOptions.Image")));
            this.accordionControlElement8.Name = "accordionControlElement8";
            this.accordionControlElement8.Text = "Reports";
            // 
            // aceReportStructure
            // 
            this.aceReportStructure.Name = "aceReportStructure";
            this.aceReportStructure.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceReportStructure.Text = "Manage Report Structures";
            this.aceReportStructure.Click += new System.EventHandler(this.aceReportStructure_Click);
            // 
            // aceReportStructureGroups
            // 
            this.aceReportStructureGroups.Name = "aceReportStructureGroups";
            this.aceReportStructureGroups.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceReportStructureGroups.Text = "Manage Report Structures (Groups)";
            this.aceReportStructureGroups.Click += new System.EventHandler(this.aceReportStructureGroups_Click);
            // 
            // aceReportErrors
            // 
            this.aceReportErrors.Name = "aceReportErrors";
            this.aceReportErrors.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceReportErrors.Text = "Check Report Errors";
            this.aceReportErrors.Click += new System.EventHandler(this.aceReportErrors_Click);
            // 
            // acAdmin
            // 
            this.acAdmin.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceUsers});
            this.acAdmin.Expanded = true;
            this.acAdmin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("acAdmin.ImageOptions.Image")));
            this.acAdmin.Name = "acAdmin";
            this.acAdmin.Text = "Administration";
            // 
            // aceUsers
            // 
            this.aceUsers.Name = "aceUsers";
            this.aceUsers.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceUsers.Text = "Users";
            this.aceUsers.Click += new System.EventHandler(this.aceUsers_Click);
            // 
            // aceExit
            // 
            this.aceExit.ControlFooterAlignment = DevExpress.XtraBars.Navigation.AccordionItemFooterAlignment.Far;
            this.aceExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("aceExit.ImageOptions.Image")));
            this.aceExit.Name = "aceExit";
            this.aceExit.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            toolTipTitleItem1.Text = "Exit";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Exit the application";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.aceExit.SuperTip = superToolTip1;
            this.aceExit.Text = "Element14";
            this.aceExit.Click += new System.EventHandler(this.aceExit_Click);
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1062, 30);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            this.fluentDesignFormControl1.Text = "Myob Assistant";
            // 
            // accordionControlElement4
            // 
            this.accordionControlElement4.Name = "accordionControlElement4";
            this.accordionControlElement4.Text = "Settings";
            // 
            // accordionControlElement6
            // 
            this.accordionControlElement6.Name = "accordionControlElement6";
            this.accordionControlElement6.Text = "Element6";
            // 
            // aceReptosImport
            // 
            this.aceReptosImport.Name = "aceReptosImport";
            this.aceReptosImport.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceReptosImport.Text = "Import Reptos Claims";
            this.aceReptosImport.Click += new System.EventHandler(this.AceReptosImport_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 594);
            this.ControlContainer = this.cntMain;
            this.Controls.Add(this.cntMain);
            this.Controls.Add(this.hmMain);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.NavigationControl = this.hmMain;
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Myob Assistant";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.hmMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer cntMain;
        private DevExpress.XtraBars.Navigation.AccordionControl hmMain;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement3;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement4;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement5;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement6;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceDHLImport;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acePLImport;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceBSImport;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceBoardReport;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement10;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acePLAccountStructure;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceExit;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceReportStructure;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement8;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceBSAccountStructure;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceDataSync;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement7;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceMyobCardIds;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acAdmin;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceUsers;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceDHLImportPreparation;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement9;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceWelcome;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceReportErrors;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceReportStructureGroups;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceReptosImport;
    }
}