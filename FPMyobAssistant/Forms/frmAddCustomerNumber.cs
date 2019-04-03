using DevExpress.XtraEditors;
using SangAdv.Common.StringExtensions;
using System;

namespace FPMyobAssistant
{
    public partial class frmAddCustomerNumber : XtraForm
    {
        #region Properties

        public string MYOBNumber => txtMYOBNumber.Text;

        #endregion Properties

        #region Constructor

        public frmAddCustomerNumber(string number, string description)
        {
            InitializeComponent();
            lblDHLNumber.Text = number.RemoveLeadingZeros();
            lblDHLCustomer.Text = description;
        }

        #endregion Constructor

        #region Process UI

        private void txtMYOBNumber_TextChanged(object sender, EventArgs e)
        {
            btnDefine.Enabled = txtMYOBNumber.Text.Trim() != string.Empty;
        }

        private void btnDefine_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtMYOBNumber.Text = string.Empty;
            Close();
        }

        #endregion Process UI
    }
}