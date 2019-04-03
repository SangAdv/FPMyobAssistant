using SangAdv.Common;
using System.Collections.Generic;
using System.Data;

namespace FPMyobAssistant
{
    internal class MARptBalanceSheet
    {
        #region Variables

        private MAReportStructure mStructure = new MAReportStructure();
        private MABSReportStorage mReportStorage = new MABSReportStorage();
        private MAValueComplier mValues;
        private int mReportId = 4; //Balance Sheet

        #endregion Variables

        #region Properties

        internal SAValueStore<MABSStorageItem> Storage { get; } = new SAValueStore<MABSStorageItem>();
        public DataTable ReportData => mReportStorage.ReportData;

        #endregion Properties

        #region Constructor

        public MARptBalanceSheet(string period)
        {
            mValues = new MAValueComplier(MAReportType.BalanceSheet, new List<string>() { period });
            mStructure.Load(mReportId);
        }

        #endregion Constructor

        #region Methods

        internal void BuildDataTable()
        {
            var maId = string.Empty;
            Storage.Reset();

            #region 1. Total Current Assets

            var tHeadingId = 1;
            var tca = mStructure.HeadingItems[tHeadingId];

            //Add the Items
            foreach (var item in tca.StructureItems)
            {
                maId = MAHelpers.SetMAId(mReportId, tHeadingId, item.ItemId);
                mValues.GetActualValues(item.AccountItems, tca.IncomeAsNegative);
                mValues.GetBudgetValue(maId);

                Storage.Add(new MABSStorageItem { ActualValue = mValues.ActualValue, PreviousActualValue = mValues.PreviousActualValue, BudgetValue = mValues.BudgetValue });

                mReportStorage.AddDataRow(item.ReportDescription, MARowType.Normal, mValues.ActualValue, mValues.PreviousActualValue, mValues.BudgetValue);
            }

            //Add the total
            mReportStorage.AddDataRow(tca.HeadingDescription, MARowType.SubTotal, Storage.Value);
            Storage.ValueToStore(MAConstants.ReportStorageType.TotalCurrentAssets);

            #endregion 1. Total Current Assets

            mReportStorage.AddEmptyRow();

            #region 2. Total Non Current Assets

            tHeadingId = 2;
            Storage.Reset();

            var tnca = mStructure.HeadingItems[tHeadingId];

            //Add the Items
            foreach (var item in tnca.StructureItems)
            {
                maId = MAHelpers.SetMAId(mReportId, tHeadingId, item.ItemId);
                mValues.GetActualValues(item.AccountItems, tnca.IncomeAsNegative);
                mValues.GetBudgetValue(maId);

                Storage.Add(new MABSStorageItem { ActualValue = mValues.ActualValue, PreviousActualValue = mValues.PreviousActualValue, BudgetValue = mValues.BudgetValue });

                mReportStorage.AddDataRow(item.ReportDescription, MARowType.Normal, mValues.ActualValue, mValues.PreviousActualValue, mValues.BudgetValue);
            }

            //Add the total
            mReportStorage.AddDataRow(tnca.HeadingDescription, MARowType.SubTotal, Storage.Value);
            Storage.Add(MAConstants.ReportStorageType.TotalCurrentAssets);

            #endregion 2. Total Non Current Assets

            #region 3. Total Assets

            tHeadingId = 3;

            var ta = mStructure.HeadingItems[tHeadingId];
            mReportStorage.AddDataRow(ta.HeadingDescription, MARowType.Total, Storage.Value);
            Storage.ValueToStore(MAConstants.ReportStorageType.TotalAssets);

            #endregion 3. Total Assets

            mReportStorage.AddEmptyRow();

            #region 4. Total Liabilities

            tHeadingId = 4;
            Storage.Reset();
            var tl = mStructure.HeadingItems[tHeadingId];

            //Add the Items
            foreach (var item in tl.StructureItems)
            {
                maId = MAHelpers.SetMAId(mReportId, tHeadingId, item.ItemId);
                mValues.GetActualValues(item.AccountItems, tl.IncomeAsNegative);
                mValues.GetBudgetValue(maId);

                Storage.Add(new MABSStorageItem { ActualValue = mValues.ActualValue, PreviousActualValue = mValues.PreviousActualValue, BudgetValue = mValues.BudgetValue });

                mReportStorage.AddDataRow(item.ReportDescription, MARowType.Normal, mValues.ActualValue, mValues.PreviousActualValue, mValues.BudgetValue);
            }

            mReportStorage.AddEmptyRow();

            //Add the total
            mReportStorage.AddDataRow(tl.HeadingDescription, MARowType.SubTotal, Storage.Value);
            Storage.ValueToStore(MAConstants.ReportStorageType.TotalLiabilities);

            #endregion 4. Total Liabilities

            mReportStorage.AddEmptyRow();

            #region 5. Net Assets

            tHeadingId = 5;

            var na = mStructure.HeadingItems[tHeadingId];
            Storage.StoreToValue(MAConstants.ReportStorageType.TotalAssets);
            Storage.Subtract(MAConstants.ReportStorageType.TotalLiabilities);
            mReportStorage.AddDataRow(na.HeadingDescription, MARowType.GrandTotal, Storage.Value);

            #endregion 5. Net Assets

            mReportStorage.AddEmptyRow();

            #region 6. Total Equity

            tHeadingId = 6;
            Storage.Reset();

            var te = mStructure.HeadingItems[tHeadingId];

            //Add the Items
            foreach (var item in te.StructureItems)
            {
                maId = MAHelpers.SetMAId(mReportId, tHeadingId, item.ItemId);
                mValues.GetActualValues(item.AccountItems, te.IncomeAsNegative);
                mValues.GetBudgetValue(maId);

                Storage.Add(new MABSStorageItem { ActualValue = mValues.ActualValue, PreviousActualValue = mValues.PreviousActualValue, BudgetValue = mValues.BudgetValue });

                mReportStorage.AddDataRow(item.ReportDescription, MARowType.Normal, mValues.ActualValue, mValues.PreviousActualValue, mValues.BudgetValue);
            }

            mReportStorage.AddEmptyRow();

            //Add the total
            mReportStorage.AddDataRow(te.HeadingDescription, MARowType.GrandTotal, Storage.Value);

            #endregion 6. Total Equity
        }

        #endregion Methods
    }
}