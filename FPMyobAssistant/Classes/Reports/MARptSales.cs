using SangAdv.Common;
using System.Collections.Generic;
using System.Data;

namespace FPMyobAssistant
{
    internal class MARptSales
    {
        #region Variables

        private MAReportStructure mStructure = new MAReportStructure();
        private MAPLReportStorage mReportStorage = new MAPLReportStorage();
        private MAValueComplier mValues;
        private int mReportId = 1; //Sales Details

        #endregion Variables

        #region Properties

        internal SAValueStore<MAPLStorageItem> Storage { get; } = new SAValueStore<MAPLStorageItem>();
        public DataTable ReportData => mReportStorage.ReportData;

        #endregion Properties

        #region Constructor

        public MARptSales(List<string> periods)
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

            #region 1. Gross Sales (AU/NZ)

            var tHeadingId = 1;
            var gsh1 = mStructure.HeadingItems[tHeadingId];

            //Add the Items
            foreach (var item in gsh1.StructureItems)
            {
                mValues.GetActualValues(item.AccountItems, gsh1.IncomeAsNegative);
                mValues.GetBudgetValue(MAHelpers.SetMAId(mReportId, tHeadingId, item.ItemId));

                Storage.Add(new MAPLStorageItem { ActualValue = mValues.ActualValue, BudgetValue = mValues.BudgetValue, PreviousActualValue = mValues.PreviousActualValue });

                mReportStorage.AddDataRow(item.ReportDescription, MARowType.Normal, mValues.ActualValue, mValues.BudgetValue, mValues.PreviousActualValue);
            }

            //Add the total
            mReportStorage.AddDataRow(gsh1.HeadingDescription, MARowType.Total, Storage.Value);

            #endregion 1. Gross Sales (AU/NZ)

            #region 2. Gross Sales

            tHeadingId = 2;
            var gsh2 = mStructure.HeadingItems[tHeadingId];

            //Add the Items
            foreach (var item in gsh2.StructureItems)
            {
                maId = MAHelpers.SetMAId(mReportId, tHeadingId, item.ItemId);
                mValues.GetActualValues(item.AccountItems, gsh2.IncomeAsNegative);
                mValues.GetBudgetValue(maId);

                Storage.ToStore(maId, new MAPLStorageItem { ActualValue = mValues.ActualValue, BudgetValue = mValues.BudgetValue, PreviousActualValue = mValues.PreviousActualValue });
                Storage.Add(maId);

                mReportStorage.AddDataRow(item.ReportDescription, MARowType.Normal, mValues.ActualValue, mValues.BudgetValue, mValues.PreviousActualValue);
            }

            //Add the total
            Storage.ValueToStore(MAConstants.ReportStorageType.GrossSales);
            mReportStorage.AddDataRow(gsh2.HeadingDescription, MARowType.Total, Storage.Value);

            #endregion 2. Gross Sales

            #region 3. Net Sales

            tHeadingId = 3;
            Storage.Reset();

            var nsh = mStructure.HeadingItems[tHeadingId];

            //Add the Items
            foreach (var item in nsh.StructureItems)
            {
                maId = MAHelpers.SetMAId(mReportId, tHeadingId, item.ItemId);
                mValues.GetActualValues(item.AccountItems, nsh.IncomeAsNegative);
                mValues.GetBudgetValue(maId);

                Storage.ToStore(maId, new MAPLStorageItem { ActualValue = mValues.ActualValue, BudgetValue = mValues.BudgetValue, PreviousActualValue = mValues.PreviousActualValue });
                Storage.Add(maId);

                mReportStorage.AddDataRow(item.ReportDescription, MARowType.Normal, mValues.ActualValue, mValues.BudgetValue, mValues.PreviousActualValue);
            }
            Storage.ValueToStore(MAHelpers.SetMAId(mReportId, tHeadingId, 0));

            //Add the total
            Storage.StoreToValue(MAConstants.ReportStorageType.GrossSales);
            Storage.Subtract(MAHelpers.SetMAId(mReportId, tHeadingId, 0));

            mReportStorage.AddDataRow(nsh.HeadingDescription, MARowType.Total, Storage.Value);

            #endregion 3. Net Sales
        }

        #endregion Methods
    }
}