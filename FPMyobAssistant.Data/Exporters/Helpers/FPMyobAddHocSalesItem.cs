namespace FPMyobAssistant
{
    public class FPMyobAddHocSalesItem
    {
        public string CardId { get; set; } = string.Empty;
        public string Invoice { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public float Amount { get; set; } = 0;
        public float AmountIncTax { get; set; } = 0;
    }
}