using Weather.Infrastructure;

namespace Weather.Service
{
    //ServiceFactory 的抽象化實例介面
    public interface IOpenmeteoServiceProvider
    {
        public OpenmeteoService Create(string url);
    }
}
