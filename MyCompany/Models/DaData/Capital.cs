using Newtonsoft.Json;

namespace MyCompany.Models.DaData
{
    public class Capital
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public float Value { get; set; }
    }
}
