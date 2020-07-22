using System;

namespace MyCompany.Models
{
    public class PersonalData
    {
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string URLPhoto { get; set; }
        public DateTime BirthDate { get; set; }
        public string INN { get; set; }
        public string SNILS { get; set; }
        public float InSalary { get; set; }
        public float OutSalary { get; set; }
        public Document MainDocument { get; set; }
        public Adress LegalAdres { get; set; }
        public Adress PostalAdress { get; set; }
        public Adress ActualAdress { get; set; }
    }
}
