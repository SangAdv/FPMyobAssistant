using System.Windows.Forms;

namespace FPMyobAssistant
{
    public partial class ucPLImport : ucBase
    {
        #region Constructor

        public ucPLImport()
        {
            InitializeComponent();
            Base = new MABaseControls(this);
            Base.SetTitle("P&&L Import");

            eucPLImport.Initialise();
            eucPLBudgetImport.Initialise();
        }

        #endregion Constructor

        #region Process UI

        #region Data

        private void eucPLImport_AddMessage(string stringValue)
        {
            AddMessage(stringValue);
        }

        private void eucPLImport_ClearMessages()
        {
            ClearMessages();
        }

        private void eucPLImport_DisableAll()
        {
            RaiseShowWaitPanelEvent();
        }

        private void eucPLImport_EnableAll()
        {
            RaiseHideWaitPanelEvent();
        }

        private void eucPLImport_MessageChanged(string stringValue)
        {
            Base.SetMessage(stringValue);
        }

        #endregion Data

        #region Budget

        private void eucPLBudgetImport_AddMessage(string stringValue)
        {
            AddMessage(stringValue);
        }

        private void eucPLBudgetImport_ClearMessages()
        {
            ClearMessages();
        }

        private void eucPLBudgetImport_DisableAll()
        {
            RaiseShowWaitPanelEvent();
        }

        private void eucPLBudgetImport_EnableAll()
        {
            RaiseHideWaitPanelEvent();
        }

        private void eucPLBudgetImport_MessageChanged(string stringValue)
        {
            Base.SetMessage(stringValue);
        }

        #endregion Budget

        #endregion Process UI

        #region Private Methods

        #region General

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

        #endregion General

        #endregion Private Methods
    }
}