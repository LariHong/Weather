using System.Text.Json;
using Weather.Model;
using Weather.Service;

namespace Weather.Infrastructure
{
    // IAdministrativeService實作
    public class AdministrativeService : IAdministrativeService
    {
        private readonly HttpService _httpService;
        public AdministrativeService(HttpService httpService)
        {
            _httpService = httpService;
        }
        //獲取行政區座標
        public async Task<Coordinates> GetCoordinates(string country, string city, string administrative)
        {
            var json = await _httpService.GetJson();

            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;
            var administrative_json = root.GetProperty(country)
                            .GetProperty(city)
                            .GetProperty(administrative);

            double latitude = double.Parse(administrative_json.GetProperty("latitude").GetString());
            double longitude = double.Parse(administrative_json.GetProperty("longitude").GetString());

            return new Coordinates
            {
                Latitude = latitude,
                Longitude = longitude
            };
        }
    }
}
