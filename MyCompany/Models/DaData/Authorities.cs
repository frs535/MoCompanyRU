using Newtonsoft.Json;

namespace MyCompany.Models.DaData
{
    public class Authorities
    {
        [JsonProperty("fts_registration")]
        public GovernmentAgency FTSRegistration { get; set; }

        [JsonProperty("fts_report")]
        public GovernmentAgency FTSReport { get; set; }

        [JsonProperty("pf")]
        public GovernmentAgency PF { get; set; }

        [JsonProperty("sif")]
        public GovernmentAgency SIF { get; set; }
    }
}
