using DevExpress.Spreadsheet;
using SangAdv.Common;
using SangAdv.DevExpressUI;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FPMyobAssistant
{
    public class MASymbionReptosImport : AMADistributorReptosImport
    {
        private SAExcelImport mEI;
        private MAClainAmount mClaimAmount = new MAClainAmount();

        public MASymbionReptosImport(IWin32Window owner, string period) : base(owner, (int)MADistributors.Symbion, period)
        {
        }

        public override void DoImport(List<string> filenames)
        {
            //Import the files
            foreach (var item in filenames)
            {
                RaiseMessageChangedEvent($"Importing: {item}");
                mEI = new SAExcelImport(item, DocumentFormat.Xlsx, SACultureType.enAU);

                if (string.IsNullOrEmpty(mEI.GetText(0, 9))) importSummary();
                else importDetail();
            }

            //Add the surcharge item
            var total = Importer.Total();

            Importer.Add("4-3555", mClaimAmount.ClaimAmount - total.totalClaimAmount, mClaimAmount.ClaimGSTAmount - total.totalClaimGSTAmount);

            Importer.Update();
        }

        private void importSummary()
        {
            for (var i = 1; i < 100000; i++)
            {
                if (string.IsNullOrEmpty(mEI.GetText(i, 0))) break;

                var tClaim = mEI.GetValue<float>(i, 6);
                var tclaimGST = mEI.GetValue<float>(i, 7);

                mClaimAmount.Subtract(tClaim, tclaimGST);
            }
        }

        private void importDetail()
        {
            for (var i = 1; i < 100000; i++)
            {
                if (string.IsNullOrEmpty(mEI.GetText(i, 0))) break;

                var tPDE = mEI.GetText(i, 11);
                var tProduct = mEI.GetText(i, 12);

                var tClaim = mEI.GetValue<float>(i, 26);
                var tclaimGST = mEI.GetValue<float>(i, 27);

                if (!Importer.Add(tPDE, tProduct, tClaim, tclaimGST, true))
                {
                    RaiseMessageChangedEvent(Importer.ErrorMessage);
                    return;
                }
            }
        }
    }
}