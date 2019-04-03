using SangAdv.Common;
using System.Collections.Generic;
using System.Data;

namespace FPMyobAssistant
{
    internal class MARptCosts
    {
        #region Variables

        private MAReportStructure mStructure = new MAReportStructure();
        private MAPLReportStorage mReportStorage = new MAPLReportStorage();
        private MAValueComplier mValues;
        private int mReportId = 3; //Cost Breakdown

        #endregion Variables

        #region Properties

        internal SAValueStore<MAPLStorageItem> Storage { get; } = new SAValueStore<MAPLStorageItem>();
        public DataTable ReportData => mReportStorage.ReportData;

        #endregion Properties

        #region Constructor

        public MARptCosts(List<string> periods)
        {
            mValues = new MAValueComplier(MAReportType.ProfitLoss, periods);
            mStructure.Load(mReportId);
        }

        #endregion Constructor

        #region Methods

        internal void BuildDataTable()
        {
            string maId = string.Empty;
            Storage.Reset();

            #region 1. Operating Costs

            var tHeadingId = 1;
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

            #endregion 1. Operating Costs

            mReportStorage.AddEmptyRow();

            #region 2. Other Costs

            Storage.Reset();

            tHeadingId = 2;
            var otc = mStructure.HeadingItems[tHeadingId];

            //Add the Items
            foreach (var item in otc.StructureItems)
            {
                maId = MAHelpers.SetMAId(mReportId, tHeadingId, item.ItemId);
                mValues.GetActualValues(item.AccountItems, otc.IncomeAsNegative);
                mValues.GetBudgetValue(maId);

                Storage.ToStore(maId, new MAPLStorageItem { ActualValue = mValues.ActualValue, BudgetValue = mValues.BudgetValue, PreviousActualValue = mValues.PreviousActualValue });
                Storage.Add(maId);

                mReportStorage.AddDataRow(item.ReportDescription, MARowType.Normal, mValues.ActualValue, mValues.BudgetValue, mValues.PreviousActualValue);
            }

            //Add the total
            mReportStorage.AddDataRow(otc.HeadingDescription, MARowType.Total, Storage.Value);

            #endregion 2. Other Costs
        }

        #endregion Methods
    }
}