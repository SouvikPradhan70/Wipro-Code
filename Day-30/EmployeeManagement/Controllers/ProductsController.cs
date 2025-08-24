using EmployeeManagement.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace EmployeeManagement.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IMemoryCache _cache;

        public ProductsController(IMemoryCache cache)
        {
            _cache = cache;
        }

        [ServiceFilter(typeof(ProductCacheResultFilter))]
        public IActionResult List()
        {
            var products = new List<string> { "Laptop", "Mobile", "Tablet" };
            return Json(products);
        }

        public IActionResult CacheStatus()
        {
            if (_cache.TryGetValue("AllKeys", out List<string> keys))
            {
                return Json(new { CachedKeys = keys });
            }
            else
            {
                return Json(new { CachedKeys = new string[] { } });
            }
        }
    }
}
