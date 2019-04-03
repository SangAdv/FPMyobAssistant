using SangAdv.Common.StringExtensions;
using SangAdv.DevExpressUI;

namespace FPMyobAssistant
{
    public partial class ucDHLMyobCardIds : ucTemplate
    {
        #region Variables

        private MABaseControls mBase;

        #endregion Variables

        #region Constructor

        public ucDHLMyobCardIds()
        {
            InitializeComponent();
            mBase = new MABaseControls(this);
            mBase.SetTitle("DHL Account > Myob CardId Mapping");
            LoadCustomerNumbers();
            lblSelected.Text = string.Empty;
        }

        #endregion Constructor

        #region Process UI

        private void lstNumbers_Click(object sender, System.EventArgs e)
        {
            lblSelected.Text = lstNumbers.Text;
            btnDelete.Enabled = lblSelected.Text.Trim() != string.Empty;
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            try
            {
                var customerNumber = lstNumbers.Text.GetID("[", "]");
                MADataAccess.LocalData.TLDDHLCustomerNumberDeleteItem(customerNumber);
                LoadCustomerNumbers();
                mBase.SetMessage($"Deleted DHL Customer number {customerNumber} Myob CardId Map");
            }
            catch
            {
                mBase.SetMessage("Could not delete selected entry");
            }
        }

        #endregion Process UI

        #region Methods

        private void LoadCustomerNumbers()
        {
            lstNumbers.Items.Clear();
            foreach (var item in MADataAccess.LocalData.TLDDHLCustomerNumberList())
            {
                lstNumbers.Items.Add($"[{item.Id.RemoveLeadingZeros()}] {item.CustomerName} >> {item.MYOBCardId}");
            }
        }

        #endregion Methods
    }
}