using Weather.Appliction;
using Weather.Model;

namespace Weather.Domain.Service
{
    //服務IWeatherApplication
    public interface IWeatherApplicationService
    {
        public Task<ResponseResult> GetCurrentWeatherResponse(AdministrativeData administrativeData);
    }
}
