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
        public async Task<ActionResult<WeatherResponse>> GetWeather()
        {
            var administrative_data = new AdministrativeData
            {
                Country = "�x�W",
                City = "�s�_��",
                Administrative = "Ī�w��"
            };

            var current_temperature = await _weatherApplicationService.GetCurrentWeather(administrative_data);

            if (current_temperature == null)
            {
                return Ok(new WeatherResponse
                {
                    Success = false,
                    Temperature = null,
                    Message = "�L�k���o�Ѯ���"
                });
            }

            return Ok(new WeatherResponse
            {
                Success = true,
                Temperature = current_temperature,
                Message = "���\���o�Ѯ�"
            });
        }

        [HttpPost("post")]
        public async Task<ActionResult<WeatherResponse>> GetWeather2([FromBody] AdministrativeData administrative_data)
        {

            var current_temperature = await _weatherApplicationService.GetCurrentWeather(administrative_data);

            if (current_temperature == null)
            {
                return Ok(new WeatherResponse
                {
                    Success = false,
                    Temperature = null,
                    Message = "�L�k���o�Ѯ���"
                });
            }

            return Ok(new WeatherResponse
            {
                Success = true,
                Temperature = current_temperature,
                Message = "���\���o�Ѯ�"
            });
        }
    }
}
