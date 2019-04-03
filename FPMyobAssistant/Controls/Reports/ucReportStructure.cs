using DevExpress.XtraEditors.Controls;
using SangAdv.Common;
using SangAdv.Common.ObjectExtensions;
using SangAdv.Common.StringExtensions;
using SangAdv.Common.UI;
using SangAdv.DevExpressUI;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FPMyobAssistant
{
    public partial class ucReportStructure : ucTemplate
    {
        #region Variables

        private MABaseControls mBase;
        private MAReportStructure mStructure = new MAReportStructure();

        private int mReportId = 0;
        private int mHeadingId = 0;
        private int mItemId = 0;

        #endregion Variables

        #region Constructor

        public ucReportStructure()
        {
            InitializeComponent();
            mBase = new MABaseControls(this);
            mBase.SetTitle("Report Structure");

            btnExportStructure.Enabled = false;
            btnUpdate.Enabled = false;
            btnFromPreviousReport.Enabled = false;

            LoadReports();
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
            mItemId = 0;

            //Only load non calculated headings
            foreach (var item in mStructure.HeadingItems.Values.OrderBy(x => x.HeadingId).Where(x => x.IsCalculation == 0))
            {
                icbHeading.Properties.Items.Add(new ImageComboBoxItem(item.HeadingDescription, item.HeadingId, 0));
            }
            icbHeading.SelectedIndex = 0;
        }

        private void LoadReportStructure()
        {
            if (mReportId == 0) return;
            if (mHeadingId == 0) return;

            tlStructure.SuspendLayout();

            //Do not load structure items for heading without children
            if (!mStructure.HeadingItems[mHeadingId].HasChildren.Value<bool>())
            {
                tlStructure.DataSource = null;
            }
            else
            {
                var tlData = new MATreelistItems();

                foreach (var item in mStructure.HeadingItems[mHeadingId].StructureItems)
                {
                    if (!item.IsGrouping)
                        tlData.Add(new MATreeListItem { Description = item.ReportDescription, Id = item.ItemId.ToString(), AccountCount = item.AccountCount });
                }

                tlStructure.DataSource = tlData.Items;
                tlStructure.ExpandAll();
            }

            tlStructure.ResumeLayout();

            ResetFields(false);

            gcItemSettings.Enabled = mStructure.HeadingItems[mHeadingId].HasChildren == 1;
            gcItemAccounts.Enabled = mStructure.HeadingItems[mHeadingId].HasChildren == 0;
        }

        private void ResetFields(bool resetStructure = true)
        {
            if (resetStructure) tlStructure.DataSource = null;
            gcItemAccounts.Enabled = false;
            txtDescription.Text = string.Empty;
            btnUpdate.Text = "Add";
            btnDelete.Enabled = false;
            btnUp.Enabled = false;
            btnDown.Enabled = false;
            mItemId = 0;
        }

        private void LoadItem()
        {
            var a = mStructure.HeadingItems[mHeadingId].GetItem(mItemId);
            if (a.ItemId == 0)
            {
                ResetFields();
                return;
            }

            gcItemAccounts.Enabled = true;

            txtDescription.Text = a.ReportDescription;

            LoadAccounts(a.AccountItems);

            btnUpdate.Text = "Update";
            btnDelete.Enabled = true;
            btnUp.Enabled = true;
            btnDown.Enabled = true;

            btnDefine.Enabled = true;
        }

        private void LoadAccounts(List<string> accounts)
        {
            tlAccounts.SuspendLayout();
            var tlData = new MATreelistItems();

            foreach (var item in accounts.OrderBy(x => x)) tlData.Add(new MATreeListItem { Description = $"{item} > {mStructure.AccountDescription(item)}", Id = item });

            tlAccounts.DataSource = tlData.Items;
            tlAccounts.ExpandAll();
            tlAccounts.ResumeLayout();
        }

        private void AddStructureItem(string itemDescription)
        {
            if (mItemId == 0) mItemId = mStructure.GetNewItemId;
            mStructure.Update(mHeadingId, mItemId, itemDescription);
            LoadReportStructure();
            mItemId = 0;
        }

        private void AddItemAccounts(List<string> accounts)
        {
            var a = mStructure.HeadingItems[mHeadingId].GetItem(mItemId);
            a.RemoveAllAccountCodes();
            a.AddAccounts(accounts);
            mStructure.HeadingItems[mHeadingId].SaveItems();
            LoadItem();
            LoadReportStructure();
            MADataAccess.DataSyncUpdate.Add(new SASyncDataItem { MainType = MAUpdateItem.ReportStructure, SubType = mReportId.ToString(), Payload = string.Empty });
        }

        #endregion Private Methods

        #region Process UI

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
                LoadReportStructure();
            }
            catch
            {
                mHeadingId = 0;
                mItemId = 0;
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            ResetFields();
        }

        private void tlStructure_Click(object sender, System.EventArgs e)
        {
            try
            {
                mItemId = tlStructure.FocusedNode["Id"].Value<int>();
                LoadItem();
            }
            catch
            {
                mItemId = 0;
                ResetFields();
            }
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            AddStructureItem(txtDescription.Text.Trim());
        }

        private void beStructureFilename_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            btnExportStructure.Enabled = false;
            beStructureFilename.Text = string.Empty;
            var tFilename = SADialogs.Dialogs.SaveDataFile(true, true, true);
            if (string.IsNullOrEmpty(tFilename)) return;
            beStructureFilename.Text = tFilename;
            btnExportStructure.Enabled = true;
        }

        private void btnExportStructure_Click(object sender, System.EventArgs e)
        {
            mStructure.Print(beStructureFilename.Text, icbReport.Text);
            beStructureFilename.Text = string.Empty;
            btnExportStructure.Enabled = false;
        }

        private void btnUp_Click(object sender, System.EventArgs e)
        {
            mStructure.HeadingItems[mHeadingId].MoveUp(mItemId);
            LoadReportStructure();
        }

        private void btnDown_Click(object sender, System.EventArgs e)
        {
            mStructure.HeadingItems[mHeadingId].MoveDown(mItemId);
            LoadReportStructure();
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            mStructure.HeadingItems[mHeadingId].Delete(mItemId);
            ResetFields();
            LoadReportStructure();
        }

        private void txtDescription_TextChanged(object sender, System.EventArgs e)
        {
            btnUpdate.Enabled = !string.IsNullOrEmpty(txtDescription.Text);
            btnFromPreviousReport.Enabled = btnUpdate.Enabled;
        }

        private void btnFromPreviousReport_Click(object sender, System.EventArgs e)
        {
            var f = new frmCopyItem();
            ;
            if (f.ShowDialog(this) == DialogResult.Cancel) return;
        }

        private void btnDefine_Click(object sender, System.EventArgs e)
        {
            var f = new frmChooseAccounts(mReportId, mItemId);
            var dialogResult = f.ShowDialog(this);
            if (dialogResult != DialogResult.OK) return;

            AddItemAccounts(f.SelectedAccounts);
        }

        #endregion Process UI
    }
}