using DevExpress.XtraEditors.Controls;
using LocalModelContext;
using SangAdv.Common.ObjectExtensions;
using SangAdv.Common.StringExtensions;
using SangAdv.Common.UI;
using System;
using static SangAdv.Common.SAFile;

namespace FPMyobAssistant
{
    public partial class eucBSImport : eucBase
    {
        #region Variables

        private MABSAccounts mBSAccounts;

        #endregion Variables

        #region Constructor

        public eucBSImport()
        {
            InitializeComponent();
            btnImport.Enabled = false; // VerifyImport();
        }

        #endregion Constructor

        #region Methods

        public void Initialise()
        {
            LoadFinancialPeriods();
            mBSAccounts = new MABSAccounts();
        }

        #endregion Methods

        #region Private Methods

        private void LoadFinancialPeriods()
        {
            var tPeriods = new MAHelpers().FinancialPeriods;
            icbPeriod.FromDictionary(tPeriods, tPeriods.Count - 1);
        }

        private void ImportBSData()
        {
            RaiseClearMessagesEvent();

            //Delete existing data
            foreach (var item in Periods)
            {
                MADataAccess.LocalData.TLDBSDeleteAll(item);
            }

            //Import new data
            try
            {
                var ei = new SAReadTXT(beBSFilename.Text);

                for (var i = 9; i < 100000; i++)
                {
                    var accountDescription = ei.GetText(i, 1).Trim();
                    if (accountDescription.Left(5).ToUpper() == "TOTAL" || accountDescription.ToUpper() == "NET ASSETS") continue;

                    var accountId = ei.GetText(i, 0);
                    if (string.IsNullOrEmpty(accountId))
                    {
                        RaiseAddMessageEvent("Import completed");
                        RaiseEnableAllEvent();
                        return;
                    }

                    //Add the account if it is not present
                    if (!mBSAccounts.BSAccountIsPresent(accountId, accountDescription, chkUpdateDescription.Checked))
                    {
                        RaiseEnableAllEvent();

                        if (!mBSAccounts.Add(accountId, accountDescription))
                        {
                            RaiseAddMessageEvent("Import interrupted by user.");
                            break;
                        }
                    }

                    RaiseAddMessageEvent($"... {accountId} {accountDescription}");
                    RaiseDisableAllEvent();

                    //Add imported data
                    var j = 1;
                    foreach (var item in Periods)
                    {
                        j++;

                        var tValue = Math.Round(CorrectValue(ei.GetText(i, j)), 2);
                        if (tValue == 0) continue;
                        MADataAccess.LocalData.TLDBSUpdate(new TLDB { AccountId = accountId, Period = item, Actual = tValue });
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

        private string SelectedFile(MAFileType fileType, bool checkIfFileExists)
        {
            RaiseClearMessagesEvent();

            var fileName = MAFileSelection.SelectFile(fileType, checkIfFileExists);
            if (string.IsNullOrEmpty(fileName))
            {
                if (MAFileSelection.HasError) RaiseAddMessageEvent(MAFileSelection.ErrorMessage);
                return string.Empty;
            }

            RaiseAddMessageEvent($"{fileName} found");
            return fileName;
        }

        private bool VerifyImport()
        {
            return beBSFilename.Text.Trim() != string.Empty;
        }

        #endregion Private Methods

        #region Process UI

        private void beBSFilename_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            beBSFilename.Text = SelectedFile(MAFileType.TXT, true);
            btnImport.Enabled = VerifyImport();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ImportBSData();
        }

        private void icbPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tYear = icbPeriod.EditValue.Value<int>();
            LoadDataImportPeriods(tYear);
        }

        #endregion Process UI
    }
}