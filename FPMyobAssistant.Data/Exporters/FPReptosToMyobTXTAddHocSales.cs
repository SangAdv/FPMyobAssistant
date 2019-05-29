using SangAdv.Common.StringExtensions;
using System;
using System.Linq;

namespace FPMyobAssistant
{
    public class FPReptosToMyobTXTAddHocSales : MyobTXTSalesExport<FPMyobAddHocSalesItem>
    {
        #region Variables

        private DateTime mInvoiceDate = DateTime.Now;

        #endregion Variables

        #region Constructor

        public FPReptosToMyobTXTAddHocSales(DateTime invoiceDate) : base()
        {
            mInvoiceDate = invoiceDate;
        }

        #endregion Constructor

        #region Methods

        public void Create()
        {
            HasError = false;
            FileItems.Clear();
            var tInvoice = string.Empty;

            //Add the heading
            AddHeading();

            //Get a list of distributors
            var dist = DataItems.Select(x => x.CardId).Distinct();

            //Add the items to the file list
            foreach (var cardId in dist)
            {
                var invoices = DataItems.Where(x => x.CardId == cardId).Select(x => x.Invoice).Distinct();

                foreach (var inv in invoices)
                {
                    //Get all the accounts
                    var accounts = DataItems.Where(x => x.CardId == cardId && x.Invoice == inv);

                    //Add them as a new items
                    foreach (var item in accounts) Additem(item.CardId, item.Invoice, item.AccountNumber.RemoveLeadingZeros(), item.Amount, item.AmountIncTax);
                    AddEntryLine();
                }

            }
        }

        #endregion Methods

        #region Private Methods

        private void AddHeading()
        {
            FileItems.Add("Date,Card ID,Invoice #,Account Number,Amount,Inc-Tax Amount,Tax Code");
        }

        private void Additem(string cardID, string invoiceNumber, string accountNumber, float amount, float amountIncTax)
        {
            FileItems.Add($"{mInvoiceDate:yyyy/MM/dd},{cardID},{invoiceNumber},{accountNumber},${amount:0.0000},${amountIncTax:0.0000},GST");
        }

        #endregion Private Methods
    }
}