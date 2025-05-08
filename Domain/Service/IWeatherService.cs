using Weather.Appliction;
using Weather.Model;

namespace Weather.Domain.Service
{
    public interface IWeatherService
    {
        public Task<WeatherResponse?> GetCurrentWeather(AdministrativeData administrativeData);
    }
}
