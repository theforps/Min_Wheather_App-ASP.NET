using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Wheather.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string name { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;

            name = "Подольск";
        }

        public void OnGet()
        {
           
        }

        public void OnPost(string city) { 
            name = city;
        }
    }
}