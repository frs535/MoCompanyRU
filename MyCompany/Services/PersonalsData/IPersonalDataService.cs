using System.Collections.Generic;
using System.Threading.Tasks;
using MyCompany.Models;
namespace MyCompany.Services.PersonalsData
{
    public interface IPersonalDataService
    {
        Task<List<PersonalData>> GetPersonalDataAsync();
        Task<bool> SendMessageAsync(string message);
        Task<ServiceResult<Dictionary<string, string>>> GetUserEmployees();
    }
}
