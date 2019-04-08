using Newtonsoft.Json;

namespace FPMyobAssistant
{
    public class MACSettingsItem
    {
        [JsonProperty("1")]
        public string ImportExclusionAccounts { get; set; } = string.Empty;
    }
}