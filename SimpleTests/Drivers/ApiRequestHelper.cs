using System.Net.Http.Json;

namespace SimpleTests.Drivers
{
    public class ApiRequestHelper
    {
        private string _url;

        public ApiRequestHelper(string url)
        {
            _url = url;
        }

        HttpClient HttpClient = new HttpClient();


        public async Task<HttpResponseMessage> GetAsync(string endpoint)
        {
            var response = await this.HttpClient.GetAsync(_url + endpoint);
            return response;
        }

        public async Task<HttpResponseMessage> PostAsync(string endpoint, object body)
        {
            var response = await this.HttpClient.PostAsJsonAsync(endpoint, body);
            return response;
        }

        public async Task<HttpResponseMessage> PutAsync(string endpoint, object body)
        {
            var response = await this.HttpClient.PutAsJsonAsync(endpoint, body);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteAsync(string endpoint)
        {
            var response = await this.HttpClient.DeleteAsync(endpoint);
            return response;
        }
    }
}
