
using Weather.Model;

namespace Weather.Service
{
    //天氣服務應用流程 
    public class WeatherApplicationService : IWeatherApplicationService
    {
        private readonly IAdministrativeServiceProvider _administrativeServiceProvider;
        private readonly IOpenmeteoServiceProvider _openmeteoServiceProvider;
        public WeatherApplicationService(IAdministrativeServiceProvider administrativeServiceProvider,IOpenmeteoServiceProvider openmeteoServiceProvider) 
        {
            _administrativeServiceProvider = administrativeServiceProvider;
            _openmeteoServiceProvider = openmeteoServiceProvider;  
        }
        
        // 獲取目前的天氣
        public async Task<double> GetCurrentWeather(AdministrativeData administrativeData)
        {
            var coordinatesProvider =  _administrativeServiceProvider.Create();
            var Coordinates = await coordinatesProvider.GetCoordinates(administrativeData.Country, administrativeData.City, administrativeData.Administrative);

            var url = $"https://api.open-meteo.com/v1/forecast?latitude={Coordinates.Latitude}&longitude={Coordinates.Longitude}&current=temperature_2m";
            
            var openmeteoProvider = _openmeteoServiceProvider.Create(url);
            var current_temperature = await openmeteoProvider.GetCurrentTemperature();

            return current_temperature;
        }
    }
}
