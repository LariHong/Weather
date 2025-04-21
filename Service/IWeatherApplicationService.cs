using Microsoft.AspNetCore.Mvc;
using Weather.Model;

namespace Weather.Service
{
    //天氣應用介面
    public interface IWeatherApplicationService
    {

        Task<WeatherResponseResult<WeatherResponse>> ProcessWeatherRequest(AdministrativeData administrative_data);
    }
}
