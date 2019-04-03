using SangAdv.Common;
using System.Collections.Generic;
using System.Data;

namespace FPMyobAssistant
{
    internal class MARptCashFlow
    {
        #region Variables

        private MAReportStructure mStructure = new MAReportStructure();
        private MABSReportStorage mReportStorage = new MABSReportStorage();
        private MAValueComplier mValues;
        private int mReportId = 5; //Balance Sheet

        #endregion Variables

        #region Properties

        internal SAValueStore<MABSStorageItem> Storage { get; } = new SAValueStore<MABSStorageItem>();
        public DataTable ReportData => mReportStorage.ReportData;

        #endregion Properties

        #region Constructor

        public MARptCashFlow(List<string> periods)
        {
            mValues = new MAValueComplier(MAReportType.ProfitLoss, periods);
            mStructure.Load(mReportId);
        }

        #endregion Constructor

        #region Methods

        internal void BuildDataTable()
        {
            Storage.Reset();

            #region 0. Operating Profit

            //Add the total
            Storage.StoreToValue(MAConstants.ReportStorageType.OperatingProfit);
            mReportStorage.AddDataRow("Operating Profit", MARowType.Normal, Storage.Value);

            #endregion 0. Operating Profit

            #region 1. EBITDA

            var eb = mStructure.HeadingItems[1];

            //Add the Items
            foreach (var item in eb.StructureItems)
            {
                mValues.GetActualValues(item.AccountItems, eb.IncomeAsNegative);

                Storage.Subtract(new MABSStorageItem { ActualValue = mValues.ActualValue, PreviousActualValue = mValues.PreviousActualValue });

                mReportStorage.AddDataRow($" {item.ReportDescription}", MARowType.Normal, mValues.ActualValue, mValues.PreviousActualValue, mValues.BudgetValue);
            }

            //Add the total
            mReportStorage.AddDataRow(eb.HeadingDescription, MARowType.Total, Storage.Value);
            Storage.ValueToStore(MAConstants.ReportStorageType.TotalCurrentAssets);

            #endregion 1. EBITDA

            #region 2. Net Cash

            var nc = mStructure.HeadingItems[2];

            //Add the Items
            foreach (var item in nc.StructureItems)
            {
                mValues.GetActualValues(item.AccountItems, eb.IncomeAsNegative);

                Storage.Subtract(new MABSStorageItem { ActualValue = mValues.ActualValue, PreviousActualValue = mValues.PreviousActualValue });

                mReportStorage.AddDataRow($" {item.ReportDescription}", MARowType.Normal, mValues.ActualValue, mValues.PreviousActualValue, mValues.BudgetValue);
            }

            //Add the total
            mReportStorage.AddDataRow(nc.HeadingDescription, MARowType.SubTotal, Storage.Value);

            #endregion 2. Net Cash

            #region 3. Free Cash

            var fc = mStructure.HeadingItems[3];

            //Add the Items
            foreach (var item in fc.StructureItems)
            {
                mValues.GetActualValues(item.AccountItems, eb.IncomeAsNegative);

                Storage.Subtract(new MABSStorageItem { ActualValue = mValues.ActualValue, PreviousActualValue = mValues.PreviousActualValue });

                mReportStorage.AddDataRow($" {item.ReportDescription}", MARowType.Normal, mValues.ActualValue, mValues.PreviousActualValue, mValues.BudgetValue);
            }

            //Add the total
            mReportStorage.AddDataRow(fc.HeadingDescription, MARowType.SubTotal, Storage.Value);
            Storage.ValueToStore(MAConstants.ReportStorageType.TotalCurrentAssets);

            #endregion 3. Free Cash

            mReportStorage.AddEmptyRow();

            #region 4. End Cash

            var ec = mStructure.HeadingItems[4];

            //Add the Items
            foreach (var item in ec.StructureItems)
            {
                mValues.GetActualValues(item.AccountItems, eb.IncomeAsNegative);

                Storage.Subtract(new MABSStorageItem { ActualValue = mValues.ActualValue, PreviousActualValue = mValues.PreviousActualValue });

                mReportStorage.AddDataRow($" {item.ReportDescription}", MARowType.Normal, mValues.ActualValue, mValues.PreviousActualValue, mValues.BudgetValue);
            }

            //Add the total
            mReportStorage.AddDataRow(ec.HeadingDescription, MARowType.GrandTotal, Storage.Value);
            Storage.ValueToStore(MAConstants.ReportStorageType.TotalCurrentAssets);

            #endregion 4. End Cash
        }

        #endregion Methods
    }
}