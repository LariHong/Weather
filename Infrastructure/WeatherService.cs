using Weather.Appliction;
using Weather.Delegate;
using Weather.Domain;
using Weather.Domain.Service;
using Weather.Model;

namespace Weather.Infrastructure
{
    //WeatherService
    public class WeatherService : IWeatherService
    {
        private readonly ICoordinateFetcher _coordinateFetcher;
        private readonly IWeatherFetcher _weatherFetcher;

        public WeatherService(ICoordinateFetcher coordinateFetcher, IWeatherFetcher weatherFetcher)
        {
            _coordinateFetcher = coordinateFetcher;
            _weatherFetcher = weatherFetcher;
        }

        public async Task<ResponseResult> GetCurrentWeather(AdministrativeData data)
        {
            try
            {
                var coordinates = await _coordinateFetcher.GetCoordinates(data);
                if (coordinates == null) return ResponseResult.Fail("獲取座標資料失敗");

                var temperature = await _weatherFetcher.GetTemperature(coordinates);
                if (temperature == null) return ResponseResult.Fail("獲取溫度資料失敗");

                return  ResponseResult.Ok(new WeatherResponse
                {
                    Success = true,
                    Administrative = data.Administrative,
                    Temperature = TemperatureFormatter.Format(temperature ?? 0)
                }, "成功取得天氣");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving temperature: {ex.Message}");
                return  ResponseResult.Fail("Exception:獲取溫度資料失敗");
            }
        }
    }
}
