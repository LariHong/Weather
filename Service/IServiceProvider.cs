namespace Weather.Service
{
    //泛型的IServiceProvider
    public interface IServiceProvider<TService>
    {
        public TService Create();
    }
}
