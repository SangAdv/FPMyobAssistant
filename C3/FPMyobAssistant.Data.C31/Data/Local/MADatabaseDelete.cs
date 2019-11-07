using LocalModelContext;
using SangAdv.Common.StringExtensions;
using System.Linq;

namespace FPMyobAssistant
{
    public sealed partial class MALocalAccess
    {
        #region TLDBS

        public void TLDBSDeleteAll(string period)
        {
            using (var db = new LocalModelDataContext(mDevartConnectionString))
            {
                db.ExecuteCommand($"Delete from TLDBS where [Period]='{period}'");
            }
        }

        #endregion TLDBS

        #region TLDBSBudget

        public void TLDBSBudgetDeleteAll(string period)
        {
            using (var db = new LocalModelDataContext(mDevartConnectionString))
            {
                db.ExecuteCommand($"Delete from TLDBSBudget where [Period]='{period}'");
            }
        }

        #endregion TLDBSBudget

        #region TLDDHLCustomerNumber

        internal void TLDDHLCustomerNumberDeleteAll()
        {
            using (var db = new LocalModelDataContext(mDevartConnectionString))
            {
                db.ExecuteCommand("Delete from TLDDHLCustomerNumber");
            }
        }

        public void TLDDHLCustomerNumberDeleteItem(string customerNo)
        {
            using (var db = new LocalModelDataContext(mDevartConnectionString))
            {
                customerNo = customerNo.AddLeadingZeros(20);
                var a = db.TLDDHLCustomerNumbers.Where(x => x.Id == customerNo);
                if (a.Any())
                {
                    db.TLDDHLCustomerNumbers.DeleteOnSubmit(a.First());
                    db.SubmitChanges();
                }
            }
        }

        #endregion TLDDHLCustomerNumber

        #region TLDDistributorProductAccountId

        public void TLDDistributorProductAccountIdDeleteAll()
        {
            using (var db = new LocalModelDataContext(mDevartConnectionString))
            {
                db.ExecuteCommand("Delete from TLDDistributorProductAccountId");
            }
        }

        #endregion TLDDistributorProductAccountId

        #region TLDKKCustomerNumber

        public void TLDKKCustomerNumberDeleteAll()
        {
            using (var db = new LocalModelDataContext(mDevartConnectionString))
            {
                db.ExecuteCommand("Delete from TLDKKCustomerNumber");
            }
        }

        #endregion TLDKKCustomerNumber

        #region TLDPL

        public void TLDPLDeleteAll(string period)
        {
            using (var db = new LocalModelDataContext(mDevartConnectionString))
            {
                db.ExecuteCommand($"Delete from TLDPL where [Period]='{period}'");
            }
        }

        #endregion TLDPL

        #region TLDPLBudget

        public void TLDPLBudgetDeleteAll(string period)
        {
            using (var db = new LocalModelDataContext(mDevartConnectionString))
            {
                db.ExecuteCommand($"Delete from TLDPLBudget where [Period]='{period}'");
            }
        }

        #endregion TLDPLBudget

        #region TLMBSAccount

        internal void TLMBSAccountDeleteAll()
        {
            using (var db = new LocalModelDataContext(mDevartConnectionString))
            {
                db.ExecuteCommand("Delete from TLMBSAccounts");
            }
        }

        #endregion TLMBSAccount

        #region TLMDistributor

        public void TLMDistributorDeleteAll()
        {
            using (var db = new LocalModelDataContext(mDevartConnectionString))
            {
                db.ExecuteCommand("Delete from TLMDistributor");
            }
        }

        #endregion TLMDistributor

        #region TLMPLAccount

        internal void TLMPLAccountDeleteAll()
        {
            using (var db = new LocalModelDataContext(mDevartConnectionString))
            {
                db.ExecuteCommand("Delete from TLMPLAccounts");
            }
        }

        #endregion TLMPLAccount

        #region TLMReportHeadings

        public void TLMReportHeadingsDeleteAll()
        {
            using (var db = new LocalModelDataContext(mDevartConnectionString))
            {
                db.ExecuteCommand("Delete from TLMReportHeadings");
            }
        }

        #endregion TLMReportHeadings

        #region TLMReportStructure

        public void TLMReportStructureDeleteAll(int reportId, int headingId)
        {
            using (var db = new LocalModelDataContext(mDevartConnectionString))
            {
                db.ExecuteCommand($"Delete from TLMReportStructure where ReportId={reportId} and HeadingId={headingId}");
            }
        }

        internal void TLMReportStructureDeleteAll(int reportId)
        {
            using (var db = new LocalModelDataContext(mDevartConnectionString))
            {
                db.ExecuteCommand($"Delete from TLMReportStructure where ReportId={reportId}");
            }
        }

        internal void TLMReportStructureDeleteAll()
        {
            using (var db = new LocalModelDataContext(mDevartConnectionString))
            {
                db.ExecuteCommand($"Delete from TLMReportStructure");
            }
        }

        #endregion TLMReportStructure

        #region TLMReports

        internal void TLMReportsDeleteAll()
        {
            using (var db = new LocalModelDataContext(mDevartConnectionString))
            {
                db.ExecuteCommand($"Delete from TLMReports");
            }
        }

        #endregion TLMReports

        #region TLSSyncLog

        internal void TLSSyncLogDelete(string updateItem, string variant)
        {
            using (var db = new LocalModelDataContext(mDevartConnectionString))
            {
                var a = db.TLSSyncLogs.Where(x => x.UpdateId.Trim() == updateItem.ToString().Trim() && x.Variant.ToUpper().Trim() == variant.ToUpper().Trim());
                if (a.Any()) db.TLSSyncLogs.DeleteOnSubmit(a.First());
                db.SubmitChanges();
            }
        }

        #endregion TLSSyncLog

        #region TLSUpdateLog

        public void TLSUpdateLogDeleteAll()
        {
            using (var db = new LocalModelDataContext(mDevartConnectionString))
            {
                db.ExecuteCommand("Delete from TLSUpdateLog");
            }
        }

        #endregion TLSUpdateLog
    }
}