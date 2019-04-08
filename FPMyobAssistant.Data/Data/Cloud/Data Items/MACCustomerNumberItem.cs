using Newtonsoft.Json;

namespace FPMyobAssistant
{
    public class MACCustomerNumberItem
    {
        [JsonProperty("1")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("2")]
        public string CustomerName { get; set; } = string.Empty;

        [JsonProperty("3")]
        public string MYOBCardId { get; set; } = string.Empty;
    }
}