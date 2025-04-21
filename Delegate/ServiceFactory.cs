namespace Weather.Delegate
{
    public delegate TService ServiceFactory<TService, in TParam>(TParam param);
}
