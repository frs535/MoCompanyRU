using System;
using System.Threading.Tasks;
using MyCompany.Models;
using MyCompany.Helpers;

namespace MyCompany.Services.Holidays
{
    public class HolidaysService:IHolidaysService
    {
        private readonly IRequestProvider _requestProvider;

        private const string ApiUrlBase = "api/v1/PaySlip";

        public async Task<Shedule> GetHolidaysAsync()
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.HolidaysEndPoint, $"{ApiUrlBase}");

            return await _requestProvider.GetAsync<Shedule>(uri);
        }
    }
}
