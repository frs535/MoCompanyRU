using System.Threading.Tasks;
using System.Collections.Generic;

namespace MyCompany.Services
{
    public interface IRequestProvider
    {
        Task<TResult> GetAsync<TResult>(string uri, string token = "");

        Task<Tresult> PostAsync<Tresult>(string uri, string data, Dictionary<string, string> headers);

        Task<Tresult> PostAsync<Tresult>(string uri, object data, Dictionary<string, string> headers);

        Task<TResult> PostAsync<TResult>(string uri, TResult data, string token = "", string header = "");

        Task<TResult> PostAsync<TResult>(string uri, string data, string clientId, string clientSecret);

        Task<TResult> PostAsync<TResult>(string uri, object data, string clientId, string clientSecret);

        Task<TResult> PutAsync<TResult>(string uri, TResult data, string token = "", string header = "");

        Task PostAsync(string uri, object data, string clientId, string clientSecret, Dictionary<string, string> headers);

        Task DeleteAsync(string uri, string token = "");
    }
}
