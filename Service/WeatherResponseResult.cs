namespace Weather.Service
{
    public class WeatherResponseResult<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public static WeatherResponseResult<T> Ok(T data, string? message = null) =>
            new() { Success = true, Message = message, Data = data };

        public static WeatherResponseResult<T> Fail(string message) =>
            new() { Success = false, Message = message, Data = default };
    }
}
