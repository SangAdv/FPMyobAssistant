using SangAdv.Common;
using SangAdv.Common.Cloud;
using SangAdv.Common.StringExtensions;
using System.Threading.Tasks;

namespace FPMyobAssistant
{
    public sealed class MADataUpdateRemote : ASAUpdateFWRemoteData<MACUpdateItem>
    {
        #region Variables

        private SAAzureTableStorage mStor;

        #endregion Variables

        #region Constructor

        public MADataUpdateRemote()
        {
            mStor = new SAAzureTableStorage(MAGlobal.CloudConn);
        }

        #endregion Constructor

        #region Abstract Methods

        public override async ValueTask LoadAsync()
        {
            Clear();
            Error.ClearErrorMessage();
            var t = await mStor.GetAllAsync<MACUpdateItem>(MAUpdateItem.UpdateData, MACPartitionNames.Item);
            foreach (var item in t)
            {
                var type = getTypes(item.Key);
                var data = new SAUpdateRemoteDataItem<MACUpdateItem> { MainType = type.mainType, SubType = type.subType, DataDate = item.Value.UTCDateTimeSecondSynced };
                data.SetPayload(item.Value);

                Add(data);
            }
        }

        public override ValueTask SaveAsync(SAUpdateRemoteDataItem<MACUpdateItem> data)
        {
            throw new System.NotImplementedException();
        }

        #endregion Abstract Methods

        #region Private Methods

        private (string mainType, string subType) getTypes(string variant)
        {
            try
            {
                var index = variant.IndexOf('-', 0);
                if (index == 0) return (variant.Trim(), "");
                return (variant.Left(index), variant.Right(variant.Length - index - 1));
            }
            catch
            {
                return (variant.Trim(), "");
            }
        }

        #endregion Private Methods
    }
}