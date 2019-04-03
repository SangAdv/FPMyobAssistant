﻿using SangAdv.Common;
using SangAdv.Common.Cloud;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FPMyobAssistant
{
    internal class MACBudgets
    {
        #region Variables

        private SAAzureTableStorage mStor;

        #endregion Variables

        #region Properties

        public List<MACBudgetItem> Budgets = new List<MACBudgetItem>();
        public string ErrorMessage { get; private set; } = string.Empty;

        #endregion Properties

        #region Constructor

        public MACBudgets(SAAzureTableStorage stor)
        {
            mStor = stor;
        }

        #endregion Constructor

        #region Methods

        public async Task<SAEventArgs> SaveAsync(MAReportType type, string period)
        {
            try
            {
                await mStor.InsertOrReplaceAsync(MACTableNames.BudgetData, MACPartitionNames.ReportType, $"{type}-{period}", Budgets);
                return new SAEventArgs();
            }
            catch (Exception ex)
            {
                return new SAEventArgs(ex.Message, SAResults.Database.SaveError);
            }
        }

        public async Task<bool> LoadAsync(MAReportType type, string period)
        {
            try
            {
                var tBudgets = await mStor.GetAsync<List<MACBudgetItem>>(MACTableNames.BudgetData, MACPartitionNames.ReportType, $"{type}-{period}");
                Budgets = tBudgets ?? new List<MACBudgetItem>();
                return true;
            }
            catch
            {
                Budgets.Clear();
                return false;
            }
        }

        public void Clear()
        {
            Budgets.Clear();
        }

        #endregion Methods
    }
}