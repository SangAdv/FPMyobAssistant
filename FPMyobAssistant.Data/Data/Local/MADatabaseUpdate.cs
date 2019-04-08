using LocalModelContext;
using SangAdv.Common.StringExtensions;
using SangAdv.SQLite;
using System.Collections.Generic;
using System.Linq;

namespace FPMyobAssistant
{
    public sealed partial class MALocalAccess
    {
        #region TLDBS

        public void TLDBSUpdate(TLDB data)
        {
            if (data.Actual == 0) return;
            data.AccountId = data.AccountId.Trim().AddLeadingZeros(10);
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                var a = db.TLDBs.Where(x => x.AccountId == data.AccountId && x.Period == data.Period);
                if (a.Any())
                {
                    a.First().Actual = data.Actual;
                    db.SubmitChanges();
                }
                else
                {
                    db.TLDBs.InsertOnSubmit(data);
                    db.SubmitChanges();
                }
            }
        }

        #endregion TLDBS

        #region TLDBSBudget

        public void TLDBSBudgetUpdate(TLDBSBudget data)
        {
            if (data.Budget == 0) return;
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                var a = db.TLDBSBudgets.Where(x => x.MAId == data.MAId && x.Period == data.Period);
                if (a.Any())
                {
                    a.First().Budget = data.Budget;
                    db.SubmitChanges();
                }
                else
                {
                    db.TLDBSBudgets.InsertOnSubmit(data);
                    db.SubmitChanges();
                }
            }
        }

        internal void TLDBSBudgetUpdate(List<MACBudgetItem> data, string period)
        {
            ErrorMessage = string.Empty;

            if (data.Count == 0) return;

            TLDPLBudgetDeleteAll(period);

            using (var sbi = new SQLiteBulkInsert(MADataAccess.LocalData.mServer.Database.ConnectionString))
            {
                sbi.AddParameter("MAId", typeof(string));
                sbi.AddParameter("Period", typeof(string));
                sbi.AddParameter("Budget", typeof(float));

                sbi.UpdateData(data, "TLDBSBudget");

                sbi.CommitData();

                ErrorMessage = sbi.ErrorMessage;
            }
        }

        #endregion TLDBSBudget

        #region TLDPL

        public void TLDPLUpdate(TLDPL data)
        {
            if (data.Actual == 0) return;
            data.AccountId = data.AccountId.Trim().AddLeadingZeros(10);
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                var a = db.TLDPLs.Where(x => x.AccountId == data.AccountId && x.Period == data.Period);
                if (a.Any())
                {
                    a.First().Actual = data.Actual;
                    db.SubmitChanges();
                }
                else
                {
                    db.TLDPLs.InsertOnSubmit(data);
                    db.SubmitChanges();
                }
            }
        }

        #endregion TLDPL

        #region TLDPLBudget

        public void TLDPLBudgetUpdate(TLDPLBudget data)
        {
            if (data.Budget == 0) return;
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                var a = db.TLDPLBudgets.Where(x => x.MAId == data.MAId && x.Period == data.Period);
                if (a.Any())
                {
                    a.First().Budget = data.Budget;
                    db.SubmitChanges();
                }
                else
                {
                    db.TLDPLBudgets.InsertOnSubmit(data);
                    db.SubmitChanges();
                }
            }
        }

        internal void TLDPLBudgetUpdate(List<MACBudgetItem> data, string period)
        {
            ErrorMessage = string.Empty;

            if (data.Count == 0) return;

            TLDPLBudgetDeleteAll(period);

            using (var sbi = new SQLiteBulkInsert(MADataAccess.LocalData.mServer.Database.ConnectionString))
            {
                sbi.AddParameter("MAId", typeof(string));
                sbi.AddParameter("Period", typeof(string));
                sbi.AddParameter("Budget", typeof(float));

                sbi.UpdateData(data, "TLDPLBudget");

                sbi.CommitData();

                ErrorMessage = sbi.ErrorMessage;
            }
        }

        #endregion TLDPLBudget

        #region TLDDistributorProductAccountId

        public void TLDDistributorProductAccountIdUpdate(TLDDistributorProductAccountId data)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                var a = db.TLDDistributorProductAccountIds.Where(x => x.DistributorId == data.DistributorId && x.ProductPDE == data.ProductPDE);
                if (a.Any())
                {
                    db.TLDDistributorProductAccountIds.DeleteOnSubmit(a.First());
                    db.SubmitChanges();
                }
                db.TLDDistributorProductAccountIds.InsertOnSubmit(data);
                db.SubmitChanges();
            }
        }

        #endregion TLDDistributorProductAccountId

        #region TLDDHLCustomerNumber

        public void TLDDHLCustomerNumberUpdate(TLDDHLCustomerNumber data)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                var a = db.TLDDHLCustomerNumbers.Where(x => x.Id == data.Id);
                if (a.Any())
                {
                    db.TLDDHLCustomerNumbers.DeleteOnSubmit(a.First());
                    db.SubmitChanges();
                }
                db.TLDDHLCustomerNumbers.InsertOnSubmit(data);
                db.SubmitChanges();
            }
        }

        internal void TLDDHLCustomerNumberUpdate(List<MACCustomerNumberItem> data)
        {
            ErrorMessage = string.Empty;

            TLDDHLCustomerNumberDeleteAll();

            using (var sbi = new SQLiteBulkInsert(MADataAccess.LocalData.mServer.Database.ConnectionString))
            {
                sbi.AddParameter("Id", typeof(string));
                sbi.AddParameter("CustomerName", typeof(string));
                sbi.AddParameter("MYOBCardId", typeof(string));

                foreach (var item in data)
                {
                    sbi.UpdateData(MADataAccess.CloudData.CustomerNumbers.Accounts, "TLDDHLCustomerNumber");
                }

                sbi.CommitData();

                ErrorMessage = sbi.ErrorMessage;
            }
        }

        #endregion TLDDHLCustomerNumber

        #region TLDDHLInvoiceExclusions

        internal void TLDDHLInvoiceExclusionsUpdate(TLDDHLInvoiceExclusion data)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                var a = db.TLDDHLInvoiceExclusions.Where(x => x.Period == data.Period);
                if (a.Any())
                {
                    db.TLDDHLInvoiceExclusions.DeleteOnSubmit(a.First());
                    db.SubmitChanges();
                }
                db.TLDDHLInvoiceExclusions.InsertOnSubmit(data);
                db.SubmitChanges();
            }
        }

        #endregion TLDDHLInvoiceExclusions

        #region TLDKKCustomerNumber

        internal void TLDKKCustomerNumberUpdate(TLDKKCustomerNumber data)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                var a = db.TLDKKCustomerNumbers.Where(x => x.Id == data.Id);
                if (a.Any())
                {
                    db.TLDKKCustomerNumbers.DeleteOnSubmit(a.First());
                    db.SubmitChanges();
                }
                db.TLDKKCustomerNumbers.InsertOnSubmit(data);
                db.SubmitChanges();
            }
        }

        #endregion TLDKKCustomerNumber

        #region TLMBSAccount

        public void TLMBSAccountUpdate(TLMBSAccount data)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                var a = db.TLMBSAccounts.Where(x => x.AccountId == data.AccountId);
                if (a.Any())
                {
                    db.TLMBSAccounts.DeleteOnSubmit(a.First());
                    db.SubmitChanges();
                }
                db.TLMBSAccounts.InsertOnSubmit(data);
                db.SubmitChanges();
            }
        }

        internal void TLMBSAccountUpdate(List<MACAccountItem> data)
        {
            ErrorMessage = string.Empty;

            if (data.Count == 0) return;

            TLMBSAccountDeleteAll();

            using (var sbi = new SQLiteBulkInsert(MADataAccess.LocalData.mServer.Database.ConnectionString))
            {
                sbi.AddParameter("AccountId", typeof(string));
                sbi.AddParameter("AccountDescription", typeof(string));
                sbi.AddParameter("ParentAccountId", typeof(string));

                sbi.UpdateData(data, "TLMBSAccounts");

                sbi.CommitData();

                ErrorMessage = sbi.ErrorMessage;
            }
        }

        #endregion TLMBSAccount

        #region TLMPLAccount

        public void TLMPLAccountUpdate(TLMPLAccount data)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                var a = db.TLMPLAccounts.Where(x => x.AccountId == data.AccountId);
                if (a.Any())
                {
                    db.TLMPLAccounts.DeleteOnSubmit(a.First());
                    db.SubmitChanges();
                }
                db.TLMPLAccounts.InsertOnSubmit(data);
                db.SubmitChanges();
            }
        }

        internal void TLMPLAccountUpdate(List<MACAccountItem> data)
        {
            ErrorMessage = string.Empty;

            if (data.Count == 0) return;

            TLMPLAccountDeleteAll();

            using (var sbi = new SQLiteBulkInsert(MADataAccess.LocalData.mServer.Database.ConnectionString))
            {
                sbi.AddParameter("AccountId", typeof(string));
                sbi.AddParameter("AccountDescription", typeof(string));
                sbi.AddParameter("ParentAccountId", typeof(string));

                sbi.UpdateData(data, "TLMPLAccounts");

                sbi.CommitData();

                ErrorMessage = sbi.ErrorMessage;
            }
        }

        #endregion TLMPLAccount

        #region TLMReport

        public void TLMReportStructureUpdate(List<TLMReportStructure> data)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                foreach (var item in data)
                {
                    var a = db.TLMReportStructures.Where(x => x.ReportId == item.ReportId && x.HeadingId == item.HeadingId && x.ItemId == item.ItemId).ToList();
                    if (a.Any()) db.TLMReportStructures.DeleteOnSubmit(a.First());
                    db.TLMReportStructures.InsertOnSubmit(item);
                }
                db.SubmitChanges();
            }
        }

        internal void TLMReportStructureUpdate(List<MACReportStructureItem> data, int reportId)
        {
            ErrorMessage = string.Empty;

            if (data.Count == 0) return;

            TLMReportStructureDeleteAll(reportId);

            var tData = new List<TLMReportStructure>();

            using (var sbi = new SQLiteBulkInsert(MADataAccess.LocalData.mServer.Database.ConnectionString))
            {
                sbi.AddParameter("ReportId", typeof(int));
                sbi.AddParameter("HeadingId", typeof(int));
                sbi.AddParameter("ItemId", typeof(int));
                sbi.AddParameter("ReportDescription", typeof(string));
                sbi.AddParameter("AccountItems", typeof(string));
                sbi.AddParameter("SequenceIndex", typeof(int));
                sbi.AddParameter("PreviousReportItem", typeof(string));

                foreach (var item in data)
                {
                    tData.Add(new TLMReportStructure
                    {
                        ReportId = reportId,
                        HeadingId = item.HeadingId,
                        ItemId = item.ItemId,
                        ReportDescription = item.ReportDescription,
                        AccountItems = item.AccountItems,
                        SequenceIndex = item.SequenceIndex
                    });
                }

                sbi.UpdateData(tData, "TLMReportStructure");
                sbi.CommitData();

                ErrorMessage = sbi.ErrorMessage;
            }
        }

        #endregion TLMReport

        #region TLMReport

        public void TLMReportUpdate(TLMReport data)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                var a = db.TLMReports.Where(x => x.ReportId == data.ReportId);
                if (a.Any())
                {
                    db.TLMReports.DeleteOnSubmit(a.First());
                    db.SubmitChanges();
                }

                if (data.ReportId == 0) data.ReportId = TLMReportNewId();
                db.TLMReports.InsertOnSubmit(data);
                db.SubmitChanges();
            }
        }

        #endregion TLMReport

        #region TLSSettings

        public void TLSSettingUpdate(TLSSetting data)
        {
            data.Id = 1;
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                var a = db.TLSSettings.Where(x => x.Id == 1).ToList();
                if (a.Any())
                {
                    db.TLSSettings.DeleteOnSubmit(a.First());
                    db.SubmitChanges();
                }
                db.TLSSettings.InsertOnSubmit(data);
                db.SubmitChanges();
            }
        }

        #endregion TLSSettings

        #region TLSSyncLog

        internal void TLSSyncLogUpdate(MAUpdateItem data, string variant)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                var a = db.TLSSyncLogs.Where(x => x.UpdateId.Trim() == data.ToString() && x.Variant == variant);
                if (!a.Any())
                {
                    db.TLSSyncLogs.InsertOnSubmit(new TLSSyncLog { UpdateId = data.ToString(), Variant = variant });
                    db.SubmitChanges();
                }
            }
        }

        #endregion TLSSyncLog

        #region TLSUpdateLog

        internal void TLSUpdateLogUpdate(string updateType, string variant, string utcDateTimeUpdated, string payload)
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                var a = db.TLSUpdateLogs.Where(x => x.UpdateId.Trim() == updateType && x.Variant == variant);
                if (a.Any())
                {
                    var cd = a.First();
                    cd.UTCDateTimePresent = utcDateTimeUpdated;
                    cd.Payload = payload;
                }
                else
                {
                    db.TLSUpdateLogs.InsertOnSubmit(new TLSUpdateLog { UpdateId = updateType, Variant = variant, Payload = payload, UTCDateTimePresent = utcDateTimeUpdated });
                }
                db.SubmitChanges();
            }
        }

        #endregion TLSUpdateLog

        #region Private Methods

        private int TLMReportNewId()
        {
            using (var db = new LocalModelDataContext(mServer.Database.ConnectionString))
            {
                try
                {
                    return db.TLMReports.Select(x => x.ReportId).Max() + 1;
                }
                catch
                {
                    return 1;
                }
            }
        }

        private string UpdateItemString(string rawUpdateId)
        {
            if (!rawUpdateId.Contains("-")) return rawUpdateId;
            var pos = rawUpdateId.IndexOf('-');
            return rawUpdateId.Substring(0, pos);
        }

        #endregion Private Methods
    }
}