using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Text.Json;
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
        private readonly IAdministrativeService _administrativeService;
        private readonly IOpenmeteoServiceProvider _openmeteoServiceProvider;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IAdministrativeService administrativeService, IOpenmeteoServiceProvider openmeteoServiceProvider)
        {
            _logger = logger;
            _administrativeService = administrativeService;
            _openmeteoServiceProvider = openmeteoServiceProvider;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<Double> Get()
        {
            var Coordinates = await _administrativeService.GetCoordinates("台灣", "新北市",  "蘆洲區");

            var url = $"https://api.open-meteo.com/v1/forecast?latitude={Coordinates.Latitude}&longitude={Coordinates.Longitude}&current=temperature_2m";

            var provider = _openmeteoServiceProvider.Create(url);
            var current_temperature = await provider.GetCurrentTemperature();

            return current_temperature;
        }
    }
}
