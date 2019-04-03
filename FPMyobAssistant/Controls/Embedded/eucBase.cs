using SangAdv.Common;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FPMyobAssistant
{
    public partial class eucBase : UserControl
    {
        #region Variables

        internal List<string> Periods = new List<string>();

        #endregion Variables

        #region Events

        public event StringDelegate MessageChanged = s => { };

        public event EmptyDelegate ClearMessages = () => { };

        public event EmptyDelegate DisableAll = () => { };

        public event EmptyDelegate EnableAll = () => { };

        public event StringDelegate AddMessage = s => { };

        public void RaiseMessageChangedEvent(string message) => MessageChanged(message);

        public void RaiseClearMessagesEvent() => ClearMessages();

        public void RaiseDisableAllEvent() => DisableAll();

        public void RaiseEnableAllEvent() => EnableAll();

        public void RaiseAddMessageEvent(string message) => AddMessage(message);

        #endregion Events

        #region Constructor

        public eucBase()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Methods

        internal void LoadBudgetImportPeriods(int year)
        {
            Periods = SAPeriods.GetMonthPeriodList($"{year}-01", $"{year}-12");
        }

        internal void LoadDataImportPeriods(int year)
        {
            Periods = SAPeriods.GetMonthPeriodList($"{year - 1}-07", $"{year}-06");
            Periods.Add("Adjustm");
        }

        #endregion Methods
    }
}