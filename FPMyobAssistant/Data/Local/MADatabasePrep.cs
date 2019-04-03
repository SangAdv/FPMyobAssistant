using LocalModelContext;
using SangAdv.Common;
using SangAdv.SQLite;
using System;

namespace FPMyobAssistant
{
    internal sealed partial class MALocalAccess
    {
        #region Variables

        private SQLiteServer mServer;

        #endregion Variables

        #region Properties

        internal bool HasError => ErrorMessage != string.Empty;
        internal bool IsSuccess => ErrorMessage == string.Empty;
        internal string ErrorMessage { get; private set; } = string.Empty;

        #endregion Properties

        #region Methods

        internal bool PrepareDatabase()
        {
            ErrorMessage = string.Empty;

            var connString = SQLiteGlobal.DatabaseConnectionString(MAGlobal.LocalDbPath);

            try
            {
                using (var db = new LocalModelDataContext(connString))
                {
                    if (!db.DatabaseExists()) db.CreateDatabase();
                }
                mServer = new SQLiteServer(MAGlobal.LocalDbPath);
                if (mServer.HasError) throw new Exception(mServer.ErrorMessage);
                UpdateDatabase();
                MAGlobal.Logging.LogEvent(SALogLevel.Trace, "Database created.", "pharmatrack.Custom", "PrepCustomDatabase", "OpenABGDataBase");
                return true;
            }
            catch (Exception ex)
            {
                MAGlobal.Logging.LogEvent(SALogLevel.Trace, $"Database not created: {ex.Message}", "pharmatrack.Custom", "PrepCustomDatabase", "OpenABGDataBase");
                ErrorMessage = ex.Message;
                return false;
            }
        }

        internal void Vacuum()
        {
            mServer.Database.Vacuum();
        }

        #endregion Methods

        #region Private Methods

        private void UpdateDatabase()
        {
            UpdateDatabase1();
        }

        private void UpdateDatabase1()
        {
            //var xlsxPath = Path.Combine(Application.StartupPath, @"Data\", "FPDHLImport.xlsx");
            //File.WriteAllBytes(xlsxPath, Properties.Resources.FPDHLImport);
            //Application.DoEvents();
            //var ei = new SAExcelImport(xlsxPath);
            //for (var i = 0; i < 1000000; i++)
            //{
            //    if (string.IsNullOrEmpty(ei.GetText(i, 0))) break;
            //    var cnm = new TLDDHLCustomerNumber { Id = ei.GetText(i, 0), CustomerName = ei.GetText(i, 1), MYOBCardId = ei.GetText(i, 2) };
            //    MADataAccess.LocalData.TLDDHLCustomerNumberUpdate(cnm);
            //}
        }

        #endregion Private Methods
    }
}