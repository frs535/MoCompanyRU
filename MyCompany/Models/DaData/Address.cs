using Newtonsoft.Json;
namespace MyCompany.Models.DaData
{
    public class Address
    {

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("unrestricted_value")]
        public string UnrestrictedValue { get; set; }

        [JsonProperty("data")]
        [JsonIgnore]
        public string Data { get; set; }
    }
}
