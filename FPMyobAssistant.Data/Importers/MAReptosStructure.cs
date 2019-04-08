using LocalModelContext;
using SangAdv.Common;
using SangAdv.Common.StringExtensions;
using SangAdv.DevExpressUI;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FPMyobAssistant
{
    public class MAReptosStructure
    {
        #region Variables

        private List<TLMPLAccount> mPLAccounts = MADataAccess.LocalData.TLMPLAccountList();

        #endregion Variables

        #region Constructor

        public MAReptosStructure()
        {
        }

        #endregion Constructor

        #region Methods

        public void Print(string filename, string reportTitle)
        {
            var rowCounter = 4;
            var er = new SAExcelReport(filename);

            foreach (var distributor in MADataAccess.LocalData.TLMDistributorDictionary().OrderBy(x => x.Value))
            {
                er.AddText(0, rowCounter, 0, distributor.Value);
                rowCounter++;

                foreach (var accountId in MADataAccess.LocalData.TLDDistributorProductAccountIdList(distributor.Key).OrderBy(x => x.AccountId).Select(x => x.AccountId).Distinct())
                {
                    er.AddText(0, rowCounter, 1, accountId);
                    er.AddText(0, rowCounter, 2, getPLAccountDescription(accountId));
                    rowCounter++;

                    foreach (var productItem in MADataAccess.LocalData.TLDDistributorProductAccountIdList(distributor.Key).Where(x => x.AccountId == accountId).OrderBy(x => x.Product))
                    {
                        er.AddText(0, rowCounter, 3, productItem.Product);
                        er.AddText(0, rowCounter, 4, productItem.ProductPDE.RemoveLeadingZeros());
                        rowCounter++;
                    }
                }
            }

            er.AutoFit(0, 0, 4);
            er.AddHeading(0, reportTitle, "Myob Assistant");
            er.Save(0);

            if (File.Exists(filename)) SAProcess.OpenFileInDefaultApp(filename);
        }

        #endregion Methods

        #region Private Methods

        private string getPLAccountDescription(string accountId)
        {
            var a = mPLAccounts.Where(x => x.AccountId.RemoveLeadingZeros() == accountId);
            if (a.Any()) return a.First().AccountDescription;
            return "Undefined P&L Account";
        }

        #endregion Private Methods
    }
}