using LocalModelContext;
using System.Collections.Generic;
using System.Linq;

namespace FPMyobAssistant
{
    internal sealed partial class MALocalAccess
    {
        #region TLDBS

        internal List<TLDB> TLDBSList()
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLDBs.ToList();
            }
        }

        #endregion TLDBS

        #region TLDBSBudget

        internal List<TLDBSBudget> TLDBSBudgetList()
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLDBSBudgets.ToList();
            }
        }

        internal List<TLDBSBudget> TLDBSBudgetList(string period)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLDBSBudgets.Where(x => x.Period == period).ToList();
            }
        }

        #endregion TLDBSBudget

        #region TLDDHLCustomerNumber

        internal TLDDHLCustomerNumber TLDDHLCustomerNumberItem(string Id)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                var a = db.TLDDHLCustomerNumbers.Where(x => x.Id == Id);
                return a.Any() ? a.First() : new TLDDHLCustomerNumber { Id = string.Empty };
            }
        }

        internal List<TLDDHLCustomerNumber> TLDDHLCustomerNumberList()
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLDDHLCustomerNumbers.ToList();
            }
        }

        #endregion TLDDHLCustomerNumber

        #region TLDDHLInvoiceExclusions

        internal TLDDHLInvoiceExclusion TLDDHLInvoiceExclusionsItem(string period)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                var a = db.TLDDHLInvoiceExclusions.Where(x => x.Period == period);
                return a.Any() ? a.First() : new TLDDHLInvoiceExclusion { Period = period };
            }
        }

        #endregion TLDDHLInvoiceExclusions

        #region TLDKKCustomerNumber

        internal TLDKKCustomerNumber TLDKKCustomerNumberItem(string Id)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                var a = db.TLDKKCustomerNumbers.Where(x => x.Id == Id);
                return a.Any() ? a.First() : new TLDKKCustomerNumber { Id = string.Empty };
            }
        }

        internal List<TLDKKCustomerNumber> TLDKKCustomerNumberList()
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLDKKCustomerNumbers.ToList();
            }
        }

        #endregion TLDKKCustomerNumber

        #region TLDPL

        internal List<TLDPL> TLDPLList()
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLDPLs.ToList();
            }
        }

        #endregion TLDPL

        #region TLDPLBudget

        internal List<TLDPLBudget> TLDPLBudgetList()
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLDPLBudgets.ToList();
            }
        }

        internal List<TLDPLBudget> TLDPLBudgetList(string period)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLDPLBudgets.Where(x => x.Period == period).ToList();
            }
        }

        #endregion TLDPLBudget

        #region TLMBSAccount

        internal List<TLMBSAccount> TLMBSAccountList()
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLMBSAccounts.ToList();
            }
        }

        #endregion TLMBSAccount

        #region TLMPLAccount

        internal List<TLMPLAccount> TLMPLAccountList()
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLMPLAccounts.ToList();
            }
        }

        #endregion TLMPLAccount

        #region TLMReportHeading

        internal List<TLMReportHeading> TLMReportHeadingList(int reportId)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLMReportHeadings.Where(x => x.ReportId == reportId).ToList();
            }
        }

        #endregion TLMReportHeading

        #region TLMReportStructure

        internal List<TLMReportStructure> TLMReportStructureList(int reportId, int headingId)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLMReportStructures.Where(x => x.ReportId == reportId && x.HeadingId == headingId).ToList();
            }
        }

        internal TLMReportStructure TLMReportStructureItem(int reportId, int headingId, int itemId)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                var items = db.TLMReportStructures.Where(x => x.ReportId == reportId && x.HeadingId == headingId && x.ItemId == itemId).ToList();
                return items.Any() ? items.First() : new TLMReportStructure { ReportDescription = "Unknown", IsGrouping = 0, AccountItems = "[]" };
            }
        }

        internal List<TLMReportStructure> TLMReportStructureList(int reportId)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLMReportStructures.Where(x => x.ReportId == reportId).ToList();
            }
        }

        internal List<TLMReportStructure> TLMReportStructureList()
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLMReportStructures.ToList();
            }
        }

        #endregion TLMReportStructure

        #region TLMReport

        internal TLMReport TLMReportItem(int reportId)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                var a = db.TLMReports.Where(x => x.ReportId == reportId).ToList();
                return a.Any() ? a.First() : new TLMReport { ReportId = 0 };
            }
        }

        internal List<TLMReport> TLMReportList()
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLMReports.ToList();
            }
        }

        internal List<TLMReport> TLMReportList(bool activeOnly)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                var a = db.TLMReports.ToList();
                return activeOnly ? a.Where(x => x.StatusId == (int)MAStatus.Active).ToList() : a;
            }
        }

        #endregion TLMReport

        #region TLSSettings

        internal TLSSetting TLSSettingsItem()
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                var a = db.TLSSettings.Where(x => x.Id == 1);
                if (a.Any()) return a.First();
                return new TLSSetting();
            }
        }

        #endregion TLSSettings

        #region TLSSyncLog

        internal List<TLSSyncLog> TlSSyncLogList()
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLSSyncLogs.ToList();
            }
        }

        #endregion TLSSyncLog

        #region TLSUpdateLog

        internal List<TLSUpdateLog> TlSUpdateLogList()
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLSUpdateLogs.ToList();
            }
        }

        #endregion TLSUpdateLog
    }
}