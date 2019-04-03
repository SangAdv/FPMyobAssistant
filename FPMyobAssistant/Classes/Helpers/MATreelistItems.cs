using System.Collections.Generic;
using System.Linq;

namespace FPMyobAssistant
{
    internal class MATreelistItems
    {
        #region Properties

        internal List<MATreeListItem> Items { get; private set; } = new List<MATreeListItem>();

        #endregion Properties

        #region Methods

        internal void Add(MATreeListItem item)
        {
            if (Items.All(x => x.Id != item.Id)) Items.Add(item);
        }

        internal void Clear()
        {
            Items.Clear();
        }

        internal bool HasItem(string itemId)
        {
            return Items.Any(x => x.Id == itemId);
        }

        #endregion Methods
    }

    internal class MATreeListItem
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Description { get; set; }
        public string AccountCode { get; set; }
        public int AccountCount { get; set; }
        public bool IsActive { get; set; }
    }
}