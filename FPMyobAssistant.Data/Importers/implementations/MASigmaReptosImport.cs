using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }
    }
}