using SangAdv.Common.PeriodExtensions;
using SangAdv.Common.UI;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FPMyobAssistant.Controls.Reptos
{
    public partial class ucReptosImport : ucBase
    {
        #region Variables

        private int mDistributorId = 0;
        private AMADistributorReptosImport mImporter;
        private string mPeriod = string.Empty;

        #endregion Variables

        #region Constructor

        public ucReptosImport()
        {
            InitializeComponent();
            Base = new MABaseControls(this);
            Base.SetTitle("Reptos Import");

            btnImport.Enabled = false;
            btnCreateMyobReptosFile.Enabled = false;
            dtImport.DateTime = DateTime.Now;
            loadDistributors();
        }

        #endregion Constructor

        #region Process UI

        private void BtnChooseFiles_Click(object sender, System.EventArgs e)
        {
            btnImport.Enabled = false;
            lstImport.Items.Clear();
            var files = SADialogs.Dialogs.LoadDataFiles(false, true, true, true, true, true, true);
            if (files.Count == 0) return;
            foreach (var item in files) lstImport.Items.Add(item);
            btnImport.Enabled = true;
        }

        private void BtnClearList_Click(object sender, System.EventArgs e)
        {
            lstImport.Items.Clear();
        }

        private void IcbDistributor_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            mDistributorId = (int)icbDistributor.EditValue;
        }

        private void DtImport_DateTimeChanged(object sender, EventArgs e)
        {
            mPeriod = dtImport.DateTime.ToMonthPeriod();
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            doImport();
        }

        private void BeStructureFilename_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            btnExportStructure.Enabled = false;
            beStructureFilename.Text = string.Empty;
            var tFilename = SADialogs.Dialogs.SaveDataFile(true, true, true);
            if (string.IsNullOrEmpty(tFilename)) return;
            beStructureFilename.Text = tFilename;
            btnExportStructure.Enabled = true;
        }

        private void BtnExportStructure_Click(object sender, EventArgs e)
        {
            var ms = new MAReptosStructure();
            ms.Print(beStructureFilename.Text, "Myob Product/Account Mappings");
        }

        private void BeMYOBFilename_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            beMYOBFilename.Text = SelectedFile(MAFileType.TXT, false);
            if (beMYOBFilename.Text.Trim() != string.Empty && File.Exists(beMYOBFilename.Text.Trim()))
            {
                var dlgResult = MessageBox.Show($"{beMYOBFilename.Text.Trim()} can be deleted?", "Confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult != DialogResult.Yes) beMYOBFilename.Text = string.Empty;
            }
            btnCreateMyobReptosFile.Enabled = VerifyImport();
        }

        private void BtnCreateMyobReptosFile_Click(object sender, EventArgs e)
        {
            exportMyobReptosFile();
        }

        #endregion Process UI

        #region Private Methods

        private void doImport()
        {
            if (mImporter != null) mImporter.MessageChangedEvent -= AddMessage;

            switch (mDistributorId)
            {
                case (int)MADistributors.API:
                    mImporter = new MAAPIReptosImport(this, mPeriod);
                    mImporter.MessageChangedEvent += AddMessage;
                    break;

                case (int)MADistributors.Sigma:
                    mImporter = new MASigmaReptosImport(this, mPeriod);
                    mImporter.MessageChangedEvent += AddMessage;
                    break;

                case (int)MADistributors.Symbion:
                    mImporter = new MASymbionReptosImport(this, mPeriod);
                    mImporter.MessageChangedEvent += AddMessage;
                    break;

                default:
                    AddMessage("Undefined distributor");
                    return;
            }

            if (mImporter.HasError)
            {
                AddMessage(mImporter.ErrorMessage);
                return;
            }

            mImporter.DoImport(lstImport.Items.ToStringList());
        }

        private void loadDistributors()
        {
            icbDistributor.FromDictionary(MADataAccess.LocalData.TLMDistributorDictionary());
        }

        private string SelectedFile(MAFileType fileType, bool checkIfFileExists)
        {
            lstMessage.Items.Clear();

            var fileName = MAFileSelection.SelectFile(fileType, checkIfFileExists);
            if (string.IsNullOrEmpty(fileName))
            {
                if (MAFileSelection.HasError) AddMessage(MAFileSelection.ErrorMessage);
                return string.Empty;
            }

            lstMessage.Items.Add($"{fileName} found");
            return fileName;
        }

        private bool VerifyImport()
        {
            if (beMYOBFilename.Text.Trim() == string.Empty) return false;
            return true;
        }

        private void exportMyobReptosFile()
        {
            var re = new FPReptosToMyobTXTAddHocSales(dtImport.DateTime);

            var red = MADataAccess.LocalData.TLDReptosList(dtImport.DateTime.ToMonthPeriod()).OrderBy(x =>  x.CardId).ThenBy(x => x.AccountNumber);
            
            foreach (var item in red)
            {
                re.Add(new FPMyobAddHocSalesItem { AccountNumber = item.AccountNumber, CardId = item.CardId, Amount = ((float)item.Claim).Round(2), AmountIncTax = ((float)(item.Claim + item.ClaimGST)).Round(2) });
            }

            re.Create();

            re.Save(beMYOBFilename.Text);
        }

        #region General

        private void AddMessage(string message)
        {
            lstMessage.Items.Add(message);
            Application.DoEvents();
        }

        private void ClearMessages()
        {
            lstMessage.Items.Clear();
            Application.DoEvents();
        }

        #endregion General

        #endregion Private Methods
    }
}