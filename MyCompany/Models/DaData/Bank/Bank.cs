using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyCompany.Models.DaData.Bank
{
    public class Bank
    {
        [JsonProperty("bic")]
        public string BIK { get; set; }

        [JsonProperty("swift")]
        public string SWIFT { get; set; }

        [JsonProperty("registration_number")]
        public string RegistrationNumber { get; set; }

        [JsonProperty("correspondent_account")]
        public string CorrespondentAccount { get; set; }

        [JsonProperty("name")]
        public BankName Name { get; set; }

        [JsonProperty("payment_city")]
        public string PaymentCity { get; set; }

        [JsonProperty("okpo")]
        public string OKPO { get; set; }

        [JsonProperty("opf")]
        public BankOpf OPF { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("rkc")]
        public string Rkc { get; set; }

        [JsonProperty("state")]
        public State State { get; set; }

        [JsonProperty("address")]
        public Data Company { get; set; }
    }
}
