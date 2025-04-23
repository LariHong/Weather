namespace Weather.Infrastructure
{
    public static class TemperatureFormatter
    {
        public static string Format(double temperature) => temperature.ToString("0.0");

    }
}
