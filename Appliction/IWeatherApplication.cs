using Microsoft.AspNetCore.Mvc;
using Weather.Model;

namespace Weather.Appliction
{
    //天氣應用介面
    public interface IWeatherApplication
    {

        Task<ResponseResult> ProcessWeatherRequest(AdministrativeData administrativeData);
    }
}
