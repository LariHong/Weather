using Weather.Model;

namespace Weather.Infrastructure
{
    //獲取行政區資訊
    public interface ICoordinateFetcher
    {
        Task<Coordinates?> GetCoordinates(AdministrativeData data);
    }
}
