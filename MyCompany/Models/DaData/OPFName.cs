using Newtonsoft.Json;

namespace MyCompany.Models.DaData
{
    public class OPFName
    {
        [JsonProperty("full_with_opf")]
        public string FullWithOPF { get; set; }

        [JsonProperty("short_with_opf")]
        public string WhortWithOPF { get; set; }

        [JsonProperty("latin")]
        public string Latin { get; set; }

        [JsonProperty("full")]
        public string Full { get; set; }

        [JsonProperty("short")]
        public string Short { get; set; } 
    }
}
