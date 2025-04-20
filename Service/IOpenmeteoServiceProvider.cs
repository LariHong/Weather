namespace Weather.Service
{
    //自動注入的類別介面
    public interface IOpenmeteoServiceProvider
    {
        public OpenmeteoService Create(string url);
    }
}
