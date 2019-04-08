using System.Collections.Generic;

namespace FPMyobAssistant
{
    public class MADHLDetail
    {
        #region Properties

        public List<MADHLDetailItem> Items = new List<MADHLDetailItem>();
        public int Count => Items.Count;

        #endregion Properties

        #region Methods

        public void Add(MADHLDetailItem detailItem)
        {
            Items.Add(detailItem);
        }

        #endregion Methods
    }
}