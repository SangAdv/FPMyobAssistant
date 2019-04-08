using SangAdv.Common;
using SangAdv.Common.Cloud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPMyobAssistant
{
    public class MACUpdates
    {
        #region Variables

        private SAAzureTableStorage mStor;
        private Dictionary<string, MACUpdateItem> mUpdates = new Dictionary<string, MACUpdateItem>();

        #endregion Variables

        #region Properties

        public string ErrorMessage { get; private set; } = string.Empty;
        public List<MACUpdateItem> UpdateList => mUpdates.Values.ToList();

        #endregion Properties

        #region Constructor

        public MACUpdates(SAAzureTableStorage stor)
        {
            mStor = stor;
        }

        #endregion Constructor

        #region Methods

        public async Task<SAEventArgs> SaveAsync(string updateItem, string variant)
        {
            try
            {
                var ui = new MACUpdateItem { UpdatedBy = MADataAccess.CloudData.Users.SelectedUserEmail, UpdateItem = updateItem, UTCDateTimeSecondSynced = SADateTimeValues.UtcNowDateTimeSecondString, Variant = variant };

                await mStor.InsertOrReplaceAsync(MACTableNames.UpdateData, MACPartitionNames.Item, $"{updateItem}-{variant}", ui);

                return new SAEventArgs();
            }
            catch (Exception ex)
            {
                return new SAEventArgs(ex.Message, SAResults.Database.SaveError);
            }
        }

        public async Task LoadAllAsync()
        {
            try
            {
                mUpdates.Clear();
                var t = await mStor.GetAllAsync<MACUpdateItem>(MACTableNames.UpdateData, MACPartitionNames.Item);
                foreach (var item in t) mUpdates[item.Key] = item.Value;
            }
            catch
            {
                mUpdates.Clear();
            }
        }

        #endregion Methods
    }
}