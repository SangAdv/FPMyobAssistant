using SangAdv.DevExpressUI;
using System;
using System.Windows.Forms;

namespace FPMyobAssistant
{
    public partial class ucMain : ucTemplate
    {
        #region Variables

        private MABaseControls mBase;

        #endregion Variables

        #region Properties

        internal string ErrorMessage { get; private set; } = string.Empty;

        #endregion Properties

        #region Constructor

        public ucMain(bool isAbout)
        {
            InitializeComponent();

            MAGlobal.Update.MessageChanged += DisplayMessage;

            btnDoUpdate.Visible = false;
            btnDoUpdate.Enabled = false;
            IsLoginEnabled();

            if (isAbout)
            {
                HideLoginControls();
                lblWelcome.Visible = true;
                lblWelcome.Text = $"Welcome, {MADataAccess.CloudData.Users.CurrentUser.Name}";
            }

            mBase = new MABaseControls(this);
        }

        #endregion Constructor

        #region Methods

        internal void SetUIDefaults()
        {
            lblVersion.Text = Application.ProductVersion;

            chkRememberUser.Checked = MAGlobal.StartUpSettings.Items.RememberUser;
            txtUsername.Text = MAGlobal.StartUpSettings.Items.User;
        }

        internal void DisplayMessage(string message)
        {
            mBase.SetMessage(message);
        }

        private void IsLoginEnabled()
        {
            try
            {
                if (string.IsNullOrEmpty(txtUsername.Text.Trim())) throw new Exception();
                if (string.IsNullOrEmpty(txtPassword.Text.Trim())) throw new Exception();
                btnLogin.Enabled = true;
            }
            catch
            {
                btnLogin.Enabled = false;
            }
        }

        private void HideLoginControls()
        {
            txtPassword.Visible = false;
            txtUsername.Visible = false;
            btnLogin.Visible = false;
            btnClose.Visible = false;
            chkRememberUser.Visible = false;
        }

        internal void DoUpdate()
        {
            DisplayMessage("Update found. Please update ...");

            btnDoUpdate.Visible = true;
            btnDoUpdate.Enabled = true;

            HideLoginControls();
        }

        #endregion Methods

        #region Process UI

        private void btnDoUpdate_Click(object sender, System.EventArgs e)
        {
            MAGlobal.Update.UpdateApplication();
            RaiseCloseApplicationEvent();
        }

        private void txtUsername_TextChanged(object sender, System.EventArgs e)
        {
            IsLoginEnabled();
        }

        private void txtPassword_TextChanged(object sender, System.EventArgs e)
        {
            IsLoginEnabled();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var tResult = await MADataAccess.CloudData.Users.IsActiveUserAsync(txtUsername.Text, txtPassword.Text);
            if (!tResult)
            {
                DisplayMessage(MADataAccess.CloudData.Users.ErrorMessage);
                return;
            }

            DisplayMessage("");
            MADataAccess.CloudData.Users.LoadCurrentUser();

            MAGlobal.StartUpSettings.Items.RememberUser = chkRememberUser.Checked;
            MAGlobal.StartUpSettings.Items.User = chkRememberUser.Checked ? txtUsername.Text : string.Empty;
            MAGlobal.StartUpSettings.SaveObjectFile();

            HideLoginControls();
            RaiseMainFormEnabledChangedEvent(true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            RaiseCloseApplicationEvent();
        }

        #endregion Process UI
    }
}