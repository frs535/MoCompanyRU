using System;
using System.Threading.Tasks;
using MyCompany.Models;
using MyCompany.Helpers;

namespace MyCompany.Services.PaySlips
{
    public class PaySlipService: IPaySlipService
    {
        private readonly IRequestProvider _requestProvider;

        private const string ApiUrlBase = "api/v1/PaySlip";

        public async Task<PaySlip> GetPaySlipAsync(DateTime month)
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.PaySlipEndpoint, $"{ApiUrlBase}");

            return await _requestProvider.GetAsync<PaySlip>(uri);
        }

        public async Task<DateTime[]> GetAvaliblePeriodsAsync()
        {
            var uri = string.Empty;

            return await _requestProvider.GetAsync<DateTime[]>(uri);
        }
    }
}
