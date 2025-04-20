using Weather.Infrastructure;

namespace Weather.Service
{
    // OpenmeteoServiceProvider自動注入介面
    public interface IOpenmeteoServiceProvider
    {
        public OpenmeteoService Create(string url);
    }
}
