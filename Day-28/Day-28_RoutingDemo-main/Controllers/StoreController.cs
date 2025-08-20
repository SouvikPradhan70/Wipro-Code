using Microsoft.AspNetCore.Mvc;

namespace RoutingDemo.Controllers
{
    [Route("shop")]
    public class StoreController : Controller
    {
        [HttpGet("")]
        [HttpGet("index")]
        public IActionResult Index()
        {

            ViewData["Message"] = "ornline store - implemtnted via routing";
            return View();

        }

        [HttpGet("category/{categoryName}")]
        public IActionResult ByCategory(string categoryName) {

            ViewData["Category"] = categoryName;
            ViewData["Message"] = "Products in category:" + categoryName;
            return View();
        
        }

        [HttpGet("product/{id:int}")]
        public IActionResult Productdetails(int id) {
            ViewData["ProductId"] = id;
            ViewData["Message"] = "Product medasage ";
            return View();
        }
    }
}