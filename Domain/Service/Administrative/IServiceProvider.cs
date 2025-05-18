using Weather.Infrastructure.Helpers;

namespace Weather.Domain.Service.Administrative
{
    //泛型的IServiceProvider
    public interface IServiceProvider<TService>
    {
        public HttpService CreateHttpService(string url);
        public TService CreateProvider(HttpService httpService);
    }
}
