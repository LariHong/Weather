using Weather.Model;

namespace Weather.Domain.Service.Administrative
{
    //IAdministrativeService介面
    public interface IAdministrativeService
    {
        public Task<Coordinates> GetCoordinates(string country, string city, string administrative);
    }
}
