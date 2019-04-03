using DevExpress.XtraEditors.Controls;
using LocalModelContext;
using SangAdv.Common.StringExtensions;
using System.Linq;

namespace FPMyobAssistant
{
    public partial class ucBSAccountStructure : ucBase
    {
        #region Variables

        private string mAccountCode = string.Empty;
        private MABSAccounts mBSAccounts = new MABSAccounts();

        #endregion Variables

        #region Constructor

        public ucBSAccountStructure()
        {
            InitializeComponent();
            Base = new MABaseControls(this);
            Base.SetTitle("Balance Sheet Account Structure");

            LoadAccountStructure();
            LoadParentList();

            ResetFields();
        }

        #endregion Constructor

        #region Private Methods

        private void LoadAccountStructure()
        {
            tlBSAccounts.SuspendLayout();
            var tlData = new MATreelistItems();

            foreach (var item in mBSAccounts.Accounts.OrderBy(x => x.AccountId)) tlData.Add(new MATreeListItem { Id = item.AccountId.ToString(), ParentId = item.ParentAccountId.ToString(), Description = item.AccountDescription, AccountCode = item.AccountId.ToString() });

            tlBSAccounts.DataSource = tlData.Items;
            tlBSAccounts.RefreshDataSource();
            tlBSAccounts.ResumeLayout();
        }

        private void LoadParentList()
        {
            icbParentAccount.Properties.Items.Clear();
            icbParentAccount.Properties.Items.Add(new ImageComboBoxItem("0 > Root", "0".AddLeadingZeros(10), 0));
            foreach (var item in mBSAccounts.Accounts.OrderBy(x => x.AccountId))
            {
                if (item.AccountId != mAccountCode) icbParentAccount.Properties.Items.Add(new ImageComboBoxItem($"{item.AccountId.ToString()} > {item.AccountDescription}", item.AccountId, 0));
            }
            icbParentAccount.SelectedIndex = 0;
        }

        private void ResetFields()
        {
            lblMyobDescription.Text = string.Empty;
        }

        private void DisplayAccountDetails()
        {
            if (string.IsNullOrEmpty(mAccountCode)) return;

            var a = mBSAccounts.Get(mAccountCode);
            if (string.IsNullOrEmpty(a.AccountId))
            {
                ResetFields();
                return;
            }

            LoadParentList();
            lblMyobDescription.Text = a.AccountDescription;
        }

        #endregion Private Methods

        private void tlBSAccounts_Click(object sender, System.EventArgs e)
        {
            try
            {
                mAccountCode = tlBSAccounts.FocusedNode["AccountCode"].ToString();
                DisplayAccountDetails();
            }
            catch
            {
                mAccountCode = string.Empty;
            }
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            mBSAccounts.Update(new TLMBSAccount { AccountDescription = lblMyobDescription.Text, AccountId = mAccountCode, ParentAccountId = icbParentAccount.EditValue.ToString() });
            LoadAccountStructure();
            ResetFields();
        }
    }
}