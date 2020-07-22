using Newtonsoft.Json;

namespace MyCompany.Models.DaData
{
    public class FIO
    {
        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("patronymic")]
        public string Patronymic { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("qc")]
        public int QC { get; set; }
    }
}
