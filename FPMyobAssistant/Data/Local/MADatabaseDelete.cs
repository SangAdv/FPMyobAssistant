using LocalModelContext;
using SangAdv.Common.StringExtensions;
using System.Linq;

namespace FPMyobAssistant
{
    internal sealed partial class MALocalAccess
    {
        #region TLDBS

        internal void TLDBSDeleteAll(string period)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                db.ExecuteCommand($"Delete from TLDBS where [Period]='{period}'");
            }
        }

        #endregion TLDBS

        #region TLDBSBudget

        internal void TLDBSBudgetDeleteAll(string period)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                db.ExecuteCommand($"Delete from TLDBSBudget where [Period]='{period}'");
            }
        }

        #endregion TLDBSBudget

        #region TLDDHLCustomerNumber

        internal void TLDDHLCustomerNumberDeleteAll()
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                db.ExecuteCommand("Delete from TLDDHLCustomerNumber");
            }
        }

        internal void TLDDHLCustomerNumberDeleteItem(string customerNo)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
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

        #region TLDPL

        internal void TLDPLDeleteAll(string period)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                db.ExecuteCommand($"Delete from TLDPL where [Period]='{period}'");
            }
        }

        #endregion TLDPL

        #region TLDPLBudget

        internal void TLDPLBudgetDeleteAll(string period)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                db.ExecuteCommand($"Delete from TLDPLBudget where [Period]='{period}'");
            }
        }

        #endregion TLDPLBudget

        #region TLMBSAccount

        internal void TLMBSAccountDeleteAll()
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                db.ExecuteCommand("Delete from TLMBSAccounts");
            }
        }

        #endregion TLMBSAccount

        #region TLMPLAccount

        internal void TLMPLAccountDeleteAll()
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                db.ExecuteCommand("Delete from TLMPLAccounts");
            }
        }

        #endregion TLMPLAccount

        #region TLMReportStructure

        internal void TLMReportStructureDeleteAll(int reportId, int headingId)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                db.ExecuteCommand($"Delete from TLMReportStructure where ReportId={reportId} and HeadingId={headingId}");
            }
        }

        internal void TLMReportStructureDeleteAll(int reportId)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                db.ExecuteCommand($"Delete from TLMReportStructure where ReportId={reportId}");
            }
        }

        #endregion TLMReportStructure

        #region TLSSyncLog

        internal void TLSSyncLogDelete(string updateItem, string variant)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                var a = db.TLSSyncLogs.Where(x => x.UpdateId.Trim() == updateItem.ToString().Trim() && x.Variant.ToUpper().Trim() == variant.ToUpper().Trim());
                if (a.Any()) db.TLSSyncLogs.DeleteOnSubmit(a.First());
                db.SubmitChanges();
            }
        }

        #endregion TLSSyncLog

        #region TLSUpdateLog

        internal void TLSUpdateLogDeleteAll()
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                db.ExecuteCommand("Delete from TLSUpdateLog");
            }
        }

        #endregion TLSUpdateLog
    }
}