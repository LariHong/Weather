
using Microsoft.AspNetCore.Mvc;
using Weather.Appliction.WeatherService;
using Weather.Delegate;
using Weather.Infrastructure.Exceptions;
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

                return ResponseResult.Ok(currentTemperatureResponseResult,"成功取得天氣資訊");
            }
            catch (CoordinateFetcherException ex)
            {
                return ResponseResult.Fail(ex.Message);
            }
            catch (WeatherFetcherException ex)
            {
                return ResponseResult.Fail(ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseResult.Fail(ex.Message);
            }
        }
    }
}
