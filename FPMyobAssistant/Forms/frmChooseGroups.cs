using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList.Nodes;
using SangAdv.Common.JSonExtensions;
using SangAdv.Common.ListExtensions;
using SangAdv.Common.ObjectExtensions;
using SangAdv.Common.StringExtensions;
using SangAdv.Common.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FPMyobAssistant
{
    public partial class frmChooseGroups : DevExpress.XtraEditors.XtraForm
    {
        #region Variables

        private MAGroupsSelector mGroupsSelector;
        private MAReportStructure mStructure = new MAReportStructure();

        private string mSelectedItemId;

        private int mReportId = 0;
        private int mHeadingId = 0;

        #endregion Variables

        #region Properties

        internal List<string> SelectedGroups => mGroupsSelector.SelectedGroups;

        #endregion Properties

        #region Constructor

        public frmChooseGroups(string selectedItemId)
        {
            InitializeComponent();

            mSelectedItemId = selectedItemId;

            tlUnselected.OptionsBehavior.AllowRecursiveNodeChecking = true;
            tlSelected.OptionsBehavior.AllowRecursiveNodeChecking = true;
            tlUnselected.Cursor = Cursor.Current;

            btnRemove.Enabled = false;
            btnAdd.Enabled = false;

            mGroupsSelector = new MAGroupsSelector();

            mGroupsSelector.SelectItem(selectedItemId);
            Text = $"Choose Groups > {mGroupsSelector.ItemDescription}";
        }

        #endregion Constructor

        #region Private Methods

        private void LoadReports()
        {
            icbReport.Properties.Items.Clear();
            foreach (var item in MADataAccess.LocalData.TLMReportList(true))
            {
                icbReport.Properties.Items.Add(new ImageComboBoxItem($"{item.ReportDescription} [{((MAReportType)item.ReportType).ToString().SplitCapitalizedWords()}]", item.ReportId, 0));
            }
            icbReport.SelectedIndex = 0;
        }

        private void LoadReportHeadings()
        {
            icbHeading.Properties.Items.Clear();
            icbHeading.Text = string.Empty;

            //Only load non calculated headings
            foreach (var item in mStructure.HeadingItems.Values.OrderBy(x => x.HeadingId).Where(x => x.IsCalculation == 0))
            {
                icbHeading.Properties.Items.Add(new ImageComboBoxItem(item.HeadingDescription, item.HeadingId, 0));
            }
            icbHeading.SelectedIndex = 0;
        }

        private void LoadLists()
        {
            mGroupsSelector.LoadItems(mReportId, mHeadingId);

            tlUnselected.SuspendLayout();
            tlSelected.SuspendLayout();

            tlUnselected.DataSource = null;
            tlSelected.DataSource = null;

            tlUnselected.DataSource = mGroupsSelector.UnselectedItems.Items;
            tlSelected.DataSource = mGroupsSelector.SelectedItems.Items;

            tlUnselected.ExpandAll();
            tlSelected.ExpandAll();

            tlUnselected.ResumeLayout();
            tlSelected.ResumeLayout();
        }

        private void ResetFields(bool resetStructure = true)
        {
            //if (resetStructure) tlStructure.DataSource = null;
            //gcItemAccounts.Enabled = false;
            //txtDescription.Text = string.Empty;
            //btnUpdate.Text = "Add";
            //btnDelete.Enabled = false;
            //btnUp.Enabled = false;
            //btnDown.Enabled = false;
        }

        #endregion Private Methods

        #region Process UI

        private void frmChooseGroups_Shown(object sender, System.EventArgs e)
        {
            LoadReports();
        }

        private void icbReport_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            mHeadingId = 0;
            ResetFields();
            try
            {
                mReportId = icbReport.EditValue.Value<int>();
                mStructure.Load(mReportId);
                LoadReportHeadings();

                if (mStructure.DuplicateItems.Count > 0)
                {
                    SADialogs.Dialogs.OKDialog("Report error", "Duplicate itemIds found", MessageBoxIcon.Error);
                }
            }
            catch
            {
                ResetFields();
            }
        }

        private void icbHeading_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                mHeadingId = icbHeading.EditValue.Value<int>();
                LoadLists();
            }
            catch
            {
                mHeadingId = 0;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (TreeListNode node in tlUnselected.GetAllCheckedNodes())
            {
                SelectedGroups.AddUnique(node["AccountCode"].ToString());
            }

            LoadLists();
            tlUnselected.UncheckAll();
            btnAdd.Enabled = false;
        }

        private void tlUnselected_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            btnAdd.Enabled = tlUnselected.GetAllCheckedNodes().Count > 0;
        }

        private void tlSelected_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            btnRemove.Enabled = tlSelected.GetAllCheckedNodes().Count > 0;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (TreeListNode node in tlSelected.GetAllCheckedNodes())
            {
                var tString = node["AccountCode"].ToString();
                if (SelectedGroups.Contains(tString)) SelectedGroups.Remove(tString);
            }

            LoadLists();
            tlSelected.UncheckAll();
            btnRemove.Enabled = false;
        }

        #endregion Process UI
    }

    internal class MAGroupsSelector
    {
        #region Variables

        private List<MAGroupItem> mAllGroups = new List<MAGroupItem>();
        private string mSelectedItemId = string.Empty;

        #endregion Variables

        #region Properties

        internal List<string> SelectedGroups { get; private set; } = new List<string>();
        internal MATreelistItems UnselectedItems { get; private set; } = new MATreelistItems();
        internal MATreelistItems SelectedItems { get; private set; } = new MATreelistItems();
        internal string ItemDescription { get; private set; } = string.Empty;

        #endregion Properties

        #region Constructor

        public MAGroupsSelector()
        {
            var b = MADataAccess.LocalData.TLMReportStructureList();
            foreach (var entry in b) mAllGroups.Add(new MAGroupItem { Description = entry.ReportDescription, ReportId = entry.ReportId, HeadingId = entry.HeadingId, ItemId = entry.ItemId, SelectedGroups = entry.GroupItems });
        }

        #endregion Constructor

        #region Methods

        internal void SelectItem(string selectedItemId)
        {
            mSelectedItemId = selectedItemId;
            try
            {
                var selItems = mAllGroups.Where(x => x.MAId == selectedItemId);
                if (selItems.Any())
                {
                    ItemDescription = selItems.First().Description;
                    SelectedGroups = selItems.First().SelectedGroups.DeserializeObject<List<string>>() ?? new List<string>();
                }
                else throw new Exception();
            }
            catch
            {
                ItemDescription = "Unknown";
                SelectedGroups = new List<string>();
            }
        }

        internal void LoadItems(int reportId, int headingId)
        {
            UnselectedItems.Clear();
            SelectedItems.Clear();

            foreach (var item in mAllGroups.OrderBy(x => x.MAId))
            {
                if (SelectedGroups.Contains(item.MAId)) LoadItem(SelectedItems, item.MAId);
                else if (item.ReportId == reportId && item.HeadingId == headingId) LoadItem(UnselectedItems, item.MAId);
            }
        }

        private void LoadItem(MATreelistItems treeListItems, string maId)
        {
            if (!treeListItems.HasItem(maId))
            {
                var items = mAllGroups.Where(x => x.MAId == maId);
                if (items.Any())
                {
                    var item = items.First();
                    treeListItems.Add(new MATreeListItem { Id = item.MAId, Description = item.Description, AccountCode = item.MAId });
                    //if (accountId == "0000000000") return;
                    //LoadItem(treeListItems, "0");
                }
            }
        }

        #endregion Methods
    }

    internal class MAGroupItem
    {
        public string Description { get; set; } = string.Empty;
        public int ReportId { get; set; } = 0;
        public int HeadingId { get; set; } = 0;
        public int ItemId { get; set; } = 0;
        public string MAId => MAHelpers.SetMAId(ReportId, HeadingId, ItemId);
        public string SelectedGroups { get; set; } = string.Empty;
    }
}