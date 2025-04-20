using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Text.Json;
using Weather.Model;
using Weather.Service;

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
        private readonly IWeatherApplicationService _weatherApplicationService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger ,IWeatherApplicationService weatherApplicationService)
        {
            _logger = logger;
            _weatherApplicationService = weatherApplicationService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<Double> GetWeather()
        {
            var administrative_data = new AdministrativeData
            {
                Country = "台灣",
                City = "新北市",
                Administrative = "蘆洲區"
            };

            var current_temperature = await _weatherApplicationService.GetCurrentWeather(administrative_data);

            return current_temperature;
        }

        [HttpPost("WeatherForecast/post")]
        public async Task<Double> GetWeather2([FromBody] AdministrativeData administrative_data)
        {

            var current_temperature = await _weatherApplicationService.GetCurrentWeather(administrative_data);

            return current_temperature;
        }
    }
}
