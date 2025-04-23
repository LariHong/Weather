using Weather.Model;
using Weather.Service;

namespace Weather.Domain
{
    //應用層服務的實作
    public class WeatherApplicationService : IWeatherApplicationService
    {
        //獲取Domain的DI
        private readonly IWeatherService _weatherService;

        public WeatherApplicationService(IWeatherService weatherService) 
        {
           _weatherService = weatherService;
        }
        public async Task<double?> GetCurrentWeather(AdministrativeData administrativeData)
        {
            return await _weatherService.GetCurrentWeather(administrativeData);
        }
    }
}
