using DevExpress.Spreadsheet;
using SangAdv.Common;
using SangAdv.DevExpressUI;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FPMyobAssistant
{
    public class MACH2ReptosImport : AMADistributorReptosImport
    {
        internal enum MACH2ImportType
        {
            SalesClaims,
            DistributionClaims
        }

        public MACH2ReptosImport(IWin32Window owner, string period) : base(owner, (int)MADistributors.CH2, period)
        {
        }

        public override void DoImport(List<string> filenames)
        {
            var tImportTye = MACH2ImportType.SalesClaims;
            float tClaim;
            float tClaimGST;

            foreach (var item in filenames)
            {
                RaiseMessageChangedEvent($"Importing: {item}");
                var ei = new SAExcelImport(item, DocumentFormat.Xlsx, SACultureType.enAU);

                if (ei.GetText(10, 26).ToUpper().Contains("DISTRIBUTION")) tImportTye = MACH2ImportType.DistributionClaims;

                for (var i = 11; i < 100000; i++)
                {
                    if (string.IsNullOrEmpty(ei.GetText(i, 1))) break;

                    var tPDE = ei.GetText(i, 1);
                    var tProduct = ei.GetText(i, 2);

                    if (tImportTye == MACH2ImportType.SalesClaims)
                    {
                        tClaim = ei.GetValue<float>(i, 25);
                        tClaimGST = ei.GetValue<float>(i, 26);
                    }
                    else
                    {
                        tClaim = ei.GetValue<float>(i, 24);
                        tClaimGST = ei.GetValue<float>(i, 25);
                    }

                    if (!Importer.Add(tPDE, tProduct, tClaim, tClaimGST, true))
                    {
                        RaiseMessageChangedEvent(Importer.ErrorMessage);
                        return;
                    }
                }
            }

            Importer.Update();
        }
    }
}