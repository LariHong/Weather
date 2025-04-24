namespace Weather.Delegate
{
    public delegate TService HttpClientFactory<TService, in TParam>(TParam param);
}
