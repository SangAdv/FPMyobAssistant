using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace FPMyobAssistant
{
    internal class MADHLMasterItem : INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Variables

        private bool mIsIncluded;

        #endregion Variables

        #region Properties

        public string OrderNumber { get; set; } = string.Empty;
        public string CustomerNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string ShipToName { get; set; } = string.Empty;
        public bool CanBeIncluded => InvoiceDate != null;

        public bool IsIncluded
        {
            get => mIsIncluded;
            set => mIsIncluded = CanBeIncluded && value;
        }

        public DateTime? InvoiceDate { get; set; }
        public MADHLDetail Detail { get; set; } = new MADHLDetail();
        public float InvoiceValue => Details.Sum(x => x.Value);
        public List<MADHLDetailItem> Details => Detail.Items;

        #endregion Properties
    }
}