using MyCompany.Models.Token;
using System.Threading.Tasks;
using MyCompany.Models;
using MyCompany.Exception;
using System.Collections.Generic;

namespace MyCompany.Services.Identity
{
    public interface IIdentityService
    {
        string CreateLogoutRequest(string token);
        Task<HttpExceptionRequest> RegisterAsync(RegistredData registredData);
        Task<HttpExceptionRequest> RestorePassswordAsync(string email);
        Task<HttpExceptionRequest> Login(string user, string password);
        Task<ServiceResult<string>> GetUidAsync();
    }
}
