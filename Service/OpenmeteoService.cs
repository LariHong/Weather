
using System.Text.Json;

namespace Weather.Service
{
    //Openmeteo 的服務實作
    public class OpenmeteoService
    {
        private HttpService _httpService;
        public OpenmeteoService(HttpService httpService)
        {
            _httpService = httpService;
        }
        // 獲取Openmeteo的目前溫度
        public async Task<double> GetCurrentTemperature()
        {

            var json = await _httpService.GetJson();

            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;
            var temperature = root.GetProperty("current")
                                    .GetProperty("temperature_2m");

            double current_temperature = temperature.GetDouble();

            return current_temperature;
        }
    }
}
