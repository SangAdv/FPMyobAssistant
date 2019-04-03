using SangAdv.Common;
using SangAdv.Common.StringExtensions;
using SangAdv.Updater.Client;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FPMyobAssistant
{
    internal static class MAGlobal
    {
        #region Constants

        internal const string CloudConn = @"DefaultEndpointsProtocol=https;AccountName=safptable;AccountKey=FZEFStOjnPKR4PqfGSbhPMP1lhtyfdiO7LHvRHL3hzUvl9y726hlYi1zR3wwrdGvqGcega4kzFED/dhrERI8cQ==;EndpointSuffix=core.windows.net";

        #endregion Constants

        #region Properties

        internal static bool IsConnected { get; set; } = false;

        internal static bool LoadDataSyncControl { get; set; } = false;

        internal static SAWinUpdate Update { get; } = new SAWinUpdate();

        internal static MAStartup StartUpSettings { get; private set; }

        internal static SALogging Logging { get; private set; }

        internal static MANodeExpanded Expanded { get; private set; }

        internal static SAValueStore<MAPLStorageItem> PLStoreSelected { get; private set; }

        internal static SAValueStore<MAPLStorageItem> PLStoreYTD { get; private set; }

        internal static string LocalDbPath
        {
            get
            {
                //==============================================================================
                //var path = Path.Combine(Application.StartupPath, @"Data\");
                //if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                //return Path.Combine(path, "FPMyob.sdb");
                //==============================================================================
                return Path.Combine(@"C:\Github\FPMyobAssistant\Data\", "FPMyob.sdb");
                //==============================================================================
            }
        }

        #endregion Properties

        #region Methods

        internal static void Initialise()
        {
            PLStoreSelected = new SAValueStore<MAPLStorageItem>();
            PLStoreYTD = new SAValueStore<MAPLStorageItem>();

            Expanded = new MANodeExpanded();
            StartUpSettings = new MAStartup();
            Logging = new SALogging();
            Logging.CreateLogTarget(Path.Combine(Application.StartupPath, @"Logs\"));
            //Clear Logs directory
            Logging.LogEvent(SALogLevel.Trace, "Clearing Logs directory.", "Desktop", "Main", "Preparing Directories");
            var a = Directory.GetFiles(Path.Combine(Application.StartupPath, @"Logs\")).OrderBy(x => x).ToList();
            if (a.Count > 3)
            {
                var b = a.Take(a.Count - 3);
                foreach (var br in b) File.Delete(br);
            }
        }

        internal static bool InvertIncomeSign(int incomeAsNegative, string accountCode)
        {
            if (incomeAsNegative == 0) return false;
            var tTemp = accountCode.RemoveLeadingZeros();
            return tTemp.Left(1) == "4"; //P&L income range Income
        }

        #endregion Methods
    }
}