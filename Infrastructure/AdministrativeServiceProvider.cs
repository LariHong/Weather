using Weather.Domain;

namespace Weather.Infrastructure
{
    // IAdministrativeServiceProvider自動注入實作
    public class AdministrativeServiceProvider : IServiceProvider<AdministrativeService>
    {
        private readonly IHttpClientFactory _client;
        public AdministrativeServiceProvider(IHttpClientFactory client)
        { 
            _client = client;
        }
        public HttpService CreateHttpService(string url)
        {
            var client = _client.CreateClient();

            return new HttpService(url, client);
        }

        public AdministrativeService CreateProvider(HttpService httpService)
        {
            return new AdministrativeService(httpService);
        }
    }
}
