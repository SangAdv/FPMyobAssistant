using LocalModelContext;
using SangAdv.Common;
using SangAdv.Common.Cloud;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FPMyobAssistant
{
    public sealed class MACDistributorProductAccount
    {
        #region Variables

        private SAAzureTableStorage mStor;

        #endregion Variables

        #region Properties

        public List<TLDDistributorProductAccountId> Accounts = new List<TLDDistributorProductAccountId>();
        public string ErrorMessage { get; private set; } = string.Empty;

        #endregion Properties

        #region Constructor

        public MACDistributorProductAccount(SAAzureTableStorage stor)
        {
            mStor = stor;
        }

        #endregion Constructor

        #region Methods

        public async Task<SAEventArgs> SaveAsync()
        {
            try
            {
                await mStor.InsertOrReplaceAsync(MAUpdateItem.DistributorProductAccount, MACPartitionNames.Item, MAUpdateItemVariant.All, Accounts);
                return new SAEventArgs();
            }
            catch (Exception ex)
            {
                return new SAEventArgs(ex.Message, SAResults.Database.SaveError);
            }
        }

        public async Task<bool> LoadAsync()
        {
            try
            {
                var tAccounts = await mStor.GetAsync<List<TLDDistributorProductAccountId>>(MAUpdateItem.DistributorProductAccount, MACPartitionNames.Item, MAUpdateItemVariant.All);
                Accounts = tAccounts ?? new List<TLDDistributorProductAccountId>();
                return true;
            }
            catch
            {
                Accounts.Clear();
                return false;
            }
        }

        public void Clear()
        {
            Accounts.Clear();
        }

        #endregion Methods
    }
}