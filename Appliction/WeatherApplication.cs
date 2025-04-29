
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
        public async Task<ResponseResult> ProcessWeatherRequest(AdministrativeData administrativeData)
        {
            try
            {
                var currentTemperatureResponseResult = await _weatherApplicationService.GetCurrentWeatherResponse(administrativeData);

                if (currentTemperatureResponseResult == null)
                {

                    return ResponseResult.Fail("天氣資訊錯誤");
                }

                return currentTemperatureResponseResult;
            }
            catch (Exception ex)
            {
                return ResponseResult.Fail("exception錯誤");
            }
        }
    }
}
