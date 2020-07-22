using System;
using MyCompany.Models;
using System.Threading.Tasks;
using MyCompany.Helpers;
using MyCompany.Exception;

namespace MyCompany.Services.Schedules
{
    public class ScheduleService: IScheduleService
    {
        private readonly IRequestProvider _requestProvider;
        
        public ScheduleService()
        {
            _requestProvider = GlobalSetting.Instance.RequestProvider;
        }

        public async Task<ServiceResult<Shedule>> GetSheduleAsync(DateTime month)
        {
            string smonth = month.ToString("MM");
            string syear = month.ToString("yyyy");
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.ScheduleEndPoint, $"{syear}/", $"{smonth}/", GlobalSetting.Instance.CurrentUserId);

            try
            {
                var result = await _requestProvider.GetAsync<Shedule>(uri, GlobalSetting.Instance.Token);
                return new ServiceResult<Shedule>(result);
            }
            catch(HttpExceptionRequest exeption)
            {
                return new ServiceResult<Shedule>(exeption);
            }
        }

    }
}
