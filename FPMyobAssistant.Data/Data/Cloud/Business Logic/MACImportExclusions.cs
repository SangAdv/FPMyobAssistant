using SangAdv.Common;
using SangAdv.Common.Cloud;
using System;
using System.Threading.Tasks;

namespace FPMyobAssistant
{
    public class MACImportExclusions
    {
        #region Variables

        private SAAzureTableStorage mStor;

        #endregion Variables

        #region Properties

        public string ErrorMessage { get; private set; } = string.Empty;
        public MACImportExclusionItems Item { get; private set; } = new MACImportExclusionItems();

        #endregion Properties

        #region Constructor

        public MACImportExclusions(SAAzureTableStorage stor)
        {
            mStor = stor;
        }

        #endregion Constructor

        #region Methods

        public async Task<SAEventArgs> SaveAsync(MACImportExclusionItems data)
        {
            try
            {
                await mStor.InsertOrReplaceAsync(MACTableNames.ExclusionData, MACPartitionNames.Item, data.Period, data);
                return new SAEventArgs();
            }
            catch (Exception ex)
            {
                return new SAEventArgs(ex.Message, SAResults.Database.SaveError);
            }
        }

        public async Task<bool> LoadAsync(string period)
        {
            try
            {
                var tItem = await mStor.GetAsync<MACImportExclusionItems>(MACTableNames.ExclusionData, MACPartitionNames.Item, period);
                Item = tItem ?? new MACImportExclusionItems();
                return true;
            }
            catch
            {
                Item = new MACImportExclusionItems();
                return false;
            }
        }

        #endregion Methods
    }
}