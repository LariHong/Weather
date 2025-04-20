using Microsoft.AspNetCore.Routing;
using System.Text.Json;

namespace Weather.Service
{
    //行政區服務的實作
    public class AdministrativeService : IAdministrativeService
    {
        private readonly HttpClient _httpClient;
        public AdministrativeService(HttpClient httpClient)
        { 
            _httpClient = httpClient;
        }
        //獲取行政區的座標資料
        public async Task<Model.Coordinates> GetCoordinates(string country="台灣",string city= "新北市",string administrative= "蘆洲區")
        {
            string url = "https://gist.githubusercontent.com/memochou1993/aa9b6b1185221f88a03109f10d32e5e2/raw/769f8a84474621533194be07d7f40d1d75c09324/%25E5%258F%25B0%25E7%2581%25A3%25E8%25A1%258C%25E6%2594%25BF%25E5%258D%2580%25E5%2588%2597%25E8%25A1%25A8.json";

            var httpService = new HttpService(url, _httpClient);

            var json = await httpService.GetJson();

            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;
            var administrative_json = root.GetProperty(country)
                            .GetProperty(city)
                            .GetProperty(administrative);

            double latitude = double.Parse(administrative_json.GetProperty("latitude").GetString());
            double longitude = double.Parse(administrative_json.GetProperty("longitude").GetString());

            return new Model.Coordinates 
            {
                Latitude = latitude,
                Longitude = longitude
            };
}
    }
}
