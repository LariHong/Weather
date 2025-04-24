using Weather.Model;

namespace Weather.Domain.Service
{
    public interface IWeatherService
    {
        public Task<double?> GetCurrentWeather(AdministrativeData administrativeData);
    }
}
