using SangAdv.Common;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FPMyobAssistant
{
    public abstract class AMADistributorReptosImport : SAErrorBase
    {
        #region Events

        public event StringDelegate MessageChangedEvent = s => { };

        public void RaiseMessageChangedEvent(string message) => MessageChangedEvent(message);

        #endregion Events

        #region Properties

        public MAReptosImporter Importer;

        #endregion Properties

        #region Constructor

        public AMADistributorReptosImport(IWin32Window owner, int distributorId, string period)
        {
            Importer = new MAReptosImporter(owner, distributorId, period);
        }

        #endregion Constructor

        #region Abstract Methods

        public abstract void DoImport(List<string> filenames);

        #endregion Abstract Methods
    }
}