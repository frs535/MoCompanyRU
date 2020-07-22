using Newtonsoft.Json;

namespace MyCompany.Models.DaData
{
    public class Phisic
    {
        [JsonProperty("inn")]
        public string INN { get; set; }

        [JsonProperty("fio")]
        public FIO FIO { get; set; }

        [JsonProperty("hid")]
        public string HID { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("share")]
        public string Share { get; set; }
    }
}
