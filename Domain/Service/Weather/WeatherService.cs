using Weather.Appliction;
using Weather.Delegate;
using Weather.Infrastructure.Exceptions;
using Weather.Infrastructure.ExternalServices;
using Weather.Infrastructure.Helpers;
using Weather.Model;

namespace Weather.Domain.Service.Weather
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

        public async Task<WeatherResponse?> GetCurrentWeather(AdministrativeData data)
        {
            try
            {
                var coordinates = await _coordinateFetcher.GetCoordinates(data);
                if (coordinates == null) throw new CoordinateFetcherException("獲取座標資料失敗");

                var temperature = await _weatherFetcher.GetTemperature(coordinates);
                if (temperature == null) throw new WeatherFetcherException("獲取溫度資料失敗");

                return new WeatherResponse
                {
                    Success = true,
                    Administrative = data.Administrative,
                    Temperature = TemperatureFormatter.Format(temperature ?? 0)
                };
            }
            catch (CoordinateFetcherException)
            {
                throw;
            }
            catch (WeatherFetcherException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception:特殊失敗");
            }
        }
    }
}
