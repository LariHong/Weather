namespace Weather.Service
{
    public interface IAdministrativeService
    {
        public Task<Model.Coordinates> GetCoordinates(string country , string city, string administrative);
    }
}
