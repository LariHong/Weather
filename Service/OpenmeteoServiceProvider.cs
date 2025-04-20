namespace Weather.Service
{
    //自動注入的類別實作
    public class OpenmeteoServiceProvider : IOpenmeteoServiceProvider
    {
        private readonly IHttpClientFactory _httpClientFactory;


        public OpenmeteoServiceProvider(IHttpClientFactory httpClientFactory) 
        {
            _httpClientFactory = httpClientFactory;
        }
        //獲取自動注入的OpenmeteoService實例
        public OpenmeteoService Create(string url)
        {
            var client = _httpClientFactory.CreateClient();
            var httpclient = new HttpService(url, client);

            return new OpenmeteoService(httpclient);
        }
    }
}
