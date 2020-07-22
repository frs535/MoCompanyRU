using Newtonsoft.Json;

namespace MyCompany.Models.DaData.Bank
{
    public class Suggestion
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("unrestricted_value")]
        public string UnrestrictedValue { get; set; }

        [JsonProperty("data")]
        public Bank Data { get; set; }
    }
}
