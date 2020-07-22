using System.Collections.Generic;
using System.Threading.Tasks;
using MyCompany.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using MyCompany.Helpers;
using MyCompany.Exception;

namespace MyCompany.Services.Identity
{

    public class IdentityService : IIdentityService
    {
        private readonly IRequestProvider _requestProvider;
        private readonly JsonSerializerSettings _serializerSettings;

        public IdentityService()
        {
            _requestProvider = GlobalSetting.Instance.RequestProvider;
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };
            _serializerSettings.Converters.Add(new StringEnumConverter());
        }

        public string CreateLogoutRequest(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return string.Empty;
            }

            return string.Format("{0}?id_token_hint={1}&post_logout_redirect_uri={2}",
                GlobalSetting.Instance.LogoutEndpoint,
                token,
                GlobalSetting.Instance.LogoutCallback);
        }

        public async Task<HttpExceptionRequest> Login(string user, string password)
        {
            var headers = new Dictionary<string, string>()
            {
                { "password", password }
            };

            var data = new
            {
                login = user,
                password
            };

            var uri = UriHelper.CombineUri(GlobalSetting.Instance.AuthorizeEndpoint, "Login");
            try
            {
                GlobalSetting.Instance.Token = await _requestProvider.PostAsync<string>(uri, data, headers);
            }
            catch(HttpExceptionRequest exeption)
            {
                return exeption;
            }

            return null;
        }

        public async Task<ServiceResult<string>> GetUidAsync()
        {
            var url = UriHelper.CombineUri(GlobalSetting.Instance.AuthorizeEndpoint, ".current");
            try
            {
                var result = await _requestProvider.GetAsync<string>(url, GlobalSetting.Instance.Token);
                return new ServiceResult<string>(result);
            }
            catch(HttpExceptionRequest exception)
            {
                return new ServiceResult<string>(exception);
            }
        }

        public async Task<HttpExceptionRequest> RegisterAsync(RegistredData registredData)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Password", registredData.Password }
            };

            var uri = UriHelper.CombineUri(GlobalSetting.Instance.AuthorizeEndpoint, "Registration");
            await _requestProvider.PostAsync(uri, registredData, GlobalSetting.Instance.ClientId, GlobalSetting.Instance.ClientSecret, headers);

            return null;
        }

        public async Task<HttpExceptionRequest> RestorePassswordAsync(string email)
        {
            //string data = CreateAuthorizationRequest();

            return null;
        }
    }
}
