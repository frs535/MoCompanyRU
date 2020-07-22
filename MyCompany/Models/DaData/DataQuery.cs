using Newtonsoft.Json;

namespace MyCompany.Models.DaData
{
    public class DataQuery
    {
        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("kpp")]
        public string KPP { get; set; } = string.Empty;

        [JsonProperty("branch_type")]
        public string BranchType { get; set; } = string.Empty;

        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;
    }


}
