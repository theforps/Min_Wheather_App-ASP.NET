using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Wheather.Pages
{
    public class IndexModel : PageModel
    {

        public string name = "";
        public WheatherModel wheather = new WheatherModel();

        public void OnGet()
        {
            string ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            wheather = ConnectToWheatherApi.GetWheather(ip).GetAwaiter().GetResult();
        }

        public void OnPost(string name) {
            wheather = ConnectToWheatherApi.GetWheather(name).GetAwaiter().GetResult();

            if (wheather.nameOfTheCity == null)
            {
                name = "";
            }
            else
            {
                name = wheather.nameOfTheCity;
            }
        }
    }
}