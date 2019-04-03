using Newtonsoft.Json;

namespace FPMyobAssistant
{
    internal class MACAccountItem
    {
        [JsonProperty("1")]
        public string AccountId { get; set; } = string.Empty;

        [JsonProperty("2")]
        public string AccountDescription { get; set; } = string.Empty;

        [JsonProperty("3")]
        public string ParentAccountId { get; set; } = string.Empty;
    }
}