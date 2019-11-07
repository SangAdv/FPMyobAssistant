using LocalModelContext;
using SangAdv.Common;
using SangAdv.Common.StringExtensions;
using SangAdv.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FPMyobAssistant
{
    public class MAReptosImporter : SAErrorBase
    {
        #region Variables

        private IWin32Window mOwner;
        private List<TLDDistributorProductAccountId> mAccounts;
        private Dictionary<string, Dictionary<string, MAClainAmount>> mItems = new Dictionary<string, Dictionary<string, MAClainAmount>>();
        private int mDistributorId;
        private string mPeriod = string.Empty;

        #endregion Variables

        #region Constructor

        public MAReptosImporter(IWin32Window owner, int distributorId, string period)
        {
            mOwner = owner;
            mDistributorId = distributorId;
            mPeriod = period;

            mAccounts = MADataAccess.LocalData.TLDDistributorProductAccountIdList(distributorId);
        }

        #endregion Constructor

        #region Methods

        public bool Add(string invoice, string productPde, string productDescription, float claimAmount, float claimsGSTAmount, bool changeSign = false)
        {
            var a = getAccountId(productPde, productDescription);
            if (string.IsNullOrEmpty(a)) return false;

            return Add(invoice, a, claimAmount, claimsGSTAmount, changeSign);
        }

        public bool Add(string invoice, string accountId, float claimAmount, float claimsGSTAmount, bool changeSign = false)
        {
            if (string.IsNullOrEmpty(invoice)) return false;
            if (string.IsNullOrEmpty(accountId)) return false;

            if (!mItems.ContainsKey(invoice)) mItems[invoice] = new Dictionary<string, MAClainAmount>();

            if (!mItems[invoice].ContainsKey(accountId)) mItems[invoice][accountId] = new MAClainAmount();

            if (!changeSign) mItems[invoice][accountId].Add(claimAmount, claimsGSTAmount);
            else mItems[invoice][accountId].Subtract(claimAmount, claimsGSTAmount);

            return true;
        }

        public (float totalClaimAmount, float totalClaimGSTAmount) Total(string invoice)
        {
            if (!mItems.ContainsKey(invoice)) return (0, 0);

            float tTotalClaimAmount = 0;
            float tTotalClaimGSTAmount = 0;
            foreach (var item in mItems[invoice])
            {
                tTotalClaimAmount += item.Value.ClaimAmount;
                tTotalClaimGSTAmount += item.Value.ClaimGSTAmount;
            }

            return (tTotalClaimAmount, tTotalClaimGSTAmount);
        }

        public bool Update()
        {
            Error.ClearErrorMessage();
            try
            {
                //Delete the old data
                MADataAccess.LocalData.Database.ExecuteCommand($"Delete from TLDReptos where [DistributorId]={mDistributorId} AND [Period]='{mPeriod}'");
                //Add the new data
                var sbi = MADataAccess.LocalData.Database.GetBulkInsert();
                sbi.UpdateData(geTldReptosList(), "TLDReptos");
                sbi.CommitData();
                return Error.IsSuccess;
            }
            catch (Exception ex)
            {
                Error.SetErrorMessage(ex.Message);
                return Error.IsSuccess;
            }
        }

        #endregion Methods

        #region Private Methods

        private string getAccountId(string productPDE, string productDescription)
        {
            Error.ClearErrorMessage();

            var a = mAccounts.Where(x => x.ProductPDE == productPDE.AddLeadingZeros(20));

            //If an account Id is present, return it
            if (a.Any()) return a.First().AccountId;

            //Define the product's accountId

            var f = new frmAddProductAccountId(productPDE, productDescription);
            f.ShowDialog(mOwner);
            if (f.AccountNumber == string.Empty)
            {
                Error.SetErrorMessage($"A product account number not supplied for product: {productPDE.RemoveLeadingZeros()} - {productDescription}");
                return string.Empty;
            }

            var dpa = new TLDDistributorProductAccountId { DistributorId = mDistributorId, ProductPDE = productPDE.AddLeadingZeros(20), AccountId = f.AccountNumber.AddLeadingZeros(10), Product = productDescription.Trim() };
            MADataAccess.LocalData.TLDDistributorProductAccountIdUpdate(dpa);

            mAccounts = MADataAccess.LocalData.TLDDistributorProductAccountIdList(mDistributorId);

            return f.AccountNumber.AddLeadingZeros(10);
        }

        private List<TLDRepto> geTldReptosList()
        {
            var tlist = new List<TLDRepto>();
            foreach (var inv in mItems)
            {
                foreach (var acc in mItems[inv.Key])
                {
                    tlist.Add(new TLDRepto { DistributorId = mDistributorId, Period = mPeriod, Invoice = inv.Key, AccountNumber = acc.Key, Claim = acc.Value.ClaimAmount.Round(2), ClaimGST = acc.Value.ClaimGSTAmount.Round(2) });
                }
            }
            return tlist;
        }

        #endregion Private Methods
    }

    internal class MAClainAmount
    {
        public float ClaimAmount { get; set; } = 0;
        public float ClaimGSTAmount { get; set; } = 0;

        public void Add(float claimAmount, float claimsGSTAmount)
        {
            ClaimAmount = (ClaimAmount + claimAmount).Round(2);
            ClaimGSTAmount = (ClaimGSTAmount + claimsGSTAmount).Round(2);
        }

        public void Subtract(float claimAmount, float claimsGSTAmount)
        {
            ClaimAmount = ClaimAmount - claimAmount;
            ClaimGSTAmount = ClaimGSTAmount - claimsGSTAmount;
        }
    }
}