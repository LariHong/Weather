namespace Weather.Service
{
    //獲取http的內容服務實作
    public class HttpService
    {
        private string _url;
        private HttpClient _client;
        public HttpService(string url,HttpClient client) 
        {
            _url = url;
            _client = client;
        }
        //獲取http的內容(Json)
        public async Task<String> GetJson()
        {
            var response = await _client.GetAsync(_url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return json;
        }
    }
}
