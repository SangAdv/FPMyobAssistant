using SangAdv.DevExpressUI;
using System.Windows.Forms;

namespace FPMyobAssistant
{
    public partial class ucSyncData : ucTemplate
    {
        #region Variables

        private MABaseControls mBase;

        #endregion Variables

        #region Constructor

        public ucSyncData(string message)
        {
            InitializeComponent();
            mBase = new MABaseControls(this);
            mBase.SetTitle("Sync Cloud Data");

            UploadMessage("");
            DownloadMessage("");

            mBase.SetMessage(message);

            MADataAccess.DataSyncUpdate.MessageChanged += RaiseUploadMessageChangedEvent;
        }

        #endregion Constructor

        #region Methods

        public override void LoadActivateData()
        {
            SetButtonStatusAsync();
        }

        private async void SetButtonStatusAsync()
        {
            btnDownload.Enabled = false;

            UploadMessage("Nothing to upload");
            DownloadMessage("Please upload first");

            var tHasSync = MADataAccess.DataSyncUpdate.HasSyncItems;
            btnUpload.Enabled = tHasSync;
            if (tHasSync) UploadMessage("Please upload data");

            if (!tHasSync)
            {
                var tHasUpdate = await MADataAccess.DataSyncUpdate.CheckHasUpdateAsync();
                btnDownload.Enabled = tHasUpdate;
                DownloadMessage(tHasUpdate ? "Please download data" : "Nothing to download");
                MAGlobal.LoadDataSyncControl = tHasUpdate;
            }
        }

        private void RaiseUploadMessageChangedEvent(string message) => UploadMessage(message);

        private void RaiseDownloadMessageChangedEvent(string message) => DownloadMessage(message);

        private void UploadMessage(string message)
        {
            lblUploadMessage.Text = message;
            Application.DoEvents();
        }

        private void DownloadMessage(string message)
        {
            lblDownloadMessage.Text = message;
            Application.DoEvents();
        }

        #endregion Methods

        #region Process UI

        private async void btnUpload_Click(object sender, System.EventArgs e)
        {
            await MADataAccess.DataSyncUpdate.DoSyncAsync();
            SetButtonStatusAsync();
        }

        private async void btnDownload_Click(object sender, System.EventArgs e)
        {
            await MADataAccess.DataSyncUpdate.DoUpdateAsync();
            SetButtonStatusAsync();
        }

        private void btnReset_Click(object sender, System.EventArgs e)
        {
            MADataAccess.LocalData.TLSUpdateLogDeleteAll();
            SetButtonStatusAsync();
        }

        #endregion Process UI
    }
}