using Weather.Service;

namespace Weather.Domain
{
    //應用層的實作
    public class WeatherApplicationService : IWeatherApplicationService
    {
        public double Temperature { get; private set; }

        public WeatherApplicationService(double temperature) 
        {
            Temperature = temperature;
        }
        public string FormatTemperature()
        {
            return Temperature.ToString("0.0");
        }

        public bool IsDangerous()
        {
            throw new NotImplementedException();
        }
    }
}
