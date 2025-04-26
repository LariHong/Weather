namespace Weather.Appliction
{
    //自定義result
    public class ResponseResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }

        public static ResponseResult Ok(object data, string? message = null) =>
            new() { Success = true, Message = message, Data = data };

        public static ResponseResult Fail(string message) =>
            new() { Success = false, Message = message, Data = default };
    }
}
