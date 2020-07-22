using Newtonsoft.Json;

namespace MyCompany.Models.DaData
{
    public class Management
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("post")]
        public string Post { get; set; }

        [JsonProperty("disqualified")]
        public string Disqualified { get; set; }
    }
}
