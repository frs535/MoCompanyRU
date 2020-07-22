using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyCompany.Models.DaData
{
    public class Data
    {
        [JsonProperty("kpp")]
        public string KPP { get; set; }

        [JsonProperty("capital")]
        public Capital Capital { get; set; }

        [JsonProperty("management")]
        public Management Management { get; set; }

        [JsonProperty("founders")]
        public List<Phisic> Founders { get; set; }

        [JsonProperty("managers")]
        public List<Phisic> Managers { get; set; }

        [JsonProperty("branch_type")]
        public string BranchType { get; set; }

        [JsonProperty("branch_count")]
        public int BranchCount { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("qc")]
        public string QC { get; set; }

        [JsonProperty("hid")]
        public string Hid { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("state")]
        public State State { get; set; }

        [JsonProperty("opf")]
        public OPF OPF { get; set; }

        [JsonProperty("name")]
        public OPFName Name { get; set; }

        [JsonProperty("inn")]
        public string INN { get; set; }

        [JsonProperty("ogrn")]
        public string OGRN { get; set; }

        [JsonProperty("okpo")]
        public string OKPO { get; set; }

        [JsonProperty("okved")]
        public string OKVED { get; set; }

        [JsonProperty("okveds")]
        public List<OKVED> OKVEDs { get; set; }

        [JsonProperty("authorities")]
        public Authorities Authorities { get; set; }

        [JsonProperty("documents")]
        public Documents Documents { get; set; }

        [JsonProperty("licenses")]
        public string Licenses { get; set; }

        [JsonProperty("finance")]
        public Finance Finance { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("phones")]
        public string Phones { get; set; }

        [JsonProperty("emails")]
        public string Emails { get; set; }

        [JsonProperty("ogrn_date")]
        public string OGRNDate { get; set; }

        [JsonProperty("kppokved_type")]
        public string OKVEDType { get; set; }

        [JsonProperty("employee_count")]
        public string EmployeeCount { get; set; }
    }
}
