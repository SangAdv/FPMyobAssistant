using DevExpress.XtraEditors.Controls;
using SangAdv.Common;
using SangAdv.Common.ObjectExtensions;
using SangAdv.Common.StringExtensions;
using SangAdv.DevExpressUI;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPMyobAssistant
{
    public partial class ucReportErrors : ucTemplate
    {
        #region Variables

        private MABaseControls mBase;
        private MAReportStructure mStructure = new MAReportStructure();

        private int mReportId = 0;
        private int mHeadingId = 0;
        private int mItemId = 0;

        private findDuplicates mDuplicates = new findDuplicates();

        #endregion Variables

        #region Constructor

        public ucReportErrors()
        {
            InitializeComponent();
            mBase = new MABaseControls(this);
            mBase.SetTitle("Check Report Errors");

            btnCheck.Enabled = false;
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

        private void checkReport()
        {
            mDuplicates.Clear();
            //process every heading non calculated headings
            foreach (var item in mStructure.HeadingItems.Values.OrderBy(x => x.HeadingId).Where(x => x.IsCalculation == 0))
            {
                listboxMessage($"Processing {item.HeadingDescription}", true);

                foreach (var sitem in mStructure.HeadingItems[item.HeadingId].StructureItems)
                {
                    foreach (var account in sitem.AccountItems) mDuplicates.Add(account);
                }
            }

            //Check duplicates
            if (mDuplicates.Duplicates.Count > 0)
            {
                listboxMessage("Found Duplicates:");
                foreach (var item in mDuplicates.Duplicates)
                {
                    listboxMessage($"{item.Key} found {item.Value} times");
                    btnRemoveAll.Enabled = true;
                    txtAccountCode.Enabled = true;
                }
            }
            else
            {
                listboxMessage("No duplicates found");
            }
        }

        private void resetFields()
        {
            lbErrors.Items.Clear();
            btnRemoveAll.Enabled = false;
            txtAccountCode.Enabled = false;
        }

        private void listboxMessage(string message, bool addEmptyLine = false)
        {
            lbErrors.Items.Add(message);
            if (addEmptyLine) lbErrors.Items.Add("");
            Application.DoEvents();
        }

        private void removeCode()
        {
            lbErrors.Items.Clear();
            foreach (var item in mStructure.HeadingItems.Values.OrderBy(x => x.HeadingId).Where(x => x.IsCalculation == 0))
            {
                listboxMessage($"Processing {item.HeadingDescription}", true);

                foreach (var sitem in mStructure.HeadingItems[item.HeadingId].StructureItems)
                {
                    if (sitem.AccountItems.Contains(txtAccountCode.Text))
                    {
                        listboxMessage($"Removing account code from {sitem.ReportDescription}");

                        sitem.AccountItems.Remove(txtAccountCode.Text);
                        mStructure.HeadingItems[item.HeadingId].SaveItems();
                    }
                }
            }

            btnRemoveAll.Enabled = false;
            txtAccountCode.Enabled = false;
            txtAccountCode.Text = string.Empty;
        }

        private async Task addItemAccountsAsync(List<string> accounts)
        {
            var a = mStructure.HeadingItems[mHeadingId].GetItem(mItemId);
            a.RemoveAllAccountCodes();
            a.AddAccounts(accounts);
            mStructure.HeadingItems[mHeadingId].SaveItems();

            await MADataAccess.DataSyncUpdate.AddAsync(new SASyncDataItem { MainType = MAUpdateItem.ReportStructure, SubType = mReportId.ToString(), Payload = string.Empty });
        }

        #endregion Private Methods

        #region Process UI

        private void btnCheck_Click(object sender, System.EventArgs e)
        {
            checkReport();
        }

        private void icbReport_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            mHeadingId = 0;
            resetFields();
            try
            {
                mReportId = icbReport.EditValue.Value<int>();
                mStructure.Load(mReportId);
                btnCheck.Enabled = true;
            }
            catch
            {
                btnCheck.Enabled = false;
                RaiseDescriptionMessageChangedEvent("Report could not be loaded");
            }
        }

        private void txtAccountCode_TextChanged(object sender, System.EventArgs e)
        {
            btnRemoveAll.Enabled = !string.IsNullOrEmpty(txtAccountCode.Text);
        }

        private void btnRemoveAll_Click(object sender, System.EventArgs e)
        {
            removeCode();
        }

        #endregion Process UI
    }

    internal class findDuplicates
    {
        #region Variables

        private Dictionary<string, int> mItems = new Dictionary<string, int>();

        #endregion Variables

        #region Properties

        public Dictionary<string, int> Duplicates => mItems.Where(x => x.Value > 1).ToDictionary(x => x.Key, x => x.Value);

        #endregion Properties

        #region Methods

        public void Add(string key)
        {
            if (!mItems.ContainsKey(key)) mItems[key] = 1;
            else
            {
                var count = mItems[key];
                mItems[key] = count + 1;
            }
        }

        public void Clear() => mItems.Clear();

        #endregion Methods
    }
}