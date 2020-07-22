using Newtonsoft.Json;

namespace MyCompany.Models.DaData
{
    public class GovernmentDocument
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("series")]
        public string Series { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("issue_date")]
        public string IssueDate { get; set; }

        [JsonProperty("issue_authority")]
        public string IssueAuthority { get; set; }
    }
}
