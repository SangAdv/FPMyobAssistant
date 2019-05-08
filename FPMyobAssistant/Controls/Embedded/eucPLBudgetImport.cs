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

namespace FPMyobAssistant
{
    public partial class eucPLBudgetImport : eucBase
    {
        #region Variables

        private string mStartPeriod = string.Empty;
        private Dictionary<int, string> mReportHeadings;

        #endregion Variables

        #region Constructor

        public eucPLBudgetImport()
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
            return beBPLFilename.Text.Trim() != string.Empty;
        }

        private void VerifyBudgetImport()
        {
            btnImport.Enabled = false;
            if (string.IsNullOrEmpty(mStartPeriod)) return;
            if (Periods.Contains(mStartPeriod)) btnImport.Enabled = true;
            else RaiseMessageChangedEvent("Please select the correct P&&L Period");
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

        private void ExportPLBudget()
        {
            RaiseClearMessagesEvent();

            mReportHeadings = new Dictionary<int, string>();
            var rowCounter = 4;
            string maId = string.Empty;
            try
            {
                var mValues = new MAValueComplier(MAReportType.ProfitLoss, Periods);
                var ei = new SAExcelReport(beBPLFilename.Text, false, false);

                //Get a list of the P&L Reports
                var colCounter = 0;
                foreach (var rpt in MADataAccess.LocalData.TLMReportList().Where(x => x.ReportType == (int)MAReportType.ProfitLoss))
                {
                    //Add the report heading to the heading variable
                    mReportHeadings.Add(rowCounter, rpt.ReportDescription);
                    rowCounter++;

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
                        foreach (var item in MADataAccess.LocalData.TLMReportStructureList(rpt.ReportId, heading.HeadingId).Where(x => !x.IsGrouping.Value<bool>()).OrderBy(x => x.SequenceIndex))
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

                //Add the column headings
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

                //Add the report headings
                foreach (var entry in mReportHeadings)
                {
                    ei.AddText(0, entry.Key, 0, $"Report: {entry.Value}", true);
                    ei.SetBlockFontDetails(0, entry.Key, 0, entry.Key, 1, Color.White);
                    ei.SetBlockBackColour(0, entry.Key, 0, entry.Key, 14, Color.FromArgb(65, 65, 65));
                }

                //Add main heading
                ei.AddHeading(0, "Budget Template", "Myob Assistant");

                ei.Save(0, true);

                RaiseAddMessageEvent($"Successfully exported budget to {beBPLFilename.Text}");
            }
            catch (Exception ex)
            {
                RaiseAddMessageEvent($"Error occurred: {ex.Message}");
                RaiseMessageChangedEvent($"Error occurred: {ex.Message}");
            }
        }

        private void PreImportPLBudget()
        {
            RaiseDisableAllEvent();

            var i = 0;

            try
            {
                icbStartPeriod.Properties.Items.Clear();

                var ei = new SAExcelImport(beBPLFilename.Text);
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

        private void ImportPLBudget()
        {
            RaiseClearMessagesEvent();

            RaiseDisableAllEvent();

            var i = 0;
            var counter = 0;

            try
            {
                var ei = new SAExcelImport(beBPLFilename.Text);
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
                    MADataAccess.LocalData.TLDPLBudgetDeleteAll(item.Value);
                }

                //Load the data
                for (i = 5; i < 10000; i++)
                {
                    //Get the row index
                    var maId = ei.GetText(i, 0);
                    if (string.IsNullOrEmpty(maId)) break;

                    if (counter > 10) break;

                    try
                    {
                        var tItemId = MAHelpers.GetMAId(maId).itemId;
                        if (tItemId == 0) continue;

                        for (var j = 3; j <= 14; j++)
                        {
                            var tValue = ei.GetText(i, j).Trim();
                            var tBudget = string.IsNullOrEmpty(tValue) ? 0 : tValue.Value<float>();
                            if (tBudget == 0) continue;

                            var period = tPeriods[j];

                            if (string.Compare(period, mStartPeriod, StringComparison.Ordinal) >= 0)
                                MADataAccess.LocalData.TLDPLBudgetUpdate(new TLDPLBudget { Budget = tBudget, Period = period, MAId = maId });
                        }

                        counter = 0;
                    }
                    catch
                    {
                        counter++;
                    }
                }
                RaiseAddMessageEvent("Budget import completed successfully");

                //Set update data
                foreach (var item in tPeriods) MADataAccess.DataSyncUpdate.Add(new SASyncDataItem { MainType = MAUpdateItem.PLBudget, SubType = item.Value, Payload = string.Empty });
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
            PreImportPLBudget();
        }

        private void beBPLFilename_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            beBPLFilename.Text = SelectedFile(MAFileType.XLSX, false);
            btnPreImport.Enabled = VerifyPreImportExport();
            btnExport.Enabled = VerifyPreImportExport();
        }

        private void btnBExport_Click(object sender, EventArgs e)
        {
            ExportPLBudget();
        }

        private void btnBImport_Click(object sender, EventArgs e)
        {
            if (!File.Exists(beBPLFilename.Text))
            {
                RaiseAddMessageEvent($"{beBPLFilename.Text } not found");
                return;
            }

            ImportPLBudget();
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