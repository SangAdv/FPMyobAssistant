using SangAdv.Common;
using System.Collections.Generic;
using System.Data;

namespace FPMyobAssistant
{
    internal class MARptSalesBP
    {
        #region Variables

        private MAReportStructure mStructure = new MAReportStructure();
        private MAPLReportStorage mReportStorage = new MAPLReportStorage();
        private MAValueComplier mValues;
        private int mReportId = (int)MAReportId.SalesDetailBP; //Sales Details

        #endregion Variables

        #region Properties

        internal SAValueStore<MAPLStorageItem> Storage { get; } = new SAValueStore<MAPLStorageItem>();
        public DataTable ReportData => mReportStorage.ReportData;

        #endregion Properties

        #region Constructor

        public MARptSalesBP(List<string> periods)
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
                mValues.GetActualValues(MAHelpers.GetAllAccountCodes(item), gsh1.IncomeAsNegative);
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
                mValues.GetActualValues(MAHelpers.GetAllAccountCodes(item), gsh2.IncomeAsNegative);
                mValues.GetBudgetValue(MAHelpers.SetMAId(mReportId, tHeadingId, item.ItemId));

                Storage.Add(new MAPLStorageItem { ActualValue = mValues.ActualValue, BudgetValue = mValues.BudgetValue, PreviousActualValue = mValues.PreviousActualValue });

                mReportStorage.AddDataRow(item.ReportDescription, MARowType.Normal, mValues.ActualValue, mValues.BudgetValue, mValues.PreviousActualValue);
            }

            //Add the total
            Storage.ValueToStore("BPGSales");
            mReportStorage.AddDataRow(gsh2.HeadingDescription, MARowType.Total, Storage.Value);

            #endregion 2. Gross Sales

            #region 3. Net Sales

            tHeadingId = 3;
            Storage.Reset();

            var nsh = mStructure.HeadingItems[tHeadingId];

            //Add the Items
            foreach (var item in nsh.StructureItems)
            {
                mValues.GetActualValues(MAHelpers.GetAllAccountCodes(item), nsh.IncomeAsNegative);
                mValues.GetBudgetValue(MAHelpers.SetMAId(mReportId, tHeadingId, item.ItemId));

                Storage.Add(new MAPLStorageItem { ActualValue = mValues.ActualValue, BudgetValue = mValues.BudgetValue, PreviousActualValue = mValues.PreviousActualValue });

                mReportStorage.AddDataRow(item.ReportDescription, MARowType.Normal, mValues.ActualValue, mValues.BudgetValue, mValues.PreviousActualValue);
            }

            Storage.ValueToStore("BPReptos");
            //Add the total
            Storage.StoreToValue("BPGSales");
            Storage.Subtract("BPReptos");

            mReportStorage.AddDataRow(nsh.HeadingDescription, MARowType.Total, Storage.Value);

            #endregion 3. Net Sales
        }

        #endregion Methods
    }
}