using DevExpress.XtraRichEdit.Layout.Engine;
using LocalModelContext;
using System.Collections.Generic;
using System.Linq;

namespace FPMyobAssistant
{
    public sealed partial class MALocalAccess
    {
        #region TLDBS

        public List<TLDB> TLDBSList()
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLDBs.ToList();
            }
        }

        #endregion TLDBS

        #region TLDBSBudget

        public List<TLDBSBudget> TLDBSBudgetList()
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

        public TLDDHLCustomerNumber TLDDHLCustomerNumberItem(string Id)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                var a = db.TLDDHLCustomerNumbers.Where(x => x.Id == Id);
                return a.Any() ? a.First() : new TLDDHLCustomerNumber { Id = string.Empty };
            }
        }

        public List<TLDDHLCustomerNumber> TLDDHLCustomerNumberList()
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLDDHLCustomerNumbers.ToList();
            }
        }

        #endregion TLDDHLCustomerNumber

        #region TLDDHLInvoiceExclusions

        public TLDDHLInvoiceExclusion TLDDHLInvoiceExclusionsItem(string period)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                var a = db.TLDDHLInvoiceExclusions.Where(x => x.Period == period);
                return a.Any() ? a.First() : new TLDDHLInvoiceExclusion { Period = period };
            }
        }

        #endregion TLDDHLInvoiceExclusions

        #region TLDDistributorProductAccountId

        public List<TLDDistributorProductAccountId> TLDDistributorProductAccountIdList()
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLDDistributorProductAccountIds.ToList();
            }
        }

        public List<TLDDistributorProductAccountId> TLDDistributorProductAccountIdList(int distributorId)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLDDistributorProductAccountIds.Where(x => x.DistributorId == distributorId).ToList();
            }
        }

        public TLDDistributorProductAccountId TLDDistributorProductAccountIdItem(int distributorId, string productPDE)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                var a = db.TLDDistributorProductAccountIds.Where(x => x.DistributorId == distributorId && x.ProductPDE == productPDE);
                if (a.Any()) return a.First();
                return new TLDDistributorProductAccountId { AccountId = string.Empty };
            }
        }

        #endregion TLDDistributorProductAccountId

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

        public List<TLDPL> TLDPLList()
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLDPLs.ToList();
            }
        }

        #endregion TLDPL

        #region TLDPLBudget

        public List<TLDPLBudget> TLDPLBudgetList()
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

        #region TLDReptos

        public List<TLDRepto> TLDReptosList(string period)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLDReptos.Where(x => x.Period == period).ToList();
            }
        }

        #endregion TLDReptos

        #region TLMBSAccount

        public List<TLMBSAccount> TLMBSAccountList()
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLMBSAccounts.ToList();
            }
        }

        #endregion TLMBSAccount

        #region TLMDistributor

        internal TLMDistributor TLMDistributorItem(int distributorId)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                var a = db.TLMDistributors.Where(x => x.DistributorId == distributorId);
                if (a.Any()) return a.First();
                return null;
            }
        }

        public List<TLMDistributor> TLMDistributorList()
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLMDistributors.OrderBy(x => x.Distributor).ToList();
            }
        }

        public Dictionary<int, string> TLMDistributorDictionary()
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLMDistributors.ToDictionary(x => (int)x.DistributorId, x => x.Distributor);
            }
        }

        #endregion TLMDistributor

        #region TLMPLAccount

        public List<TLMPLAccount> TLMPLAccountList()
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLMPLAccounts.ToList();
            }
        }

        #endregion TLMPLAccount

        #region TLMReportHeading

        public List<TLMReportHeading> TLMReportHeadingList(int reportId)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLMReportHeadings.Where(x => x.ReportId == reportId).ToList();
            }
        }

        #endregion TLMReportHeading

        #region TLMReportStructure

        public List<TLMReportStructure> TLMReportStructureList(int reportId, int headingId)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLMReportStructures.Where(x => x.ReportId == reportId && x.HeadingId == headingId).ToList();
            }
        }

        public TLMReportStructure TLMReportStructureItem(int reportId, int headingId, int itemId)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                var items = db.TLMReportStructures.Where(x => x.ReportId == reportId && x.HeadingId == headingId && x.ItemId == itemId).ToList();
                return items.Any() ? items.First() : new TLMReportStructure { ReportDescription = "Unknown", IsGrouping = 0, AccountItems = "[]" };
            }
        }

        public List<TLMReportStructure> TLMReportStructureList(int reportId)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLMReportStructures.Where(x => x.ReportId == reportId).ToList();
            }
        }

        public List<TLMReportStructure> TLMReportStructureList()
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLMReportStructures.ToList();
            }
        }

        #endregion TLMReportStructure

        #region TLMReport

        public TLMReport TLMReportItem(int reportId)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                var a = db.TLMReports.Where(x => x.ReportId == reportId).ToList();
                return a.Any() ? a.First() : new TLMReport { ReportId = 0 };
            }
        }

        public List<TLMReport> TLMReportList()
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                return db.TLMReports.ToList();
            }
        }

        public List<TLMReport> TLMReportList(bool activeOnly)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                var a = db.TLMReports.ToList();
                return activeOnly ? a.Where(x => x.StatusId == (int)MAStatus.Active).ToList() : a;
            }
        }

        #endregion TLMReport

        #region TLSSettings

        public TLSSetting TLSSettingsItem()
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

        public List<TLSSyncLog> TlSSyncLogList()
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