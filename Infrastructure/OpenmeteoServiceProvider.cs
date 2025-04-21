using Weather.Delegate;
using Weather.Service;

namespace Weather.Infrastructure
{
    // //ServiceFactory 的抽象化實例介面實作
    public class OpenmeteoServiceProvider : IOpenmeteoServiceProvider
    {
        private readonly ServiceFactory<OpenmeteoService,string> _serviceFactory;
        public OpenmeteoServiceProvider(ServiceFactory<OpenmeteoService, string> serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }
        //目前沒有用到
        public OpenmeteoService Create(string url)
        {
            return _serviceFactory(url);
        }
    }
}
