using Newtonsoft.Json;

namespace MyCompany.Models.DaData
{
    public class Finance
    {
        [JsonProperty("tax_system")]
        public string TAXSystem { get; set; }

        [JsonProperty("income")]
        public float Income { get; set; }

        [JsonProperty("expense")]
        public float Expense { get; set; }

        [JsonProperty("debt")]
        public float Debt { get; set; }

        [JsonProperty("penalty")]
        public string Penalty { get; set; }
    }
}
