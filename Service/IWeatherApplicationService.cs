namespace Weather.Service
{
    //服務IWeatherApplication
    public interface IWeatherApplicationService
    {
        public double Temperature { get; }
        public string FormatTemperature();
        public bool IsDangerous();
    }
}
