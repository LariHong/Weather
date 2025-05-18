using System.Text.Json;
using Weather.Domain.Service.Administrative;
using Weather.Infrastructure.Helpers;
using Weather.Model;

namespace Weather.Infrastructure.Administrative
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
            try
            {
                var json = await _httpService.GetApiResponseJson();

                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;
                var administrativeJson = root.GetProperty(country)
                                .GetProperty(city)
                                .GetProperty(administrative);

                double latitude = double.Parse(administrativeJson.GetProperty("latitude").GetString());
                double longitude = double.Parse(administrativeJson.GetProperty("longitude").GetString());

                return new Coordinates
                {
                    Latitude = latitude,
                    Longitude = longitude
                };
            }
            catch (JsonException ex)
            {
                // JSON 格式錯誤
                Console.WriteLine($"JSON parsing error: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                // 其他錯誤
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return null;
            }
        }
    }
}
