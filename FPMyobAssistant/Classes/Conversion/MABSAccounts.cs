using LocalModelContext;
using SangAdv.Common.StringExtensions;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FPMyobAssistant
{
    internal class MABSAccounts
    {
        #region Properties

        internal List<TLMBSAccount> Accounts { get; private set; } = new List<TLMBSAccount>();

        internal List<TLMBSAccount> NoChildAccounts
        {
            get
            {
                var tList = new List<TLMBSAccount>();
                foreach (var account in Accounts)
                {
                    if (!HasChildren(account.AccountId)) tList.Add(account);
                }

                return tList;
            }
        }

        #endregion Properties

        #region Constructor

        internal MABSAccounts()
        {
            LoadData();
        }

        #endregion Constructor

        #region Methods

        internal bool BSAccountIsPresent(string accountId, string accountDescription, bool updateDescription)
        {
            accountId = accountId.Trim().AddLeadingZeros(10);

            var exists = Accounts.Any(x => x.AccountId == accountId);
            if (updateDescription && exists)
            {
                var tItems = Accounts.Where(x => x.AccountId == accountId).ToList();
                if (tItems.First().AccountDescription != accountDescription)
                {
                    var tItem = tItems.First();
                    tItem.AccountDescription = accountDescription;
                    Update(tItem);
                }
            }

            return exists;
        }

        internal bool Add(string accountId, string accountDescription)
        {
            var tDescription = $"{accountId} > {accountDescription}";
            accountId = accountId.Trim().AddLeadingZeros(10);

            var tDictionary = new Dictionary<string, string>();
            foreach (var item in Accounts) tDictionary.Add(item.AccountId.ToString().Trim().AddLeadingZeros(10), item.AccountDescription);
            var f = new frmChooseParent(tDictionary, tDescription);
            if (f.ShowDialog() == DialogResult.Cancel) return false;
            var parentAccountId = f.ParentAccountId;

            MADataAccess.LocalData.TLMBSAccountUpdate(new TLMBSAccount() { AccountId = accountId, AccountDescription = accountDescription, ParentAccountId = parentAccountId });
            LoadData();
            return true;
        }

        internal TLMBSAccount Get(string accountId)
        {
            var a = Accounts.Where(x => x.AccountId == accountId).ToList();
            return a.Any() ? a.First() : new TLMBSAccount();
        }

        internal void Update(TLMBSAccount data)
        {
            MADataAccess.LocalData.TLMBSAccountUpdate(data);
            LoadData();
        }

        #endregion Methods

        #region Private Methods

        private void LoadData()
        {
            Accounts = MADataAccess.LocalData.TLMBSAccountList();
        }

        private bool HasChildren(string accountId)
        {
            return Accounts.Any(x => x.ParentAccountId == accountId);
        }

        #endregion Private Methods
    }
}