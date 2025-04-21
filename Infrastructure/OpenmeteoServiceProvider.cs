using Weather.Service;

namespace Weather.Infrastructure
{
    // IOpenmeteoServiceProvider自動注入實作
    public class OpenmeteoServiceProvider : IServiceProvider<OpenmeteoService,string>
    {
        private readonly IHttpClientFactory _client;
        public OpenmeteoServiceProvider(IHttpClientFactory httpClient)
        {
            _client = httpClient;
        }
        public OpenmeteoService Create(string url)
        {
            var client = _client.CreateClient();
            var httpservice = new HttpService(url, client);

            return new OpenmeteoService(httpservice);
        }
    }
}
