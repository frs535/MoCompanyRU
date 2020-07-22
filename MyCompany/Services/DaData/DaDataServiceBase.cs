using System;
namespace MyCompany.Services.DaData
{
    public class DaDataServiceBase
    {
        protected const string _suggestionsBaseURL = "https://suggestions.dadata.ru/suggestions/";
        protected const string _cleanerBaseURL = "https://cleaner.dadata.ru/";

        protected readonly IRequestProvider _requestProvider;

        protected const string token = "75e2b6a7cad546575e818d9528047e396e3f7add";
        protected const string secretKey = "93a1339a03e31dd7ac5385cb8413fce78beb2341";

        protected DaDataServiceBase()
        {
            _requestProvider = GlobalSetting.Instance.RequestProvider;
        }
    }
}
