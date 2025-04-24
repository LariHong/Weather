using Weather.Model;

namespace Weather.Infrastructure
{
    //天氣資訊獲取
    public interface IWeatherFetcher
    {
        public Task<double?> GetTemperature(Coordinates coordinates);
    }
}
