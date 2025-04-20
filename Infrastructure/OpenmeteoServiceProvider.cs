using Weather.Service;

namespace Weather.Infrastructure
{
    // IOpenmeteoServiceProvider自動注入實作
    public class OpenmeteoServiceProvider : IOpenmeteoServiceProvider
    {
        private readonly IHttpClientFactory _client;
        public OpenmeteoServiceProvider(IHttpClientFactory httpClient)
        {
            _client = httpClient;
        }
        public OpenmeteoService Create(string url)
        {
            var clinet = _client.CreateClient();
            var httpservice = new HttpService(url, clinet);

            return new OpenmeteoService(httpservice);
        }
    }
}
