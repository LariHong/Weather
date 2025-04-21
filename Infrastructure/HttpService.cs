using System.Net.Http;
using System;
using System.Text.Json;

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
            try
            {
                var response = await _client.GetAsync(_url);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                return json;
            }
            catch (HttpRequestException ex)
            {
                // 網路相關錯誤
                return $"HTTP Request error: {ex.Message}";
            }
            catch (TaskCanceledException ex)
            {
                // 逾時或取消
                return $"Request was canceled or timed out: {ex.Message}";
            }
            catch(JsonException ex)
            {
                return $"Json error: {ex.Message}";
            }
            catch (Exception ex)
            {
                // 其他未預期錯誤
                return $"Unexpected error: {ex.Message}";
            }
        }
    }
}
