using System;

namespace FPMyobAssistant
{
    internal static class MADataAccess
    {
        #region Properties

        internal static MALocalAccess LocalData => localdata.Value;

        internal static MACloudAccess CloudData => clouddata.Value;

        internal static MADataSyncUpdate DataSyncUpdate => datasyncupdate.Value;


        #endregion Properties

        #region Singleton Implementation

        private static volatile Lazy<MALocalAccess> localdata = new Lazy<MALocalAccess>(() => new MALocalAccess());

        private static volatile Lazy<MACloudAccess> clouddata = new Lazy<MACloudAccess>(() => new MACloudAccess());

        private static volatile Lazy<MADataSyncUpdate> datasyncupdate = new Lazy<MADataSyncUpdate>(() => new MADataSyncUpdate());

        #endregion Singleton Implementation
    }
}