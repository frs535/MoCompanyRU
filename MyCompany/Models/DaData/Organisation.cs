using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyCompany.Models.DaData
{
    public class Organisation
    {
        [JsonProperty("suggestions")]
        public List<Suggestion> Suggestions { get; set; }
    }
}
