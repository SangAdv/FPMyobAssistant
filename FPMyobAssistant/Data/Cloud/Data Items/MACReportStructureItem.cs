using Newtonsoft.Json;

namespace FPMyobAssistant
{
    internal class MACReportStructureItem
    {
        [JsonProperty("1")]
        public int HeadingId { get; set; } = 0;

        [JsonProperty("2")]
        public int ItemId { get; set; } = 0;

        [JsonProperty("3")]
        public string ReportDescription { get; set; } = string.Empty;

        [JsonProperty("4")]
        public string AccountItems { get; set; } = string.Empty;

        [JsonProperty("5")]
        public int SequenceIndex { get; set; } = 0;
    }
}