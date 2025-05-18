using Weather.Model;

namespace Weather.Infrastructure.ExternalServices
{
    //天氣資訊獲取
    public interface IWeatherFetcher
    {
        public Task<double?> GetTemperature(Coordinates coordinates);
    }
}
