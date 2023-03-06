using SimpleTests.Support.Models;
using System.Net.Http.Json;

namespace SimpleTests.Drivers
{
    public class ApiRequestHelper
    {
        protected string _url;

        public ApiRequestHelper(string url)
        {
            _url = url;
        }

        protected HttpClient client => new HttpClient();

        public async Task<HttpResponseMessage> GetAsync(string endpoint)
        {
            var response = await this.client.GetAsync(_url + endpoint);

            return response;
        }

        public async Task<HttpResponseMessage> PostAsync(string endpoint, object body)
        {
            var response = await this.client.PostAsJsonAsync(endpoint, body);
            return response;
        }

        public async Task<HttpResponseMessage> PutAsync(string endpoint, object body)
        {
            var response = await this.client.PutAsJsonAsync(endpoint, body);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteAsync(string endpoint)
        {
            var response = await this.client.DeleteAsync(endpoint);
            return response;
        }
    }
}
