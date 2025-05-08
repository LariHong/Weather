namespace Weather.Infrastructure.Exceptions
{
    public class CoordinateFetcherException:Exception
    {
        public CoordinateFetcherException(string message) : base(message) { }
    }

    public class WeatherFetcherException : Exception
    {
        public WeatherFetcherException(string message) : base(message) { }
    }
}
