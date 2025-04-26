using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Text.Json;
using Weather.Appliction;
using Weather.Model;

namespace Weather_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherApplication _weatherApplication;

        public WeatherForecastController(ILogger<WeatherForecastController> logger ,IWeatherApplication weatherApplication)
        {
            _logger = logger;
            _weatherApplication = weatherApplication;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ActionResult<ResponseResult>> GetWeather()
        {
            var administrative_data = new AdministrativeData
            {
                Country = "台灣",
                City = "新北市",
                Administrative = "蘆洲區"
            };

            var response = await _weatherApplication.ProcessWeatherRequest(administrative_data);

            if (!response.Success) return NotFound(response);

            return Ok(response);
        }

        [HttpPost("post")]
        public async Task<ActionResult<ResponseResult>> PostWeather([FromBody] AdministrativeData administrativeData)
        {
            var response = await _weatherApplication.ProcessWeatherRequest(administrativeData);

            if (!response.Success) return NotFound(response);

            return Ok(response);
        }
    }
}
