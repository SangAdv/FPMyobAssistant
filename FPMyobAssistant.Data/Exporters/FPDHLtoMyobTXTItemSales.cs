using System;
using System.Linq;

namespace FPMyobAssistant
{
    public class FPDHLToMyobTXTItemSales : MyobTXTSalesExport<FPMyobSalesItem>
    {
        #region Constructor

        public FPDHLToMyobTXTItemSales() : base()
        {
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
            var inl = DataItems.Select(x => x.InvoiceNumber).Distinct();
            var counter = 0;

            //Add the items to the file list
            foreach (var invnumber in inl)
            {
                //Get all the line items
                var invli = DataItems.Where(x => x.InvoiceNumber == invnumber);

                //Add them as a new items
                foreach (var item in invli) Additem(item.InvoiceDate, item.CustomerNumber, item.CustomerPO, item.InvoiceNumber, item.ItemCode, item.ItemDescription, item.Quantity, item.Price, item.TotalPrice);
                if (counter < inl.Count() - 1) AddEntryLine();

                counter++;
            }
        }

        #endregion Methods

        #region Private Methods

        private void AddHeading()
        {
            FileItems.Add("Date,Card ID,Customer PO,Invoice #,Item Number,Description,Quantity,Price,GST Amount,Total,Inc-Tax Total,Tax Code");
        }

        private void Additem(string invoiceDate, string cardID, string customerPO, string invoiceNumber, string itemNumber, string itemDescription, int quantity, float price, float totalPrice)
        {
            var fTotal = (float)Math.Round(Convert.ToSingle(quantity) * price, 2);
            var fGST = (float)Math.Round(fTotal * (float)0.1, 2);
            var fIncTotal = (float)Math.Round(fTotal + fGST, 2);

            var tTotal = fTotal < 0 ? $"-${fTotal * -1:0.00}" : $"${fTotal:0.00}";
            var tGST = fGST < 0 ? $"-${fGST * -1:0.00}" : $"${fGST:0.00}";

            string tIncTotal = fIncTotal < 0 ? $"-${fIncTotal * -1:0.00}" : $"${fIncTotal:0.00}";

            FileItems.Add($"{invoiceDate},{cardID},{customerPO},{invoiceNumber},{itemNumber},{itemDescription},{quantity}.000000,${price:0.0000},{tGST},{tTotal},{tIncTotal},GST");
        }

        #endregion Private Methods
    }
}