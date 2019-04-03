using SangAdv.Common;
using System.Collections.Generic;
using System.Data;

namespace FPMyobAssistant
{
    internal class MARptProfitBeforeTax
    {
        #region Variables

        private MAReportStructure mStructure = new MAReportStructure();
        private MAPLReportStorage mReportStorage = new MAPLReportStorage();
        private MAValueComplier mValues;
        private int mReportId = 2; //Profit Before Tax

        #endregion Variables

        #region Properties

        internal SAValueStore<MAPLStorageItem> Storage { get; } = new SAValueStore<MAPLStorageItem>();
        public DataTable ReportData => mReportStorage.ReportData;

        #endregion Properties

        #region Constructor

        public MARptProfitBeforeTax(List<string> periods)
        {
            mValues = new MAValueComplier(MAReportType.ProfitLoss, periods);
            mStructure.Load(mReportId);
        }

        #endregion Constructor

        #region Methods

        internal void BuildDataTable()
        {
            Storage.Reset();

            #region 1. Gross Sales

            var tHeadingId = 1;
            var gsh1 = mStructure.HeadingItems[tHeadingId];

            //Add the total
            mReportStorage.AddDataRow(gsh1.HeadingDescription, MARowType.Total, Storage.FromStore(MAConstants.ReportStorageType.GrossSales));

            #endregion 1. Gross Sales

            #region 2. Net Sales

            tHeadingId = 2;
            var gsh2 = mStructure.HeadingItems[tHeadingId];

            var tString = "Reptos & Variable Selling Exp";
            mReportStorage.AddDataRow(tString, MARowType.Normal, Storage.FromStore(MAConstants.ReportStorageType.Reptos));

            //Add the total
            Storage.StoreToValue(MAConstants.ReportStorageType.GrossSales);
            Storage.Subtract(MAConstants.ReportStorageType.Reptos);
            mReportStorage.AddDataRow(gsh2.HeadingDescription, MARowType.Total, Storage.Value);

            #endregion 2. Net Sales

            mReportStorage.AddEmptyRow();

            #region 3. Gross Margin

            tHeadingId = 3;
            var gm = mStructure.HeadingItems[tHeadingId];

            //Add the Items
            foreach (var item in gm.StructureItems)
            {
                mValues.GetActualValues(item.AccountItems, gm.IncomeAsNegative);
                mValues.GetBudgetValue(MAHelpers.SetMAId(mReportId, tHeadingId, item.ItemId));

                Storage.Subtract(new MAPLStorageItem { ActualValue = mValues.ActualValue, BudgetValue = mValues.BudgetValue, PreviousActualValue = mValues.PreviousActualValue });

                mReportStorage.AddDataRow(item.ReportDescription, MARowType.Normal, mValues.ActualValue, mValues.BudgetValue, mValues.PreviousActualValue);
            }

            //Add the total
            mReportStorage.AddDataRow(gm.HeadingDescription, MARowType.Total, Storage.Value);
            Storage.ValueToStore(MAConstants.ReportStorageType.GrossMargin);

            #endregion 3. Gross Margin

            mReportStorage.AddEmptyRow();

            #region 4. Operating Costs

            Storage.Reset();
            tHeadingId = 4;

            var oc = mStructure.HeadingItems[tHeadingId];

            //Add the Items
            foreach (var item in oc.StructureItems)
            {
                mValues.GetActualValues(item.AccountItems, oc.IncomeAsNegative);
                mValues.GetBudgetValue(MAHelpers.SetMAId(mReportId, tHeadingId, item.ItemId));

                Storage.Add(new MAPLStorageItem { ActualValue = mValues.ActualValue, BudgetValue = mValues.BudgetValue, PreviousActualValue = mValues.PreviousActualValue });

                mReportStorage.AddDataRow(item.ReportDescription, MARowType.Normal, mValues.ActualValue, mValues.BudgetValue, mValues.PreviousActualValue);
            }

            //Add the total
            mReportStorage.AddDataRow(oc.HeadingDescription, MARowType.Total, Storage.Value);
            Storage.ValueToStore(MAConstants.ReportStorageType.OperatingCosts);

            #endregion 4. Operating Costs

            mReportStorage.AddEmptyRow();

            #region 5. EBITDA

            var ebitda = mStructure.HeadingItems[5];

            Storage.StoreToValue(MAConstants.ReportStorageType.GrossMargin);
            Storage.Subtract(MAConstants.ReportStorageType.OperatingCosts);

            mReportStorage.AddDataRow(ebitda.HeadingDescription, MARowType.Total, Storage.Value);

            #endregion 5. EBITDA

            mReportStorage.AddEmptyRow();

            #region 6. PBT

            tHeadingId = 6;
            var pbt = mStructure.HeadingItems[tHeadingId];

            //Add the Items
            foreach (var item in pbt.StructureItems)
            {
                mValues.GetActualValues(item.AccountItems, pbt.IncomeAsNegative);
                mValues.GetBudgetValue(MAHelpers.SetMAId(mReportId, tHeadingId, item.ItemId));

                Storage.Subtract(new MAPLStorageItem { ActualValue = mValues.ActualValue, BudgetValue = mValues.BudgetValue, PreviousActualValue = mValues.PreviousActualValue });

                mReportStorage.AddDataRow(item.ReportDescription, MARowType.Normal, mValues.ActualValue, mValues.BudgetValue, mValues.PreviousActualValue);
            }

            //Add the total
            mReportStorage.AddDataRow(pbt.HeadingDescription, MARowType.Total, Storage.Value);
            Storage.ValueToStore(MAConstants.ReportStorageType.OperatingProfit);

            #endregion 6. PBT
        }

        #endregion Methods
    }
}