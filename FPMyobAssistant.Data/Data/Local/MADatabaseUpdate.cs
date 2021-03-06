﻿using LocalModelContext;
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
            using (var db = new LocalModelDataContext(mDevartConnectionString))
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
            using (var db = new LocalModelDataContext(mDevartConnectionString))
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

        #region TLDDHLCustomerNumber

        public void TLDDHLCustomerNumberUpdate(TLDDHLCustomerNumber data)
        {
            using (var db = new LocalModelDataContext(mDevartConnectionString))
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
                    sbi.UpdateData(MADataAccess.CloudData.Customer.Accounts, "TLDDHLCustomerNumber");
                }

                sbi.CommitData();

                ErrorMessage = sbi.ErrorMessage;
            }
        }

        #endregion TLDDHLCustomerNumber

        #region TLDDHLInvoiceExclusions

        internal void TLDDHLInvoiceExclusionsUpdate(TLDDHLInvoiceExclusion data)
        {
            using (var db = new LocalModelDataContext(mDevartConnectionString))
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

        #region TLDDistributorProductAccountId

        public void TLDDistributorProductAccountIdUpdate(TLDDistributorProductAccountId data)
        {
            using (var db = new LocalModelDataContext(mDevartConnectionString))
            {
                var a = db.TLDDistributorProductAccountIds.Where(x => x.DistributorId == data.DistributorId && x.ProductPDE == data.ProductPDE);
                if (a.Any())
                {
                    if (a.First().AccountId == data.AccountId) return;

                    db.TLDDistributorProductAccountIds.DeleteOnSubmit(a.First());
                    db.SubmitChanges();
                }
                db.TLDDistributorProductAccountIds.InsertOnSubmit(data);
                db.SubmitChanges();
            }
        }

        public void TLDDistributorProductAccountIdUpdate(List<TLDDistributorProductAccountId> data)
        {
            ErrorMessage = string.Empty;

            if (data.Count == 0) return;

            TLDDistributorProductAccountIdDeleteAll();

            using (var sbi = new SQLiteBulkInsert(MADataAccess.LocalData.mServer.Database.ConnectionString))
            {
                sbi.AddParameter("DistributorId", typeof(int));
                sbi.AddParameter("ProductPDE", typeof(string));
                sbi.AddParameter("AccountId", typeof(string));
                sbi.AddParameter("Product", typeof(string));

                sbi.UpdateData(data, "TLDDistributorProductAccountId");

                sbi.CommitData();

                ErrorMessage = sbi.ErrorMessage;
            }
        }

        #endregion TLDDistributorProductAccountId

        #region TLDPL

        public void TLDPLUpdate(TLDPL data)
        {
            if (data.Actual == 0) return;
            data.AccountId = data.AccountId.Trim().AddLeadingZeros(10);
            using (var db = new LocalModelDataContext(mDevartConnectionString))
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
            using (var db = new LocalModelDataContext(mDevartConnectionString))
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

        #region TLDKKCustomerNumber

        internal void TLDKKCustomerNumberUpdate(List<TLDKKCustomerNumber> data)
        {
            ErrorMessage = string.Empty;

            TLDDHLCustomerNumberDeleteAll();

            using (var sbi = new SQLiteBulkInsert(MADataAccess.LocalData.mServer.Database.ConnectionString))
            {
                sbi.AddParameter("Id", typeof(string));
                sbi.AddParameter("CustomerName", typeof(string));
                sbi.AddParameter("MYOBCardId", typeof(string));

                sbi.UpdateData(data, "TLDKKCustomerNumber");

                sbi.CommitData();

                ErrorMessage = sbi.ErrorMessage;
            }
        }

        #endregion TLDKKCustomerNumber

        #region TLMBSAccount

        public void TLMBSAccountUpdate(TLMBSAccount data)
        {
            using (var db = new LocalModelDataContext(mDevartConnectionString))
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

        #region TLMDistributor

        internal void TLMDistributorUpdate(List<TLMDistributor> data)
        {
            ErrorMessage = string.Empty;

            TLDDHLCustomerNumberDeleteAll();

            using (var sbi = new SQLiteBulkInsert(MADataAccess.LocalData.mServer.Database.ConnectionString))
            {
                sbi.AddParameter("DistributorId", typeof(int));
                sbi.AddParameter("Distributor", typeof(string));
                sbi.AddParameter("CardId", typeof(string));

                sbi.UpdateData(data, "TLMDistributor");

                sbi.CommitData();

                ErrorMessage = sbi.ErrorMessage;
            }
        }

        #endregion TLMDistributor

        #region TLMPLAccounts

        public void TLMPLAccountUpdate(TLMPLAccount data)
        {
            using (var db = new LocalModelDataContext(mDevartConnectionString))
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

        #endregion TLMPLAccounts

        #region TLMReportHeadings

        internal void TLMReportHeadingsUpdate(List<TLMReportHeading> data)
        {
            ErrorMessage = string.Empty;

            TLDDHLCustomerNumberDeleteAll();

            using (var sbi = new SQLiteBulkInsert(MADataAccess.LocalData.mServer.Database.ConnectionString))
            {
                sbi.AddParameter("ReportId", typeof(int));
                sbi.AddParameter("HeadingId", typeof(int));
                sbi.AddParameter("ReportHeading", typeof(string));
                sbi.AddParameter("IsCalculation", typeof(int));
                sbi.AddParameter("HasChildren", typeof(int));
                sbi.AddParameter("IncomeAsNegative", typeof(int));

                sbi.UpdateData(data, "TLMReportHeadings");

                sbi.CommitData();

                ErrorMessage = sbi.ErrorMessage;
            }
        }

        #endregion TLMReportHeadings

        #region TLMReportStructure

        public void TLMReportStructureUpdate(List<TLMReportStructure> data)
        {
            using (var db = new LocalModelDataContext(mDevartConnectionString))
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

        #endregion TLMReportStructure

        #region TLMReports

        public void TLMReportsUpdate(TLMReport data)
        {
            using (var db = new LocalModelDataContext(mDevartConnectionString))
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

        #endregion TLMReports

        #region TLSSettings

        public void TLSSettingUpdate(TLSSetting data)
        {
            data.Id = 1;
            using (var db = new LocalModelDataContext(mDevartConnectionString))
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

        internal void TLSSyncLogUpdate(string data, string variant)
        {
            using (var db = new LocalModelDataContext(mDevartConnectionString))
            {
                var a = db.TLSSyncLogs.Where(x => x.UpdateId.Trim() == data.Trim() && x.Variant.Trim() == variant.Trim());
                if (!a.Any())
                {
                    db.TLSSyncLogs.InsertOnSubmit(new TLSSyncLog { UpdateId = data.ToString(), Variant = variant.Trim() });
                    db.SubmitChanges();
                }
            }
        }

        #endregion TLSSyncLog

        #region TLSUpdateLog

        internal void TLSUpdateLogUpdate(string updateType, string variant, string utcDateTimeUpdated, string payload)
        {
            using (var db = new LocalModelDataContext(mDevartConnectionString))
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
            using (var db = new LocalModelDataContext(mDevartConnectionString))
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