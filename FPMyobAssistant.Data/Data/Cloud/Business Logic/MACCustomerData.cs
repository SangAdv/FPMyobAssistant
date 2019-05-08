using SangAdv.Common;
using SangAdv.Common.Cloud;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FPMyobAssistant
{
    public class MACCustomerData
    {
        #region Variables

        private SAAzureTableStorage mStor;

        #endregion Variables

        #region Properties

        public List<MACCustomerNumberItem> Accounts = new List<MACCustomerNumberItem>();
        public string ErrorMessage { get; private set; } = string.Empty;

        #endregion Properties

        #region Constructor

        public MACCustomerData(SAAzureTableStorage stor)
        {
            mStor = stor;
        }

        #endregion Constructor

        #region Methods

        public async Task<SAEventArgs> SaveAsync(string variant)
        {
            try
            {
                await mStor.InsertOrReplaceAsync(MAUpdateItem.CustomerData, MACPartitionNames.MYOBId, variant, Accounts);
                return new SAEventArgs();
            }
            catch (Exception ex)
            {
                return new SAEventArgs(ex.Message, SAResults.Database.SaveError);
            }
        }

        public async Task<bool> LoadAsync(string variant)
        {
            try
            {
                var tAccounts = await mStor.GetAsync<List<MACCustomerNumberItem>>(MAUpdateItem.CustomerData, MACPartitionNames.MYOBId, variant);
                Accounts = tAccounts ?? new List<MACCustomerNumberItem>();
                return true;
            }
            catch
            {
                Accounts.Clear();
                return false;
            }
        }

        #endregion Methods
    }
}