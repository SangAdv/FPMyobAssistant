using LocalModelContext;
using Mapster;
using SangAdv.Common;
using SangAdv.Common.ObjectExtensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FPMyobAssistant
{
    internal sealed class MADataUpdateLocal : ASAUpdateFWLocalData<string>
    {
        #region Eevents

        public event StringDelegate MessageChanged = (s) => { };

        #endregion Eevents

        #region Abstract Methods

        public override async Task LoadAsync()
        {
            Clear();
            Error.ClearErrorMessage();
            foreach (var item in MADataAccess.LocalData.TlSUpdateLogList())
            {
                Add(new SAUpdateLocalDataItem<string> { MainType = item.UpdateId, SubType = item.Variant, CurrentDataDate = item.UTCDateTimePresent, Payload = item.Payload });
            }

            await Task.Delay(1);
        }

        public override async Task<bool> DoUpdateAsync(List<SAUpdateLocalDataItem<string>> updateItems)
        {
            return await DoDataUpdateAsync(updateItems);
        }

        public override async Task SaveAsync()
        {
            foreach (var item in Items)
            {
                UpdateUpdateItem(item.Value.MainType, item.Value.SubType, item.Value.UpdateDataDate, item.Value.Payload);
            }

            await Task.Delay(1);
        }

        #endregion Abstract Methods

        #region Private Methods

        private async Task<bool> DoDataUpdateAsync(List<SAUpdateLocalDataItem<string>> updateItems)
        {
            Error.ClearErrorMessage();
            var tSuccess = true;
            var tMessage = string.Empty;

            foreach (var item in updateItems)
            {
                switch (item.MainType)
                {
                    case MAUpdateItem.Accounts:
                        tSuccess = await UpdateAccountDataAsync();
                        if (tSuccess) tMessage = "Updated account data";
                        break;

                    case MAUpdateItem.PLBudget:
                        tSuccess = await UpdatePLBudgetAsync(item.SubType);
                        if (tSuccess) tMessage = "Updated budget data";
                        break;

                    case MAUpdateItem.BSBudget:
                        tSuccess = await UpdateBSBudgetAsync(item.SubType);
                        if (tSuccess) tMessage = "Updated budget data";
                        break;

                    case MAUpdateItem.CustomerData:
                        tSuccess = await UpdateCustomerDataAsync();
                        if (tSuccess) tMessage = "Updated customer data";
                        break;

                    case MAUpdateItem.ImportExclusions:
                        tSuccess = await UpdateImportExclusionsAsync(item.SubType);
                        if (tSuccess) tMessage = $"Updated import exclusions: Period {item.SubType}";
                        break;

                    case MAUpdateItem.ReportStructure:
                        tSuccess = await UpdateReportStructureAsync(item.SubType.Value<int>());
                        if (tSuccess) tMessage = $"Updated report structure data: ReportId {item.SubType}";
                        break;

                    case MAUpdateItem.Settings:
                        tSuccess = await UpdateSettingsAsync();
                        if (tSuccess) tMessage = "Updated settings data";
                        break;
                }

                if (tSuccess)
                {
                    MessageChanged(tMessage);
                    //UpdateUpdateItem(item.UpdateId.ParseEnum<MAUpdateItem>(), item.Variant, item.UTCDateTimeAvailable, item.UpdatedBy);
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

        private async Task<bool> UpdateCustomerDataAsync()
        {
            try
            {
                await MADataAccess.CloudData.CustomerNumbers.LoadAsync();

                MADataAccess.LocalData.TLDDHLCustomerNumberUpdate(MADataAccess.CloudData.CustomerNumbers.Accounts);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> UpdatePLBudgetAsync(string period)
        {
            try
            {
                //Update P&L Budget

                await MADataAccess.CloudData.Budgets.LoadAsync(MAReportType.ProfitLoss, period);

                MADataAccess.LocalData.TLDPLBudgetUpdate(MADataAccess.CloudData.Budgets.Budgets, period);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> UpdateBSBudgetAsync(string period)
        {
            try
            {
                //Update P&L Budget

                await MADataAccess.CloudData.Budgets.LoadAsync(MAReportType.BalanceSheet, period);

                MADataAccess.LocalData.TLDBSBudgetUpdate(MADataAccess.CloudData.Budgets.Budgets, period);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> UpdateAccountDataAsync()
        {
            try
            {
                //Sync Balance Sheet Accounts
                await MADataAccess.CloudData.Accounts.LoadAsync(MAReportType.BalanceSheet);

                MADataAccess.LocalData.TLMBSAccountUpdate(MADataAccess.CloudData.Accounts.Accounts);

                //Sync P&L Accounts
                await MADataAccess.CloudData.Accounts.LoadAsync(MAReportType.ProfitLoss);

                MADataAccess.LocalData.TLMPLAccountUpdate(MADataAccess.CloudData.Accounts.Accounts);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> UpdateReportStructureAsync(int reportId)
        {
            try
            {
                await MADataAccess.CloudData.Structure.LoadAsync(reportId);

                MADataAccess.LocalData.TLMReportStructureUpdate(MADataAccess.CloudData.Structure.Get(reportId), reportId);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> UpdateImportExclusionsAsync(string period)
        {
            try
            {
                await MADataAccess.CloudData.ImportExclusions.LoadAsync(period);

                MADataAccess.LocalData.TLDDHLInvoiceExclusionsUpdate(MADataAccess.CloudData.ImportExclusions.Item.Adapt<TLDDHLInvoiceExclusion>());

                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> UpdateSettingsAsync()
        {
            try
            {
                await MADataAccess.CloudData.Settings.LoadAsync();
                MADataAccess.LocalData.TLSSettingUpdate(MADataAccess.CloudData.Settings.Settings.Adapt<TLSSetting>());
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void UpdateUpdateItem(string updateType, string variant, string utcDateTimeUpdated, string payload)
        {
            MADataAccess.LocalData.TLSUpdateLogUpdate(updateType, variant, utcDateTimeUpdated, payload);
        }

        #endregion Private Methods
    }
}