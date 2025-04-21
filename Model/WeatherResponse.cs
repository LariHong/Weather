namespace Weather.Model
{
    public class WeatherResponse
    {
        public bool Success { get; set; }
        public double? Temperature { get; set; }
        public string? Message { get; set; }
    }
}
