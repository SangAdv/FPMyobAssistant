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
        private Dictionary<string, MAClainAmount> mItems = new Dictionary<string, MAClainAmount>();
        private string CardId = string.Empty;
        private int mDistributorId;
        private string mPeriod = string.Empty;

        #endregion Variables

        #region Constructor

        public MAReptosImporter(IWin32Window owner, int distributorId, string period)
        {
            mOwner = owner;
            mDistributorId = distributorId;
            mPeriod = period;

            CardId = getCardId(distributorId);
            if (string.IsNullOrEmpty(CardId))
            {
                Error.SetErrorMessage("Distributor not found");
                return;
            }

            mAccounts = MADataAccess.LocalData.TLDDistributorProductAccountIdList(distributorId);
        }

        #endregion Constructor

        #region Methods

        public bool Add(string productPde, string productDescription, float claimAmount, float claimsGSTAmount, bool changeSign = false)
        {
            var a = getAccountId(productPde, productDescription);
            if (string.IsNullOrEmpty(a)) return false;

            if (!mItems.ContainsKey(a)) mItems[a] = new MAClainAmount();

            if (!changeSign) mItems[a].Add(claimAmount, claimsGSTAmount);
            else mItems[a].Subtract(claimAmount, claimsGSTAmount);

            return true;
        }

        public bool Update()
        {
            Error.ClearErrorMessage();
            try
            {
                //Delete the old data
                MADataAccess.LocalData.Database.ExecuteCommand($"Delete from TLDReptos where [CardId]='{CardId}' AND [Period]='{mPeriod}'");
                //Add the new data
                var sbi = new SQLiteBulkInsert(MADataAccess.LocalData.Database.ConnectionString);
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

        private string getCardId(int distributorId)
        {
            var distributor = MADataAccess.LocalData.TLMDistributorItem(distributorId);
            if (distributor == null) return string.Empty;
            return distributor.CardId;
        }

        private string getAccountId(string productPDE, string productDescription)
        {
            Error.ClearErrorMessage();

            var a = mAccounts.Where(x => x.ProductPDE == productPDE.AddLeadingZeros(20));

            //If an account Id is present, return it
            if (a.Any()) return a.First().AccountId;

            //Define the product's accountId
            var taccountId = string.Empty;

            var f = new frmAddProductAccountId(productPDE, productDescription);
            f.ShowDialog(mOwner);
            if (f.AccountNumber == string.Empty)
            {
                Error.SetErrorMessage($"A product account number not supplied for product: {productPDE.RemoveLeadingZeros()} - {productDescription}");
                return string.Empty;
            }

            var dpa = new TLDDistributorProductAccountId { DistributorId = mDistributorId, ProductPDE = productPDE.AddLeadingZeros(20), AccountId = f.AccountNumber, Product = productDescription };
            MADataAccess.LocalData.TLDDistributorProductAccountIdUpdate(dpa);

            mAccounts = MADataAccess.LocalData.TLDDistributorProductAccountIdList(mDistributorId);

            return f.AccountNumber;
        }

        private List<TLDRepto> geTldReptosList()
        {
            var tlist = new List<TLDRepto>();
            foreach (var item in mItems) tlist.Add(new TLDRepto { AccountNumber = item.Key, CardId = CardId, Period = mPeriod, Claim = item.Value.ClaimAmount.Round(2), ClaimGST = item.Value.ClaimGSTAmount.Round(2) });
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