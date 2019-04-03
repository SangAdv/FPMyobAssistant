using Newtonsoft.Json;

namespace FPMyobAssistant
{
    internal class MACSettingsItem
    {
        [JsonProperty("1")]
        public string ImportExclusionAccounts { get; set; } = string.Empty;
    }
}