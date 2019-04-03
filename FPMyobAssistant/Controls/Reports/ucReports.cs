using DevExpress.XtraEditors.Controls;
using LocalModelContext;
using SangAdv.Common.ObjectExtensions;
using SangAdv.DevExpressUI;

namespace FPMyobAssistant
{
    public partial class ucReports : ucTemplate
    {
        #region Variables

        private MABaseControls mBase;
        private int mReportId = 0;

        #endregion Variables

        #region Constructor

        public ucReports()
        {
            ModuleID = 100;
            InitializeComponent();
            mBase = new MABaseControls(this);
            mBase.SetTitle("Manage Reports");

            tlReports.ExpandAll();

            LoadReports();
            LoadReportTypes();
        }

        #endregion Constructor

        #region Private Methods

        private void LoadReports()
        {
            tlReports.SuspendLayout();

            var tlData = new MATreelistItems();

            tlData.Add(new MATreeListItem { Id = "PL", ParentId = "0", Description = "Profit and Loss Reports" });
            tlData.Add(new MATreeListItem { Id = "BS", ParentId = "0", Description = "Balance Sheet Reports" });

            foreach (var item in MADataAccess.LocalData.TLMReportList())
            {
                tlData.Items.Add(new MATreeListItem { Id = item.ReportId.ToString(), ParentId = item.ReportType == (int)MAReportType.ProfitLoss ? "PL" : "BS", Description = item.ReportDescription, IsActive = item.StatusId == (int)MAStatus.Active });
            }

            tlReports.DataSource = tlData.Items;

            tlReports.ResumeLayout();
            tlReports.ExpandAll();
            ResetFields();
        }

        private void LoadReportTypes()
        {
            icbReportType.Properties.Items.Clear();
            icbReportType.Properties.Items.Add(new ImageComboBoxItem("Profit and Loss Report", (int)MAReportType.ProfitLoss, 0));
            icbReportType.Properties.Items.Add(new ImageComboBoxItem("Balance Sheet Report", (int)MAReportType.BalanceSheet, 0));
            icbReportType.SelectedIndex = 0;
        }

        private void ResetFields()
        {
            txtReportTitle.Text = string.Empty;
            chkActive.Checked = true;
            icbReportType.SelectedIndex = 0;
            btnUpdate.Text = "Add";
        }

        private void LoadReport()
        {
            if (mReportId == 0) return;

            var a = MADataAccess.LocalData.TLMReportItem(mReportId);
            if (a.ReportId == 0) return;

            txtReportTitle.Text = a.ReportDescription;
            chkActive.Checked = a.StatusId == (int)MAStatus.Active;
            icbReportType.EditValue = (int)a.ReportType;
            btnUpdate.Text = "Update";
        }

        #endregion Private Methods

        #region Process UI

        private void tlReports_Click(object sender, System.EventArgs e)
        {
            try
            {
                mReportId = tlReports.FocusedNode["Id"].Value<int>();
                LoadReport();
            }
            catch
            {
                mReportId = 0;
                ResetFields();
            }
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            var tStatusId = chkActive.Checked ? (int)MAStatus.Active : (int)MAStatus.Cancelled;
            MADataAccess.LocalData.TLMReportUpdate(new TLMReport { ReportDescription = txtReportTitle.Text.Trim(), ReportId = mReportId, ReportType = icbReportType.EditValue.Value<int>(), StatusId = tStatusId });
            LoadReports();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            ResetFields();
        }

        private void tlReports_AfterExpand(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            MAGlobal.Expanded.Add(ModuleID, tlReports.FocusedNode["Id"].ToString());
        }

        private void tlReports_AfterCollapse(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            MAGlobal.Expanded.Remove(ModuleID, tlReports.FocusedNode["Id"].ToString());
        }

        #endregion Process UI
    }
}