using Microsoft.AspNetCore.Mvc;
using Weather.Model;

namespace Weather.Service
{
    //天氣應用介面
    public interface IWeatherApplication
    {

        Task<WeatherResponseResult<WeatherResponse>> ProcessWeatherRequest(AdministrativeData administrativeData);
    }
}
