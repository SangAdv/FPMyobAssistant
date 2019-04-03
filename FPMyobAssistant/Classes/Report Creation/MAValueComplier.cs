using LocalModelContext;
using SangAdv.Common.JSonExtensions;
using SangAdv.Common.PeriodExtensions;
using System.Collections.Generic;
using System.Linq;

namespace FPMyobAssistant
{
    internal class MAValueComplier
    {
        #region Variables

        private MAReportType mReportType = MAReportType.ProfitLoss;
        private List<string> mPeriods = new List<string>();

        private List<TLDPL> mPLData = MADataAccess.LocalData.TLDPLList();
        private List<TLDPLBudget> mPLBudgetData = MADataAccess.LocalData.TLDPLBudgetList();

        private List<TLDB> mBSData = MADataAccess.LocalData.TLDBSList();
        private List<TLDBSBudget> mBSBudgetData = MADataAccess.LocalData.TLDBSBudgetList();



        #endregion Variables

        #region Properties

        public float ActualValue { get; private set; } = 0;
        public float BudgetValue { get; private set; } = 0;
        public float PreviousActualValue { get; private set; } = 0;

        #endregion Properties

        #region Constructor

        internal MAValueComplier(MAReportType reportType, List<string> periods)
        {
            mPeriods = periods;
            mReportType = reportType;
        }

        #endregion Constructor

        #region Methods

        internal void GetActualValues(List<string> accounts, int incomeAsNegative)
        {
            ActualValue = 0;
            PreviousActualValue = 0;

            foreach (var period in mPeriods)
            {
                foreach (var account in accounts)
                {
                    var a = GetLocalActualValue(period, account);
                    if (MAGlobal.InvertIncomeSign(incomeAsNegative, account)) ActualValue -= a;
                    else ActualValue += a;

                    var pa = GetLocalActualValue(period.SubtractMonthPeriods(12), account);
                    if (MAGlobal.InvertIncomeSign(incomeAsNegative, account)) PreviousActualValue -= pa;
                    else PreviousActualValue += pa;
                }
            }
        }

        private float GetLocalActualValue(string period, string accountId)
        {
            if (mReportType == MAReportType.ProfitLoss)
            {
                var a = mPLData.Where(x => x.AccountId == accountId && x.Period == period).ToList();
                return a.Any() ? (float)a.First().Actual : 0;
            }
            else
            {
                var a = mBSData.Where(x => x.AccountId == accountId && x.Period == period).ToList();
                return a.Any() ? (float)a.First().Actual : 0;
            }
        }

        internal void GetBudgetValue(string maId)
        {
            BudgetValue = 0;
            var items = getStructureItems(maId);
            foreach (var item in items)
            {
                if (mReportType == MAReportType.ProfitLoss)
                {
                    foreach (var period in mPeriods) BudgetValue += getLocalBudgetValue(period, item);
                }
                else
                {
                    BudgetValue += getLocalBudgetValue(mPeriods.First(), item);
                }
            }
        }

        internal void GetBudgetValue(string period, string maId)
        {
            BudgetValue = getLocalBudgetValue(period, maId);
        }

        private List<string> getStructureItems(string maId)
        {
            var tList = new List<string>();
            var tItemDetail = MAHelpers.GetMAId(maId);
            var tStructItem = MADataAccess.LocalData.TLMReportStructureItem(tItemDetail.reportId, tItemDetail.headingId, tItemDetail.itemId);
            if (tStructItem.IsGrouping == 0)
            {
                tList.Add(maId);
            }
            else
            {
                var tItems = tStructItem.GroupItems.DeserializeObject<List<string>>();
                foreach (var item in tItems) tList.Add(item);
            }
            return tList;
        }

        private float getLocalBudgetValue(string period, string maId)
        {
            if (mReportType == MAReportType.ProfitLoss)
            {
                var a = mPLBudgetData.Where(x => x.MAId == maId && x.Period == period).ToList();
                return a.Any() ? (float)a.First().Budget : 0;
            }
            else
            {
                var a = mBSBudgetData.Where(x => x.MAId == maId && x.Period == period).ToList();
                return a.Any() ? (float)a.First().Budget : 0;
            }
        }

        #endregion Methods
    }
}