using SangAdv.Common;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FPMyobAssistant
{
    public partial class eucExcludedAccountNumbers : UserControl
    {
        #region Events

        public event EmptyDelegate AccountsChanged = () => { };

        #endregion Events

        #region Variables

        private SAStringList mExcludedAccounts = new SAStringList();
        private string mSelectedNumber = string.Empty;

        #endregion Variables

        #region Properties

        public List<string> ExcludedAccounts
        {
            get => mExcludedAccounts.ValueList;
            set
            {
                mExcludedAccounts.ValueList = value;
                LoadAccountNumbers();
            }
        }

        #endregion Properties

        #region Constructor

        public eucExcludedAccountNumbers()
        {
            InitializeComponent();
            ResetFields();
        }

        #endregion Constructor

        #region Methods

        private void LoadAccountNumbers()
        {
            lstAccountNumbers.Items.Clear();
            foreach (var item in mExcludedAccounts.ValueList) lstAccountNumbers.Items.Add(item);
        }

        private void ResetFields()
        {
            txtAccountNumber.Text = string.Empty;
            btnAddExcludedAccount.Enabled = false;
            btnDeleteExcludedAccount.Enabled = false;
        }

        #endregion Methods

        #region Process UI

        private void txtAccountNumber_TextChanged(object sender, System.EventArgs e)
        {
            btnAddExcludedAccount.Enabled = !string.IsNullOrEmpty(txtAccountNumber.Text);
        }

        private void btnAddExcludedAccount_Click(object sender, System.EventArgs e)
        {
            mExcludedAccounts.Add(txtAccountNumber.Text.Trim());
            LoadAccountNumbers();
            mSelectedNumber = string.Empty;
            ResetFields();
            AccountsChanged();
        }

        private void lstAccountNumbers_Click(object sender, System.EventArgs e)
        {
            ResetFields();
            try
            {
                mSelectedNumber = lstAccountNumbers.Text;
                btnDeleteExcludedAccount.Enabled = true;
            }
            catch
            {
                ResetFields();
            }
        }

        private void btnDeleteExcludedAccount_Click(object sender, System.EventArgs e)
        {
            mExcludedAccounts.Remove(mSelectedNumber);
            LoadAccountNumbers();
            mSelectedNumber = string.Empty;
            AccountsChanged();
        }

        #endregion Process UI
    }
}