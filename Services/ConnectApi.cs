using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;
using Weather.Pages.Models;

namespace Weather.Services;

public class ConnectApi : IConnectApi
{
    private readonly IConfiguration _configuration;
        
    public ConnectApi(IConfiguration configuration)
    {
        _configuration = configuration;
    }
        
    public async Task<WeatherInfo> GetWeather(string info)
    {
        var url = _configuration.GetSection("WeatherApi")["Url"];
        var apiKey = _configuration.GetSection("WeatherApi")["Key"];
            
        var parameters = $"?key={apiKey}&q={info}&aqi=no";
        var result = "";

        var client = new HttpClient();
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await client.GetAsync(parameters);

        if (response.IsSuccessStatusCode)
        {
            result = await response.Content.ReadAsStringAsync();
        }

        var weather = new WeatherInfo();
        
        try
        {
            JsonNode forecastNode = JsonNode.Parse(result)!;

            weather = new WeatherInfo
            {
                City = forecastNode["location"]!["name"]!.ToString(),
                Temp = forecastNode["current"]!["temp_c"]!.ToString(),
                Icon = forecastNode["current"]!["condition"]!["icon"]!.ToString(),
                Info = forecastNode["current"]!["condition"]!["text"]!.ToString(),
                Country = forecastNode["location"]!["country"]!.ToString(),
            };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
            
        return weather;
    }
}