using Newtonsoft.Json;

namespace MyCompany.Models.DaData
{
    public class State
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("actuality_date")]
        public string ActualityDate { get; set; }

        [JsonProperty("registration_date")]
        public string RegistrationDate { get; set; }

        [JsonProperty("liquidation_date")]
        public string LiquidationDate { get; set; }
    }
}
