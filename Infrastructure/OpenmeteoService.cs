using System.Text.Json;
using Weather.Service;

namespace Weather.Infrastructure
{
    // IOpenmeteoService實作
    public class OpenmeteoService : IOpenmeteoService
    {
        private readonly HttpService _httpService;
        public OpenmeteoService(HttpService httpService) 
        {
            _httpService = httpService;
        }
        //獲取目前氣溫
        public async Task<double?> GetCurrentTemperature()
        {
            try
            {
                var json = await _httpService.GetJson();

                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;
                var temperature = root.GetProperty("current")
                                        .GetProperty("temperature_2m");

                double currentTemperature = temperature.GetDouble();

                return currentTemperature;
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
