using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Wheather.Pages
{
    public class IndexModel : PageModel
    {
        [Required]
        public string NameOfTheCity { get; set; }
        public string Degrees { get; set; }
        public string Weather { get; set; }
        public string ImgWeather { get; set; }

        public void OnGet()
        {
            NameOfTheCity = "Moscow";
        }

        public void OnPost() {
            
        }
    }
}