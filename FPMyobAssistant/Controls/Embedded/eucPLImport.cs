using DevExpress.XtraEditors.Controls;
using LocalModelContext;
using SangAdv.Common.ObjectExtensions;
using SangAdv.Common.UI;
using System;
using System.IO;
using static SangAdv.Common.SAFile;

namespace FPMyobAssistant
{
    public partial class eucPLImport : eucBase
    {
        #region Variables

        private MAPLAccounts mPlAccounts;

        #endregion Variables

        #region Constructor

        public eucPLImport()
        {
            InitializeComponent();
            btnImport.Enabled = false;
        }

        #endregion Constructor

        #region Methods

        public void Initialise()
        {
            mPlAccounts = new MAPLAccounts();
            LoadFinancialPeriods();
        }

        private void LoadFinancialPeriods()
        {
            var tPeriods = new MAHelpers().FinancialPeriods;
            icbPeriod.FromDictionary(tPeriods, tPeriods.Count - 1);
        }

        private void ImportPLData()
        {
            RaiseClearMessagesEvent();

            //Clear current data
            foreach (var item in Periods) MADataAccess.LocalData.TLDPLDeleteAll(item);

            //Import new data
            try
            {
                var ei = new SAReadTXT(bePLFilename.Text);

                for (var i = 9; i < 1000; i++)
                {
                    if (string.IsNullOrEmpty(ei.GetText(i, 1)))
                    {
                        RaiseMessageChangedEvent("Import completed");
                        RaiseEnableAllEvent();
                        return;
                    }

                    var accountId = ei.GetText(i, 0);
                    var accountDescription = ei.GetText(i, 1).Trim();

                    if (!string.IsNullOrEmpty(accountId))
                    {
                        //Add the account if it is not present
                        if (!mPlAccounts.PLAccountIsPresent(accountId, accountDescription, chkUpdateDescription.Checked))
                        {
                            RaiseEnableAllEvent();

                            if (!mPlAccounts.Add(accountId, accountDescription))
                            {
                                RaiseAddMessageEvent("Import interrupted by user.");
                                break;
                            }
                        }

                        RaiseAddMessageEvent($"... {ei.GetText(i, 1).Trim()}");
                        RaiseDisableAllEvent();

                        var j = 2;
                        foreach (var item in Periods)
                        {
                            MADataAccess.LocalData.TLDPLUpdate(new TLDPL { AccountId = accountId, Period = item, Actual = Math.Round(CorrectValue(ei.GetText(i, j)), 2) });
                            j++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RaiseMessageChangedEvent($"Error occurred: {ex.Message}");
            }
        }

        private float CorrectValue(string importValue)
        {
            var a = importValue.Trim();
            if (string.IsNullOrEmpty(a)) return 0;
            a = a.Replace("$", "");
            return a.Value<float>();
        }

        private bool VerifyPreImport()
        {
            return bePLFilename.Text.Trim() != string.Empty;
        }

        private string SelectedFile(MAFileType fileType, bool checkIfFileExists)
        {
            RaiseClearMessagesEvent();

            var fileName = MAFileSelection.SelectFile(fileType, checkIfFileExists);
            if (string.IsNullOrEmpty(fileName))
            {
                if (MAFileSelection.HasError) RaiseAddMessageEvent(MAFileSelection.ErrorMessage);
                return string.Empty;
            }

            RaiseAddMessageEvent(File.Exists(fileName) ? $"{fileName} found" : $"{fileName} not found");
            return fileName;
        }

        #endregion Methods

        #region Process UI

        private void btnImport_Click(object sender, System.EventArgs e)
        {
            ImportPLData();
        }

        private void bePLFilename_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            bePLFilename.Text = SelectedFile(MAFileType.TXT, true);
            btnImport.Enabled = VerifyPreImport();
        }

        private void icbPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tYear = icbPeriod.EditValue.Value<int>();
            //LoadPeriods(tYear);
            //Periods.Add("Adjustm");
            LoadDataImportPeriods(tYear);
        }

        #endregion Process UI
    }
}