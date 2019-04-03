using SangAdv.Common.JSonExtensions;
using SangAdv.Common.ObjectExtensions;
using SangAdv.Common.StringExtensions;
using System;
using System.Collections.Generic;

namespace FPMyobAssistant
{
    internal class MAHelpers
    {
        #region Methods

        internal Dictionary<string, string> FinancialPeriods { get; } = new Dictionary<string, string>();

        #endregion Methods

        #region Constructor

        internal MAHelpers(bool isBudget = false)
        {
            CreateFinancialPeriods(isBudget);
        }

        #endregion Constructor

        #region Private Methods

        private void CreateFinancialPeriods(bool isBudget = false)
        {
            FinancialPeriods.Clear();

            if (isBudget)
            {
                for (var year = 2015; year <= DateTime.Now.AddYears(1).Year; year++) FinancialPeriods.Add(year.ToString(), $"1/{year} - 12/{year}");
            }
            else
            {
                var tMonth = DateTime.Now.Month;
                var tYear = DateTime.Now.Year;
                if (tMonth > 6) tYear++;

                for (var year = 2016; year <= tYear; year++) FinancialPeriods.Add(year.ToString(), $"7/{year - 1} - 6/{year}");
            }
        }

        #endregion Private Methods

        #region Static Methods

        internal static MABSStorageItem FromPLStorageItem(MAPLStorageItem storageItem)
        {
            return new MABSStorageItem { ActualValue = storageItem.ActualValue, PreviousActualValue = storageItem.PreviousActualValue, BudgetValue = storageItem.BudgetValue };
        }

        internal static string SetMAId(int reportId, int headingId, int itemId)
        {
            return $"({reportId})[{headingId}]<{itemId}>";
        }

        internal static (int reportId, int headingId, int itemId) GetMAId(string maId)
        {
            var tReportId = maId.GetID("(", ")");
            var tHeadingId = maId.GetID("[", "]");
            var tItemId = maId.GetID("<", ">");

            return (tReportId.Value<int>(), tHeadingId.Value<int>(), tItemId.Value<int>());
        }

        internal static List<string> GetAllAccountCodes(MAReportStructureItem structItem)
        {
            if (!structItem.IsGrouping) return structItem.AccountItems;

            var tList = new List<string>();

            foreach (var item in structItem.GroupItems)
            {
                foreach (var account in GetDeserialisedAccountList(item)) tList.Add(account);
            }

            return tList;
        }

        #endregion Static Methods

        #region Private Static Methods

        private static List<string> GetDeserialisedAccountList(string item)
        {
            var tMaid = GetMAId(item);
            var structItem = MADataAccess.LocalData.TLMReportStructureItem(tMaid.reportId, tMaid.headingId, tMaid.itemId);

            if (string.IsNullOrEmpty(structItem.AccountItems)) return new List<string>();
            try
            {
                var tList = structItem.AccountItems.DeserializeObject<List<string>>();
                return tList ?? new List<string>();
            }
            catch
            {
                return new List<string>();
            }
        }

        #endregion Private Static Methods
    }
}