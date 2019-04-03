using LocalModelContext;
using SangAdv.Common;
using SangAdv.Common.JSonExtensions;
using SangAdv.Common.ListExtensions;
using SangAdv.Common.ObjectExtensions;
using SangAdv.Common.StringExtensions;
using SangAdv.DevExpressUI;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FPMyobAssistant
{
    internal class MAReportStructure
    {
        #region Variables

        private int mReportId = 0;
        private MAReportType mReportType = MAReportType.ProfitLoss;
        private Dictionary<string, string> mAllTypeAccountCodes = new Dictionary<string, string>();

        #endregion Variables

        #region Properties

        public Dictionary<int, MAReportHeadingItem> HeadingItems { get; } = new Dictionary<int, MAReportHeadingItem>();

        internal Dictionary<string, string> AvailableTypeAccountCodes
        {
            get
            {
                var tDictionary = new Dictionary<string, string>();
                foreach (var item in mAllTypeAccountCodes)
                {
                    if (!HasAccount(item.Key)) tDictionary.Add(item.Key, item.Value);
                }

                return tDictionary;
            }
        }

        public int GetNewItemId => HeadingItems.Values.Select(x => x.MaxItemId).Max() + 1;

        public List<int> DuplicateItems { get; private set; } = new List<int>();

        #region Private Properties

        private bool HasAccount(string accountCode)
        {
            return HeadingItems.Values.Any(x => x.HasAccount(accountCode));
        }

        #endregion Private Properties

        #endregion Properties

        #region Methods

        internal void Load(int reportId)
        {
            mReportId = reportId;
            LoadReport();
        }

        internal void Update(int headingId, int itemId, string description)
        {
            HeadingItems[headingId].Update(itemId, description);
        }

        internal string AccountDescription(string accountCode)
        {
            return mAllTypeAccountCodes.TryGetValue(accountCode, out var tString) ? tString : string.Empty;
        }

        internal void Print(string filename, string reportTitle)
        {
            var rowCounter = 4;
            var er = new SAExcelReport(filename, false, false);

            foreach (var headingItem in HeadingItems.OrderBy(x => x.Key))
            {
                er.AddText(0, rowCounter, 0, headingItem.Key.ToString());
                er.AddText(0, rowCounter, 1, headingItem.Value.HeadingDescription);
                rowCounter++;

                foreach (var structureItem in headingItem.Value.StructureItems.OrderBy(x => x.SequenceIndex))
                {
                    if (!structureItem.IsGrouping)
                    {
                        er.AddText(0, rowCounter, 2, structureItem.ReportDescription);
                        rowCounter++;

                        foreach (var accountItem in structureItem.AccountItems.OrderBy(x => x))
                        {
                            er.AddText(0, rowCounter, 3, accountItem);
                            er.AddText(0, rowCounter, 4, AccountDescription(accountItem));
                            rowCounter++;
                        }
                    }
                }
            }

            er.AutoFit(0, 0, 4);
            er.AddHeading(0, reportTitle, "Myob Assistant");
            er.Save(0);

            if (File.Exists(filename)) SAProcess.OpenFileInDefaultApp(filename);
        }

        #endregion Methods

        #region Private Methods

        private void LoadReport()
        {
            var r = MADataAccess.LocalData.TLMReportItem(mReportId);
            mReportType = (MAReportType)r.ReportType;

            mAllTypeAccountCodes.Clear();
            if (mReportType == MAReportType.ProfitLoss)
            {
                foreach (var item in MADataAccess.LocalData.TLMPLAccountList())
                {
                    if (item.ParentAccountId != "0000000000") mAllTypeAccountCodes.Add(item.AccountId, item.AccountDescription);
                }
            }
            else
            {
                var tTemp = new MABSAccounts();
                foreach (var item in tTemp.NoChildAccounts)
                {
                    if (item.ParentAccountId != "0000000000") mAllTypeAccountCodes.Add(item.AccountId.Trim().AddLeadingZeros(10), item.AccountDescription);
                }
            }

            //Load Report Heading Items
            HeadingItems.Clear();
            foreach (var item in MADataAccess.LocalData.TLMReportHeadingList(mReportId))
            {
                var hi = new MAReportHeadingItem(mReportId) { HeadingId = item.HeadingId, HeadingDescription = item.ReportHeading, IsCalculation = item.IsCalculation, HasChildren = item.HasChildren, IncomeAsNegative = item.IncomeAsNegative };
                //Load report Items
                hi.LoadItems();
                DuplicateItems = hi.DuplicateItems;
                //If heading does not have children, ensure system added entry is present

                HeadingItems.Add(item.HeadingId, hi);
            }
            //Ensure heading without Children have System Entries
            foreach (var heading in HeadingItems)
            {
                if (heading.Value.HasChildren.Value<bool>()) continue;

                if (heading.Value.StructureItemCount == 0 && !heading.Value.IsCalculation.Value<bool>()) heading.Value.Update(0, "System Added Entry");
            }
        }

        #endregion Private Methods
    }

    internal class MAReportHeadingItem
    {
        #region Variables

        private int mReportId = 0;
        private List<MAReportStructureItem> mStructureItems = new List<MAReportStructureItem>();

        #endregion Variables

        #region Properties

        public int HeadingId { get; set; }
        public string HeadingDescription { get; set; } = string.Empty;
        public int IsCalculation { get; set; }
        public int HasChildren { get; set; } = 1;
        public int IncomeAsNegative { get; set; } = 0;

        public List<MAReportStructureItem> StructureItems
        {
            get { return HasChildren.Value<bool>() ? mStructureItems.Where(x => x.ItemId != 0).OrderBy(x => x.SequenceIndex).ToList() : mStructureItems.Where(x => x.ItemId == 0).OrderBy(x => x.SequenceIndex).ToList(); }
        }

        public int MaxItemId
        {
            get
            {
                try
                {
                    return mStructureItems.Select(x => x.ItemId).Max();
                }
                catch
                {
                    return 0;
                }
            }
        }

        public int NextSequenceIndex
        {
            get
            {
                try
                {
                    return mStructureItems.Select(x => x.SequenceIndex).Max() + 1;
                }
                catch
                {
                    return 1;
                }
            }
        }

        public List<int> DuplicateItems { get; private set; } = new List<int>();

        #endregion Properties

        #region Derived Properties

        public int StructureItemCount => StructureItems.Count;

        #endregion Derived Properties

        #region Constructor

        public MAReportHeadingItem(int reportId)
        {
            mReportId = reportId;
        }

        #endregion Constructor

        #region Methods

        internal void Update(int itemId, string description)
        {
            var a = mStructureItems.Where(x => x.HeadingId == HeadingId && x.ItemId == itemId).ToList();
            if (a.Any()) a.First().ReportDescription = description;
            else
            {
                mStructureItems.Add(new MAReportStructureItem { HeadingId = HeadingId, ItemId = itemId, ReportDescription = description, SequenceIndex = NextSequenceIndex });
            }

            SaveItems();
        }

        internal void Delete(int itemId)
        {
            var a = mStructureItems.Where(x => x.ItemId == itemId);
            if (a.Any()) mStructureItems.Remove(a.First());
            SaveItems();
        }

        internal bool HasAccount(string accountCode)
        {
            return mStructureItems.Any(x => x.HasAccount(accountCode));
        }

        internal void LoadItems()
        {
            var currentItems = new List<int>();
            DuplicateItems.Clear();
            mStructureItems.Clear();

            //Add a system entry if item does not have children and the entry is not present
            var a = MADataAccess.LocalData.TLMReportStructureList(mReportId, HeadingId);

            foreach (var item in a)
            {
                if (!currentItems.Contains(item.ItemId)) currentItems.Add(item.ItemId);
                else DuplicateItems.Add(item.ItemId);

                var b = new MAReportStructureItem
                {
                    HeadingId = HeadingId,
                    ItemId = item.ItemId,
                    ReportDescription = item.ReportDescription,
                    AccountItems = string.IsNullOrEmpty(item.AccountItems) ? new List<string>() : item.AccountItems.DeserializeObject<List<string>>(),
                    GroupItems = string.IsNullOrEmpty(item.GroupItems) ? new List<string>() : item.GroupItems.DeserializeObject<List<string>>(),
                    IsGrouping = item.IsGrouping.Value<bool>(),
                    SequenceIndex = item.SequenceIndex
                };
                mStructureItems.Add(b);
            }
        }

        internal void SaveItems()
        {
            //Delete all the items
            MADataAccess.LocalData.TLMReportStructureDeleteAll(mReportId, HeadingId);
            //Now add all the items
            var tList = new List<TLMReportStructure>();
            foreach (var item in mStructureItems) tList.Add(new TLMReportStructure
            {
                ReportId = mReportId,
                HeadingId = HeadingId,
                ItemId = item.ItemId,
                ReportDescription = item.ReportDescription,
                AccountItems = item.AccountItems.SerializeObject(),
                GroupItems = item.GroupItems.SerializeObject(),
                IsGrouping = item.IsGrouping ? 1 : 0,
                SequenceIndex = item.SequenceIndex
            });
            MADataAccess.LocalData.TLMReportStructureUpdate(tList);
        }

        internal MAReportStructureItem GetItem(int itemId)
        {
            var a = mStructureItems.Where(x => x.ItemId == itemId).ToList();
            return a.Any() ? a.First() : new MAReportStructureItem();
        }

        internal void MoveUp(int itemId)
        {
            if (StructureItemCount == 0) return;
            var currentItem = GetItem(itemId);
            for (var i = currentItem.SequenceIndex - 1; i > 0; i--)
            {
                var prevItem = mStructureItems.Where(x => x.SequenceIndex == i).ToList();
                if (prevItem.Any())
                {
                    prevItem.First().SequenceIndex = currentItem.SequenceIndex;
                    currentItem.SequenceIndex = i;
                    SaveItems();
                    break;
                }
            }
        }

        internal void MoveDown(int itemId)
        {
            if (StructureItemCount == 0) return;
            var currentItem = GetItem(itemId);
            var maxSequenceCount = mStructureItems.Select(x => x.SequenceIndex).Max();

            for (var i = currentItem.SequenceIndex + 1; i <= maxSequenceCount; i++)
            {
                var nextItem = mStructureItems.Where(x => x.SequenceIndex == i).ToList();
                if (nextItem.Any())
                {
                    nextItem.First().SequenceIndex = currentItem.SequenceIndex;
                    currentItem.SequenceIndex = i;
                    SaveItems();
                    break;
                }
            }
        }

        #endregion Methods
    }

    internal class MAReportStructureItem
    {
        #region Properties

        public int HeadingId { get; set; }
        public int ItemId { get; set; }
        public string ReportDescription { get; set; } = string.Empty;
        public List<string> AccountItems { get; set; } = new List<string>();
        public List<string> GroupItems { get; set; } = new List<string>();
        public bool IsGrouping { get; set; }
        public int SequenceIndex { get; set; } = 0;

        #endregion Properties

        #region Derived Properties

        public int AccountCount => AccountItems.Count;
        public int GroupCount => GroupItems.Count;

        #endregion Derived Properties

        #region Methods

        #region Accounts

        public void AddAccount(string accountCode)
        {
            AccountItems.AddUnique(accountCode);
        }

        public void AddAccounts(List<string> accountCodes)
        {
            foreach (var accountCode in accountCodes)
                AddAccount(accountCode);
        }

        public void RemoveAccountCode(string accontCode)
        {
            if (HasAccount(accontCode)) AccountItems.Remove(accontCode);
        }

        public void RemoveAllAccountCodes()
        {
            AccountItems.Clear();
        }

        public bool HasAccount(string accountCode)
        {
            return AccountItems.Contains(accountCode);
        }

        #endregion Accounts

        #region Groups

        public void AddGroup(string groupCode)
        {
            GroupItems.AddUnique(groupCode);
        }

        public void AddGroups(List<string> groupCodes)
        {
            foreach (var groupCode in groupCodes)
                AddGroup(groupCode);
        }

        public void RemoveGroupCode(string groupCode)
        {
            if (HasGroup(groupCode)) GroupItems.Remove(groupCode);
        }

        public void RemoveAllGroupCodes()
        {
            GroupItems.Clear();
        }

        public bool HasGroup(string groupCode)
        {
            return GroupItems.Contains(groupCode);
        }

        #endregion Groups

        #endregion Methods
    }
}