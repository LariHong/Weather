using Weather.Delegate;
using Weather.Domain.Service.Openmeteo;
using Weather.Infrastructure.Helpers;

namespace Weather.Infrastructure.Openmeteo
{
    // //ServiceFactory 的抽象化實例介面實作
    public class OpenmeteoServiceProvider : IOpenmeteoServiceProvider
    {
        public OpenmeteoServiceProvider()
        {

        }
        public OpenmeteoService CreateProvider(HttpService httpService)
        {
            return new OpenmeteoService(httpService);
        }
    }
}
