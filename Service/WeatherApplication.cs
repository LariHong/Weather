
using Microsoft.AspNetCore.Mvc;
using Weather.Delegate;
using Weather.Domain;
using Weather.Infrastructure;
using Weather.Model;

namespace Weather.Service
{
    //天氣服務應用流程 
    public class WeatherApplication : IWeatherApplication
    {
        private readonly IWeatherService _weatherService;
        public WeatherApplication(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        public async Task<WeatherResponseResult<WeatherResponse>> ProcessWeatherRequest(AdministrativeData administrativeData)
        {
            try
            {
                var currentTemperature = await _weatherService.GetCurrentWeather(administrativeData);

                if (currentTemperature == null)
                {

                    return WeatherResponseResult<WeatherResponse>.Fail("天氣資訊錯誤");
                }
                //目前只有一個獲取值的簡單功能 因此不做DI
                IWeatherApplicationService weatherApplicationService = new WeatherApplicationService(currentTemperature??0);

                return WeatherResponseResult<WeatherResponse>.Ok(new WeatherResponse
                {
                    Success = true,
                    Administrative = administrativeData.Administrative,
                    Temperature = weatherApplicationService.FormatTemperature()
                }, "成功取得天氣");
            }
            catch (Exception ex)
            {
                return WeatherResponseResult<WeatherResponse>.Fail("exception錯誤");
            }
        }
    }
}
