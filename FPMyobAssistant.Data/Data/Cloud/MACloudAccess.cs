using SangAdv.Common;
using SangAdv.Common.Cloud;
using System;

namespace FPMyobAssistant
{
    public sealed class MACloudAccess : SAErrorBase
    {
        #region Properties

        public MACAccounts Accounts { get; private set; }
        public MACBudgets Budgets { get; private set; }
        public MACCustomerNumbers CustomerNumbers { get; private set; }
        public MACImportExclusions ImportExclusions { get; private set; }
        public MACReportStructure Structure { get; private set; }
        public MACSettings Settings { get; private set; }

        public MACUpdates Updates { get; private set; }

        public MACUsers Users { get; private set; }

        #endregion Properties

        #region Constructor

        public MACloudAccess()
        {
            Error.ClearErrorMessage();
            try
            {
                var tStor = new SAAzureTableStorage(MAGlobal.CloudConn);

                Users = new MACUsers(tStor);
                Updates = new MACUpdates(tStor);
                CustomerNumbers = new MACCustomerNumbers(tStor);
                Budgets = new MACBudgets(tStor);
                Structure = new MACReportStructure(tStor);
                Accounts = new MACAccounts(tStor);
                ImportExclusions = new MACImportExclusions(tStor);
                Settings = new MACSettings(tStor);
            }
            catch (Exception ex)
            {
                Error.SetErrorMessage(ex.Message);
            }
        }

        #endregion Constructor
    }
}