using Weather.Domain.Service.Weather;
using Weather.Model;

namespace Weather.Appliction.WeatherService
{
    //給應用層服務的實作
    public class WeatherApplicationService : IWeatherApplicationService
    {
        private readonly IWeatherService _weatherService;

        public WeatherApplicationService(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        public async Task<WeatherResponse?> GetCurrentWeatherResponse(AdministrativeData administrativeData)
        {
            return await _weatherService.GetCurrentWeather(administrativeData);
        }
    }
}
