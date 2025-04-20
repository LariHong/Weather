using System.Net.Http;
using System;

namespace Weather.Infrastructure
{
    //獲取http的內容服務實作
    public class HttpService
    {
        private readonly HttpClient _client;
        private readonly string _url;
        public HttpService(string url, HttpClient httpClient)
        {
            _client = httpClient;
            _url = url;
        }
        //獲取http的內容(Json)
        public async Task<string> GetJson()
        {
            var response = await _client.GetAsync(_url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return json;
        }
    }
}
