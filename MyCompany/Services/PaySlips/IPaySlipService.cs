using System;
using MyCompany.Models;
using System.Threading.Tasks;

namespace MyCompany.Services.PaySlips
{
    public interface IPaySlipService
    {
        Task<PaySlip> GetPaySlipAsync(DateTime month);
        Task<DateTime[]> GetAvaliblePeriodsAsync();
    }
}
