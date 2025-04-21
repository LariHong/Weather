using Weather.Service;

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
        public AdministrativeService Create()
        {
            string url = "https://gist.githubusercontent.com/memochou1993/aa9b6b1185221f88a03109f10d32e5e2/raw/769f8a84474621533194be07d7f40d1d75c09324/%25E5%258F%25B0%25E7%2581%25A3%25E8%25A1%258C%25E6%2594%25BF%25E5%258D%2580%25E5%2588%2597%25E8%25A1%25A8.json";
            var client = _client.CreateClient();
            var httpservice = new HttpService(url,client);

            return new AdministrativeService(httpservice);
        }
    }
}
