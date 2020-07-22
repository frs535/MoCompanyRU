using Newtonsoft.Json;
using System.Collections.Generic;

namespace MyCompany.Models.DaData.Bank
{
    public class BankResult
    {
        [JsonProperty("suggestions")]
        public List<Suggestion> Suggestions { get; set; }
    }
}
