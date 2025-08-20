using Microsoft.AspNetCore.Mvc;
using MvcBindingDemo.Models;

namespace MvcBindingDemo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index() => View(new Person());

        [HttpPost]
        public IActionResult Index(Person model)
        {
            if (!ModelState.IsValid) return View(model);
            return View("Result", model);
        }
    }
}
