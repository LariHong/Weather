using Weather.Domain.Service.Administrative;
using Weather.Infrastructure.Helpers;

namespace Weather.Infrastructure.Administrative
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
