using Newtonsoft.Json;

namespace MyCompany.Models.DaData
{
    public class OKVED
    {
        [JsonProperty("main")]
        public string Main { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
