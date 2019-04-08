using SangAdv.Common;
using SangAdv.Common.Cloud;
using System;
using System.Threading.Tasks;

namespace FPMyobAssistant
{
    public class MACSettings
    {
        #region Variables

        private SAAzureTableStorage mStor;

        #endregion Variables

        #region Properties

        public MACSettingsItem Settings = new MACSettingsItem();
        public string ErrorMessage { get; private set; } = string.Empty;

        #endregion Properties

        #region Constructor

        public MACSettings(SAAzureTableStorage stor)
        {
            mStor = stor;
        }

        #endregion Constructor

        #region Methods

        public async Task<SAEventArgs> SaveAsync()
        {
            try
            {
                await mStor.InsertOrReplaceAsync(MACTableNames.SettingData, MACPartitionNames.Item, "1", Settings);
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
                var tItem = await mStor.GetAsync<MACSettingsItem>(MACTableNames.SettingData, MACPartitionNames.Item, "1");
                Settings = tItem ?? new MACSettingsItem();
                return true;
            }
            catch
            {
                Settings = new MACSettingsItem();
                return false;
            }
        }

        #endregion Methods
    }
}