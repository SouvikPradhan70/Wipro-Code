using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorIntro.Pages
{
    public class TimeModel : PageModel
    {

        public string CurrentTime { get; set; } = "";
        public void OnGet()
        {
            CurrentTime = DateTime.Now.ToString("hh:mm:ss tt");

        }
    }
}
