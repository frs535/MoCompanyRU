using Newtonsoft.Json;

namespace MyCompany.Models.DaData
{
    public class Suggestion
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("unrestricted_value")]
        public string UnrestrictedValue { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}
