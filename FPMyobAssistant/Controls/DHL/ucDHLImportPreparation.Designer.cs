namespace FPMyobAssistant
{
    partial class ucDHLImportPreparation
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDHLImportPreparation));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.mADHLMasterItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mADHLExcludedItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.beDHLFilename = new DevExpress.XtraEditors.ButtonEdit();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.eucExcludedAccountNumbers = new FPMyobAssistant.eucExcludedAccountNumbers();
            this.gcIncluded = new DevExpress.XtraGrid.GridControl();
            this.gvIncluded = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIsIncluded = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShipToName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkInclude = new DevExpress.XtraEditors.CheckEdit();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblOrderNumber = new DevExpress.XtraEditors.LabelControl();
            this.lblIncludedTotal = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.beExportFilename = new DevExpress.XtraEditors.ButtonEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvIncludedDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPDE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValue = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.mADHLMasterItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mADHLExcludedItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beDHLFilename.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcIncluded)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvIncluded)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInclude.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beExportFilename.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvIncludedDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // mADHLMasterItemBindingSource
            // 
            this.mADHLMasterItemBindingSource.DataSource = typeof(FPMyobAssistant.MADHLMasterItem);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(32, 40);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 13);
            this.labelControl1.TabIndex = 22;
            this.labelControl1.Text = "DHL Data File:";
            // 
            // beDHLFilename
            // 
            this.beDHLFilename.Location = new System.Drawing.Point(110, 37);
            this.beDHLFilename.Name = "beDHLFilename";
            this.beDHLFilename.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beDHLFilename.Properties.Appearance.Options.UseFont = true;
            this.beDHLFilename.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beDHLFilename.Properties.ReadOnly = true;
            this.beDHLFilename.Size = new System.Drawing.Size(869, 20);
            this.beDHLFilename.TabIndex = 21;
            this.beDHLFilename.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beDHLFilename_ButtonClick);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(985, 34);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 25;
            this.btnImport.Text = "Import";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // eucExcludedAccountNumbers
            // 
            this.eucExcludedAccountNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eucExcludedAccountNumbers.ExcludedAccounts = ((System.Collections.Generic.List<string>)(resources.GetObject("eucExcludedAccountNumbers.ExcludedAccounts")));
            this.eucExcludedAccountNumbers.Location = new System.Drawing.Point(1153, 145);
            this.eucExcludedAccountNumbers.Name = "eucExcludedAccountNumbers";
            this.eucExcludedAccountNumbers.Size = new System.Drawing.Size(206, 428);
            this.eucExcludedAccountNumbers.TabIndex = 28;
            // 
            // gcIncluded
            // 
            this.gcIncluded.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcIncluded.DataSource = this.mADHLMasterItemBindingSource;
            gridLevelNode1.LevelTemplate = this.gvIncludedDetails;
            gridLevelNode1.RelationName = "Details";
            this.gcIncluded.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gcIncluded.Location = new System.Drawing.Point(32, 91);
            this.gcIncluded.MainView = this.gvIncluded;
            this.gcIncluded.Name = "gcIncluded";
            this.gcIncluded.Size = new System.Drawing.Size(1101, 449);
            this.gcIncluded.TabIndex = 0;
            this.gcIncluded.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvIncluded,
            this.gvIncludedDetails});
            // 
            // gvIncluded
            // 
            this.gvIncluded.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIsIncluded,
            this.colInvoiceDate,
            this.colOrderNumber,
            this.colCustomerNumber,
            this.colCustomerName,
            this.colShipToName,
            this.colInvoiceValue});
            this.gvIncluded.GridControl = this.gcIncluded;
            this.gvIncluded.Name = "gvIncluded";
            this.gvIncluded.OptionsBehavior.Editable = false;
            this.gvIncluded.OptionsBehavior.ReadOnly = true;
            this.gvIncluded.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Embedded;
            this.gvIncluded.OptionsDetail.ShowDetailTabs = false;
            this.gvIncluded.OptionsView.ShowGroupPanel = false;
            this.gvIncluded.OptionsView.ShowIndicator = false;
            this.gvIncluded.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colIsIncluded, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colInvoiceDate, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvIncluded.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvIncluded_FocusedRowChanged);
            // 
            // colIsIncluded
            // 
            this.colIsIncluded.Caption = "Is Included";
            this.colIsIncluded.FieldName = "IsIncluded";
            this.colIsIncluded.Name = "colIsIncluded";
            this.colIsIncluded.Visible = true;
            this.colIsIncluded.VisibleIndex = 0;
            // 
            // colInvoiceDate
            // 
            this.colInvoiceDate.FieldName = "InvoiceDate";
            this.colInvoiceDate.Name = "colInvoiceDate";
            this.colInvoiceDate.OptionsColumn.ReadOnly = true;
            this.colInvoiceDate.Visible = true;
            this.colInvoiceDate.VisibleIndex = 1;
            // 
            // colOrderNumber
            // 
            this.colOrderNumber.FieldName = "OrderNumber";
            this.colOrderNumber.Name = "colOrderNumber";
            this.colOrderNumber.OptionsColumn.ReadOnly = true;
            this.colOrderNumber.Visible = true;
            this.colOrderNumber.VisibleIndex = 2;
            // 
            // colCustomerNumber
            // 
            this.colCustomerNumber.FieldName = "CustomerNumber";
            this.colCustomerNumber.Name = "colCustomerNumber";
            this.colCustomerNumber.OptionsColumn.ReadOnly = true;
            this.colCustomerNumber.Visible = true;
            this.colCustomerNumber.VisibleIndex = 3;
            // 
            // colCustomerName
            // 
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.OptionsColumn.ReadOnly = true;
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 4;
            // 
            // colShipToName
            // 
            this.colShipToName.FieldName = "ShipToName";
            this.colShipToName.Name = "colShipToName";
            this.colShipToName.OptionsColumn.ReadOnly = true;
            this.colShipToName.Visible = true;
            this.colShipToName.VisibleIndex = 5;
            // 
            // colInvoiceValue
            // 
            this.colInvoiceValue.Caption = "Value";
            this.colInvoiceValue.DisplayFormat.FormatString = "c2";
            this.colInvoiceValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colInvoiceValue.FieldName = "InvoiceValue";
            this.colInvoiceValue.Name = "colInvoiceValue";
            this.colInvoiceValue.OptionsColumn.ReadOnly = true;
            this.colInvoiceValue.Visible = true;
            this.colInvoiceValue.VisibleIndex = 6;
            // 
            // chkInclude
            // 
            this.chkInclude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkInclude.Location = new System.Drawing.Point(1153, 112);
            this.chkInclude.Name = "chkInclude";
            this.chkInclude.Properties.Caption = "Is Included";
            this.chkInclude.Size = new System.Drawing.Size(85, 20);
            this.chkInclude.TabIndex = 29;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(1244, 110);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 30;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(1153, 91);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(32, 13);
            this.labelControl2.TabIndex = 31;
            this.labelControl2.Text = "Order:";
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrderNumber.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNumber.Appearance.Options.UseFont = true;
            this.lblOrderNumber.Location = new System.Drawing.Point(1191, 91);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(83, 13);
            this.lblOrderNumber.TabIndex = 32;
            this.lblOrderNumber.Text = "lblOrderNumber";
            // 
            // lblIncludedTotal
            // 
            this.lblIncludedTotal.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncludedTotal.Appearance.Options.UseFont = true;
            this.lblIncludedTotal.Location = new System.Drawing.Point(113, 72);
            this.lblIncludedTotal.Name = "lblIncludedTotal";
            this.lblIncludedTotal.Size = new System.Drawing.Size(27, 13);
            this.lblIncludedTotal.TabIndex = 34;
            this.lblIncludedTotal.Text = "$0.00";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(32, 72);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(75, 13);
            this.labelControl4.TabIndex = 33;
            this.labelControl4.Text = "Included Total:";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(1058, 544);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 35;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(32, 549);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(87, 13);
            this.labelControl3.TabIndex = 37;
            this.labelControl3.Text = "Export Selection:";
            // 
            // beExportFilename
            // 
            this.beExportFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.beExportFilename.Location = new System.Drawing.Point(125, 546);
            this.beExportFilename.Name = "beExportFilename";
            this.beExportFilename.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beExportFilename.Properties.Appearance.Options.UseFont = true;
            this.beExportFilename.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beExportFilename.Properties.ReadOnly = true;
            this.beExportFilename.Size = new System.Drawing.Size(927, 20);
            this.beExportFilename.TabIndex = 36;
            this.beExportFilename.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beExportFilename_ButtonClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "PDE";
            this.gridColumn1.FieldName = "Details.PDE";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Product";
            this.gridColumn2.FieldName = "Details.Product";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Quantity";
            this.gridColumn3.DisplayFormat.FormatString = "n0";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.FieldName = "Details.Quantity";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Value";
            this.gridColumn4.DisplayFormat.FormatString = "c2";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "Details.Value";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gvIncludedDetails
            // 
            this.gvIncludedDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPDE,
            this.colProduct,
            this.colQuantity,
            this.colValue});
            this.gvIncludedDetails.GridControl = this.gcIncluded;
            this.gvIncludedDetails.Name = "gvIncludedDetails";
            this.gvIncludedDetails.OptionsDetail.ShowDetailTabs = false;
            this.gvIncludedDetails.OptionsView.ShowGroupPanel = false;
            this.gvIncludedDetails.OptionsView.ShowIndicator = false;
            // 
            // colPDE
            // 
            this.colPDE.FieldName = "PDE";
            this.colPDE.Name = "colPDE";
            this.colPDE.Visible = true;
            this.colPDE.VisibleIndex = 0;
            // 
            // colProduct
            // 
            this.colProduct.FieldName = "Product";
            this.colProduct.Name = "colProduct";
            this.colProduct.Visible = true;
            this.colProduct.VisibleIndex = 1;
            // 
            // colQuantity
            // 
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 2;
            // 
            // colValue
            // 
            this.colValue.DisplayFormat.FormatString = "C2";
            this.colValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colValue.FieldName = "Value";
            this.colValue.Name = "colValue";
            this.colValue.Visible = true;
            this.colValue.VisibleIndex = 3;
            // 
            // ucDHLImportPreparation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.beExportFilename);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblIncludedTotal);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.lblOrderNumber);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.chkInclude);
            this.Controls.Add(this.gcIncluded);
            this.Controls.Add(this.eucExcludedAccountNumbers);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.beDHLFilename);
            this.Name = "ucDHLImportPreparation";
            this.Size = new System.Drawing.Size(1385, 608);
            ((System.ComponentModel.ISupportInitialize)(this.mADHLMasterItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mADHLExcludedItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beDHLFilename.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcIncluded)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvIncluded)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInclude.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beExportFilename.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvIncludedDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ButtonEdit beDHLFilename;
        private DevExpress.XtraEditors.SimpleButton btnImport;
        private System.Windows.Forms.BindingSource mADHLMasterItemBindingSource;
        private System.Windows.Forms.BindingSource mADHLExcludedItemBindingSource;
        private eucExcludedAccountNumbers eucExcludedAccountNumbers;
        private DevExpress.XtraGrid.GridControl gcIncluded;
        private DevExpress.XtraGrid.Views.Grid.GridView gvIncluded;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceDate;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colShipToName;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceValue;
        private DevExpress.XtraGrid.Columns.GridColumn colIsIncluded;
        private DevExpress.XtraEditors.CheckEdit chkInclude;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblOrderNumber;
        private DevExpress.XtraEditors.LabelControl lblIncludedTotal;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ButtonEdit beExportFilename;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Views.Grid.GridView gvIncludedDetails;
        private DevExpress.XtraGrid.Columns.GridColumn colPDE;
        private DevExpress.XtraGrid.Columns.GridColumn colProduct;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colValue;
    }
}
