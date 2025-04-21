using Weather.Model;

namespace Weather.Service
{
    public interface IWeatherService
    {
        public Task<double?> GetCurrentWeather(AdministrativeData administrativeData);
    }
}
