using DevExpress.Spreadsheet;
using SangAdv.Common;
using SangAdv.Common.StringExtensions;
using SangAdv.DevExpressUI;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace FPMyobAssistant
{
    public class MASigmaReptosImport : AMADistributorReptosImport
    {
        public MASigmaReptosImport(IWin32Window owner, string period) : base(owner, (int)MADistributors.Sigma, period)
        {
        }

        public override void DoImport(List<string> filenames)
        {
            foreach (var item in filenames)
            {
                var filename = Path.GetFileNameWithoutExtension(item);
                float tTotal = 0;

                RaiseMessageChangedEvent($"Importing: {item}");
                var ei = new SAExcelImport(item, DocumentFormat.Csv, SACultureType.enAU);

                for (var i = 1; i < 100000; i++)
                {
                    if (string.IsNullOrEmpty(ei.GetText(i, 0))) break;

                    var tPDE = ei.GetText(i, 11);
                    var tProduct = ei.GetText(i, 9);

                    var tClaim = ei.GetValue<float>(i, 23);
                    var tclaimGST = ei.GetValue<float>(i, 25);

                    if (!Importer.Add(filename, tPDE, tProduct, tClaim, tclaimGST, true))
                    {
                        RaiseMessageChangedEvent(Importer.ErrorMessage);
                        return;
                    }

                    tTotal += tClaim;
                }

                //Sigma processing fee: 1.95% or $50
                var tProcessing = (float) (tTotal * 0.0195);
                if (tProcessing < 50) tProcessing = (float)50;

                Importer.Add(filename, "4-3550".AddLeadingZeros(10), tProcessing, (float)(tProcessing * .1), true);
            }

            Importer.Update();
        }
    }
}