namespace FPMyobAssistant.Controls.Reptos
{
    partial class ucReptosImport
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
            this.LabelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dtImport = new DevExpress.XtraEditors.DateEdit();
            this.btnChooseFiles = new DevExpress.XtraEditors.SimpleButton();
            this.btnClearList = new DevExpress.XtraEditors.SimpleButton();
            this.lstImport = new DevExpress.XtraEditors.ListBoxControl();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.lstMessage = new DevExpress.XtraEditors.ListBoxControl();
            this.btnExportStructure = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.beStructureFilename = new DevExpress.XtraEditors.ButtonEdit();
            this.beMYOBFilename = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnCreateMyobReptosFile = new DevExpress.XtraEditors.SimpleButton();
            this.btnProcess = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.beImportFolder = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.icbDistributor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtImport.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtImport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beStructureFilename.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beMYOBFilename.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beImportFolder.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelControl1
            // 
            this.LabelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelControl1.Appearance.Options.UseFont = true;
            this.LabelControl1.Location = new System.Drawing.Point(34, 59);
            this.LabelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LabelControl1.Name = "LabelControl1";
            this.LabelControl1.Size = new System.Drawing.Size(79, 17);
            this.LabelControl1.TabIndex = 128;
            this.LabelControl1.Text = "Distributor:";
            // 
            // icbDistributor
            // 
            this.icbDistributor.Location = new System.Drawing.Point(34, 82);
            this.icbDistributor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.icbDistributor.Name = "icbDistributor";
            this.icbDistributor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbDistributor.Size = new System.Drawing.Size(362, 22);
            this.icbDistributor.TabIndex = 127;
            this.icbDistributor.SelectedIndexChanged += new System.EventHandler(this.IcbDistributor_SelectedIndexChanged);
            // 
            // LabelControl4
            // 
            this.LabelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelControl4.Appearance.Options.UseFont = true;
            this.LabelControl4.Location = new System.Drawing.Point(750, 59);
            this.LabelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LabelControl4.Name = "LabelControl4";
            this.LabelControl4.Size = new System.Drawing.Size(91, 17);
            this.LabelControl4.TabIndex = 126;
            this.LabelControl4.Text = "Import Date:";
            // 
            // dtImport
            // 
            this.dtImport.EditValue = null;
            this.dtImport.Location = new System.Drawing.Point(750, 82);
            this.dtImport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtImport.Name = "dtImport";
            this.dtImport.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtImport.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtImport.Size = new System.Drawing.Size(142, 22);
            this.dtImport.TabIndex = 125;
            this.dtImport.DateTimeChanged += new System.EventHandler(this.DtImport_DateTimeChanged);
            // 
            // btnChooseFiles
            // 
            this.btnChooseFiles.Location = new System.Drawing.Point(34, 172);
            this.btnChooseFiles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChooseFiles.Name = "btnChooseFiles";
            this.btnChooseFiles.Size = new System.Drawing.Size(150, 28);
            this.btnChooseFiles.TabIndex = 124;
            this.btnChooseFiles.Text = "Choose Raw Data Files";
            this.btnChooseFiles.Click += new System.EventHandler(this.BtnChooseFiles_Click);
            // 
            // btnClearList
            // 
            this.btnClearList.Location = new System.Drawing.Point(748, 187);
            this.btnClearList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(143, 28);
            this.btnClearList.TabIndex = 123;
            this.btnClearList.Text = "Clear Import List";
            this.btnClearList.Click += new System.EventHandler(this.BtnClearList_Click);
            // 
            // lstImport
            // 
            this.lstImport.Location = new System.Drawing.Point(34, 223);
            this.lstImport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstImport.Name = "lstImport";
            this.lstImport.Size = new System.Drawing.Size(857, 286);
            this.lstImport.TabIndex = 122;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(34, 516);
            this.btnImport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(150, 28);
            this.btnImport.TabIndex = 121;
            this.btnImport.Text = "Import Reptos";
            this.btnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // lstMessage
            // 
            this.lstMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstMessage.Location = new System.Drawing.Point(34, 663);
            this.lstMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstMessage.Name = "lstMessage";
            this.lstMessage.Size = new System.Drawing.Size(857, 210);
            this.lstMessage.TabIndex = 129;
            // 
            // btnExportStructure
            // 
            this.btnExportStructure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportStructure.Location = new System.Drawing.Point(822, 935);
            this.btnExportStructure.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportStructure.Name = "btnExportStructure";
            this.btnExportStructure.Size = new System.Drawing.Size(70, 28);
            this.btnExportStructure.TabIndex = 132;
            this.btnExportStructure.Text = "Export";
            this.btnExportStructure.Click += new System.EventHandler(this.BtnExportStructure_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(34, 880);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(229, 19);
            this.labelControl2.TabIndex = 131;
            this.labelControl2.Text = "Reptos Product/account Mapping:";
            // 
            // beStructureFilename
            // 
            this.beStructureFilename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.beStructureFilename.Location = new System.Drawing.Point(34, 903);
            this.beStructureFilename.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.beStructureFilename.Name = "beStructureFilename";
            this.beStructureFilename.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beStructureFilename.Properties.Appearance.Options.UseFont = true;
            this.beStructureFilename.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beStructureFilename.Properties.ReadOnly = true;
            this.beStructureFilename.Size = new System.Drawing.Size(857, 26);
            this.beStructureFilename.TabIndex = 130;
            this.beStructureFilename.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.BeStructureFilename_ButtonClick);
            // 
            // beMYOBFilename
            // 
            this.beMYOBFilename.Location = new System.Drawing.Point(34, 581);
            this.beMYOBFilename.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.beMYOBFilename.Name = "beMYOBFilename";
            this.beMYOBFilename.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beMYOBFilename.Properties.Appearance.Options.UseFont = true;
            this.beMYOBFilename.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beMYOBFilename.Properties.ReadOnly = true;
            this.beMYOBFilename.Size = new System.Drawing.Size(859, 26);
            this.beMYOBFilename.TabIndex = 133;
            this.beMYOBFilename.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.BeMYOBFilename_ButtonClick);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(34, 558);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(162, 19);
            this.labelControl3.TabIndex = 134;
            this.labelControl3.Text = "MYOB Reptos Import File:";
            // 
            // btnCreateMyobReptosFile
            // 
            this.btnCreateMyobReptosFile.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateMyobReptosFile.Appearance.Options.UseFont = true;
            this.btnCreateMyobReptosFile.Location = new System.Drawing.Point(805, 613);
            this.btnCreateMyobReptosFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCreateMyobReptosFile.Name = "btnCreateMyobReptosFile";
            this.btnCreateMyobReptosFile.Size = new System.Drawing.Size(87, 28);
            this.btnCreateMyobReptosFile.TabIndex = 135;
            this.btnCreateMyobReptosFile.Text = "Create File";
            this.btnCreateMyobReptosFile.Click += new System.EventHandler(this.BtnCreateMyobReptosFile_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(797, 126);
            this.btnProcess.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(94, 30);
            this.btnProcess.TabIndex = 138;
            this.btnProcess.Text = "Process";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(34, 132);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(83, 16);
            this.labelControl5.TabIndex = 137;
            this.labelControl5.Text = "Import Folder:";
            // 
            // beImportFolder
            // 
            this.beImportFolder.Location = new System.Drawing.Point(123, 130);
            this.beImportFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.beImportFolder.Name = "beImportFolder";
            this.beImportFolder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beImportFolder.Size = new System.Drawing.Size(655, 22);
            this.beImportFolder.TabIndex = 136;
            this.beImportFolder.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beImportFolder_ButtonClick);
            this.beImportFolder.TextChanged += new System.EventHandler(this.beImportFolder_TextChanged);
            // 
            // ucReptosImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.beImportFolder);
            this.Controls.Add(this.btnCreateMyobReptosFile);
            this.Controls.Add(this.beMYOBFilename);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.btnExportStructure);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.beStructureFilename);
            this.Controls.Add(this.lstMessage);
            this.Controls.Add(this.LabelControl1);
            this.Controls.Add(this.icbDistributor);
            this.Controls.Add(this.LabelControl4);
            this.Controls.Add(this.dtImport);
            this.Controls.Add(this.btnChooseFiles);
            this.Controls.Add(this.btnClearList);
            this.Controls.Add(this.lstImport);
            this.Controls.Add(this.btnImport);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucReptosImport";
            this.Size = new System.Drawing.Size(1268, 997);
            ((System.ComponentModel.ISupportInitialize)(this.icbDistributor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtImport.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtImport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beStructureFilename.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beMYOBFilename.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beImportFolder.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal DevExpress.XtraEditors.LabelControl LabelControl1;
        internal DevExpress.XtraEditors.ImageComboBoxEdit icbDistributor;
        internal DevExpress.XtraEditors.LabelControl LabelControl4;
        internal DevExpress.XtraEditors.DateEdit dtImport;
        internal DevExpress.XtraEditors.SimpleButton btnChooseFiles;
        internal DevExpress.XtraEditors.SimpleButton btnClearList;
        internal DevExpress.XtraEditors.ListBoxControl lstImport;
        internal DevExpress.XtraEditors.SimpleButton btnImport;
        internal DevExpress.XtraEditors.ListBoxControl lstMessage;
        private DevExpress.XtraEditors.SimpleButton btnExportStructure;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ButtonEdit beStructureFilename;
        private DevExpress.XtraEditors.ButtonEdit beMYOBFilename;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnCreateMyobReptosFile;
        private DevExpress.XtraEditors.SimpleButton btnProcess;
        internal DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ButtonEdit beImportFolder;
    }
}
