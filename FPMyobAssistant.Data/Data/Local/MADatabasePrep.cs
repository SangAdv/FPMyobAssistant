using LocalModelContext;
using SangAdv.Common;
using SangAdv.DevExpressUI;
using SangAdv.SQLite;
using System;
using System.Collections.Generic;
using System.IO;

namespace FPMyobAssistant
{
    public sealed partial class MALocalAccess
    {
        #region Variables

        private SQLiteServer mServer;
        private SAExcelImport mImport;

        #endregion Variables

        #region Properties

        internal bool HasError => ErrorMessage != string.Empty;
        internal bool IsSuccess => ErrorMessage == string.Empty;
        public string ErrorMessage { get; private set; } = string.Empty;
        public SQLiteDatabase Database => mServer.Database;

        #endregion Properties

        #region Methods

        public bool PrepareDatabase()
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
                updateDatabase();
                updateMasterData();
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

        public void Vacuum()
        {
            mServer.Database.Vacuum();
        }

        #endregion Methods

        #region Private Methods

        private void updateDatabase()
        {
            updateDatabase1();
        }

        private void updateDatabase1()
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

        private void updateMasterData()
        {
            if (File.Exists(MAGlobal.MasterDataPath))
            {
                if (loadMasterData())
                {
                    File.Delete(MAGlobal.MasterDataPath);
                }
            }
        }

        private bool loadMasterData()
        {
            mImport = new SAExcelImport(MAGlobal.MasterDataFilename);

            if (!updateTLDKKCustomerNumber()) return false;
            if (!updateTLMDistributor()) return false;
            if (!updateTLMReportHeadings()) return false;
            if (!updateTLMReports()) return false;
            return true;
        }

        #region Update MasterData

        private bool updateTLDKKCustomerNumber()
        {
            try
            {
                MADataAccess.LocalData.TLDKKCustomerNumberDeleteAll();

                var tList = new List<TLDKKCustomerNumber>();
                mImport.SetActiveSheet("TLDKKCustomerNumber");

                for (var i = 0; i < 1000000; i++)
                {
                    if (string.IsNullOrEmpty(mImport.GetText(i, 0))) break;
                    tList.Add(new TLDKKCustomerNumber { Id = mImport.GetText(i, 0), CustomerName = mImport.GetText(i, 1), MYOBCardId = mImport.GetText(i, 2) });
                }

                MADataAccess.LocalData.TLDKKCustomerNumberUpdate(tList);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool updateTLMDistributor()
        {
            try
            {
                MADataAccess.LocalData.TLMDistributorDeleteAll();

                var tList = new List<TLMDistributor>();
                mImport.SetActiveSheet("TLMDistributor");

                for (var i = 0; i < 1000000; i++)
                {
                    if (string.IsNullOrEmpty(mImport.GetText(i, 0))) break;
                    tList.Add(new TLMDistributor { DistributorId = mImport.GetValue<int>(i, 0), Distributor = mImport.GetText(i, 1), CardId = mImport.GetText(i, 2) });
                }

                MADataAccess.LocalData.TLMDistributorUpdate(tList);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool updateTLMReportHeadings()
        {
            try
            {
                MADataAccess.LocalData.TLMReportHeadingsDeleteAll();

                var tList = new List<TLMReportHeading>();
                mImport.SetActiveSheet("TLMReportHeadings");

                for (var i = 0; i < 1000000; i++)
                {
                    if (string.IsNullOrEmpty(mImport.GetText(i, 0))) break;
                    tList.Add(new TLMReportHeading { ReportId = mImport.GetValue<int>(i, 0), HeadingId = mImport.GetValue<int>(i, 1), ReportHeading = mImport.GetText(i, 2), IsCalculation = mImport.GetValue<int>(i, 3), HasChildren = mImport.GetValue<int>(i, 4), IncomeAsNegative = mImport.GetValue<int>(i, 5) });
                }

                MADataAccess.LocalData.TLMReportHeadingsUpdate(tList);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool updateTLMReports()
        {
            try
            {
                MADataAccess.LocalData.TLMReportsDeleteAll();

                var tList = new List<TLMReport>();
                mImport.SetActiveSheet("TLMReports");

                for (var i = 0; i < 1000000; i++)
                {
                    if (string.IsNullOrEmpty(mImport.GetText(i, 0))) break;
                    MADataAccess.LocalData.TLMReportsUpdate((new TLMReport { ReportId = mImport.GetValue<int>(i, 0), ReportType = mImport.GetValue<int>(i, 1), ReportDescription = mImport.GetText(i, 2), StatusId = mImport.GetValue<int>(i, 3) }));
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion Update MasterData

        #endregion Private Methods
    }
}