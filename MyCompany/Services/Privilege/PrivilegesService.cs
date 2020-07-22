using System.Threading.Tasks;
using MyCompany.Models;
using MyCompany.Helpers;

namespace MyCompany.Services.Privilege
{
    public class PrivilegesService : IPrivilegesService
    {
        private readonly IRequestProvider _requestProvider;

        private const string ApiUrlBase = "api/v1/PaySlip";

        public async Task<Privileges> GetPrivilegesAsync()
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.PrivilegesEndPoint, $"{ApiUrlBase}");

            return await _requestProvider.GetAsync<Privileges>(uri);
        }
    }
}
