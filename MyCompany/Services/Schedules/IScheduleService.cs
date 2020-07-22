using System.Threading.Tasks;
using MyCompany.Models;
using System;

namespace MyCompany.Services.Schedules
{
    public interface IScheduleService
    {
        Task<ServiceResult<Shedule>> GetSheduleAsync(DateTime month);
    }
}
