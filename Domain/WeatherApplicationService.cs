using Weather.Domain.Service;
using Weather.Model;

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
        public async Task<double?> GetWeatherResponse(AdministrativeData administrativeData)
        {
            return await _weatherService.GetCurrentWeather(administrativeData);
        }
    }
}
