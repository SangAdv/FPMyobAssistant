using DevExpress.XtraTreeList.Nodes;
using Mapster;
using SangAdv.Common.JSonExtensions;
using SangAdv.Common.ListExtensions;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace FPMyobAssistant
{
    public partial class frmChooseAccounts : DevExpress.XtraEditors.XtraForm
    {
        #region Variables

        private MAAccountsSelector mAccountsSelector;
        private string mFocusesAccountCode = string.Empty;

        #endregion Variables

        #region Properties

        internal List<string> SelectedAccounts => mAccountsSelector.SelectedAccounts;

        #endregion Properties

        #region Constructor

        public frmChooseAccounts(int reportId, int selectedItemId)
        {
            InitializeComponent();

            tlUnselected.OptionsBehavior.AllowRecursiveNodeChecking = true;
            tlSelected.OptionsBehavior.AllowRecursiveNodeChecking = true;

            btnRemove.Enabled = false;
            btnAdd.Enabled = false;

            mAccountsSelector = new MAAccountsSelector(reportId);

            mAccountsSelector.SelectItem(selectedItemId);
            Text = $"Choose Account > {mAccountsSelector.ItemDescription}";
        }

        #endregion Constructor

        #region Methods

        private void LoadLists()
        {
            mAccountsSelector.LoadItems();

            tlUnselected.SuspendLayout();
            tlSelected.SuspendLayout();

            tlUnselected.DataSource = null;
            tlSelected.DataSource = null;

            tlUnselected.DataSource = mAccountsSelector.UnselectedItems.Items;
            tlSelected.DataSource = mAccountsSelector.SelectedItems.Items;

            tlUnselected.ExpandAll();
            tlSelected.ExpandAll();

            tlUnselected.ResumeLayout();
            tlSelected.ResumeLayout();
        }

        #endregion Methods

        #region Process UI

        private void frmChooseAccounts_Shown(object sender, System.EventArgs e)
        {
            LoadLists();
        }

        private void tlUnselected_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            btnAdd.Enabled = tlUnselected.GetAllCheckedNodes().Count > 0;
        }

        private void tlSelected_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            btnRemove.Enabled = tlSelected.GetAllCheckedNodes().Count > 0;
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            foreach (TreeListNode node in tlUnselected.GetAllCheckedNodes())
            {
                if (!node.HasChildren) SelectedAccounts.AddUnique(node["AccountCode"].ToString());
            }

            LoadLists();
            tlUnselected.UncheckAll();
            btnAdd.Enabled = false;
        }

        private void btnRemove_Click(object sender, System.EventArgs e)
        {
            foreach (TreeListNode node in tlSelected.GetAllCheckedNodes())
            {
                var tString = node["AccountCode"].ToString();
                if (SelectedAccounts.Contains(tString)) SelectedAccounts.Remove(tString);
            }

            LoadLists();
            tlSelected.UncheckAll();
            btnRemove.Enabled = false;
        }

        private void tlSelected_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                mFocusesAccountCode = tlSelected.GetFocusedRowCellValue(colAccountCode1).ToString();
                tlUnselected.Refresh();
            }
            catch
            {
                // ignored
            }
        }

        private void tlUnselected_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            if (string.IsNullOrEmpty(mFocusesAccountCode)) return;
            try
            {
                var a = e.Node;
                var b = a.GetValue(colAccountCode).ToString();
                if (b == mFocusesAccountCode)
                {
                    e.Appearance.BackColor = Color.Red;
                }
            }
            catch
            {
            }
        }

        private void tlUnselected_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            mFocusesAccountCode = string.Empty;
        }

        #endregion Process UI
    }

    internal class MAAccountsSelector
    {
        #region Variables

        private int mselectedItemId = 0;
        private Dictionary<int, List<string>> mReportAccounts = new Dictionary<int, List<string>>();
        private Dictionary<int, string> mReportItemDescription = new Dictionary<int, string>();
        internal List<MACAccountItem> mAllAccounts = new List<MACAccountItem>();

        #endregion Variables

        #region Properties

        internal List<string> SelectedAccounts { get; private set; } = new List<string>();
        internal string ItemDescription => mReportItemDescription[mselectedItemId];
        internal MATreelistItems UnselectedItems { get; private set; } = new MATreelistItems();
        internal MATreelistItems SelectedItems { get; private set; } = new MATreelistItems();

        #endregion Properties

        #region Constructor

        public MAAccountsSelector(int reportId)
        {
            var a = MADataAccess.LocalData.TLMReportStructureList(reportId);
            foreach (var item in a)
            {
                mReportAccounts[item.ItemId] = string.IsNullOrEmpty(item.AccountItems) ? new List<string>() : item.AccountItems.DeserializeObject<List<string>>();
                mReportItemDescription[item.ItemId] = string.IsNullOrEmpty(item.ReportDescription) ? "Empty Description!" : item.ReportDescription;
            }

            var rpt = MADataAccess.LocalData.TLMReportItem(reportId);

            mAllAccounts = rpt.ReportType == (long)MAReportType.ProfitLoss ? MADataAccess.LocalData.TLMPLAccountList().Adapt<List<MACAccountItem>>() : MADataAccess.LocalData.TLMBSAccountList().Adapt<List<MACAccountItem>>();
        }

        #endregion Constructor

        #region Methods

        internal void SelectItem(int selectedItemId)
        {
            mselectedItemId = selectedItemId;
            SelectedAccounts = mReportAccounts[selectedItemId];
        }

        internal void LoadItems()
        {
            UnselectedItems.Clear();
            SelectedItems.Clear();

            foreach (var item in mAllAccounts.OrderBy(x => x.AccountId))
            {
                if (SelectedAccounts.Contains(item.AccountId)) LoadItem(SelectedItems, item.AccountId);
                if (!mReportAccounts.Any(x => x.Value.Contains(item.AccountId))) LoadItem(UnselectedItems, item.AccountId);
            }
        }

        private void LoadItem(MATreelistItems treeListItems, string accountId)
        {
            if (!treeListItems.HasItem(accountId))
            {
                var items = mAllAccounts.Where(x => x.AccountId == accountId);
                if (items.Any())
                {
                    var item = items.First();
                    treeListItems.Add(new MATreeListItem { Id = item.AccountId, ParentId = item.ParentAccountId, Description = item.AccountDescription, AccountCode = item.AccountId });
                    if (accountId == "0000000000") return;
                    LoadItem(treeListItems, item.ParentAccountId);
                }
            }
        }

        #endregion Methods
    }
}