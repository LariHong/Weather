using Weather.Delegate;
using Weather.Domain;

namespace Weather.Infrastructure
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
