using DevExpress.XtraBars.FluentDesignSystem;
using DevExpress.XtraSplashScreen;
using FPMyobAssistant.Controls.Reptos;
using SangAdv.Common;
using SangAdv.DevExpressUI;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPMyobAssistant
{
    public partial class frmMain : FluentDesignForm
    {
        #region Variables

        private IOverlaySplashScreenHandle mHandle;

        #endregion Variables

        #region Properties

        internal string ErrorMessage { get; private set; } = string.Empty;

        #endregion Properties

        #region Constructor

        public frmMain()
        {
            InitializeComponent();
            EnableAcrylicAccent = true;
        }

        #endregion Constructor

        #region Private Methods

        private void ShowWaitPanel()
        {
            if (mHandle != null) return;
            mHandle = SplashScreenManager.ShowOverlayForm(this);
            Application.DoEvents();
        }

        private void HideWaitPanel()
        {
            if (mHandle == null) return;
            SplashScreenManager.CloseOverlayForm(mHandle);
            mHandle = null;
            Application.DoEvents();
        }

        private void DisplayControl(ucTemplate control)
        {
            foreach (Control cnt in cntMain.Controls)
            {
                DetachEventHandlers((ucTemplate)cnt);
                cntMain.Controls.Remove(cnt);
            }

            if (MAGlobal.LoadDataSyncControl) control = new ucSyncData("Please download data ...");

            AttachEventHandlers(control);
            cntMain.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            control.LoadActivateData();
        }

        private bool CloseApplication()
        {
            var ts = MADataAccess.LocalData.TlSSyncLogList();
            if (ts.Any())
            {
                DisplayControl(new ucSyncData("Please upload data before exiting"));
                return false;
            }

            hmMain.Enabled = false;
            MADataAccess.LocalData.Vacuum();
            return true;
        }

        private void EnableMainMenu(bool enabled)
        {
            hmMain.Enabled = enabled;
            if (!string.IsNullOrEmpty(MADataAccess.CloudData.Users.CurrentUserEmail))
            {
                acAdmin.Enabled = MADataAccess.CloudData.Users.CurrentUser.IsAdministrator;
                aceWelcome.Text = $"Welcome, {MADataAccess.CloudData.Users.CurrentUser.Name}";
            }
        }

        private void DetachEventHandlers(ucTemplate control)
        {
            control.ShowWaitPanelEvent -= ShowWaitPanel;
            control.HideWaitPanelEvent -= HideWaitPanel;
            control.CloseApplication -= ControlCloseApplication;
        }

        private void AttachEventHandlers(ucTemplate control)
        {
            control.ShowWaitPanelEvent += ShowWaitPanel;
            control.HideWaitPanelEvent += HideWaitPanel;
            control.CloseApplication += ControlCloseApplication;
            control.MainFormEnabledChangedEvent += EnableMainMenu;
        }

        private void ControlCloseApplication()
        {
            Close();
        }

        private async void PrepareApplication()
        {
            hmMain.Enabled = false;

            var ucm = new ucMain(false);
            DisplayControl(ucm);

            ShowWaitPanel();

            MAGlobal.IsConnected = SAConnection.CheckGoogleConnection();
            //if (!MAGlobal.IsConnected)
            //{
            //    ucm.DisplayMessage("Please connect to the internet");
            //    return;
            //}

#if !DEBUG

            if (MAGlobal.IsConnected && !await CheckUpdateAsync(ucm))
            {
                HideWaitPanel();
                return;
            }

#endif

            LoadStartupSettings(ucm);
            ucm.SetUIDefaults();

            if (MAGlobal.IsConnected)
            {
                await PrepareCloudDatabaseAsync(ucm);
            }

            if (!PrepareDatabase(ucm))
            {
                ucm.DisplayMessage(ErrorMessage);
                return;
            }

            #region Prepare Updates

            if (MAGlobal.IsConnected)
            {
                await MADataAccess.DataSyncUpdate.InitialiseAsync();
                MAGlobal.LoadDataSyncControl = await MADataAccess.DataSyncUpdate.CheckHasUpdateAsync();
            }

            #endregion Prepare Updates

            SaveStartupSettings(ucm);
            HideWaitPanel();
        }

        #region Prepare Application

        internal bool LoadStartupSettings(ucMain main)
        {
            bool tHasError = false;
            main.DisplayMessage("Loading startup settings ...");

            MAGlobal.Initialise();
            if (MAGlobal.StartUpSettings.HasError)
            {
                if (MAGlobal.StartUpSettings.ErrorMessage != "File specified is not a valid startup file")
                {
                    tHasError = true;
                    ErrorMessage = MAGlobal.StartUpSettings.ErrorMessage;
                }
            }
            return tHasError;
        }

        internal async Task<bool> PrepareCloudDatabaseAsync(ucMain main)
        {
            bool tIsSuccess = true;
            main.DisplayMessage("Preparing cloud database ...");

            #region Prepare Users

            tIsSuccess = await CreateDefaultAdminUserAsync();
            if (!tIsSuccess)
            {
                main.DisplayMessage($"Error: {ErrorMessage}");
                return tIsSuccess;
            }

            await MADataAccess.CloudData.Users.LoadAllAsync();

            #endregion Prepare Users

            return tIsSuccess;
        }

        internal bool PrepareDatabase(ucMain main)
        {
            main.DisplayMessage("Preparing system database ...");

            if (!MADataAccess.LocalData.PrepareDatabase())
            {
                ErrorMessage = MADataAccess.LocalData.ErrorMessage;
                return false;
            }

            return true;
        }

        internal bool SaveStartupSettings(ucMain main)
        {
            main.DisplayMessage("Preparing system database ...");

            MAGlobal.StartUpSettings.Items.CurrentVersion = Application.ProductVersion;
            MAGlobal.StartUpSettings.SaveObjectFile();

            main.DisplayMessage(string.Empty);
            return !MAGlobal.StartUpSettings.HasError;
        }

        private async Task<bool> CreateDefaultAdminUserAsync()
        {
            await MADataAccess.CloudData.Users.LoadAsync("johann.nell@sanguineadvantage.com");
            if (!string.IsNullOrEmpty(MADataAccess.CloudData.Users.SelectedUserEmail)) return true;

            var user = MADataAccess.CloudData.Users.User;

            user.IsAdministrator = true;
            user.password = "Sanguine11";
            user.Name = "Johann Nell";

            var tResult = await MADataAccess.CloudData.Users.SaveAsync("johann.nell@sanguineadvantage.com");
            if (tResult.HasError)
            {
                ErrorMessage = tResult.Message;
                return false;
            }

            return true;
        }

        internal async Task<bool> CheckUpdateAsync(ucMain main)
        {
            MAGlobal.Update.MessageChanged += main.DisplayMessage;
            await MAGlobal.Update.InitialiseAsync("http://repo.sanguine.online/applications/", "myobassistant", "myob Assistant", "FPMyobAssistant.exe", Application.StartupPath, "updater.exe");

            if (MAGlobal.Update.DoInstallerUpdate)
            {
                var tSuccess = await MAGlobal.Update.UpdateInstallerAsync();
                if (!tSuccess) return false;
            }

            if (MAGlobal.Update.HasNewApplicationRelease) main.DoUpdate();

            return !MAGlobal.Update.HasNewApplicationRelease;
        }

        #endregion Prepare Application

        #endregion Private Methods

        #region Process UI

        private void frmMain_Shown(object sender, EventArgs e)
        {
            PrepareApplication();
        }

        #region Buttons

        private void aceDHLImport_Click(object sender, EventArgs e)
        {
            DisplayControl(new ucDHLImport());
        }

        private void acePLImport_Click(object sender, EventArgs e)
        {
            DisplayControl(new ucPLImport());
        }

        private void aceBSImport_Click(object sender, EventArgs e)
        {
            DisplayControl(new ucBSImport());
        }

        private void aceExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void acePLAccountStructure_Click(object sender, EventArgs e)
        {
            DisplayControl(new ucPLAccountStructure());
        }

        private void aceBSAccountStructure_Click(object sender, EventArgs e)
        {
            DisplayControl(new ucBSAccountStructure());
        }

        private void aceReportStructure_Click(object sender, EventArgs e)
        {
            DisplayControl(new ucReportStructure());
        }

        private void aceReportStructureGroups_Click(object sender, EventArgs e)
        {
            DisplayControl(new ucReportStructureGroups());
        }

        private void aceReportErrors_Click(object sender, EventArgs e)
        {
            DisplayControl(new ucReportErrors());
        }

        private void aceBoardReport_Click(object sender, EventArgs e)
        {
            DisplayControl(new ucBoardReport());
        }

        private void aceDataSync_Click(object sender, EventArgs e)
        {
            DisplayControl(new ucSyncData(""));
        }

        private void aceMyobCardIds_Click(object sender, EventArgs e)
        {
            DisplayControl(new ucDHLMyobCardIds());
        }

        private void aceUsers_Click(object sender, EventArgs e)
        {
            DisplayControl(new ucUsers());
        }

        private void aceDHLImportPreparation_Click(object sender, EventArgs e)
        {
            DisplayControl(new ucDHLImportPreparation());
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !CloseApplication();
        }

        private void aceWelcome_Click(object sender, EventArgs e)
        {
            DisplayControl(new ucMain(true));
        }

        private void AceReptosImport_Click(object sender, EventArgs e)
        {
            DisplayControl(new ucReptosImport());
        }

        private void AceMyobProductAccountIds_Click(object sender, EventArgs e)
        {
            DisplayControl(new ucProductMyobAccountId());
        }

        #endregion Buttons

        #endregion Process UI
    }
}