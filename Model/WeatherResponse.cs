namespace Weather.Model
{
    //WeatherResponse 資料
    public class WeatherResponse
    {
        public bool Success { get; set; }
        public double? Temperature { get; set; }
        public string? Message { get; set; }
    }
}
