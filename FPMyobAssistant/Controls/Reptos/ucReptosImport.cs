using LocalModelContext;
using SangAdv.Common;
using SangAdv.Common.PeriodExtensions;
using SangAdv.Common.StringExtensions;
using SangAdv.Common.UI;
using System;
using System.Collections.Generic;
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
        private List<TLMDistributor> mDistributors = MADataAccess.LocalData.TLMDistributorList();
        private List<string> mFolders = new List<string>();
        private List<string> mLookup = new List<string>();

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
            btnProcess.Enabled = false;

            LoadDistributors();
            LoadAPILookup();
        }

        #endregion Constructor

        #region Process UI

        private void BtnChooseFiles_Click(object sender, System.EventArgs e)
        {
            btnImport.Enabled = false;
            var files = SADialogs.Dialogs.LoadDataFiles(false, true, true, true, true, true, true);
            if (files.Count == 0) return;
            foreach (var item in files) lstImport.Items.Add(item);
            btnImport.Enabled = true;
        }

        private void BtnClearList_Click(object sender, System.EventArgs e)
        {
            ClearFilesList();
        }

        private void IcbDistributor_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            mDistributorId = (int)icbDistributor.EditValue;
            ClearMessages();
            ClearFilesList();
        }

        private void DtImport_DateTimeChanged(object sender, EventArgs e)
        {
            mPeriod = dtImport.DateTime.ToMonthPeriod();
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            DoImport();
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
            ExportMyobReptosFile();
        }

        private void beImportFolder_TextChanged(object sender, EventArgs e)
        {
            btnProcess.Enabled = !string.IsNullOrEmpty(beImportFolder.Text);
        }

        private void beImportFolder_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            lstMessage.Items.Clear();
            beImportFolder.Text = string.Empty;
            btnProcess.Enabled = false;
            using (var fbd = new FolderBrowserDialog())
            {
                var result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    beImportFolder.Text = fbd.SelectedPath;
                    btnProcess.Enabled = true;
                }
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            ProcessFolder();
        }

        #endregion Process UI

        #region Private Methods

        private void ProcessFolder()
        {
            switch (mDistributorId)
            {
                case (int)MADistributors.API:
                    AddMessage(ProcessAPIFolder() ? "Success" : "Failed");
                    break;

                case (int)MADistributors.Sigma:
                    if (!ExtractAllSigmaFiles()) return;
                    DeleteSigmaPDFFiles(beImportFolder.Text);
                    break;

                default:
                    AddMessage("Folder processing not required");
                    return;
            }
        }

        private void DoImport()
        {
            if (mImporter != null) mImporter.MessageChangedEvent -= AddMessage;

            switch (mDistributorId)
            {
                case (int)MADistributors.API:
                    AddMessage("Importing API");
                    mImporter = new MAAPIReptosImport(this, mPeriod);
                    mImporter.MessageChangedEvent += AddMessage;
                    break;

                case (int)MADistributors.Sigma:
                    AddMessage("Importing Sigma");
                    mImporter = new MASigmaReptosImport(this, mPeriod);
                    mImporter.MessageChangedEvent += AddMessage;
                    break;

                case (int)MADistributors.Symbion:
                    AddMessage("Importing Symbion");
                    mImporter = new MASymbionReptosImport(this, mPeriod);
                    mImporter.MessageChangedEvent += AddMessage;
                    break;

                case (int)MADistributors.CH2:
                    AddMessage("Importing CH2");
                    mImporter = new MACH2ReptosImport(this, mPeriod);
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

        private void LoadDistributors()
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

        private void ExportMyobReptosFile()
        {
            var re = new FPReptosToMyobTXTAddHocSales(dtImport.DateTime);

            var red = MADataAccess.LocalData.TLDReptosList(dtImport.DateTime.ToMonthPeriod()).OrderBy(x => x.DistributorId).ThenBy(x => x.AccountNumber).ThenBy(x => x.AccountNumber);

            foreach (var item in red)
            {
                re.Add(new FPMyobAddHocSalesItem { Invoice = item.Invoice, AccountNumber = item.AccountNumber, CardId = getDistributorCardId(item.DistributorId), Amount = ((float)item.Claim).Round(2), AmountIncTax = ((float)(item.Claim + item.ClaimGST)).Round(2) });
            }

            re.Create();

            re.Save(beMYOBFilename.Text);

            AddMessage($"Exported: {beMYOBFilename.Text}");
        }

        private void ClearFilesList()
        {
            beImportFolder.Text = string.Empty;
            lstImport.Items.Clear();
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

        private string getDistributorCardId(int distributorId)
        {
            var dist = mDistributors.Where(x => x.DistributorId == distributorId);
            return dist.Any() ? dist.First().CardId : "Undefined";
        }

        #endregion General

        #region Process API Folder

        private bool ProcessAPIFolder()
        {
            //Get all folders
            GetAllAPIFolders();
            if (!ExtractAllAPIFiles()) return false;
            //if (!saveXLStoXALS()) return false;
            if (!RenameAPIToTXT()) return false;
            return true;
        }

        private void GetAllAPIFolders()
        {
            mFolders.Clear();
            mFolders.Add(beImportFolder.Text);
            foreach (var item in Directory.GetDirectories(beImportFolder.Text)) mFolders.Add(item);
        }

        private bool ExtractAllAPIFiles()
        {
            var saZip = new SAZip();

            AddMessage(string.Empty);
            AddMessage("Extracting Files");

            foreach (var folder in mFolders)
            {
                AddMessage($"Processing: {folder}");

                var tFileCount = GetAllAPIFilesCount(folder);
                var originalFiles = GetAPIFiles(folder, "zip");
                var tCount = originalFiles.Count;

                AddMessage($"Found {originalFiles.Count} file(s)");

                if (tCount > 0)
                {
                    foreach (var file in originalFiles)
                    {
                        AddMessage($"Extracting {file}");
                        saZip.Extract(file, folder);
                        File.Delete(file);
                    }

                    if (tFileCount != GetAllAPIFilesCount(folder)) return false;
                }
            }

            return true;
        }

        private int GetAllAPIFilesCount(string folder)
        {
            return Directory.GetFiles(folder, "*.*").Length;
        }

        private List<string> GetAPIFiles(string folder, string pattern)
        {
            var tList = new List<string>();
            var originalFiles = Directory.GetFiles(folder, $"*.{pattern}");
            foreach (var file in originalFiles)
            {
                if (Path.GetExtension(file).ToUpper() == $".{pattern}".ToUpper()) tList.Add(file);
            }

            return tList;
        }

        private bool RenameAPIToTXT()
        {
            var tSuccess = true;

            AddMessage(string.Empty);
            AddMessage("Renaming Files");

            foreach (var folder in mFolders)
            {
                AddMessage($"Processing: {folder}");

                var originalFiles = GetAPIFiles(folder, "xls");
                var tCount = originalFiles.Count;

                AddMessage($"Found {originalFiles.Count} file(s)");

                if (tCount > 0)
                {
                    foreach (var file in originalFiles)
                    {
                        AddMessage($"Renaming {file}");
                        var tFilename = Path.GetFileNameWithoutExtension(file);
                        var tNewFilename = Path.Combine(Path.GetDirectoryName(file), GetNewAPIFilename(tFilename, "txt"));
                        File.Move(file, tNewFilename);

                        if (!File.Exists(tNewFilename))
                        {
                            tSuccess = false;
                            break;
                        }
                    }
                }
            }

            return tSuccess;
        }

        private string GetNewAPIFilename(string originalFilename, string extension)
        {
            foreach (var item in mLookup)
            {
                if (originalFilename.Contains(item))
                {
                    return $"{originalFilename.LeftOf(item).Replace("Doc_", "")}.{extension}";
                }
            }

            return string.Empty;
        }

        private void LoadAPILookup()
        {
            mLookup.Clear();
            mLookup.Add("_Ex-DC Rebate");
            mLookup.Add("_Brand Deals");
            mLookup.Add("_Sales Deals");
            mLookup.Add("_Vend Rebate");
            mLookup.Add("_Scan Sales");

            mLookup.Add("_Ex-DC_Rebate");
            mLookup.Add("_Brand_Deals");
            mLookup.Add("_Sales_Deals");
        }

        #endregion Process API Folder

        #region Process Sigma Folder

        private bool ExtractAllSigmaFiles()
        {
            var saZip = new SAZip();

            var folder = beImportFolder.Text;

            AddMessage(string.Empty);
            AddMessage("Extracting Files");

            AddMessage($"Processing: {folder}");

            var tFileCount = GetSigmaFiles(folder, "ZIP").Count;
            var originalFiles = GetSigmaFiles(folder, "zip");
            var tCount = originalFiles.Count;

            AddMessage($"Found {originalFiles.Count} file(s)");

            if (tCount > 0)
            {
                foreach (var file in originalFiles)
                {
                    var tNewFilename = Path.GetFileNameWithoutExtension(file).Right(4).Left(2);

                    AddMessage($"Extracting {file}");
                    saZip.Extract(file, folder);
                    Application.DoEvents();
                    RenameExtractedSigmaFile(folder, tNewFilename);
                    Application.DoEvents();
                    File.Delete(file);
                }

                if (tFileCount != GetSigmaFiles(folder, "CSV").Count) return false;
            }

            return true;
        }

        private List<string> GetSigmaFiles(string folder, string pattern)
        {
            var tList = new List<string>();
            var originalFiles = Directory.GetFiles(folder, $"*.{pattern}");
            foreach (var file in originalFiles)
            {
                if (Path.GetExtension(file).ToUpper() == $".{pattern}".ToUpper()) tList.Add(file);
            }

            return tList;
        }

        private void RenameExtractedSigmaFile(string folder, string newFilename)
        {
            var files = GetSigmaFiles(folder, "CSV");
            foreach (var file in files)
            {
                if (Path.GetFileNameWithoutExtension(file).Length > 2)
                {
                    var tNewFilename = Path.Combine(folder, $"{newFilename}.CSV");
                    if (File.Exists(tNewFilename)) File.Delete(tNewFilename);
                    File.Move(Path.Combine(folder, file), Path.Combine(folder, $"{newFilename}.CSV"));
                }
            }
        }

        private void DeleteSigmaPDFFiles(string folder)
        {
            var files = GetSigmaFiles(folder, "PDF");
            foreach (var file in files)
            {
                File.Delete(Path.Combine(folder, file));
            }
        }

        #endregion Process Sigma Folder

        #endregion Private Methods
    }
}