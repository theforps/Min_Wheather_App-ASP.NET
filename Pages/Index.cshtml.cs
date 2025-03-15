using Microsoft.AspNetCore.Mvc.RazorPages;
using Weather.Pages.Models;
using Weather.Services;

namespace Weather.Pages;

public class IndexModel : PageModel
{
    private readonly IConnectApi _connectApi;
        
    public IndexModel(IConnectApi connectApi)
    {
        _connectApi = connectApi;
    }
    
    public WeatherInfo Weather = new();
    public string Search = "";

    public async Task OnGet()
    {
        string ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
        Weather = await _connectApi.GetWeather(ip);
    }

    public async Task OnPost(string Search) {
        Weather = await _connectApi.GetWeather(Search);
        
        
    }
}