using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FPMyobAssistant
{
    public class MASymbionReptosImport : AMADistributorReptosImport
    {
        public MASymbionReptosImport(IWin32Window owner, string period) : base(owner, (int)MADistributors.Symbion, period)
        {
        }

        public override void DoImport(List<string> filenames)
        {
            throw new NotImplementedException();
        }
    }
}