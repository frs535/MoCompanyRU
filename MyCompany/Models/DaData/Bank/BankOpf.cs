using Newtonsoft.Json;

namespace MyCompany.Models.DaData.Bank
{
    public class BankOpf
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("full")]
        public string Full { get; set; }

        [JsonProperty("short")]
        public string Short { get; set; }
    }
}
