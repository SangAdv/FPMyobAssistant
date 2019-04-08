using Newtonsoft.Json;

namespace FPMyobAssistant
{
    public class MACUpdateItem
    {
        [JsonProperty("1")]
        public string Variant { get; set; } = string.Empty;

        [JsonProperty("2")]
        public string UpdateItem { get; set; } = MAUpdateItem.Accounts;

        [JsonProperty("3")]
        public string UTCDateTimeSecondSynced { get; set; } = string.Empty;

        [JsonProperty("4")]
        public string UpdatedBy { get; set; } = string.Empty;
    }
}