using System.Net.Http.Headers;
using System.Text.Json.Nodes;

namespace Wheather
{
    public class DataObject
    {
        public string Name { get; set; }
    }

    public class ConnectToApi
    {
        public static string city;
        public static string URL = $"https://api.weatherapi.com/v1/current.json?key=ddcf041e48294f1f922192858231501&q={city}&aqi=no";
        static readonly HttpClient client = new HttpClient();

        static async Task Test(string name)
        {
            city = name;

            using HttpResponseMessage response = await client.GetAsync(URL);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            JsonNode forecastNode = JsonNode.Parse(responseBody)!;
            


            //int hotHigh = forecastNode["TemperatureRanges"]!["Hot"]!["High"]!.GetValue<int>();
            Console.WriteLine($"Hot.High={forecastNode.ToJsonString()}");
        }
    }
}
