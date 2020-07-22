using System;
using System.Threading.Tasks;
using MyCompany.Models;

namespace MyCompany.Services.Privilege
{
    public interface IPrivilegesService
    {
        Task<Privileges> GetPrivilegesAsync();
    }
}
