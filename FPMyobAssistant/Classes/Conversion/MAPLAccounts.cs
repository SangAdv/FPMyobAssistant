using LocalModelContext;
using SangAdv.Common.StringExtensions;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FPMyobAssistant
{
    internal class MAPLAccounts
    {
        #region Properties

        internal List<TLMPLAccount> Accounts { get; private set; } = new List<TLMPLAccount>();

        #endregion Properties

        #region Constructor

        internal MAPLAccounts()
        {
            LoadData();
        }

        #endregion Constructor

        #region Methods

        internal bool PLAccountIsPresent(string accountId, string accountDescription, bool updateDescription)
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
            foreach (var item in Accounts) tDictionary.Add(item.AccountId, item.AccountDescription);
            var f = new frmChooseParent(tDictionary, tDescription);
            if (f.ShowDialog() == DialogResult.Cancel) return false;
            var parentAccountId = f.ParentAccountId;

            MADataAccess.LocalData.TLMPLAccountUpdate(new TLMPLAccount { AccountId = accountId, AccountDescription = accountDescription, ParentAccountId = parentAccountId });
            LoadData();
            return true;
        }

        internal TLMPLAccount Get(string accountId)
        {
            var a = Accounts.Where(x => x.AccountId == accountId).ToList();
            return a.Any() ? a.First() : new TLMPLAccount();
        }

        internal void Update(TLMPLAccount data)
        {
            MADataAccess.LocalData.TLMPLAccountUpdate(data);
            LoadData();
        }

        #endregion Methods

        #region Private Methods

        private void LoadData()
        {
            Accounts = MADataAccess.LocalData.TLMPLAccountList();
        }

        #endregion Private Methods
    }
}