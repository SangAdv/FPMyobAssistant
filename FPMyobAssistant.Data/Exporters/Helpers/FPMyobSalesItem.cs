namespace FPMyobAssistant
{
    public class FPMyobSalesItem
    {
        public string InvoiceDate { get; set; } = string.Empty;
        public string CustomerNumber { get; set; } = string.Empty;
        public string CustomerPO { get; set; } = string.Empty;
        public string InvoiceNumber { get; set; } = string.Empty;
        public string ItemCode { get; set; } = string.Empty;
        public string ItemDescription { get; set; } = string.Empty;
        public int Quantity { get; set; } = 0;
        public float Price { get; set; } = 0;
        public float TotalPrice { get; set; } = 0;
    }
}