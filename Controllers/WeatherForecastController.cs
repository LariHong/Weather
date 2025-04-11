using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Weather_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<Double> Get()
        {
            var url2 = "https://gist.githubusercontent.com/memochou1993/aa9b6b1185221f88a03109f10d32e5e2/raw/769f8a84474621533194be07d7f40d1d75c09324/%25E5%258F%25B0%25E7%2581%25A3%25E8%25A1%258C%25E6%2594%25BF%25E5%258D%2580%25E5%2588%2597%25E8%25A1%25A8.json";
            using var client2 = new HttpClient();
            var response2 = await client2.GetAsync(url2);
            response2.EnsureSuccessStatusCode();

            var json2 = await response2.Content.ReadAsStringAsync();

            using var doc2 = JsonDocument.Parse(json2);
            var root2 = doc2.RootElement;
            var administrative = root2.GetProperty("台灣")
                                    .GetProperty("新北市")
                                    .GetProperty("蘆洲區");

            double latitude = double.Parse(administrative.GetProperty("latitude").GetString());
            double longitude = double.Parse(administrative.GetProperty("longitude").GetString());


            var url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current=temperature_2m";
            
            
            using var client = new HttpClient();
            var response =await client.GetAsync(url) ;
            response.EnsureSuccessStatusCode();

            
            var json = await response.Content.ReadAsStringAsync() ;

            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;
            var temperature = root.GetProperty("current")
                                    .GetProperty("temperature_2m");

            double current_temperature = temperature.GetDouble();

            Console.WriteLine(current_temperature);

            return current_temperature;
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}
