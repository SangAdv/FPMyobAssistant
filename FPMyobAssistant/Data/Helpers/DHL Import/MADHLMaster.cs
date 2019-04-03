using LocalModelContext;
using SangAdv.Common;
using SangAdv.Common.JSonExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace FPMyobAssistant
{
    internal class MADHLMaster
    {
        #region Variables

        private SAStringList mExcludedAccounts = new SAStringList();
        private SAStringList mExcludedOrders = new SAStringList();

        #endregion Variables

        #region Constructor

        public MADHLMaster()
        {
            LoadExcludedAccounts();
        }

        #endregion Constructor

        #region Properties

        public BindingList<MADHLMasterItem> Items = new BindingList<MADHLMasterItem>();
        public List<string> ExcludedAccounts => mExcludedAccounts.ValueList;
        public bool ExclusionsChanged { get; private set; } = false;
        public float IncludedInvoiceTotal => Items.Where(x => x.IsIncluded).Sum(x => x.InvoiceValue);

        #endregion Properties

        #region Methods

        public void Add(MADHLMasterItem masterItem)
        {
            Items.Add(masterItem);
            if (!masterItem.IsIncluded)
            {
                if (!mExcludedOrders.Contains(masterItem.OrderNumber))
                {
                    mExcludedOrders.Add(masterItem.OrderNumber);
                    ExclusionsChanged = true;
                }
            }
        }

        public bool Contains(string orderNumber) => Items.Any(x => x.OrderNumber.Trim() == orderNumber.Trim());

        public MADHLMasterItem Get(string orderNumber) => Items.FirstOrDefault(x => x.OrderNumber.Trim() == orderNumber.Trim());

        public bool IsExcludedAccount(string customerAccountNumber)
        {
            return mExcludedAccounts.Contains(customerAccountNumber);
        }

        public bool IsExcludedOrder(string orderNumber)
        {
            return mExcludedOrders.Contains(orderNumber);
        }

        private void LoadExcludedAccounts()
        {
            var tSettings = MADataAccess.LocalData.TLSSettingsItem();
            if (string.IsNullOrEmpty(tSettings.ImportExclusionAccounts)) mExcludedAccounts.Clear();
            else SetExcludedAccounts(tSettings.ImportExclusionAccounts.DeserializeObject<List<string>>());
        }

        public void LoadMasterExcludedOrders(string period)
        {
            var tData = MADataAccess.LocalData.TLDDHLInvoiceExclusionsItem(period);
            if (string.IsNullOrEmpty(tData.Exclusions)) mExcludedOrders.Clear();
            else mExcludedOrders.ValueList = tData.Exclusions.DeserializeObject<List<string>>();
        }

        public void SetExcludedAccounts(List<string> accounts)
        {
            mExcludedAccounts.ValueList = accounts;
        }

        public void Clear()
        {
            Items.Clear();
        }

        public void UpdateExcludedOrders(string period, string ordernumber, bool isIncluded)
        {
            if (!isIncluded) //Add to exclusion list
            {
                if (mExcludedOrders.Contains(ordernumber)) return;
                mExcludedOrders.Add(ordernumber);
            }
            else //Remove from exclusion list
            {
                if (!mExcludedOrders.Contains(ordernumber)) return;
                mExcludedOrders.Remove(ordernumber);
            }

            UpdateExclusions(period);
        }

        public void UpdateExclusions(string period)
        {
            MADataAccess.LocalData.TLDDHLInvoiceExclusionsUpdate(new TLDDHLInvoiceExclusion { Period = period, Exclusions = mExcludedOrders.ValueList.SerializeObject() });
            var syncItem = new SASyncDataItem { MainType = MAUpdateItem.ImportExclusions, SubType = period, Payload = string.Empty };
            MADataAccess.DataSyncUpdate.Add(syncItem);
        }

        #endregion Methods
    }

    internal class MADHLDetailBU
    {
        public List<MADHLDetailItem> Details { get; set; } = new List<MADHLDetailItem>();
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
    }
}