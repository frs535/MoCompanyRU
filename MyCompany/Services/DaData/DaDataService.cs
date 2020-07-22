using System.Collections.Generic;
using System.Threading.Tasks;
using MyCompany.Helpers;
using MyCompany.Models.DaData;
using Newtonsoft.Json;

namespace MyCompany.Services.DaData
{
    public class DaDataService: DaDataServiceBase, IDaDataService
    {
        private const string ApiUrlBase = "api/4_1/rs/findById/party";
        private const string AdressUrlBase = "api/v1/clean/address";
        private const string ApiBankUrlBase = "api/4_1/rs/findById/bank";

        public async Task<Organisation> GetOrganisationAsync(DataQuery query)
        {
            string uri = UriHelper.CombineUri(_suggestionsBaseURL, $"{ApiUrlBase}");

            string data = JsonConvert.SerializeObject(query);

             Dictionary<string, string> dictionary = new Dictionary<string, string>
             {
                 {"Accept", "application/json" },
                 {"Authorization",$"Token {token}"}
             };

            return await _requestProvider.PostAsync<Organisation>(uri, data, dictionary);
        }

        public async Task<List<Models.DaData.Adresses.Address>> GetAddressAsync(string adress)
        {
            string uri = UriHelper.CombineUri(_cleanerBaseURL, $"{AdressUrlBase}");

            char s = '"';
            string data = $"[{s}{adress}{s}]";

            Dictionary<string, string> dictionary = new Dictionary<string, string>
             {
                 {"Authorization",$"Token {token}"},
                {"X-Secret", secretKey }
             };

            return await _requestProvider.PostAsync<List<Models.DaData.Adresses.Address>>(uri, data, dictionary);
        }

        public async Task<Models.DaData.Bank.BankResult> GetBankAsync(DataQuery query)
        {
            string uri = UriHelper.CombineUri(_suggestionsBaseURL, $"{ApiBankUrlBase}");

            string data = JsonConvert.SerializeObject(query);

            Dictionary<string, string> dictionary = new Dictionary<string, string>
             {
                 {"Accept", "application/json" },
                 {"Authorization",$"Token {token}"}
             };
            return await _requestProvider.PostAsync<Models.DaData.Bank.BankResult>(uri, data, dictionary);
        }
    }
}
