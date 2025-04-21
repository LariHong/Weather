
using Weather.Delegate;
using Weather.Infrastructure;
using Weather.Model;

namespace Weather.Service
{
    //天氣服務應用流程 
    public class WeatherApplicationService : IWeatherApplicationService
    {
        private readonly IServiceProvider<AdministrativeService> _administrativeServiceProvider;
        private readonly ServiceFactory<OpenmeteoService, string> _openmeteoServiceProvider;
        public WeatherApplicationService(IServiceProvider<AdministrativeService> administrativeServiceProvider, ServiceFactory<OpenmeteoService, string> openmeteoServiceProvider) 
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
                var current_temperature = await openmeteoProvider.GetCurrentTemperature();
                if (current_temperature==null)
                {
                    Console.WriteLine("無法取得天氣資料");
                    return null;
                }

                return current_temperature;
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
