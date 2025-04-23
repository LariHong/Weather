using Weather.Model;

namespace Weather.Service
{
    //服務IWeatherApplication
    public interface IWeatherApplicationService
    {
        public Task<double?> GetCurrentWeather(AdministrativeData administrativeData);
    }
}
