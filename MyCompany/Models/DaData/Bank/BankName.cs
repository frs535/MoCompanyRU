using Newtonsoft.Json;

namespace MyCompany.Models.DaData.Bank
{
    public class BankName
    {
        [JsonProperty("payment")]
        public string Payment { get; set; }

        [JsonProperty("full")]
        public string Full { get; set; }

        [JsonProperty("short")]
        public string Short { get; set; }
    }
}
