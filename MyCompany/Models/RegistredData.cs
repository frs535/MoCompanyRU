
namespace MyCompany.Models
{
    public class RegistredData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsCompany { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public Adress LegalAdres { get; set; }
        public Adress PostalAdress { get; set; }
        public Adress ActualAdress { get; set; }        
        public Bank Bank { get; set; }
    }
}
