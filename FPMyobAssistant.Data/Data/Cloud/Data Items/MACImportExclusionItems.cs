using Newtonsoft.Json;

namespace FPMyobAssistant
{
    public class MACImportExclusionItems
    {
        [JsonProperty("1")]
        public string Period { get; set; } = string.Empty;

        [JsonProperty("2")]
        public string Exclusions { get; set; } = string.Empty;
    }
}