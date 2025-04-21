using Weather.Delegate;
using Weather.Model;
using Weather.Service;

namespace Weather.Infrastructure
{

    public class WeatherService : IWeatherService
    {
        private readonly IServiceProvider<AdministrativeService> _administrativeServiceProvider;
        private readonly ServiceFactory<OpenmeteoService, string> _openmeteoServiceProvider;
        public WeatherService(IServiceProvider<AdministrativeService> administrativeServiceProvider, ServiceFactory<OpenmeteoService, string> openmeteoServiceProvider)
        {
            _administrativeServiceProvider = administrativeServiceProvider;
            _openmeteoServiceProvider = openmeteoServiceProvider;
        }

        // 獲取目前的天氣
        public async Task<double?> GetCurrentWeather(AdministrativeData administrativeData)
        {
            try
            {
                var coordinatesProvider = _administrativeServiceProvider.Create();
                var coordinates = await coordinatesProvider.GetCoordinates(administrativeData.Country, administrativeData.City, administrativeData.Administrative);

                if (coordinates == null)
                {
                    Console.WriteLine("Failed to get coordinates.");

                    return null;
                }

                var url = $"https://api.open-meteo.com/v1/forecast?latitude={coordinates.Latitude}&longitude={coordinates.Longitude}&current=temperature_2m";

                var openmeteoProvider = _openmeteoServiceProvider(url);
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
