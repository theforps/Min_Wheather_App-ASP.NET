using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Wheather.Pages
{
    public class IndexModel : PageModel
    {
        [Required]
        public string Name { get; set; }


        public IndexModel()
        {
            Name = "Moscow";
        }



        public void OnGet()
        {

        }

        public void OnPost() {
            
        }
    }
}