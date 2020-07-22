
using System.Threading.Tasks;
using MyCompany.Models.DaData;
using System.Collections.Generic;

namespace MyCompany.Services.DaData
{
    public interface IDaDataService
    {
        Task<Organisation> GetOrganisationAsync(DataQuery query);
        Task<List<Models.DaData.Adresses.Address>> GetAddressAsync(string adress);
        Task<Models.DaData.Bank.BankResult> GetBankAsync(DataQuery query);
    }
}
