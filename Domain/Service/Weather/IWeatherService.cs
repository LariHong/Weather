using Weather.Appliction;
using Weather.Model;

namespace Weather.Domain.Service.Weather
{
    public interface IWeatherService
    {
        public Task<WeatherResponse?> GetCurrentWeather(AdministrativeData administrativeData);
    }
}
