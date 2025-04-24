using Weather.Infrastructure;

namespace Weather.Domain
{
    //泛型的IServiceProvider
    public interface IServiceProvider<TService>
    {
        public HttpService CreateHttpService(string url);
        public TService CreateProvider(HttpService httpService);
    }
}
