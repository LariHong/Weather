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

        public async Task<double?> GetCurrentWeather(AdministrativeData data)
        {
            try
            {
                var coordinates = await _coordinateFetcher.GetCoordinates(data);
                if (coordinates == null) return null;

                var temperature = await _weatherFetcher.GetTemperature(coordinates);
                return temperature;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving temperature: {ex.Message}");
                return null;
            }
        }
    }
}
