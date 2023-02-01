using System.Net.Http.Headers;
using System.Text.Json.Nodes;

namespace Wheather
{
    public static class ConnectToWheatherApi
    {
        public static async Task<WheatherModel> GetWheather(string city)
        {
            var url = $"https://api.weatherapi.com/v1/current.json";
            var parameters = $"?key=ddcf041e48294f1f922192858231501&q={city}&aqi=no";
            var result = "";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(parameters);

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }

            WheatherModel wheather = new WheatherModel();
            try
            {
                JsonNode forecastNode = JsonNode.Parse(result)!;

                wheather = new WheatherModel
                {
                    nameOfTheCity = forecastNode["location"]!["name"]!.ToString(),
                    temp_c = forecastNode["current"]!["temp_c"]!.ToString(),
                    icon = forecastNode["current"]!["condition"]!["icon"]!.ToString(),
                    info = forecastNode["current"]!["condition"]!["text"]!.ToString(),
                    country = forecastNode["location"]!["country"]!.ToString(),
                };
            }
            catch (Exception ex) { }
            
            return wheather;
        }
    }
}
