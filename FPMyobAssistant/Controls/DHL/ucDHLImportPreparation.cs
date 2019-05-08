using DevExpress.XtraGrid.Views.Grid;
using SangAdv.Common;
using SangAdv.Common.JSonExtensions;
using SangAdv.Common.PeriodExtensions;
using SangAdv.Common.UI;
using SangAdv.DevExpressUI;
using System;
using System.Windows.Forms;

namespace FPMyobAssistant
{
    public partial class ucDHLImportPreparation : ucTemplate
    {
        #region Variables

        private MADHLMaster mMaster = new MADHLMaster();
        private MABaseControls mBase;
        private string mSelectedOrderNumber = string.Empty;
        private string mPeriod = string.Empty;

        #endregion Variables

        #region Constructor

        public ucDHLImportPreparation()
        {
            InitializeComponent();
            mBase = new MABaseControls(this);
            mBase.SetTitle("DHL Import Preparation");

            eucExcludedAccountNumbers.AccountsChanged += AccountsChanged;
            eucExcludedAccountNumbers.ExcludedAccounts = mMaster.ExcludedAccounts;

            mADHLMasterItemBindingSource.DataSource = mMaster.Items;
            gvIncluded.OptionsView.BestFitMode = GridBestFitMode.Full;

            btnImport.Enabled = VerifyImport();
            lblOrderNumber.Text = string.Empty;

            beExportFilename.Enabled = false;
            btnExport.Enabled = false;
        }

        #endregion Constructor

        #region Methods

        private void AccountsChanged()
        {
            mMaster.SetExcludedAccounts(eucExcludedAccountNumbers.ExcludedAccounts);
            var tSetting = MADataAccess.LocalData.TLSSettingsItem();
            tSetting.ImportExclusionAccounts = eucExcludedAccountNumbers.ExcludedAccounts.SerializeObject();
            MADataAccess.LocalData.TLSSettingUpdate(tSetting);
            MADataAccess.DataSyncUpdate.Add(new SASyncDataItem { MainType = MAUpdateItem.Settings, SubType = "", Payload = string.Empty });
        }

        private bool VerifyImport()
        {
            if (beDHLFilename.Text.Trim() == string.Empty) return false;

            return true;
        }

        private void ReadFile()
        {
            gcIncluded.SuspendLayout();

            var ei = new SAExcelImport(beDHLFilename.Text.Trim(), true);

            if (ei.HasError)
            {
                AddMessage($"Error: Could not read file from disk. Original error: {ei.ErrorMessage}");
                return;
            }

            AddMessage($"Importing from: {beDHLFilename.Text.Trim()} ...");

            mPeriod = DateTime.Parse(ei.GetText(1, 29)).ToMonthPeriod();

            BuildMaster(ei);
            BuildDetail(ei);

            AddMessage("");

            gcIncluded.ResumeLayout();
        }

        private void BuildMaster(SAExcelImport ei)
        {
            mMaster.Clear();
            mMaster.LoadMasterExcludedOrders(mPeriod);

            DateTime? tInvoiceDate;
            for (var i = 1; i < 100000; i++)
            {
                var tIsIncluded = true;
                tInvoiceDate = null;

                //Check if we have reached the last line
                if (string.IsNullOrEmpty(ei.GetText(i, 6))) break;

                var tOrderNo = ei.GetText(i, 2);

                //If the order exists in master, break
                if (mMaster.Contains(tOrderNo)) continue;

                //Get variables
                var tCustomerNo = ei.GetText(i, 9);
                var tCustomerName = ei.GetText(i, 10);
                var tShipToName = ei.GetText(i, 12);

                //Check if the invoice date is blank. If blank, add to Check file
                if (string.IsNullOrEmpty(ei.GetText(i, 28))) tIsIncluded = false;

                if (tIsIncluded)
                {
                    tInvoiceDate = DateTime.Parse(ei.GetText(i, 28));

                    if (mMaster.IsExcludedOrder(tOrderNo)) tIsIncluded = false;
                    if (mMaster.IsExcludedAccount(tCustomerNo)) tIsIncluded = false;
                }

                mMaster.Add(new MADHLMasterItem
                {
                    OrderNumber = tOrderNo,
                    CustomerName = tCustomerName,
                    ShipToName = tShipToName,
                    CustomerNumber = tCustomerNo,
                    InvoiceDate = tInvoiceDate,
                    IsIncluded = tIsIncluded
                });
            }

            if (mMaster.ExclusionsChanged) mMaster.UpdateExclusions(mPeriod);
        }

