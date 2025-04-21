namespace Weather.Service
{
    public interface IServiceProvider<TService>
    {
        public TService Create();
    }

    public interface IServiceProvider<TService, TParam>
    {
        public TService Create(TParam param);
    }
}
