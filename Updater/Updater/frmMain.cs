using SangAdv.Updater;
using SangAdv.Updater.Client;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Updater;
using Updater.Properties;

namespace SAUpdateInstaller
{
    public partial class frmMain : Form
    {
        #region Variables

        private bool mHasLoadedNotes = false;

        #endregion Variables

        #region Constructor

        public frmMain()
        {
            InitializeComponent();
            Text = "";
            pnlNotes.Visible = false;
            pnlInstall.Visible = false;
        }

        #endregion Constructor

        #region Process UI

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblVersion.Text = Application.ProductVersion;

            var tDirectory = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.Personal)).FullName;
            if (tDirectory.ToUpper().Contains("OneDrive".ToUpper())) tDirectory = Directory.GetParent(tDirectory).FullName;

            tDirectory = Path.Combine(tDirectory, "myobasst");

            var nrs = new FTPRepository(@"http://repo.sanguine.online/applications/", "myobassistant");
            var nc = new WinClient();
            var uo = new UpdateOptions
            {
                ApplicationTitle = "myob Assistant",
                LaunchFilename = "FPMyobAssistant.exe",
                ApplicationFolder = tDirectory,
                ChooseApplicationFolder = true,
                CreateStartupSettings = false
            };
            uo.UpdateFromCommandLine(Global.CommandLineArgs);

            upExec.License = Resources.License;
            upExec.MustAcceptLicense = true;
            upExec.Logo = Resources.index;
            upExec.InstallerVersion = Application.ProductVersion;

            upExec.Initialise(SAUpdaterWinOSVersion.Win7, SAUpdaterFrameworkVersions.Version45, nrs, nc, uo);

            upExec.Add(SAApplicationType.KillProcess);
            upExec.Add(SAApplicationType.Download);
            upExec.Add(SAApplicationType.DownloadFiles);
            upExec.Add(SAApplicationType.Install);
            upExec.Add(SAApplicationType.InstallEnd);

            btnNotes.Visible = upExec.HasNotes;
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();

            upExec.ShowFirst();
            pnlInstall.Visible = true;
        }

        private void btnNotes_Click(object sender, EventArgs e)
        {
            ShowNotes();
        }

        private void upExec_InstallCompleted(bool success)
        {
            ControlBox = true;
            btnNotes.Enabled = true;
        }

        private void upExec_InstallStarted()
        {
            btnNotes.Enabled = false;
        }

        private void lblPoweredBy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"http://www.sanguineadvantage.com/");
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            HideNotes();
        }

        private void upExec_CloseInstaller()
        {
            Close();
        }

        private void upExec_ChangeControlBoxStatus(bool enabled)
        {
            ControlBox = enabled;
        }

        #endregion Process UI

        #region Methods

        private void ShowInstaller()
        {
            pnlInstall.Visible = true;
        }

        private void ShowNotes()
        {
            pnlInstall.Visible = false;
            pnlNotes.Visible = true;

            if (!mHasLoadedNotes)
            {
                VersionNotes.LoadNotes();
                mHasLoadedNotes = true;
            }
        }

        private void HideNotes()
        {
            pnlNotes.Visible = false;
            pnlInstall.Visible = true;
        }

        #endregion Methods
    }
}