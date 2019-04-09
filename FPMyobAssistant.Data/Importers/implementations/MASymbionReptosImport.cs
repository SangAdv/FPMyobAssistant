using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Spreadsheet;
using SangAdv.Common;
using SangAdv.DevExpressUI;

namespace FPMyobAssistant
{
    public class MASymbionReptosImport : AMADistributorReptosImport
    {
        public MASymbionReptosImport(IWin32Window owner, string period) : base(owner, (int)MADistributors.Symbion, period)
        {
        }

        public override void DoImport(List<string> filenames)
        {
            foreach (var item in filenames)
            {
                RaiseMessageChangedEvent($"Importing: {item}");
                var ei = new SAExcelImport(item, DocumentFormat.Xlsx, SACultureType.enAU);

                for (var i = 1; i < 100000; i++)
                {
                    if (string.IsNullOrEmpty(ei.GetText(i, 0))) break;

                    var tPDE = ei.GetText(i, 11);
                    var tProduct = ei.GetText(i, 12);

                    var tClaim = ei.GetValue<float>(i, 26);
                    var tclaimGST = ei.GetValue<float>(i, 27);

                    if (!Importer.Add(tPDE, tProduct, tClaim, tclaimGST, true))
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