using DevExpress.Spreadsheet;
using SangAdv.Common;
using SangAdv.Common.ObjectExtensions;
using SangAdv.Common.PeriodExtensions;
using SangAdv.Common.StringExtensions;
using SangAdv.DevExpressUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace FPMyobAssistant
{
    internal class MAReportCreator
    {
        #region Events

        internal event StringDelegate MessageChanged = s => { };

        #endregion Events

        #region Variables

        private const int mPLDataStart = 4;
        private const int mBSDataStart = 3;

        private SAExcelReport mReport;

        private bool mOpenSavedSpreadsheet;

        private MAReportOptions mOptions;

        #endregion Variables

        #region Constructor

        internal MAReportCreator(string filename, MAReportOptions options, bool openSpreadSheet)
        {
            MAGlobal.PLStoreSelected.Reset();
            MAGlobal.PLStoreYTD.Reset();

            mOptions = options;

            mOpenSavedSpreadsheet = openSpreadSheet;

            mReport = new SAExcelReport(filename, false, false);
        }

        #endregion Constructor

        #region Methods

        internal void DoDetailSales(List<string> selectedPeriods, List<string> ytdPeriods)
        {
            MessageChanged("Creating sales report...");

            var rpt1 = new MARptSales(selectedPeriods);
            var rpt2 = new MARptSales(ytdPeriods);

            rpt1.BuildDataTable();
            if (mOptions.IncludePLYtd) rpt2.BuildDataTable();

            CreateBasePLReport(rpt1.ReportData, rpt2.ReportData, "Sales Detail", MAReportIndex.SalesDetail);

            MAGlobal.PLStoreSelected.ToStore(MAConstants.ReportStorageType.GrossSales, rpt1.Storage.FromStore(MAConstants.ReportStorageType.GrossSales));
            MAGlobal.PLStoreSelected.ToStore(MAConstants.ReportStorageType.Reptos, rpt1.Storage.FromStore(MAConstants.ReportStorageType.Reptos));

            if (mOptions.IncludePLYtd)
            {
                MAGlobal.PLStoreYTD.ToStore(MAConstants.ReportStorageType.GrossSales, rpt2.Storage.FromStore(MAConstants.ReportStorageType.GrossSales));
                MAGlobal.PLStoreYTD.ToStore(MAConstants.ReportStorageType.Reptos, rpt2.Storage.FromStore(MAConstants.ReportStorageType.Reptos));
            }
        }

        internal void DoDetailSalesBP(List<string> selectedPeriods, List<string> ytdPeriods)
        {
            MessageChanged("Creating short sales report...");

            var rpt1 = new MARptSalesBP(selectedPeriods);
            var rpt2 = new MARptSalesBP(ytdPeriods);

            rpt1.BuildDataTable();
            if (mOptions.IncludePLYtd) rpt2.BuildDataTable();

            CreateBasePLReport(rpt1.ReportData, rpt2.ReportData, "Sales Detail (BP)", MAReportIndex.SalesDetailBP);
        }

        internal void DoProfitBeforeTax(List<string> selectedPeriods, List<string> ytdPeriods)
        {
            MessageChanged("Creating profit before tax report...");

            var rpt1 = new MARptProfitBeforeTax(selectedPeriods);
            var rpt2 = new MARptProfitBeforeTax(ytdPeriods);

            rpt1.Storage.ToStore(MAConstants.ReportStorageType.GrossSales, MAGlobal.PLStoreSelected.FromStore(MAConstants.ReportStorageType.GrossSales));
            rpt1.Storage.ToStore(MAConstants.ReportStorageType.Reptos, MAGlobal.PLStoreSelected.FromStore(MAConstants.ReportStorageType.Reptos));

            rpt1.BuildDataTable();

            if (mOptions.IncludePLYtd)
            {
                rpt2.Storage.ToStore(MAConstants.ReportStorageType.GrossSales, MAGlobal.PLStoreYTD.FromStore(MAConstants.ReportStorageType.GrossSales));
                rpt2.Storage.ToStore(MAConstants.ReportStorageType.Reptos, MAGlobal.PLStoreYTD.FromStore(MAConstants.ReportStorageType.Reptos));

                rpt2.BuildDataTable();
            }

            CreateBasePLReport(rpt1.ReportData, rpt2.ReportData, "Profit Before Tax", MAReportIndex.PBT);

            MAGlobal.PLStoreSelected.ToStore(MAConstants.ReportStorageType.OperatingProfit, rpt1.Storage.FromStore(MAConstants.ReportStorageType.OperatingProfit));
            if (mOptions.IncludePLYtd) MAGlobal.PLStoreYTD.ToStore(MAConstants.ReportStorageType.OperatingProfit, rpt2.Storage.FromStore(MAConstants.ReportStorageType.OperatingProfit));
        }

        internal void DoCostBreakdown(List<string> selectedPeriods, List<string> ytdPeriods)
        {
            MessageChanged("Creating cost breakdown report...");

            var rpt1 = new MARptCosts(selectedPeriods);
            var rpt2 = new MARptCosts(ytdPeriods);

            rpt1.BuildDataTable();
            if (mOptions.IncludePLYtd) rpt2.BuildDataTable();

            CreateBasePLReport(rpt1.ReportData, rpt2.ReportData, "Cost Breakdown", MAReportIndex.CostBreakDown);
        }

        internal void DoCostBreakdownBP(List<string> selectedPeriods, List<string> ytdPeriods)
        {
            MessageChanged("Creating short cost breakdown report...");

            var rpt1 = new MARptCostsBP(selectedPeriods);
            var rpt2 = new MARptCostsBP(ytdPeriods);

            rpt1.BuildDataTable();
            if (mOptions.IncludePLYtd) rpt2.BuildDataTable();

            CreateBasePLReport(rpt1.ReportData, rpt2.ReportData, "Cost Breakdown (BP)", MAReportIndex.CostBreakDownBP);
        }

        internal void DoBalanceSheet(string period)
        {
            MessageChanged("Creating balance sheet report...");

            var rpt1 = new MARptBalanceSheet(period);
            rpt1.BuildDataTable();

            CreateBSheetReport(rpt1.ReportData, period, mOptions.IncludeBSheetLastYear, mOptions.IncludeBSheetBudget);
        }

        internal void DoCashFlow(List<string> ytdPeriods)
        {
            MessageChanged("Creating cashflow report...");

            var rpt1 = new MARptCashFlow(new List<string> { ytdPeriods.Last() });
            var rpt2 = new MARptCashFlow(ytdPeriods);

            rpt1.Storage.ToStore(MAConstants.ReportStorageType.OperatingProfit, MAHelpers.FromPLStorageItem(MAGlobal.PLStoreSelected.FromStore(MAConstants.ReportStorageType.OperatingProfit)));
            rpt1.BuildDataTable();

            if (mOptions.IncludePLYtd)
            {
                rpt2.Storage.ToStore(MAConstants.ReportStorageType.OperatingProfit, MAHelpers.FromPLStorageItem(MAGlobal.PLStoreYTD.FromStore(MAConstants.ReportStorageType.OperatingProfit)));
                rpt2.BuildDataTable();
            }

            CreateCashflowReport(rpt1.ReportData, rpt2.ReportData, ytdPeriods.Last());
        }

        internal void Save()
        {
            mReport.Save(0, mOpenSavedSpreadsheet);
        }

        #endregion Methods

        #region Private Methods

        private void CreateBasePLReport(DataTable selectedData, DataTable ytdData, string worksheetName, MAReportIndex reportIndex, bool doFormatting = true)
        {
            mReport.AddWorkSheet(worksheetName);

            var workSheetIndex = (int)reportIndex;

            mReport.AddDataTable(workSheetIndex, mPLDataStart, 0, selectedData, true);

            if (mOptions.IncludePLYtd)
            {
                ytdData.Columns.Remove("Description");
                ytdData.Columns.Remove("RowType");

                mReport.AddDataTable(workSheetIndex, mPLDataStart, 8, ytdData, true);
            }

            if (doFormatting)
            {
                mReport.DeleteColumns(workSheetIndex, 1, 1);
                FormatPLReport(reportIndex, worksheetName, selectedData, mOptions.IncludePLYtd);
            }
        }

        private void CreateBSheetReport(DataTable selectedData, string period, bool includeLastYear, bool includeBudget)
        {
            var worksheetIndex = (int)MAReportIndex.BalanceSheet;

            mReport.AddWorkSheet("Balance Sheet");

            mReport.AddDataTable(worksheetIndex, mBSDataStart, 0, selectedData, true);

            mReport.DeleteColumns(worksheetIndex, 1, 1);
            FormatBSReport(MAReportIndex.BalanceSheet, "Balance Sheet", selectedData, period, includeLastYear, includeBudget);
        }

        private void CreateCashflowReport(DataTable selectedData, DataTable ytdData, string period)
        {
            var workSheetIndex = (int)MAReportIndex.CashFlow;

            mReport.AddWorkSheet("Cashflow");

            mReport.AddDataTable(workSheetIndex, mBSDataStart, 0, selectedData, true);
            mReport.AddDataTable(workSheetIndex, mBSDataStart, 3, ytdData, true);

            mReport.DeleteColumns(workSheetIndex, 1, 1);
            mReport.DeleteColumns(workSheetIndex, 2, 2);
            mReport.DeleteColumns(workSheetIndex, 3, 1);

            FormatCashflowReport(MAReportIndex.CashFlow, "Cashflow", selectedData, period);
        }

        private void FormatPLReport(MAReportIndex reportIndex, string reportTitle, DataTable dataTable, bool doYtd)
        {
            var workSheet = (int)reportIndex;

            var rowCounter = mPLDataStart + 1;
            var tReport = mReport.GetWorkSheet(workSheet);

            //Color the report totals
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["RowType"].Value<int>() == (int)MARowType.Total)
                {
                    mReport.SetBlockBackColour(workSheet, rowCounter, 0, rowCounter, 5, Color.LightGray);
                    tReport.Range.FromLTRB(0, rowCounter, 5, rowCounter).Font.Bold = true;
                    if (doYtd)
                    {
                        mReport.SetBlockBackColour(workSheet, rowCounter, 7, rowCounter, 11, Color.LightGray);
                        tReport.Range.FromLTRB(7, rowCounter, 11, rowCounter).Font.Bold = true;
                    }
                }

                rowCounter++;
            }

            //Clear empty rows
            rowCounter = mPLDataStart + 1;
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["RowType"].Value<int>() == (int)MARowType.Empty)
                {
                    for (var i = 0; i <= 11; i++) tReport.Cells[rowCounter, i].Value = "  ";
                }

                rowCounter++;
            }

            //Format the value columns
            var tNumberFormat = "#,##0;(#,##0);\"\"";
            var tPercentageFormat = "#,##0%;(#,##0%);\"\"";
            if (!mOptions.ShowSpaces)
            {
                tNumberFormat = "#,##0;(#,##0)";
                tPercentageFormat = "#,##0%;(#,##0%)";
            }

            mReport.SetBlockFormat(workSheet, mPLDataStart + 1, 1, mPLDataStart + dataTable.Rows.Count, 3, tNumberFormat);
            if (doYtd) mReport.SetBlockFormat(workSheet, mPLDataStart + 1, 7, mPLDataStart + dataTable.Rows.Count, 9, tNumberFormat);

            mReport.SetBlockFormat(workSheet, mPLDataStart + 1, 4, mPLDataStart + dataTable.Rows.Count, 5, tPercentageFormat);
            if (doYtd) mReport.SetBlockFormat(workSheet, mPLDataStart + 1, 10, mPLDataStart + dataTable.Rows.Count, 11, tPercentageFormat);

            //Add the title and headings
            rowCounter = mPLDataStart - 1;

            mReport.AddText(workSheet, rowCounter + 1, 0, "AUD");
            mReport.AddText(workSheet, rowCounter, 3, mOptions.PeriodHeading);
            if (doYtd) mReport.AddText(workSheet, rowCounter, 9, mOptions.YTDPeriodHeading);

            mReport.SetBlockBackColour(workSheet, rowCounter, 0, rowCounter + 1, 5, Color.FromArgb(0, 176, 240));
            tReport.Range.FromLTRB(0, rowCounter, 5, rowCounter + 1).Font.Bold = true;
            tReport.Range.FromLTRB(1, rowCounter, 5, rowCounter + 1).Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;

            if (doYtd)
            {
                mReport.SetBlockBackColour(workSheet, rowCounter, 7, rowCounter + 1, 11, Color.FromArgb(0, 176, 240));
                tReport.Range.FromLTRB(7, rowCounter, 11, rowCounter + 1).Font.Bold = true;
                tReport.Range.FromLTRB(7, rowCounter, 11, rowCounter + 1).Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            }

            //Add the heading borders
            tReport.Range.FromLTRB(0, rowCounter, 5, rowCounter + 1).Borders.SetOutsideBorders(Color.White, BorderLineStyle.Medium);
            tReport.Range.FromLTRB(1, rowCounter, 5, rowCounter).Borders.SetOutsideBorders(Color.White, BorderLineStyle.Medium);
            for (var i = 1; i <= 5; i++) tReport.Range.FromLTRB(i, rowCounter + 1, i, rowCounter + 1).Borders.SetOutsideBorders(Color.White, BorderLineStyle.Medium);

            if (doYtd)
            {
                tReport.Range.FromLTRB(7, rowCounter, 11, rowCounter + 1).Borders.SetOutsideBorders(Color.White, BorderLineStyle.Medium);
                for (var i = 7; i <= 11; i++) tReport.Range.FromLTRB(i, rowCounter + 1, i, rowCounter + 1).Borders.SetOutsideBorders(Color.White, BorderLineStyle.Medium);
            }

            mReport.AutoFit(workSheet, 0, 11);

            //Make the value columns the same width
            double tColumnWidth = 0;
            for (var i = 1; i <= 11; i++)
                if (tReport.Columns[i].Width > tColumnWidth) tColumnWidth = tReport.Columns[i].Width;

            for (var i = 1; i <= 11; i++)
                tReport.Columns[i].Width = tColumnWidth;

            tReport.Columns[6].Width = 50;
            tReport.ActiveView.ShowGridlines = false;

            mReport.AddHeading(workSheet, reportTitle, "Myob Assistant");
        }

        private void FormatBSReport(MAReportIndex reportIndex, string reportTitle, DataTable dataTable, string period, bool includeLastYear, bool includeBudget)
        {
            var workSheet = (int)reportIndex;

            var rowCounter = mBSDataStart + 1;
            var tReport = mReport.GetWorkSheet(workSheet);

            var tEndColumn = 3;

            //Process Include LY and Budget
            if (!includeBudget)
            {
                mReport.DeleteColumns(workSheet, 3, 1);
                tEndColumn = tEndColumn - 1;
            }

            if (!includeLastYear)
            {
                mReport.DeleteColumns(workSheet, 2, 1);
                tEndColumn = tEndColumn - 1;
            }

            //Color the report totals
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["RowType"].Value<int>() == (int)MARowType.Total)
                {
                    mReport.SetBlockBackColour(workSheet, rowCounter, 0, rowCounter, tEndColumn, Color.LightGray);
                    tReport.Range.FromLTRB(0, rowCounter, tEndColumn, rowCounter).Font.Bold = true;
                }
                else if (row["RowType"].Value<int>() == (int)MARowType.SubTotal)
                {
                    mReport.SetBlockBackColour(workSheet, rowCounter, 0, rowCounter, tEndColumn, Color.FromArgb(220, 230, 241));
                    tReport.Range.FromLTRB(0, rowCounter, tEndColumn, rowCounter).Font.Bold = true;
                }
                else if (row["RowType"].Value<int>() == (int)MARowType.GrandTotal)
                {
                    mReport.SetBlockBackColour(workSheet, rowCounter, 0, rowCounter, tEndColumn, Color.FromArgb(83, 141, 213));
                    tReport.Range.FromLTRB(0, rowCounter, tEndColumn, rowCounter).Font.Bold = true;
                }

                rowCounter++;
            }

            //Clear empty rows
            rowCounter = mBSDataStart + 1;
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["RowType"].Value<int>() == (int)MARowType.Empty)
                {
                    for (var i = 0; i <= tEndColumn; i++) tReport.Cells[rowCounter, i].Value = "  ";
                }

                rowCounter++;
            }

            //Format the value columns
            var tNumberFormat = "#,##0;(#,##0);\"\"";
            if (!mOptions.ShowSpaces) tNumberFormat = "#,##0;(#,##0)";

            mReport.SetBlockFormat(workSheet, mBSDataStart + 1, 1, mBSDataStart + dataTable.Rows.Count, tEndColumn, tNumberFormat);

            //Add the title and headings
            var tPeriodToDate = $"{new DateTime(period.Left(4).Value<int>(), period.Right(2).Value<int>(), 1):MMMyy}";
            mReport.AddText(workSheet, mBSDataStart, 0, "AUD");
            mReport.AddText(workSheet, mBSDataStart, 1, tPeriodToDate);

            if (includeLastYear)
            {
                period = period.SubtractMonthPeriods(12);
                var tLYPeriodToDate = $"{new DateTime(period.Left(4).Value<int>(), period.Right(2).Value<int>(), 1):MMMyy}";
                mReport.AddText(workSheet, mBSDataStart, 2, tLYPeriodToDate);
            }

            mReport.SetBlockBackColour(workSheet, mBSDataStart, 0, mBSDataStart, tEndColumn, Color.FromArgb(0, 176, 240));
            tReport.Range.FromLTRB(0, mBSDataStart, tEndColumn, mBSDataStart).Font.Bold = true;
            tReport.Range.FromLTRB(1, mBSDataStart, tEndColumn, mBSDataStart).Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;

            //Add the heading borders
            tReport.Range.FromLTRB(0, mBSDataStart, tEndColumn, mBSDataStart).Borders.SetOutsideBorders(Color.White, BorderLineStyle.Medium);
            for (var i = 1; i <= tEndColumn; i++) tReport.Range.FromLTRB(i, mBSDataStart, i, mBSDataStart).Borders.SetOutsideBorders(Color.White, BorderLineStyle.Medium);

            mReport.AutoFit(workSheet, 0, 11);

            //Make the value columns the same width
            double tColumnWidth = 0;
            for (var i = 1; i <= tEndColumn; i++)
                if (tReport.Columns[i].Width > tColumnWidth) tColumnWidth = tReport.Columns[i].Width;

            for (var i = 1; i <= tEndColumn; i++)
                tReport.Columns[i].Width = tColumnWidth;

            tReport.ActiveView.ShowGridlines = false;

            mReport.AddHeading(workSheet, reportTitle, "Myob Assistant");
        }

        private void FormatCashflowReport(MAReportIndex reportIndex, string reportTitle, DataTable dataTable, string period)
        {
            var workSheet = (int)reportIndex;

            var rowCounter = mBSDataStart + 1;
            var tReport = mReport.GetWorkSheet(workSheet);

            var tEndColumn = 2;

            //Delete the budget column
            mReport.DeleteColumns(workSheet, 3, 1);

            //Color the report totals
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["RowType"].Value<int>() == (int)MARowType.Total)
                {
                    mReport.SetBlockBackColour(workSheet, rowCounter, 0, rowCounter, tEndColumn, Color.LightGray);
                    tReport.Range.FromLTRB(0, rowCounter, tEndColumn, rowCounter).Font.Bold = true;
                }
                else if (row["RowType"].Value<int>() == (int)MARowType.SubTotal)
                {
                    mReport.SetBlockBackColour(workSheet, rowCounter, 0, rowCounter, tEndColumn, Color.FromArgb(220, 230, 241));
                    tReport.Range.FromLTRB(0, rowCounter, tEndColumn, rowCounter).Font.Bold = true;
                }
                else if (row["RowType"].Value<int>() == (int)MARowType.GrandTotal)
                {
                    mReport.SetBlockBackColour(workSheet, rowCounter, 0, rowCounter, tEndColumn, Color.FromArgb(83, 141, 213));
                    tReport.Range.FromLTRB(0, rowCounter, tEndColumn, rowCounter).Font.Bold = true;
                }

                rowCounter++;
            }

            //Clear empty rows
            rowCounter = mBSDataStart + 1;
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["RowType"].Value<int>() == (int)MARowType.Empty)
                {
                    for (var i = 0; i <= tEndColumn; i++) tReport.Cells[rowCounter, i].Value = "  ";
                }

                rowCounter++;
            }

            //Format the value columns
            var tNumberFormat = "#,##0;(#,##0);\"\"";
            if (!mOptions.ShowSpaces) tNumberFormat = "#,##0;(#,##0)";

            mReport.SetBlockFormat(workSheet, mBSDataStart + 1, 1, mBSDataStart + dataTable.Rows.Count, 2, tNumberFormat);

            //Add the title and headings
            var tPeriodToDate = $"{new DateTime(period.Left(4).Value<int>(), period.Right(2).Value<int>(), 1):MMMyy}";

            mReport.AddText(workSheet, mBSDataStart, 0, "AUD");
            mReport.AddText(workSheet, mBSDataStart, 1, tPeriodToDate);
            mReport.AddText(workSheet, mBSDataStart, 2, "YTD");

            mReport.SetBlockBackColour(workSheet, mBSDataStart, 0, mBSDataStart, tEndColumn, Color.FromArgb(0, 176, 240));
            tReport.Range.FromLTRB(0, mBSDataStart, tEndColumn, mBSDataStart).Font.Bold = true;
            tReport.Range.FromLTRB(1, mBSDataStart, tEndColumn, mBSDataStart).Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;

            //Add the heading borders
            tReport.Range.FromLTRB(0, mBSDataStart, tEndColumn, mBSDataStart).Borders.SetOutsideBorders(Color.White, BorderLineStyle.Medium);
            for (var i = 1; i <= tEndColumn; i++) tReport.Range.FromLTRB(i, mBSDataStart, i, mBSDataStart).Borders.SetOutsideBorders(Color.White, BorderLineStyle.Medium);

            mReport.AutoFit(workSheet, 0, 11);

            //Make the value columns the same width
            double tColumnWidth = 0;
            for (var i = 1; i <= tEndColumn; i++)
                if (tReport.Columns[i].Width > tColumnWidth) tColumnWidth = tReport.Columns[i].Width;

            for (var i = 1; i <= tEndColumn; i++)
                tReport.Columns[i].Width = tColumnWidth;

            tReport.ActiveView.ShowGridlines = false;

            mReport.AddHeading(workSheet, reportTitle, "Myob Assistant");
        }

        #endregion Private Methods
    }
}