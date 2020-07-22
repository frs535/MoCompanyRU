using Newtonsoft.Json;

namespace MyCompany.Models.DaData
{
    public class Documents
    {
        [JsonProperty("fts_registration")]
        public GovernmentDocument FTSRegistration { get; set; }

        [JsonProperty("pf_registration")]
        public GovernmentDocument PFRegistration { get; set; }

        [JsonProperty("sif_registration")]
        public GovernmentDocument SIFRegistration { get; set; }

        [JsonProperty("smb")]
        public GovernmentDocument SMB { get; set; }
    }
}
