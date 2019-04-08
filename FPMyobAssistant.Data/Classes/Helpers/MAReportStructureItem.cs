using SangAdv.Common.ListExtensions;
using System.Collections.Generic;

namespace FPMyobAssistant
{
    public class MAReportStructureItem
    {
        #region Properties

        public int HeadingId { get; set; }
        public int ItemId { get; set; }
        public string ReportDescription { get; set; } = string.Empty;
        public List<string> AccountItems { get; set; } = new List<string>();
        public List<string> GroupItems { get; set; } = new List<string>();
        public bool IsGrouping { get; set; }
        public int SequenceIndex { get; set; } = 0;

        #endregion Properties

        #region Derived Properties

        public int AccountCount => AccountItems.Count;
        public int GroupCount => GroupItems.Count;

        #endregion Derived Properties

        #region Methods

        #region Accounts

        public void AddAccount(string accountCode)
        {
            AccountItems.AddUnique(accountCode);
        }

        public void AddAccounts(List<string> accountCodes)
        {
            foreach (var accountCode in accountCodes)
                AddAccount(accountCode);
        }

        public void RemoveAccountCode(string accontCode)
        {
            if (HasAccount(accontCode)) AccountItems.Remove(accontCode);
        }

        public void RemoveAllAccountCodes()
        {
            AccountItems.Clear();
        }

        public bool HasAccount(string accountCode)
        {
            return AccountItems.Contains(accountCode);
        }

        #endregion Accounts

        #region Groups

        public void AddGroup(string groupCode)
        {
            GroupItems.AddUnique(groupCode);
        }

        public void AddGroups(List<string> groupCodes)
        {
            foreach (var groupCode in groupCodes)
                AddGroup(groupCode);
        }

        public void RemoveGroupCode(string groupCode)
        {
            if (HasGroup(groupCode)) GroupItems.Remove(groupCode);
        }

        public void RemoveAllGroupCodes()
        {
            GroupItems.Clear();
        }

        public bool HasGroup(string groupCode)
        {
            return GroupItems.Contains(groupCode);
        }

        #endregion Groups

        #endregion Methods
    }
}