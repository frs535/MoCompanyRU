using System;
namespace MyCompany.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string TabNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Role Rols { get; set; }
    }
}
