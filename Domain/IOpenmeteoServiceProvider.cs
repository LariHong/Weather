using Weather.Infrastructure;

namespace Weather.Domain
{
    //ServiceFactory 的抽象化實例介面
    public interface IOpenmeteoServiceProvider
    {
        public OpenmeteoService CreateProvider(HttpService httpService);
    }
}
