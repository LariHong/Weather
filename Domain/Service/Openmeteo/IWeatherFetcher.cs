using Weather.Model;

namespace Weather.Domain.Service.Openmeteo
{
    //天氣資訊獲取
    public interface IWeatherFetcher
    {
        public Task<double?> GetTemperature(Coordinates coordinates);
    }
}
