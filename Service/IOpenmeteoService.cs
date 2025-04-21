namespace Weather.Service
{
    //OpenmeteoService介面
    public interface IOpenmeteoService
    {
        public Task<double?> GetCurrentTemperature();
    }
}
