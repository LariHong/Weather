using Weather.Model;

namespace Weather.Service
{
    //天氣應用介面
    public interface IWeatherApplicationService
    {
        public Task<double?> GetCurrentWeather(AdministrativeData administrativeData);
    }
}
