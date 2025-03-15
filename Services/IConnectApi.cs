using Weather.Pages.Models;

namespace Weather.Services;

public interface IConnectApi
{
    Task<WeatherInfo> GetWeather(string city);
    
    
}