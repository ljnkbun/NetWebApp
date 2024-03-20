using Core.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Core.Helpers
{
    public sealed class RestClientHelper : IRestClientHelper
    {
        private readonly HttpClient _httpClient;

        public RestClientHelper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAsync(string requestUri, Dictionary<string, string> additionalHeaders = null)
        {
            AddHeaders(_httpClient, additionalHeaders);
            AddAuthorizationHeaders(_httpClient);
            return await _httpClient.GetStringAsync(requestUri);
        }

        public async Task<string> GetAsync<T>(string requestUri, T request, Dictionary<string, string> additionalHeaders = null)
            where T : class
        {
            AddHeaders(_httpClient, additionalHeaders);
            AddAuthorizationHeaders(_httpClient);

            var json = JsonSerializer.Serialize(request);
            var httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri)
            {
                Content = httpContent
            };

            var httpResponseMessage = await _httpClient.SendAsync(requestMessage);
            return await httpResponseMessage.Content.ReadAsStringAsync();
        }
        public async Task<string> PostAsync<T>(string requestUri, T request, Dictionary<string, string> additionalHeaders = null) where T : class
        {
            AddHeaders(_httpClient, additionalHeaders);
            AddAuthorizationHeaders(_httpClient);
            var json = JsonSerializer.Serialize(request);

            var httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var httpResponseMessage = await _httpClient.PostAsync(requestUri, httpContent);
            return await httpResponseMessage.Content.ReadAsStringAsync();
        }

        public async Task<string> DeleteAsync(string requestUri, Dictionary<string, string> additionalHeaders = null)
        {
            AddHeaders(_httpClient, additionalHeaders);
            AddAuthorizationHeaders(_httpClient);
            var httpResponseMessage = await _httpClient.DeleteAsync(requestUri);
            return await httpResponseMessage.Content.ReadAsStringAsync();
        }

        public async Task<string> PutAsync<T>(string requestUri, T request, Dictionary<string, string> additionalHeaders = null) where T : class
        {
            AddHeaders(_httpClient, additionalHeaders);
            AddAuthorizationHeaders(_httpClient);
            var json = JsonSerializer.Serialize(request);

            var httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var httpResponseMessage = await _httpClient.PutAsync(requestUri, httpContent);
            return await httpResponseMessage.Content.ReadAsStringAsync();
        }

        public async Task<string> PatchAsync<T>(string requestUri, T request, Dictionary<string, string> additionalHeaders = null) where T : class
        {
            AddHeaders(_httpClient, additionalHeaders);
            AddAuthorizationHeaders(_httpClient);
            var json = JsonSerializer.Serialize(request);

            var httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var httpResponseMessage = await _httpClient.PatchAsync(requestUri, httpContent);
            return await httpResponseMessage.Content.ReadAsStringAsync();
        }

        private void AddHeaders(HttpClient httpClient, Dictionary<string, string> additionalHeaders)
        {
            httpClient.DefaultRequestHeaders.Clear();
            if (additionalHeaders == null)
                return;
            foreach (KeyValuePair<string, string> current in additionalHeaders)
            {
                httpClient.DefaultRequestHeaders.Add(current.Key, current.Value);
            }
        }

        private void AddAuthorizationHeaders(HttpClient httpClient)
        {
            var additionalHeaders = RequestHeader.AdditionalHeaders;
            if (additionalHeaders == null)
                return;
            if (additionalHeaders.ContainsKey("Jwtoken"))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", additionalHeaders["Jwtoken"]);
            }
        }

        public async Task<string> PostHttpContentAsync<T>(string requestUri, HttpContent content, Dictionary<string, string> additionalHeaders = null) where T : class
        {
            AddHeaders(_httpClient, additionalHeaders);
            var httpResponseMessage = await _httpClient.PostAsync(requestUri, content);
            return await httpResponseMessage.Content.ReadAsStringAsync();
        }

    }
}
