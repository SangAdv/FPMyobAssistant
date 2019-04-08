using SangAdv.Common;
using SangAdv.Common.Cloud;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FPMyobAssistant
{
    public class MACCustomerNumbers
    {
        #region Variables

        private SAAzureTableStorage mStor;

        #endregion Variables

        #region Properties

        public List<MACCustomerNumberItem> Accounts = new List<MACCustomerNumberItem>();
        public string ErrorMessage { get; private set; } = string.Empty;

        #endregion Properties

        #region Constructor

        public MACCustomerNumbers(SAAzureTableStorage stor)
        {
            mStor = stor;
        }

        #endregion Constructor

        #region Methods

        public async Task<SAEventArgs> SaveAsync()
        {
            try
            {
                await mStor.InsertOrReplaceAsync(MACTableNames.CustomerData, MACPartitionNames.MYOBId, "DHL", Accounts);
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
                var tAccounts = await mStor.GetAsync<List<MACCustomerNumberItem>>(MACTableNames.CustomerData, MACPartitionNames.MYOBId, "DHL");
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