using SangAdv.Common;
using SangAdv.Common.ObjectExtensions;
using SangAdv.Common.PeriodExtensions;
using SangAdv.Common.StringExtensions;
using SangAdv.Common.UI;
using SangAdv.DevExpressUI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FPMyobAssistant
{
    public partial class ucBoardReport : ucTemplate
    {
        #region Enums

        private enum MABoardReportType : int
        {
            Month = 1,
            Quarter = 2,
            HalfYear = 3,
            Annual = 4
        }

        #endregion Enums

        #region Variables

        private MABaseControls mBase;
        private MABoardReportType mReportType = MABoardReportType.Month;

        private List<string> mSelectedPeriods = new List<string>();
        private List<string> mYTDPeriods = new List<string>();

        #endregion Variables

        #region Constructor

        public ucBoardReport()
        {
            InitializeComponent();
            mBase = new MABaseControls(this);
            mBase.SetTitle("Export Board Report");

            Initialise();
            chkIncludePLAdjustments.Enabled = false;
        }

        #endregion Constructor

        #region Methods

        private void Initialise()
        {
            LoadPeriods();
            CanExport();
        }

        private void LoadPeriods()
        {
            icbEndPeriod.Properties.Items.Clear();

            var tMinPeriod = MADataAccess.LocalData.TLDPLList().Select(x => x.Period).Min();
            var tMaxPeriod = MADataAccess.LocalData.TLDPLList().Select(x => x.Period).Max();

            var tMaxBudgetPeriod = MADataAccess.LocalData.TLDPLBudgetList().Select(x => x.Period).Max();

            if (tMaxBudgetPeriod.PeriodToInt() > tMaxPeriod.PeriodToInt()) tMaxPeriod = tMaxBudgetPeriod;

            foreach (var period in SAPeriods.GetMonthPeriodList(tMinPeriod, tMaxPeriod))
            {
                if (period.IsMonthPeriod()) icbEndPeriod.Properties.Items.Add(period, period, 0);
            }
            icbEndPeriod.Text = DateTime.Now.ToMonthPeriod();
        }

        private void CanExport()
        {
            btnExport.Enabled = !string.IsNullOrEmpty(beBoardReportFilename.Text);
        }

        private void ExportReport()
        {
            //Create Report Periods
            mBase.SetMessage("Creating period list...");
            RaiseShowWaitPanelEvent();

            CreatePeriodLists();

            var tPeriodToDate = $"{new DateTime(icbEndPeriod.Text.Left(4).Value<int>(), icbEndPeriod.Text.Right(2).Value<int>(), 1):MMMyy}";

            var tHeading = $"MTD-{tPeriodToDate}";
            if (chkQuarter.Checked) tHeading = $"QTR-{tPeriodToDate}";
            if (chkHalfYear.Checked) tHeading = $"HY-{tPeriodToDate}";
            if (chkAnnual.Checked) tHeading = $"FY-{tPeriodToDate}";

            var options = new MAReportOptions
            {
                PeriodHeading = tHeading,
                YTDPeriodHeading = $"YTD-{tPeriodToDate}",
                ShowSpaces = chkShowSpaces.Checked,
                IncludePLYtd = chkIncludePLYTD.Checked,
                IncludeBSheetBudget = chkIncludeBSheetBudget.Checked,
                IncludeBSheetLastYear = chkIncludeBSheetLastYear.Checked
            };

            var tReport = new MAReportCreator(beBoardReportFilename.Text, options, chkOpenReport.Checked);

            tReport.MessageChanged += mBase.SetMessage;

            tReport.DoDetailSales(mSelectedPeriods, mYTDPeriods);
            tReport.DoDetailSalesBP(mSelectedPeriods, mYTDPeriods);
            tReport.DoProfitBeforeTax(mSelectedPeriods, mYTDPeriods);
            tReport.DoCostBreakdown(mSelectedPeriods, mYTDPeriods);
            tReport.DoCostBreakdownBP(mSelectedPeriods, mYTDPeriods);
            tReport.DoBalanceSheet(icbEndPeriod.Text);
            tReport.DoCashFlow(mYTDPeriods);
            tReport.Save();

            RaiseHideWaitPanelEvent();
            mBase.SetMessage($"{beBoardReportFilename.Text} created.");
        }

        private void CreatePeriodLists()
        {
            var startPeriod = string.Empty;
            var periods = new List<string>();

            mSelectedPeriods.Clear();
            mYTDPeriods.Clear();

            //Create selected period list
            switch (mReportType)
            {
                case MABoardReportType.Month:
                    mSelectedPeriods.Add(icbEndPeriod.Text);
                    break;

                case MABoardReportType.Quarter:
                    periods = SAPeriods.GetMonthPeriodList(icbEndPeriod.Text.SubtractMonthPeriods(2), icbEndPeriod.Text);
                    foreach (var period in periods) mSelectedPeriods.Add(period);
                    break;

                case MABoardReportType.Annual:
                    periods = SAPeriods.GetMonthPeriodList(icbEndPeriod.Text.SubtractMonthPeriods(11), icbEndPeriod.Text);
                    foreach (var period in periods) mSelectedPeriods.Add(period);
                    break;
            }

            //Create YTD period List
            var fin2 = GetFinancialYearStart();
            startPeriod = $"{fin2.Year}-{fin2.Month:00}";
            periods = SAPeriods.GetMonthPeriodList(startPeriod, icbEndPeriod.Text);
            foreach (var period in periods) mYTDPeriods.Add(period);
        }

        private (int Year, int Month) GetFinancialYearStart()
        {
            //Financial Year starts in July
            //var selectedYear = icbEndPeriod.Text.Left(4).Value<int>();
            //var selectedMonth = icbEndPeriod.Text.Right(2).Value<int>();
            //if (selectedMonth >= 1 && selectedMonth <= 6) selectedYear -= 1;
            //return (selectedYear, 7);

            //Financial Year starts in January
            var selectedYear = icbEndPeriod.Text.Left(4).Value<int>();
            return (selectedYear, 1);
        }

        #endregion Methods

        #region Process UI

        private void rptType_CheckedChanged(object sender, EventArgs e)
        {
            chkIncludePLAdjustments.Enabled = false;

            if (chkMonth.Checked) mReportType = MABoardReportType.Month;
            if (chkQuarter.Checked) mReportType = MABoardReportType.Quarter;
            if (chkHalfYear.Checked) mReportType = MABoardReportType.HalfYear;
            if (chkAnnual.Checked)
            {
                mReportType = MABoardReportType.Annual;
                chkIncludePLAdjustments.Enabled = true;
            }
        }

        private void beBoardReportFilename_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            beBoardReportFilename.Text = string.Empty;
            var tFilename = SADialogs.Dialogs.SaveDataFile(true, true, true);
            if (string.IsNullOrEmpty(tFilename))
            {
                CanExport();
                return;
            }
            beBoardReportFilename.Text = tFilename;
            CanExport();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportReport();
        }

        #endregion Process UI
    }
}