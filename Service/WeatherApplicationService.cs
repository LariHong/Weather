
using Microsoft.AspNetCore.Mvc;
using Weather.Delegate;
using Weather.Infrastructure;
using Weather.Model;

namespace Weather.Service
{
    //天氣服務應用流程 
    public class WeatherApplicationService : IWeatherApplicationService
    {
        private readonly IWeatherService _weatherService;
        public WeatherApplicationService(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        public async Task<WeatherResponseResult<WeatherResponse>> ProcessWeatherRequest(AdministrativeData administrative_data)
        {
            try
            {
                var current_temperature = await _weatherService.GetCurrentWeather(administrative_data);

                if (current_temperature == null)
                {

                    return WeatherResponseResult<WeatherResponse>.Fail("天氣資訊錯誤");
                }

                var formattedTemperature = _weatherService.FormatTemperature(current_temperature.Value);

                return WeatherResponseResult<WeatherResponse>.Ok(new WeatherResponse
                {
                    Success = true,
                    Administrative = administrative_data.Administrative,
                    Temperature = formattedTemperature
                }, "成功取得天氣");
            }
            catch (Exception ex)
            {
                return WeatherResponseResult<WeatherResponse>.Fail("exception錯誤");
            }
        }
    }
}
