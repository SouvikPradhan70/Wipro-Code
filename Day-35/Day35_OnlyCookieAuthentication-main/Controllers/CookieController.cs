// here we will define a simple cookie based authentication
// we will use a simple string and try to set it as a cookie

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace OnlyCookieAuthentication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CookieController : Controller
    {
        // action to set a cookie
        [HttpPost]
        public IActionResult SetCookie()
        {
            // set a simple cookie
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(30);
            Response.Cookies.Append("MyCookie", "This is my first cookie", option);
            return Content("Cookie has been set");
        }

        // action to get a cookie
        [HttpGet]
        public IActionResult GetCookie()
        {
            // get the cookie value
            var cookieValue = Request.Cookies["MyCookie"];
            if (cookieValue != null)
            {
                return Content($"Cookie Value: {cookieValue}");
            }
            else
            {
                return Content("Cookie not found");
            }
        }

        // action to delete a cookie
        [HttpDelete]
        public IActionResult DeleteCookie()
        {
            Response.Cookies.Delete("MyCookie");
            return Content("Cookie has been deleted");
        }
    }
}