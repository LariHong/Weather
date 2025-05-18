using Weather.Infrastructure.Openmeteo;
using Weather.Infrastructure.Helpers;

namespace Weather.Domain.Service.Openmeteo
{
    //ServiceFactory 的抽象化實例介面
    public interface IOpenmeteoServiceProvider
    {
        public OpenmeteoService CreateProvider(HttpService httpService);
    }
}
