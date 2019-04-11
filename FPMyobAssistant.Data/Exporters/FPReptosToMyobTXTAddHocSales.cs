using System;
using System.Linq;
using SangAdv.Common.StringExtensions;

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

            //Add the heading
            AddHeading();

            //Get a list of invoicenumbers
            var inl = DataItems.Select(x => x.CardId).Distinct();
            var counter = 0;

            //Add the items to the file list
            foreach (var cardId in inl)
            {
                //Get all the line items
                var invli = DataItems.Where(x => x.CardId == cardId);

                //Add them as a new items
                foreach (var item in invli) Additem(item.CardId, "", item.AccountNumber.RemoveLeadingZeros(), item.Amount, item.AmountIncTax);
                if (counter < inl.Count() - 1) AddEntryLine();

                counter++;
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