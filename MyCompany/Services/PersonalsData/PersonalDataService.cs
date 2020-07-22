using System.Threading.Tasks;
using MyCompany.Models;
using MyCompany.Helpers;
using System.Collections.Generic;
using MyCompany.Exception;

namespace MyCompany.Services.PersonalsData
{
    public class PersonalDataService : IPersonalDataService
    {
        private readonly IRequestProvider _requestProvider;

        public PersonalDataService()
        {
            _requestProvider = GlobalSetting.Instance.RequestProvider;
        }

        public async Task<List<PersonalData>> GetPersonalDataAsync()
        {
            //https://ai.deskit.ru/api/V1/cabinet/PersonalData
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.PaySlipEndpoint, GlobalSetting.Instance.CurrentUserId);

            return await _requestProvider.GetAsync<List<PersonalData>>(uri, GlobalSetting.Instance.Token);
        }

        public async Task<bool> SendMessageAsync(string message)
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.PaySlipEndpoint);//, $"{ApiUrlBase}");

            return true;
        }

        public async Task<ServiceResult<Dictionary<string, string>>> GetUserEmployees()
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.PaySlipEndpoint, "U", GlobalSetting.Instance.ClientId);

            try
            {
                var result = await _requestProvider.GetAsync<string>(uri, GlobalSetting.Instance.Token);
                return new ServiceResult<Dictionary<string, string>>();
            }
            catch(HttpExceptionRequest exception)
            {
                return new ServiceResult<Dictionary<string, string>>(exception);
            }
        }
    }
}
