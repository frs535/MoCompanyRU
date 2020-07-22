using MyCompany.Models;
using System.Threading.Tasks;

namespace MyCompany.Services.Holidays
{
    public interface IHolidaysService
    {
        Task<Shedule> GetHolidaysAsync();
    }
}
