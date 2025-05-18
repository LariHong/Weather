namespace Weather.Domain.Service.Openmeteo
{
    //OpenmeteoService介面
    public interface IOpenmeteoService
    {
        public Task<double?> GetCurrentTemperature();
    }
}
