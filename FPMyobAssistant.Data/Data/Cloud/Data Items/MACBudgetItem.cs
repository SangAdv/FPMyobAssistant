using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FPMyobAssistant
{
    public class MACBudgetItem
    {
        [JsonProperty("1")]
        public string MAId { get; set; } = string.Empty;

        [JsonProperty("2")]
        public string Period { get; set; } = string.Empty;

        [JsonProperty("3")]
        public float Budget { get; set; } = 0;
    }
}