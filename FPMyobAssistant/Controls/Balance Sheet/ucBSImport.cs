using System.Windows.Forms;

namespace FPMyobAssistant
{
    public partial class ucBSImport : ucBase
    {
        #region Constructor

        public ucBSImport()
        {
            InitializeComponent();

            Base = new MABaseControls(this);
            Base.SetTitle("Balance Sheet Import");

            eucBSImport.Initialise();
            eucBSBudgetImport.Initialise();
        }

        #endregion Constructor

        #region Private Methods

        private void AddMessage(string message)
        {
            lstMessages.Items.Add(message);
            Application.DoEvents();
        }

        private void ClearMessages()
        {
            lstMessages.Items.Clear();
            Application.DoEvents();
        }

        #endregion Private Methods

        #region Process UI

        #region Data

        private void eucBSImport_AddMessage(string stringValue)
        {
            AddMessage(stringValue);
        }

        private void eucBSImport_ClearMessages()
        {
            ClearMessages();
        }

        private void eucBSImport_DisableAll()
        {
            RaiseShowWaitPanelEvent();
        }

        private void eucBSImport_EnableAll()
        {
            RaiseHideWaitPanelEvent();
        }

        private void eucBSImport_MessageChanged(string stringValue)
        {
            Base.SetMessage(stringValue);
        }

        #endregion Data

        #region Budget

        private void eucBSBudgetImport_AddMessage(string stringValue)
        {
            AddMessage(stringValue);
        }

        private void eucBSBudgetImport_ClearMessages()
        {
            ClearMessages();
        }

        private void eucBSBudgetImport_DisableAll()
        {
            RaiseShowWaitPanelEvent();
        }

        private void eucBSBudgetImport_EnableAll()
        {
            RaiseHideWaitPanelEvent();
        }

        private void eucBSBudgetImport_MessageChanged(string stringValue)
        {
            Base.SetMessage(stringValue);
        }

        #endregion Budget

        #endregion Process UI
    }
}