using Weather.Delegate;
using Weather.Domain;
using Weather.Model;

namespace Weather.Infrastructure
{
    //天氣資訊獲取
    public class WeatherFetcher : IWeatherFetcher
    {
        private readonly HttpClientFactory<HttpService, string> _httpClientFactory;
        private readonly IOpenmeteoServiceProvider _openmeteoServiceProvider;

        public WeatherFetcher(HttpClientFactory<HttpService, string> httpClientFactory,
                              IOpenmeteoServiceProvider openmeteoServiceProvider)
        {
            _httpClientFactory = httpClientFactory;
            _openmeteoServiceProvider = openmeteoServiceProvider;
        }
        public async Task<double?> GetTemperature(Coordinates coordinates)
        {
            var url = $"https://api.open-meteo.com/v1/forecast?latitude={coordinates.Latitude}&longitude={coordinates.Longitude}&current=temperature_2m";
            var httpService = _httpClientFactory(url);
            var weatherProvider = _openmeteoServiceProvider.CreateProvider(httpService);

            return await weatherProvider.GetCurrentTemperature();
        }
    }
}
