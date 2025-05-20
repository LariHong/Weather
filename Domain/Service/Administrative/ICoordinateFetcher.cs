using Weather.Model;

namespace Weather.Domain.Service.Administrative
{
    //獲取行政區資訊
    public interface ICoordinateFetcher
    {
        Task<Coordinates?> GetCoordinates(AdministrativeData data);
    }
}
