
using Microsoft.AspNetCore.Mvc;
using Weather.Delegate;
using Weather.Domain.Service;
using Weather.Infrastructure;
using Weather.Model;

namespace Weather.Appliction
{
    //天氣服務應用流程 
    public class WeatherApplication : IWeatherApplication
    {
        private readonly IWeatherApplicationService _weatherApplicationService;

        public WeatherApplication(IWeatherApplicationService weatherApplicationService)
        {
            _weatherApplicationService = weatherApplicationService;
        }
        public async Task<WeatherResponseResult<WeatherResponse>> ProcessWeatherRequest(AdministrativeData administrativeData)
        {
            try
            {
                var currentTemperature = await _weatherApplicationService.GetWeatherResponse(administrativeData);

                if (currentTemperature == null)
                {

                    return WeatherResponseResult<WeatherResponse>.Fail("天氣資訊錯誤");
                }

                return WeatherResponseResult<WeatherResponse>.Ok(new WeatherResponse
                {
                    Success = true,
                    Administrative = administrativeData.Administrative,
                    Temperature = TemperatureFormatter.Format(currentTemperature ?? 0)
                }, "成功取得天氣");
            }
            catch (Exception ex)
            {
                return WeatherResponseResult<WeatherResponse>.Fail("exception錯誤");
            }
        }
    }
}
