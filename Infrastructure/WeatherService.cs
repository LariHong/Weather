using Weather.Delegate;
using Weather.Domain;
using Weather.Domain.Service;
using Weather.Model;

namespace Weather.Infrastructure
{

    public class WeatherService : IWeatherService
    {
        private readonly IServiceProvider<AdministrativeService> _administrativeServiceProvider;
        private readonly HttpClientFactory<HttpService, string> _httpClientFactory;
        private readonly IOpenmeteoServiceProvider _openmeteoServiceProvider;
        public WeatherService(IServiceProvider<AdministrativeService> administrativeServiceProvider, 
                                HttpClientFactory<HttpService, string>  httpClientFactory,
                                IOpenmeteoServiceProvider openmeteoServiceProvider)
        {
            _administrativeServiceProvider = administrativeServiceProvider;
            _httpClientFactory = httpClientFactory;
            _openmeteoServiceProvider = openmeteoServiceProvider;
        }

        // 獲取目前的天氣
        public async Task<double?> GetCurrentWeather(AdministrativeData administrativeData)
        {
            try
            {
                var administrativeUrl = "https://gist.githubusercontent.com/memochou1993/aa9b6b1185221f88a03109f10d32e5e2/raw/769f8a84474621533194be07d7f40d1d75c09324/%25E5%258F%25B0%25E7%2581%25A3%25E8%25A1%258C%25E6%2594%25BF%25E5%258D%2580%25E5%2588%2597%25E8%25A1%25A8.json"; ;
                var httpServiceClient = _administrativeServiceProvider.CreateHttpService(administrativeUrl);
                var coordinatesProvider = _administrativeServiceProvider.CreateProvider(httpServiceClient);

                var coordinates = await coordinatesProvider.GetCoordinates(administrativeData.Country, administrativeData.City, administrativeData.Administrative);

                if (coordinates == null)
                {
                    Console.WriteLine("Failed to get coordinates.");

                    return null;
                }

                var url = $"https://api.open-meteo.com/v1/forecast?latitude={coordinates.Latitude}&longitude={coordinates.Longitude}&current=temperature_2m";

                var openmeteoHttpServiceClient = _httpClientFactory(url);
                var openmeteoProvider = _openmeteoServiceProvider.CreateProvider(openmeteoHttpServiceClient);
                var currentTemperature = await openmeteoProvider.GetCurrentTemperature();

                if (currentTemperature == null)
                {
                    Console.WriteLine("無法取得天氣資料");

                    return null;
                }

                return currentTemperature;
            }
            catch (Exception ex)
            {
                // 記錄錯誤訊息或拋出給上層處理
                Console.WriteLine($"Error retrieving temperature: {ex.Message}");

                return null;
            }
        }
    }
}
