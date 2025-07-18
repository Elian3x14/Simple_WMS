using System.Net.Http.Json;
using TKS_intern_shared.ViewModels.Errors;

namespace TKS_intern_client.Services
{
    public class ApiClient
    {
        private readonly HttpClient _http;

        public ApiClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<T?> GetAsync<T>(string url)
        {
            return await _http.GetFromJsonAsync<T>(url);
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string url, T data)
        {
            return await _http.PostAsJsonAsync(url, data); 
        }

        public async Task<HttpResponseMessage> PutAsync<T>(string url, T data)
        {
            return await _http.PutAsJsonAsync(url, data);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            return await _http.DeleteAsync(url);
        }
    }
}
