using Weather.Domain.Service.Administrative;
using Weather.Infrastructure.Administrative;
using Weather.Model;

namespace Weather.Infrastructure.ExternalServices
{
    //獲取行政區資訊
    public class CoordinateFetcher : ICoordinateFetcher
    {
        private readonly IServiceProvider<AdministrativeService> _administrativeServiceProvider;

        public CoordinateFetcher(IServiceProvider<AdministrativeService> administrativeServiceProvider)
        {
            _administrativeServiceProvider = administrativeServiceProvider;
        }

        public async Task<Coordinates?> GetCoordinates(AdministrativeData data)
        {
            var administrativeUrl = "https://gist.githubusercontent.com/memochou1993/aa9b6b1185221f88a03109f10d32e5e2/raw/769f8a84474621533194be07d7f40d1d75c09324/%25E5%258F%25B0%25E7%2581%25A3%25E8%25A1%258C%25E6%2594%25BF%25E5%258D%2580%25E5%2588%2597%25E8%25A1%25A8.json";
            var httpServiceClient = _administrativeServiceProvider.CreateHttpService(administrativeUrl);
            var coordinatesProvider = _administrativeServiceProvider.CreateProvider(httpServiceClient);

            return await coordinatesProvider.GetCoordinates(data.Country, data.City, data.Administrative);
        }
    }
}
