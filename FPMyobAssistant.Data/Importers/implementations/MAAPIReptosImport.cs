using DevExpress.Spreadsheet;
using SangAdv.Common;
using SangAdv.DevExpressUI;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace FPMyobAssistant
{
    public class MAAPIReptosImport : AMADistributorReptosImport
    {
        private SAExcelImport mEI;

        public MAAPIReptosImport(IWin32Window owner, string period) : base(owner, (int)MADistributors.API, period)
        {
        }

        public override void DoImport(List<string> filenames)
        {
            foreach (var item in filenames)
            {
                var filename = Path.GetFileNameWithoutExtension(item);
                
                RaiseMessageChangedEvent($"Importing: {item}");
                mEI = new SAExcelImport(item, DocumentFormat.Csv, SACultureType.enAU);

                if (string.IsNullOrEmpty(mEI.GetText(1, 36))) importCorporateClaims(filename);
                else importSalesClaims(filename);
            }

            Importer.Update();
        }

        private void importCorporateClaims(string filenameAsInvoice)
        {
            for (var i = 2; i < 100000; i++)
            {
                if (string.IsNullOrEmpty(mEI.GetText(i, 0))) break;

                var tPDE = mEI.GetText(i, 7);
                var tProduct = mEI.GetText(i, 8);

                var tClaim = mEI.GetValue<float>(i, 11);
                var tclaimGST = (float)(tClaim * 0.1);

                if (!Importer.Add(filenameAsInvoice,tPDE, tProduct, tClaim, tclaimGST, true))
                {
                    RaiseMessageChangedEvent(Importer.ErrorMessage);
                    return;
                }
            }
        }

        private void importSalesClaims(string filenameAsInvoice)
        {
            for (var i = 2; i < 100000; i++)
            {
                if (string.IsNullOrEmpty(mEI.GetText(i, 0))) break;

                var tPDE = mEI.GetText(i, 17);
                var tProduct = mEI.GetText(i, 18);

                var tClaim = mEI.GetValue<float>(i, 31);
                var tclaimGST = mEI.GetValue<float>(i, 32);

                if (!Importer.Add(filenameAsInvoice,tPDE, tProduct, tClaim, tclaimGST, true))
                {
                    RaiseMessageChangedEvent(Importer.ErrorMessage);
                    return;
                }
            }
        }
    }
}