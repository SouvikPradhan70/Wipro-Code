using Microsoft.AspNetCore.Mvc;

namespace ASPDotNETCoreHello.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
