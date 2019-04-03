using LocalModelContext;
using SangAdv.Common;
using SangAdv.Common.JSonExtensions;
using SangAdv.Common.ListExtensions;
using SangAdv.Common.ObjectExtensions;
using SangAdv.Common.PeriodExtensions;
using SangAdv.Common.StringExtensions;
using SangAdv.DevExpressUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FPMyobAssistant
{
    public partial class ucDHLImport : ucTemplate
    {
        #region Variables

        private const int SummaryPage = 0;
        private const int DetailPage = 1;

        private FPDHLToMyobTXTItemSales mConversion;
        private bool mHasError = false;
        private MABaseControls mBase;
        private string mPeriod = string.Empty;
        private SAStringList mExcludedOrders = new SAStringList();

        private OrderSummary mSummaryExcluded = new OrderSummary();
        private OrderSummary mSummaryIncluded = new OrderSummary();

        #endregion Variables

        #region Constructor

        public ucDHLImport()
        {
            InitializeComponent();
            mBase = new MABaseControls(this);
            mBase.SetTitle("Myob-DHL Import");

            deStartDate.DateTime = DateTime.Now;
            btnImport.Enabled = VerifyImport();

            chkUseExclusions.Visible = false;
            chkUseExclusions.Checked = false;
        }

        #endregion Constructor

        #region Private Methods

        private string SelectedFile(MAFileType fileType, bool checkIfFileExists)
        {
            lstMessages.Items.Clear();

            var fileName = MAFileSelection.SelectFile(fileType, checkIfFileExists);
            if (string.IsNullOrEmpty(fileName))
            {
                if (MAFileSelection.HasError) AddMessage(MAFileSelection.ErrorMessage);
                return string.Empty;
            }

            lstMessages.Items.Add($"{fileName} found");
            return fileName;
        }

        private bool VerifyImport()
        {
            if (beDHLFilename.Text.Trim() == string.Empty) return false;
            if (beMYOBFilename.Text.Trim() == string.Empty) return false;
            if (beCheckFilename.Text.Trim() == string.Empty) return false;
            return true;
        }

        private void SaveFile()
        {
            AddMessage(mConversion.Save(beMYOBFilename.Text));
        }

        private void ReadFile()
        {
            float tTotalValue = 0;

            lstMessages.Items.Clear();
            mHasError = false;
            var tCheckRowCounter = 1;

            mSummaryIncluded.Items.Clear();
            mSummaryExcluded.Items.Clear();

            var ei = new SAExcelImport(beDHLFilename.Text.Trim(), true);

            var ee = new SAExcelReport(beCheckFilename.Text.Trim(), false, false);

            //Prepare excel export pages
            ee.AddWorkSheet("Summary");
            ee.AddWorkSheet("Excluded Detail");

            if (ei.HasError)
            {
                AddMessage($"Error: Could not read file from disk. Original error: {ei.ErrorMessage}");
                mHasError = true;
                return;
            }

            if (ee.HasError)
            {
                AddMessage($"Error: Could not open file from disk. Original error: {ee.ErrorMessage}");
                mHasError = true;
                return;
            }

            AddMessage($"Importing from: {beDHLFilename.Text.Trim()} ...");

            //Add the DHL Headings to the excel export
            for (var i = 0; i < 44; i++) ee.AddText(DetailPage, 0, i, ei.GetText(0, i));

            //Read the line items
            for (var i = 1; i < 100000; i++)
            {
                var tInclude = true;

                //Check if we have reached the last line
                if (string.IsNullOrEmpty(ei.GetText(i, 6))) break;

                //Check for exclusions if selected
                var tOrderNo = ei.GetText(i, 2);
                var tInvoiceNumber = CorrectedInvoiceNumber(ei.GetText(i, 32));
                var tValue = (float)Math.Round(ei.GetValue<float>(i, 27), 2);

                if (chkUseExclusions.Checked)
                {
                    if (mExcludedOrders.Contains(tOrderNo))
                    {
                        tInclude = false;
                        for (var j = 0; j < 44; j++) ee.AddText(DetailPage, tCheckRowCounter, j, ei.GetText(i, j));
                        tCheckRowCounter++;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(ei.GetText(i, 28)))
                    {
                        tInclude = false;
                        mExcludedOrders.Add(tOrderNo);
                        for (var j = 0; j < 44; j++) ee.AddText(0, tCheckRowCounter, j, ei.GetText(i, j));
                        tCheckRowCounter++;
                    }
                }

                //Check if the invoice date is blank. If blank, add to Check file
                var tCustomerName = ei.GetText(i, 10);
                if (tInclude)
                {
                    mSummaryIncluded.Add(new OrderSummaryItem { CustomerName = tCustomerName, InvoiceNo = tInvoiceNumber, OrderNo = tOrderNo, Value = tValue });
                    tTotalValue += tValue;
                    //Get the invoice date
                    var tDate = ei.GetText(i, 28);
                    var tInvoiceDate = DateTime.Parse(tDate);

                    if (tInvoiceDate.ToMonthPeriod() != mPeriod)
                    {
                        AddMessage($"The imported line's date {tInvoiceDate.ToShortDateString()} does not match expected period {mPeriod}");
                        return;
                    }

                    if (string.Compare(tInvoiceDate.ToString("yyyyMMdd"), deStartDate.DateTime.ToString("yyyyMMdd"), StringComparison.Ordinal) >= 0)
                    {
                        //Get the right quantity
                        var tUnits = 0;
                        if (string.IsNullOrEmpty(ei.GetText(i, 21))) tUnits = string.IsNullOrEmpty(ei.GetText(i, 22)) ? 0 : ei.GetValue<int>(i, 22);
                        else tUnits = ei.GetValue<int>(i, 21);

                        var tCustomerNo = ei.GetText(i, 9);
                        var tPDE = ei.GetText(i, 6);
                        var tCustPONo = ei.GetText(i, 1);
                        var tPrice = ei.GetValue<float>(i, 24);

                        var tMYOBCardId = MYOBCardId(tCustomerNo, ei.GetText(i, 10));
                        if (mHasError) return;

                        mConversion.Add(new FPMyobSalesItem()
                        {
                            CustomerNumber = tMYOBCardId,
                            CustomerPO = tCustPONo,
                            ItemCode = tPDE,
                            Quantity = tUnits,
                            Price = tPrice,
                            ItemDescription = ei.GetText(i, 7),
                            InvoiceNumber = CorrectedInvoiceNumber(tInvoiceNumber),
                            InvoiceDate = FormattedDate(tInvoiceDate)
                        });
                    }
                }
                else mSummaryExcluded.Add(new OrderSummaryItem { CustomerName = tCustomerName, InvoiceNo = tInvoiceNumber, OrderNo = tOrderNo, Value = tValue });
            }

            //Prepare the summary page
            prepareSummaryPage(ee, tTotalValue);

            //Save the check file
            ee.Save(0);
            AddMessage($"Checked. Saving to {beCheckFilename.Text} ...");
        }

        private void prepareSummaryPage(SAExcelReport report, float totalValue)
        {
            //Find duplicates
            List<string> duplicates = new List<string>();

            foreach (var item in mSummaryIncluded.Items)
            {
                var dups = mSummaryIncluded.Items.Where(x => x.InvoiceNo == item.InvoiceNo);
                if (dups.Count() > 1) duplicates.AddUnique(item.InvoiceNo);
            }

            //Add Summary Items
            var rowCounter = 3;

            report.AddText(SummaryPage, rowCounter, 0, "Period", true);
            report.AddText(SummaryPage, rowCounter++, 1, mPeriod);

            rowCounter++;

            //Add Included
            var tInvoiceCount = mSummaryIncluded.Items.Select(x => x.InvoiceNo).Distinct().Count();
            var tOrderCount = mSummaryIncluded.Items.Select(x => x.OrderNo).Distinct().Count();

            report.AddText(SummaryPage, rowCounter, 0, "Included", true);
            report.AddText(SummaryPage, rowCounter++, 1, $"{tInvoiceCount} invoices ({tOrderCount} orders)");
            report.AddText(SummaryPage, rowCounter, 0, "Duplicate Invoices Found:", true);
            report.AddText(SummaryPage, rowCounter++, 1, $"{duplicates.Count}");

            foreach (var item in mSummaryIncluded.Items)
            {
                report.AddText(SummaryPage, rowCounter, 0, item.OrderNo);
                report.AddText(SummaryPage, rowCounter, 1, item.InvoiceNo);

                if (duplicates.Contains(item.InvoiceNo))
                {
                    report.SetBlockBackColour(SummaryPage, rowCounter, 1, rowCounter, 1, Color.Red);
                    report.SetBlockFontDetails(SummaryPage, rowCounter, 1, rowCounter, 1, Color.Silver);
                }

                report.AddText(SummaryPage, rowCounter, 2, item.CustomerName);
                report.AddText(SummaryPage, rowCounter++, 3, item.Value.ToString("C2"));
            }

            report.AddText(SummaryPage, rowCounter, 0, "Total (Incl GST)", true);
            report.AddText(SummaryPage, rowCounter++, 3, totalValue.ToString("C2"), true);

            rowCounter++;

            //Add Excluded
            tInvoiceCount = mSummaryExcluded.Items.Where(x => !string.IsNullOrEmpty(x.InvoiceNo)).Select(x => x.InvoiceNo).Distinct().Count();
            tOrderCount = mSummaryExcluded.Items.Select(x => x.OrderNo).Distinct().Count();

            report.AddText(SummaryPage, rowCounter, 0, "Excluded", true);
            report.AddText(SummaryPage, rowCounter++, 1, $"{tInvoiceCount} invoices ({tOrderCount} orders)");

            foreach (var item in mSummaryExcluded.Items)
            {
                report.AddText(SummaryPage, rowCounter, 0, item.OrderNo);
                report.AddText(SummaryPage, rowCounter, 1, item.InvoiceNo);
                report.AddText(SummaryPage, rowCounter, 2, item.CustomerName);
                report.AddText(SummaryPage, rowCounter++, 3, item.Value.ToString("C2"));
            }

            report.AutoFit(SummaryPage, 0, 3);

            report.AddHeading(SummaryPage, "DHL Import Check", "Myob Assistant");
        }

        private string FormattedDate(DateTime dateTime) => $"{dateTime.Day:00}/{dateTime.Month:00}/{dateTime.Year}";

        private string CorrectedInvoiceNumber(string invoiceNumber)
        {
            if (invoiceNumber.Contains("."))
            {
                var a = invoiceNumber.IndexOf('.');
                return a < 9 ? invoiceNumber.Substring(0, a) : invoiceNumber.Substring(0, 8);
            }

            return invoiceNumber.Length < 9 ? invoiceNumber : invoiceNumber.Substring(0, 8);
        }

        private void AddMessage(string message)
        {
            lstMessages.Items.Add(message);
            Application.DoEvents();
        }

        private string MYOBCardId(string dhlCustomerId, string dhlCustomerName)
        {
            dhlCustomerId = dhlCustomerId.AddLeadingZeros(20);

            mHasError = false;
            var a = MADataAccess.LocalData.TLDDHLCustomerNumberItem(dhlCustomerId);

            if (a.Id != string.Empty) return a.MYOBCardId;

            //Add the entry
            var f = new frmAddCustomerNumber(dhlCustomerId, dhlCustomerName);
            f.ShowDialog(this);
            if (f.MYOBNumber == string.Empty)
            {
                AddMessage($"A MYOB Card ID not supplied for DHL Customer: {dhlCustomerId.RemoveLeadingZeros()} - {dhlCustomerName}");
                mHasError = true;
                return string.Empty;
            }

            var cnm = new TLDDHLCustomerNumber { Id = dhlCustomerId, CustomerName = dhlCustomerName, MYOBCardId = f.MYOBNumber };
            MADataAccess.LocalData.TLDDHLCustomerNumberUpdate(cnm);
            a = MADataAccess.LocalData.TLDDHLCustomerNumberItem(dhlCustomerId);

            MADataAccess.DataSyncUpdate.Add(new SASyncDataItem { MainType = MAUpdateItem.CustomerData, SubType = "", Payload = string.Empty });

            return a.MYOBCardId;
        }

        private void CheckExclusionData()
        {
            chkUseExclusions.Visible = false;
            chkUseExclusions.Checked = false;

            var ei = new SAExcelImport(beDHLFilename.Text.Trim(), true);

            if (ei.HasError)
            {
                AddMessage($"Error: Could not read file from disk. Original error: {ei.ErrorMessage}");
                return;
            }

            try
            {
                mPeriod = DateTime.Parse(ei.GetText(1, 29)).ToMonthPeriod();
            }
            catch (Exception ex)
            {
                AddMessage($"Error: Could not read file as DHL data file. Original error: {ex.Message}");
                return;
            }

            deStartDate.DateTime = new DateTime(mPeriod.Left(4).Value<int>(), mPeriod.Right(2).Value<int>(), 1);

            AddMessage($"Data found for period: {mPeriod}");

            ReadExclusionData();
        }

        private void ReadExclusionData()
        {
            var tData = MADataAccess.LocalData.TLDDHLInvoiceExclusionsItem(mPeriod);

            if (!string.IsNullOrEmpty(tData.Exclusions))
            {
                mExcludedOrders.ValueList = tData.Exclusions.DeserializeObject<List<string>>();
                chkUseExclusions.Checked = true;
                chkUseExclusions.Visible = true;
                AddMessage("It is recommended to apply order exclusions ...");
            }
            else
            {
                AddMessage("It is recommended to do a DHL Import preparation before doing this import ...");
            }
        }

        #endregion Private Methods

        #region Process UI

        private void btnImport_Click(object sender, EventArgs e)
        {
            mConversion = new FPDHLToMyobTXTItemSales();
            ReadFile();

            if (mHasError) return;
            AddMessage($"{mConversion.DataCount} items imported. Doing conversion ...");

            mConversion.Create();

            AddMessage($"Converted. Saving to {beMYOBFilename.Text.Trim()} ...");
            SaveFile();
        }

        private void beDHLFilename_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            beDHLFilename.Text = SelectedFile(MAFileType.XLSX, true);
            if (!string.IsNullOrEmpty(beDHLFilename.Text.Trim())) CheckExclusionData();
            btnImport.Enabled = VerifyImport();
        }

        private void beMYOBFilename_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            beMYOBFilename.Text = SelectedFile(MAFileType.TXT, false);
            if (beMYOBFilename.Text.Trim() != string.Empty && File.Exists(beMYOBFilename.Text.Trim()))
            {
                var dlgResult = MessageBox.Show($"{beMYOBFilename.Text.Trim()} can be deleted?", "Confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult != DialogResult.Yes) beMYOBFilename.Text = string.Empty;
            }
            btnImport.Enabled = VerifyImport();
        }

        private void beCheckFilename_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            beCheckFilename.Text = SelectedFile(MAFileType.XLSX, false);
            if (beCheckFilename.Text.Trim() != string.Empty && File.Exists(beCheckFilename.Text.Trim()))
            {
                var dlgResult = MessageBox.Show($"{beCheckFilename.Text.Trim()} can be deleted?", "Confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult != DialogResult.Yes) beCheckFilename.Text = string.Empty;
            }
            btnImport.Enabled = VerifyImport();
        }

        #endregion Process UI
    }

    internal class OrderSummary
    {
        public List<OrderSummaryItem> Items { get; set; } = new List<OrderSummaryItem>();

        public int Count => Items.Count;

        public void Add(OrderSummaryItem item)
        {
            var a = Items.Where(x => x.InvoiceNo.Trim() == item.InvoiceNo.Trim() && x.OrderNo.Trim() == item.OrderNo.Trim());
            if (!a.Any()) Items.Add(item);
            else a.First().Value += item.Value;
        }
    }

    internal class OrderSummaryItem
    {
        public string OrderNo { get; set; }
        public string InvoiceNo { get; set; }
        public string CustomerName { get; set; }
        public float Value { get; set; }
    }
}