namespace FPMyobAssistant
{
    public class MACUpdateItem
    {
        public string Variant { get; set; } = MAUpdateItemVariant.All;
        public string UpdateItem { get; set; } = MAUpdateItem.AccountData;
        public string UTCDateTimeSecondSynced { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } = MAGlobal.StartUpSettings.Items.User;
    }
}