        private void BuildDetail(SAExcelImport ei)
        {
            for (var i = 1; i < 100000; i++)
            {
                var tOrderNo = ei.GetText(i, 2);
                if (mMaster.Contains(tOrderNo))
                {
                    var tMaster = mMaster.Get(tOrderNo);

                    var tPDE = ei.GetText(i, 6);
                    var tProduct = ei.GetText(i, 7);

                    //Get the right quantity
                    var tUnits = 0;
                    if (string.IsNullOrEmpty(ei.GetText(i, 21))) tUnits = string.IsNullOrEmpty(ei.GetText(i, 22)) ? 0 : ei.GetValue<int>(i, 22);
                    else tUnits = ei.GetValue<int>(i, 21);

                    var ndi = new MADHLDetailItem
                    {
                        PDE = tPDE,
                        Product = tProduct,
                        Quantity = tUnits,
                        Value = (float)Math.Round((decimal)ei.GetValue<float>(i, 27), 2)
                    };

                    tMaster.Detail.Add(ndi);
                }
            }
        }

        private void AddMessage(string message)
        {
            mBase.SetMessage(message);
        }

        private string SelectedFile(MAFileType fileType, bool checkIfFileExists)
        {
            var fileName = MAFileSelection.SelectFile(fileType, checkIfFileExists);
            if (string.IsNullOrEmpty(fileName))
            {
                if (MAFileSelection.HasError) AddMessage(MAFileSelection.ErrorMessage);
                return string.Empty;
            }

            AddMessage($"{fileName} found");
            return fileName;
        }

        private void DisplayIncludedTotal()
        {
            lblIncludedTotal.Text = mMaster.IncludedInvoiceTotal.ToString("C");
            Application.DoEvents();
        }

        #endregion Methods

        #region Process UI

        private void beDHLFilename_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            beDHLFilename.Text = SelectedFile(MAFileType.XLSX, true);
            btnImport.Enabled = VerifyImport();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            mMaster.Clear();
            ReadFile();
            gvIncluded.TopRowIndex = 0;
            gvIncluded.FocusedRowHandle = 0;
            gvIncluded.BestFitColumns();
            DisplayIncludedTotal();
            beExportFilename.Enabled = true;
        }

        private void gvIncluded_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                chkInclude.Enabled = true;
                var a = gvIncluded.GetFocusedRowCellValue("IsIncluded");
                chkInclude.Checked = (bool)a;
                mSelectedOrderNumber = gvIncluded.GetFocusedRowCellValue("OrderNumber").ToString();
                lblOrderNumber.Text = mSelectedOrderNumber;
            }
            catch
            {
                chkInclude.Enabled = false;
                lblOrderNumber.Text = string.Empty;
                mSelectedOrderNumber = string.Empty;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var topRow = gvIncluded.TopRowIndex;

            if (string.IsNullOrEmpty(mSelectedOrderNumber)) return;
            var tData = mMaster.Get(mSelectedOrderNumber);
            tData.IsIncluded = chkInclude.Checked;

            mMaster.UpdateExcludedOrders(mPeriod, mSelectedOrderNumber, tData.IsIncluded);

            gvIncluded.TopRowIndex = topRow;

            DisplayIncludedTotal();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            gcIncluded.ExportToXlsx(beExportFilename.Text);
        }

        private void beExportFilename_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            btnExport.Enabled = false;
            beExportFilename.Text = string.Empty;
            var tFilename = SADialogs.Dialogs.SaveDataFile(true, true, true);
            if (string.IsNullOrEmpty(tFilename)) return;
            beExportFilename.Text = tFilename;
            btnExport.Enabled = true;
        }

        #endregion Process UI
    }
}