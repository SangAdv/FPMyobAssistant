using DevExpress.Spreadsheet;
using DevExpress.XtraEditors.Controls;
using LocalModelContext;
using SangAdv.Common;
using SangAdv.Common.ObjectExtensions;
using SangAdv.Common.PeriodExtensions;
using SangAdv.DevExpressUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPMyobAssistant
{
    public partial class eucBSBudgetImport : eucBase
    {
        #region Variables

        private string mStartPeriod = string.Empty;

        #endregion Variables

        #region Constructor

        public eucBSBudgetImport()
        {
            InitializeComponent();
            btnPreImport.Enabled = false;
            btnExport.Enabled = false;
            btnImport.Enabled = false;
        }

        #endregion Constructor

        #region Methods

        public void Initialise()
        {
            LoadFinancialPeriods();
        }

        private void LoadFinancialPeriods()
        {
            icbPeriod.Properties.Items.Clear();
            var tPeriods = new MAHelpers(true).FinancialPeriods;
            foreach (var item in tPeriods) icbPeriod.Properties.Items.Add(new ImageComboBoxItem(item.Value, item.Key, 0));
            icbPeriod.SelectedIndex = tPeriods.Count - 1;
        }

        private bool VerifyPreImportExport()
        {
            return beBBSFilename.Text.Trim() != string.Empty;
        }

        private void VerifyBudgetImport()
        {
            btnImport.Enabled = false;
            if (string.IsNullOrEmpty(mStartPeriod)) return;
            if (Periods.Contains(mStartPeriod)) btnImport.Enabled = true;
            else RaiseMessageChangedEvent("Please select the correct Balance Sheet Period");
        }

        private string SelectedFile(MAFileType fileType, bool checkIfFileExists)
        {
            RaiseClearMessagesEvent();

            var fileName = MAFileSelection.SelectFile(fileType, checkIfFileExists);
            if (string.IsNullOrEmpty(fileName))
            {
                if (MAFileSelection.HasError) RaiseAddMessageEvent(MAFileSelection.ErrorMessage);
                return string.Empty;
            }

            RaiseAddMessageEvent(File.Exists(fileName) ? $"{fileName} found" : $"{fileName} not found");
            return fileName;
        }

        private void ExportBSBudget()
        {
            RaiseClearMessagesEvent();
            var rowCounter = 4;
            string maId = string.Empty;
            try
            {
                var mValues = new MAValueComplier(MAReportType.BalanceSheet, Periods);
                var ei = new SAExcelReport(beBBSFilename.Text, false, false);

                //Get a list of the Balance Sheet Reports
                var colCounter = 0;
                foreach (var rpt in MADataAccess.LocalData.TLMReportList().Where(x => x.ReportType == (int)MAReportType.BalanceSheet))
                {
                    //Get a list of non calculated headings
                    foreach (var heading in MADataAccess.LocalData.TLMReportHeadingList(rpt.ReportId).Where(x => x.IsCalculation == 0))
                    {
                        //Add Heading
                        maId = MAHelpers.SetMAId(rpt.ReportId, heading.HeadingId, 0);
                        ei.AddText(0, rowCounter, 0, maId);
                        ei.AddText(0, rowCounter, 1, heading.ReportHeading);
                        ei.SetBlockBackColour(0, rowCounter, 0, rowCounter, 14, Color.Silver);
                        rowCounter++;

                        //Get a list of the structure Items
                        foreach (var item in MADataAccess.LocalData.TLMReportStructureList(rpt.ReportId, heading.HeadingId))
                        {
                            maId = MAHelpers.SetMAId(rpt.ReportId, heading.HeadingId, item.ItemId);

                            ei.AddText(0, rowCounter, 0, maId);

                            ei.AddText(0, rowCounter, 2, item.ReportDescription);

                            colCounter = 3;
                            foreach (var period in Periods)
                            {
                                mValues.GetBudgetValue(period, maId);
                                ei.AddValue(0, rowCounter, colCounter, mValues.BudgetValue, "#,##0");
                                colCounter++;
                            }
                            rowCounter++;
                        }
                    }
                }

                //Add the headings
                ei.AddText(0, 3, 0, "Index");
                ei.AddText(0, 3, 1, "Heading");
                ei.AddText(0, 3, 1, "Item");
                colCounter = 3;
                foreach (var period in Periods)
                {
                    ei.AddText(0, 3, colCounter, period);
                    colCounter++;
                }
                ei.SetBlockBackColour(0, 3, 0, 3, 14, Color.FromArgb(0, 114, 198));
                ei.SetBlockFontDetails(0, 3, 0, 3, 14, Color.White);

                ei.AutoFit(0, 0, 15);
                ei.AddHeading(0, "Budget Template", "Myob Assistant");
                ei.Save(0, true);

                RaiseAddMessageEvent($"Successfully exported budget to {beBBSFilename.Text}");
            }
            catch (Exception ex)
            {
                RaiseAddMessageEvent($"Error occurred: {ex.Message}");
                RaiseMessageChangedEvent($"Error occurred: {ex.Message}");
            }
        }

        private void PreImportBSBudget()
        {
            RaiseDisableAllEvent();

            var i = 0;

            try
            {
                icbStartPeriod.Properties.Items.Clear();
                Application.DoEvents();

                var ei = new SAExcelImport(beBBSFilename.Text, DocumentFormat.Xlsx);
                //Load the periods
                var tPeriods = new Dictionary<int, string>();
                for (var j = 3; j <= 14; j++)
                {
                    var period = ei.GetText(3, j);
                    tPeriods.Add(j, ei.GetText(3, j));
                    if (period.IsMonthPeriod()) icbStartPeriod.Properties.Items.Add(period, period, 0);
                }

                if (icbStartPeriod.Properties.Items.Count > 0)
                {
                    icbStartPeriod.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                RaiseAddMessageEvent($"Error occurred: {ex.Message} on row {i}");
                RaiseAddMessageEvent("Budget pre import failed");
            }

            RaiseEnableAllEvent();
        }

        private async Task ImportBSBudgetAsync()
        {
            RaiseClearMessagesEvent();

            RaiseDisableAllEvent();

            var i = 0;

            try
            {
                var ei = new SAExcelImport(beBBSFilename.Text, DocumentFormat.Xlsx);
                //Load the periods
                var tPeriods = new Dictionary<int, string>();
                for (var j = 3; j <= 14; j++)
                {
                    var period = ei.GetText(3, j);
                    if (string.Compare(period, mStartPeriod, StringComparison.Ordinal) >= 0) tPeriods.Add(j, period);
                }

                //Clear old data
                foreach (var item in tPeriods)
                {
                    MADataAccess.LocalData.TLDBSBudgetDeleteAll(item.Value);
                }

                //Load the data
                for (i = 5; i < 10000; i++)
                {
                    //Get the row index
                    var maId = ei.GetText(i, 0);
                    if (string.IsNullOrEmpty(maId)) break;

                    var tItemId = MAHelpers.GetMAId(maId).itemId;
                    if (tItemId == 0) continue;

                    for (var j = 3; j <= 14; j++)
                    {
                        var tValue = ei.GetText(i, j).Trim();
                        var tBudget = string.IsNullOrEmpty(tValue) ? 0 : tValue.Value<float>();
                        if (tBudget == 0) continue;

                        var period = tPeriods[j];

                        if (string.Compare(period, mStartPeriod, StringComparison.Ordinal) >= 0) MADataAccess.LocalData.TLDBSBudgetUpdate(new TLDBSBudget { Budget = tBudget, Period = period, MAId = maId });
                    }
                }
                RaiseAddMessageEvent("Budget import completed successfully");

                //Set update data
                foreach (var item in tPeriods) await MADataAccess.DataSyncUpdate.AddAsync(new SASyncDataItem { MainType = MAUpdateItem.BSBudget, SubType = item.Value, Payload = string.Empty });
            }
            catch (Exception ex)
            {
                RaiseAddMessageEvent($"Error occurred: {ex.Message} on row {i}");
                RaiseAddMessageEvent("Budget import failed");
            }

            RaiseEnableAllEvent();
        }

        #endregion Methods

        #region Process UI

        private void btnPreImport_Click(object sender, EventArgs e)
        {
            PreImportBSBudget();
        }

        private void beBPLFilename_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            beBBSFilename.Text = SelectedFile(MAFileType.XLSX, false);
            btnPreImport.Enabled = VerifyPreImportExport();
            btnExport.Enabled = VerifyPreImportExport();
        }

        private void btnBExport_Click(object sender, EventArgs e)
        {
            ExportBSBudget();
        }

        private async void btnBImport_Click(object sender, EventArgs e)
        {
            if (!File.Exists(beBBSFilename.Text))
            {
                RaiseAddMessageEvent($"{beBBSFilename.Text } not found");
                return;
            }

            await ImportBSBudgetAsync();
        }

        private void icbBPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tYear = icbPeriod.EditValue.Value<int>();
            LoadBudgetImportPeriods(tYear);
            VerifyBudgetImport();
        }

        private void icbStartPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            mStartPeriod = icbStartPeriod.EditValue.ToString();
            VerifyBudgetImport();
        }

        #endregion Process UI
    }
}