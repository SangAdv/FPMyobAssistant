using SangAdv.Common;
using SangAdv.Common.Cloud;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FPMyobAssistant
{
    public sealed class MACReportStructure
    {
        #region Variables

        private const int mReportCount = 5;
        private SAAzureTableStorage mStor;
        private Dictionary<int, List<MACReportStructureItem>> mStructure = new Dictionary<int, List<MACReportStructureItem>>();

        #endregion Variables

        #region Properties

        public int ReportCount => mReportCount;
        public string ErrorMessage { get; private set; } = string.Empty;

        #endregion Properties

        #region Constructor

        public MACReportStructure(SAAzureTableStorage stor)
        {
            mStor = stor;
        }

        #endregion Constructor

        #region Methods

        public async Task<SAEventArgs> SaveAsync(int reportId)
        {
            try
            {
                await mStor.InsertOrReplaceAsync(MAUpdateItem.ReportStructure, MACPartitionNames.ReportStructure, reportId.ToString(), mStructure[reportId]);
                return new SAEventArgs();
            }
            catch (Exception ex)
            {
                return new SAEventArgs(ex.Message, SAResults.Database.SaveError);
            }
        }

        public async Task<bool> LoadAsync(int reportId)
        {
            try
            {
                var tReportHeading = await mStor.GetAsync<List<MACReportStructureItem>>(MAUpdateItem.ReportStructure, MACPartitionNames.ReportStructure, reportId.ToString());
                mStructure[reportId] = tReportHeading ?? new List<MACReportStructureItem>();
                return true;
            }
            catch
            {
                mStructure[reportId] = new List<MACReportStructureItem>();
                return false;
            }
        }

        public List<MACReportStructureItem> Get(int reportId)
        {
            if (mStructure.ContainsKey(reportId)) return mStructure[reportId];
            return new List<MACReportStructureItem>();
        }

        public void Clear(int reportId) => mStructure[reportId] = new List<MACReportStructureItem>();

        public void Add(int reportId, MACReportStructureItem structureItem) => mStructure[reportId].Add(structureItem);

        #endregion Methods
    }
}