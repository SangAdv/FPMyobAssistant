using DevExpress.XtraEditors.Controls;
using LocalModelContext;
using SangAdv.Common.StringExtensions;
using System.Linq;

namespace FPMyobAssistant
{
    public partial class ucPLAccountStructure : ucBase
    {
        #region Variables

        private string mAccountCode = string.Empty;
        private MAPLAccounts mPLAccounts = new MAPLAccounts();

        #endregion Variables

        #region Constructor

        public ucPLAccountStructure()
        {
            InitializeComponent();
            Base = new MABaseControls(this);
            Base.SetTitle("P&&L Account Structure");

            LoadAccountStructure();
            LoadParentList();

            ResetFields();
        }

        #endregion Constructor

        #region Private Methods

        private void LoadAccountStructure()
        {
            tlPLAccounts.SuspendLayout();
            var tlData = new MATreelistItems();

            foreach (var item in mPLAccounts.Accounts.OrderBy(x => x.AccountId)) tlData.Add(new MATreeListItem { Id = item.AccountId, ParentId = item.ParentAccountId, Description = item.AccountDescription, AccountCode = item.AccountId });

            tlPLAccounts.DataSource = tlData.Items;
            tlPLAccounts.RefreshDataSource();
            tlPLAccounts.ResumeLayout();
        }

        private void LoadParentList()
        {
            icbParentAccount.Properties.Items.Clear();
            icbParentAccount.Properties.Items.Add(new ImageComboBoxItem("0-0000 > Root", "0".AddLeadingZeros(10), 0));
            foreach (var item in mPLAccounts.Accounts.OrderBy(x => x.AccountId))
            {
                if (item.AccountId != mAccountCode) icbParentAccount.Properties.Items.Add(new ImageComboBoxItem($"{item.AccountId.RemoveLeadingZeros()} > {item.AccountDescription}", item.AccountId, 0));
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

            var a = mPLAccounts.Get(mAccountCode);
            if (string.IsNullOrEmpty(a.AccountId))
            {
                ResetFields();
                return;
            }

            LoadParentList();
            lblMyobDescription.Text = a.AccountDescription;
        }

        #endregion Private Methods

        #region Process UI

        private void tlPLAccounts_Click(object sender, System.EventArgs e)
        {
            try
            {
                mAccountCode = tlPLAccounts.FocusedNode["AccountCode"].ToString();
                DisplayAccountDetails();
            }
            catch
            {
                mAccountCode = string.Empty;
            }
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            mPLAccounts.Update(new TLMPLAccount { AccountDescription = lblMyobDescription.Text, AccountId = mAccountCode, ParentAccountId = icbParentAccount.EditValue.ToString() });
            LoadAccountStructure();
            ResetFields();
        }

        #endregion Process UI
    }
}