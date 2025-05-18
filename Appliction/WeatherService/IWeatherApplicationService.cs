using Weather.Model;

namespace Weather.Appliction.WeatherService
{
    //服務IWeatherApplication
    public interface IWeatherApplicationService
    {
        public Task<WeatherResponse?> GetCurrentWeatherResponse(AdministrativeData administrativeData);
    }
}
