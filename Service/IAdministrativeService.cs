using Weather.Model;

namespace Weather.Service
{
    public interface IAdministrativeService
    {
        public Task<Coordinates> GetCoordinates(string country, string city, string administrative);
    }
}
