using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using MyCompany.Services;
using Xamarin.Forms;

namespace MyCompany
{
    public class GlobalSetting
    {
        public const string DefaultEndpoint = "https://ai.deskit.ru";
        private readonly IRequestProvider _requestProvider;

        private string _baseIdentityEndpoint;

        public GlobalSetting()
        { 
            BaseIdentityEndpoint = DefaultEndpoint;
            
            _requestProvider = new RequestProvider();

        }

        public string Token { get; set; } = string.Empty;

        public Calendar Calendar
        {
            get { return CultureInfo.CurrentCulture.Calendar; }
        }

        public CalendarWeekRule CalendarWeekRule
        {
            get { return CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule; }
        }

        public IRequestProvider RequestProvider
        {
            get { return _requestProvider; }
        }

        public string CurrentUserId { get; set; } = string.Empty;

        public Dictionary<string, string> Employees { get; set; } = new Dictionary<string, string>();

        public string ClientId { get; set; } = string.Empty;

        public string ClientSecret { get; set; } = string.Empty;

        public static GlobalSetting Instance { get; } = new GlobalSetting();

        public string BaseIdentityEndpoint
        {
            get { return _baseIdentityEndpoint; }
            set
            {
                _baseIdentityEndpoint = value;
                UpdateEndpoint(_baseIdentityEndpoint);
            }
        }

        public string HolidaysEndPoint { get; set; }

        public string AuthorizeEndpoint { get; set; }

        public string PaySlipEndpoint { get; set; }

        public string ScheduleEndPoint { get; set; }

        public string PrivilegesEndPoint { get; set; }

        public string TokenEndpoint { get; set; }

        public string LogoutEndpoint { get; set; }

        public string Callback { get; set; }

        public string LogoutCallback { get; set; }

        public async Task SaveSettingsAsync()
        {
            
            await Application.Current.SavePropertiesAsync();
        }

        public async Task<TResult> GetPropertyAsync<TResult>(string key, TResult defaultValue)
        {
            return await Task.Run(() =>
            {
                if (Application.Current.Properties.ContainsKey(key))
                    return (TResult)Application.Current.Properties[key];

                return defaultValue;
            });
        }

        public async Task SetPropertyAsync(string key, object value)
        {
            await Task.Run(() =>
            {
                if (Application.Current.Properties.ContainsKey(key))
                    Application.Current.Properties[key] = value;
                else
                    Application.Current.Properties.Add(key, value);
            });
        }

        public void UpdateEndpoint(string endpoint)
        {
            //https://ai.deskit.ru/api/V1/users/
            
            LogoutCallback = $"{endpoint}/Account/Redirecting";

            var connectBaseEndpoint = $"{endpoint}/api/v1";
            AuthorizeEndpoint = $"{connectBaseEndpoint}/users";
            PaySlipEndpoint = $"{connectBaseEndpoint}/cabinet/personaldata";
            ScheduleEndPoint = $"{connectBaseEndpoint}/cabinet/sсhedule";
            TokenEndpoint = $"{connectBaseEndpoint}/users";
            LogoutEndpoint = $"{connectBaseEndpoint}/endsession";

            var baseUri = ExtractBaseUri(endpoint);
            Callback = $"{baseUri}/ambsoft";
        }

        private string ExtractBaseUri(string endpoint)
        {
            var uri = new Uri(endpoint);
            var baseUri = uri.GetLeftPart(UriPartial.Authority);

            return baseUri;
        }
    }
}
