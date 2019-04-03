using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using SangAdv.Common.ObjectExtensions;
using SangAdv.Common.StringExtensions;
using System.Linq;

namespace FPMyobAssistant
{
    public partial class frmCopyItem : XtraForm
    {
        #region Variables

        private MAPLAccounts mPLAccounts = new MAPLAccounts();
        private MAReportStructure mStructure = new MAReportStructure();

        private int mReportId = 0;
        private int mHeadingId = 0;
        private int mItemId = 0;

        #endregion Variables

        #region Constructor

        public frmCopyItem()
        {
            InitializeComponent();
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

            icbItem.Properties.Items.Clear();
            icbItem.Text = string.Empty;
            mItemId = 0;

            foreach (var item in mStructure.HeadingItems[mHeadingId].StructureItems.OrderBy(x => x.ReportDescription))
            {
                icbItem.Properties.Items.Add(new ImageComboBoxItem(item.ReportDescription, item.ItemId, 0));
            }
            icbItem.SelectedIndex = 0;
        }

        private void ResetFields(bool resetStructure = true)
        {
            btnHeadingChoose.Enabled = false;
            mItemId = 0;
        }

        #endregion Private Methods

        #region Process UI

        private void frmCopyItem_Shown(object sender, System.EventArgs e)
        {
            LoadReports();
        }

        private void icbReport_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            mHeadingId = 0;
            mItemId = 0;
            ResetFields();
            try
            {
                mReportId = icbReport.EditValue.Value<int>();
                mStructure.Load(mReportId);
                LoadReportHeadings();
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

        private void icbItem_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                mItemId = icbHeading.EditValue.Value<int>();
                btnHeadingChoose.Enabled = true;
            }
            catch
            {
                btnHeadingChoose.Enabled = false;
            }
        }

        private void btnItemChoose_Click(object sender, System.EventArgs e)
        {
        }

        private void btnHeadingChoose_Click(object sender, System.EventArgs e)
        {
        }

        #endregion Process UI
    }
}