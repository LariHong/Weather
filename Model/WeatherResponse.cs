namespace Weather.Model
{
    //WeatherResponse 資料
    public class WeatherResponse
    {
        public bool Success { get; set; }
        public string? Temperature { get; set; }
        public string? Administrative { get; set; }
    }
}
