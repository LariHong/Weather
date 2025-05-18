namespace Weather.Infrastructure.Helpers
{
    public static class TemperatureFormatter
    {
        public static string Format(double temperature) => temperature.ToString("0.0");

    }
}
