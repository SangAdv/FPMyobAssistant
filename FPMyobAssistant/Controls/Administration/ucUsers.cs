using SangAdv.Common;
using SangAdv.DevExpressUI;

namespace FPMyobAssistant
{
    public partial class ucUsers : ucTemplate
    {
        #region Variables

        private MABaseControls mBase;
        private string mSelectedEmail = string.Empty;
        private bool mHasSelection = false;

        #endregion Variables

        #region Constructor

        public ucUsers()
        {
            InitializeComponent();
            mBase = new MABaseControls(this);
            mBase.SetTitle("User Management");

            ResetFields();
        }

        #endregion Constructor

        #region Methods

        public override void LoadActivateData()
        {
            LoadUsers();
        }

        private async void LoadUsers()
        {
            var i = 1;
            var tli = new SATreeListItems();

            await MADataAccess.CloudData.Users.LoadAllAsync();

            foreach (var user in MADataAccess.CloudData.Users.Users)
            {
                var tDescription = $"{user.Value.Name} > {user.Key}";
                if (user.Value.IsAdministrator) tDescription = $"{tDescription} [Admin]";
                tli.Add(new SATreeListItem { Id = i, Identifier = user.Key, Description = tDescription, ParentId = 0 });
                i++;
            }

            ucUserlist.SetTreeItems(tli.Items);
        }

        private void ResetFields()
        {
            txtEmail.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            btnSave.Enabled = CheckCanSave();

            mSelectedEmail = string.Empty;
            mHasSelection = false;
        }

        private bool CheckCanSave()
        {
            if (string.IsNullOrEmpty(txtEmail.Text.Trim())) return false;
            if (string.IsNullOrEmpty(txtName.Text.Trim())) return false;
            if (string.IsNullOrEmpty(txtPassword.Text.Trim())) return false;
            return true;
        }

        #endregion Methods

        #region Process UI

        private void ucUserlist_NodeClicked(string stringValue)
        {
            mSelectedEmail = string.Empty;
            var user = MADataAccess.CloudData.Users.Get(stringValue);
            if (!string.IsNullOrEmpty(user.Name))
            {
                mSelectedEmail = stringValue;
                mHasSelection = true;

                txtEmail.Text = stringValue;
                txtName.Text = user.Name;
                txtPassword.Text = user.password;
                chkIsAdministrator.Checked = user.IsAdministrator;
                btnSave.Enabled = CheckCanSave();
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            ResetFields();
        }

        private async void btnSave_Click(object sender, System.EventArgs e)
        {
            if (mHasSelection)
            {
                if (mSelectedEmail.ToUpper().Trim() != txtEmail.Text.ToUpper().Trim())
                {
                    await MADataAccess.CloudData.Users.DeleteAsync(mSelectedEmail);
                }
            }

            var user = MADataAccess.CloudData.Users.User;
            user.Name = txtName.Text;
            user.password = txtPassword.Text;
            user.IsAdministrator = chkIsAdministrator.Checked;
            await MADataAccess.CloudData.Users.SaveAsync(txtEmail.Text);

            ResetFields();
            LoadUsers();
        }

        private void txt_TextChanged(object sender, System.EventArgs e)
        {
            btnSave.Enabled = CheckCanSave();
        }

        #endregion Process UI
    }
}