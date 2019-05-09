using SangAdv.Common;
using System.Threading.Tasks;

namespace FPMyobAssistant
{
    public class MADataSyncUpdate
    {
        #region Events

        public event StringDelegate MessageChanged = s => { };

        #endregion Events

        #region Variables

        private SAAzureSyncUpdateFramework<string, MACUpdateItem> mSyncUpdate;

        #endregion Variables

        #region Properties

        public bool HasSyncItems => mSyncUpdate.Sync.HasSyncItems;

        #endregion Properties

        #region Constructor

        public MADataSyncUpdate()
        {
            var options = new SAAzureUpdateAzureOptions(MAGlobal.CloudConn, MAUpdateItem.UpdateData);
            mSyncUpdate = new SAAzureSyncUpdateFramework<string, MACUpdateItem>(new MASyncDataLocal(), new MADataUpdateLocal(), options);
        }

        #endregion Constructor

        #region Methods

        public async Task InitialiseAsync() => await mSyncUpdate.InitialiseAsync();

        public async Task DoUpdateAsync()
        {
            var success = await mSyncUpdate.Update.DoUpdateAsync();
            if (success) await mSyncUpdate.Update.SaveAsync();
        }

        public async Task<bool> CheckHasUpdateAsync() => await mSyncUpdate.Update.CheckUpdateAsync(true, true);

        public async Task AddAsync(SASyncDataItem item)
        {
            mSyncUpdate.Sync.Add(item);
            await mSyncUpdate.Sync.SaveAsync();
        }

        public async void SaveAllAsync()
        {
            await mSyncUpdate.SaveAllAsync();
        }

        public async Task DoSyncAsync() => await mSyncUpdate.Sync.DoSyncAsync();

        #endregion Methods
    }
}