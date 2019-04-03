using Mapster;
using SangAdv.Common;
using SangAdv.Common.ObjectExtensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FPMyobAssistant
{
    internal class MASyncDataLocal : ASASyncFW
    {
        #region Events

        public event StringDelegate MessageChanged = s => { };

        #endregion Events

        #region Abstract Methods

        public override async Task LoadAsync()
        {
            foreach (var item in MADataAccess.LocalData.TlSSyncLogList()) Items.Add(new SASyncDataItem { MainType = item.UpdateId, SubType = item.Variant, Payload = string.Empty });
            await Task.Delay(1);
        }

        public override async Task DoSyncAsync(List<SASyncDataItem> updateItems)
        {
            await DoLocalSyncAsync();
        }

        public override Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public override Task RemoveItemAsync(string mainType, string subType = "")
        {
            throw new NotImplementedException();
        }

        #endregion Abstract Methods

        #region Private Methods

        private async Task<bool> DoLocalSyncAsync()
        {
            Error.ClearErrorMessage();
            var tSuccess = true;
            var tMessage = string.Empty;

            foreach (var item in Items)
            {
                switch (item.MainType)
                {
                    case MAUpdateItem.Accounts:
                        tSuccess = await SyncAccountDataAsync();
                        if (tSuccess) tMessage = "Synced account data";
                        break;

                    case MAUpdateItem.PLBudget:
                        tSuccess = await SyncPLBudgetAsync(item.SubType);
                        if (tSuccess) tMessage = $"Synced budget data: Period {item.SubType}";
                        break;

                    case MAUpdateItem.BSBudget:
                        tSuccess = await SyncBSBudgetAsync(item.SubType);
                        if (tSuccess) tMessage = $"Synced budget data: Period {item.SubType}";
                        break;

                    case MAUpdateItem.CustomerData:
                        tSuccess = await SyncCustomerDataAsync();
                        if (tSuccess) tMessage = "Synced customer data";
                        break;

                    case MAUpdateItem.ImportExclusions:
                        tSuccess = await SyncImportExclusionsAsync(item.SubType);
                        if (tSuccess) tMessage = $"Synced import exclusions: Period {item.SubType}";
                        break;

                    case MAUpdateItem.ReportStructure:
                        tSuccess = await SyncReportStructureAsync(item.SubType.Value<int>());
                        if (tSuccess) tMessage = $"Synced report structure data: ReportId {item.SubType}";
                        break;

                    case MAUpdateItem.Settings:
                        tSuccess = await SyncSettingsAsync();
                        if (tSuccess) tMessage = $"Synced settings data";
                        break;
                }

                if (tSuccess)
                {
                    MessageChanged(tMessage);
                    MADataAccess.LocalData.TLSSyncLogDelete(item.MainType, item.SubType);
                    await RemoveAsync(item.MainType, item.SubType);
                }
                else
                {
                    Error.SetErrorMessage($"Could not clear sync item {item}");
                    MessageChanged(ErrorMessage);
                    return false;
                }
            }

            return true;
        }

        private async Task<bool> SyncCustomerDataAsync()
        {
            try
            {
                MADataAccess.CloudData.CustomerNumbers.Accounts.Clear();

                foreach (var item in MADataAccess.LocalData.TLDDHLCustomerNumberList()) MADataAccess.CloudData.CustomerNumbers.Accounts.Add(new MACCustomerNumberItem { CustomerName = item.CustomerName, Id = item.Id, MYOBCardId = item.MYOBCardId });

                await MADataAccess.CloudData.CustomerNumbers.SaveAsync();

                await MADataAccess.CloudData.Updates.SaveAsync(MAUpdateItem.CustomerData, string.Empty);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> SyncPLBudgetAsync(string period)
        {
            try
            {
                //Update P&L Budget

                MADataAccess.CloudData.Budgets.Clear();

                foreach (var item in MADataAccess.LocalData.TLDPLBudgetList(period)) MADataAccess.CloudData.Budgets.Budgets.Add(new MACBudgetItem { MAId = item.MAId, Period = item.Period, Budget = (float)item.Budget });

                await MADataAccess.CloudData.Budgets.SaveAsync(MAReportType.ProfitLoss, period);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> SyncBSBudgetAsync(string period)
        {
            try
            {
                //Update P&L Budget

                MADataAccess.CloudData.Budgets.Clear();

                foreach (var item in MADataAccess.LocalData.TLDPLBudgetList(period)) MADataAccess.CloudData.Budgets.Budgets.Add(new MACBudgetItem { MAId = item.MAId, Period = item.Period, Budget = (float)item.Budget });

                await MADataAccess.CloudData.Budgets.SaveAsync(MAReportType.BalanceSheet, period);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> SyncAccountDataAsync()
        {
            try
            {
                //Sync P&L Accounts
                MADataAccess.CloudData.Accounts.Clear();
                foreach (var item in MADataAccess.LocalData.TLMBSAccountList()) MADataAccess.CloudData.Accounts.Accounts.Add(new MACAccountItem { AccountId = item.AccountId, AccountDescription = item.AccountDescription, ParentAccountId = item.ParentAccountId });
                await MADataAccess.CloudData.Accounts.SaveAsync(MAReportType.BalanceSheet);

                //Sync Balance Sheet Accounts
                MADataAccess.CloudData.Accounts.Clear();
                foreach (var item in MADataAccess.LocalData.TLMPLAccountList()) MADataAccess.CloudData.Accounts.Accounts.Add(new MACAccountItem { AccountId = item.AccountId, AccountDescription = item.AccountDescription, ParentAccountId = item.ParentAccountId });
                await MADataAccess.CloudData.Accounts.SaveAsync(MAReportType.ProfitLoss);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> SyncReportStructureAsync(int reportId)
        {
            try
            {
                MADataAccess.CloudData.Structure.Clear(reportId);

                foreach (var item in MADataAccess.LocalData.TLMReportStructureList(reportId))
                {
                    MADataAccess.CloudData.Structure.Add(reportId, new MACReportStructureItem { HeadingId = item.HeadingId, ItemId = item.ItemId, ReportDescription = item.ReportDescription, AccountItems = item.AccountItems, SequenceIndex = item.SequenceIndex });
                }

                await MADataAccess.CloudData.Structure.SaveAsync(reportId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> SyncImportExclusionsAsync(string period)
        {
            try
            {
                await MADataAccess.CloudData.ImportExclusions.SaveAsync(MADataAccess.LocalData.TLDDHLInvoiceExclusionsItem(period).Adapt<MACImportExclusionItems>());
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> SyncSettingsAsync()
        {
            try
            {
                MADataAccess.CloudData.Settings.Settings = MADataAccess.LocalData.TLSSettingsItem().Adapt<MACSettingsItem>();
                await MADataAccess.CloudData.Settings.SaveAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion Private Methods
    }
}