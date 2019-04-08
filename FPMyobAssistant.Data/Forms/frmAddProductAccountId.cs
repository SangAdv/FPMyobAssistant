using System;
using SangAdv.Common.StringExtensions;

namespace FPMyobAssistant
{
    public partial class frmAddProductAccountId : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        public string AccountNumber => txtAccountNumber.Text;

        #endregion Properties

        #region Constructor

        public frmAddProductAccountId(string productPDE, string productDescription)
        {
            InitializeComponent();
            lblProductPDE.Text = productPDE.RemoveLeadingZeros();
            lblProduct.Text = productDescription;
        }

        #endregion Constructor

        #region Process UI

        private void txtAccountNumber_TextChanged(object sender, EventArgs e)
        {
            btnDefine.Enabled = txtAccountNumber.Text.Trim() != string.Empty;
        }

        private void btnDefine_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtAccountNumber.Text = string.Empty;
            Close();
        }

        #endregion Process UI
    }
}