using SangAdv.Common;
using SangAdv.Common.Cloud;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FPMyobAssistant
{
    internal class MACAccounts
    {
        #region Variables

        private SAAzureTableStorage mStor;

        #endregion Variables

        #region Properties

        public List<MACAccountItem> Accounts = new List<MACAccountItem>();
        public string ErrorMessage { get; private set; } = string.Empty;

        #endregion Properties

        #region Constructor

        public MACAccounts(SAAzureTableStorage stor)
        {
            mStor = stor;
        }

        #endregion Constructor

        #region Methods

        public async Task<SAEventArgs> SaveAsync(MAReportType type)
        {
            try
            {
                await mStor.InsertOrReplaceAsync(MACTableNames.AccountData, MACPartitionNames.ReportType, type.ToString(), Accounts);
                return new SAEventArgs();
            }
            catch (Exception ex)
            {
                return new SAEventArgs(ex.Message, SAResults.Database.SaveError);
            }
        }

        public async Task<bool> LoadAsync(MAReportType type)
        {
            try
            {
                var tAccounts = await mStor.GetAsync<List<MACAccountItem>>(MACTableNames.AccountData, MACPartitionNames.ReportType, type.ToString());
                Accounts = tAccounts ?? new List<MACAccountItem>();
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