using LocalModelContext;
using SangAdv.Common.ObjectExtensions;
using SangAdv.Common.StringExtensions;
using SangAdv.Common.UI;
using System;
using System.Linq;

namespace FPMyobAssistant
{
    public partial class ucProductMyobAccountId : ucBase
    {
        #region Variables

        private int mDistributorId;
        private string mProductPDE = string.Empty;
        private string mProduct = string.Empty;

        #endregion Variables

        #region Constructor

        public ucProductMyobAccountId()
        {
            InitializeComponent();
            Base = new MABaseControls(this);
            Base.SetTitle("Myob Reptos Product/AccountId mapping");

            loadDistributors();
            resetFields();
        }

        #endregion Constructor

        #region Process UI

        private void IcbDistributor_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            mDistributorId = icbDistributor.EditValue.Value<int>();
            loadAccountMappings();
        }

        private void LstImport_Click(object sender, System.EventArgs e)
        {
            try
            {
                var tPDE = lstImport.Text.GetID("(", ")").AddLeadingZeros(20);
                var cam = MADataAccess.LocalData.TLDDistributorProductAccountIdItem(mDistributorId, tPDE);
                if (string.IsNullOrEmpty(cam.AccountId)) throw new Exception();

                mProductPDE = cam.ProductPDE;
                mProduct = cam.Product;

                txtMYOBNumber.Text = cam.AccountId.RemoveLeadingZeros();
                btnDefine.Enabled = true;
            }
            catch
            {
                resetFields();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            resetFields();
        }

        private void BtnDefine_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mProductPDE)) return;

            var data = new TLDDistributorProductAccountId
            {
                DistributorId = mDistributorId,
                ProductPDE = mProductPDE,
                Product = mProduct.Trim(),
                AccountId = txtMYOBNumber.Text.Trim().AddLeadingZeros(10)
            };
            MADataAccess.LocalData.TLDDistributorProductAccountIdUpdate(data);

            loadAccountMappings();
        }

        #endregion Process UI

        #region Private Methods

        private void loadDistributors()
        {
            icbDistributor.FromDictionary(MADataAccess.LocalData.TLMDistributorDictionary());
        }

        private void loadAccountMappings()
        {
            lstImport.SuspendLayout();
            lstImport.Items.Clear();
            var am = MADataAccess.LocalData.TLDDistributorProductAccountIdList(mDistributorId).OrderBy(x => x.Product);
            foreach (var item in am) lstImport.Items.Add($"({item.ProductPDE.RemoveLeadingZeros()}) {item.Product} > {item.AccountId.RemoveLeadingZeros()}");
            lstImport.ResumeLayout();
        }

        private void resetFields()
        {
            txtMYOBNumber.Text = string.Empty;
            btnDefine.Enabled = false;
            mProductPDE = string.Empty;
        }

        #endregion Private Methods
    }
}