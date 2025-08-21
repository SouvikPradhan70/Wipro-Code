using Microsoft.AspNetCore.Mvc;
using BlogDemo.Models;
namespace BlogDemo.Controllers;

public class ProductsController : Controller
{


    private readonly static List<Product> products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Wireless Mouse",
                Description = "Ergonomic wireless mouse with adjustable DPI",
                Slug = "wireless-mouse",
                Price = 1299.99m,
                CreatedAt = DateTime.Now.AddDays(-10)
            },
            new Product
            {
                Id = 2,
                Name = "Mechanical Keyboard",
                Description = "RGB backlit mechanical keyboard with blue switches",
                Slug = "mechanical-keyboard",
                Price = 4999.50m,
                CreatedAt = DateTime.Now.AddDays(-20)
            },
            new Product
            {

                Name = "Gaming Headset",
                Description = "Surround sound gaming headset with noise-cancelling mic",
                Slug = "gaming-headset",
                Price = 2999.00m,
                CreatedAt = DateTime.Now.AddDays(-5)
            },
            new Product
            {
                Id = 4,
                Name = "4K Monitor",
                Description = "27-inch 4K UHD monitor with HDR support",
                Slug = "4k-monitor",
                Price = 18999.00m,
                CreatedAt = DateTime.Now.AddDays(-15)
            },
            new Product
            {
                Id = 5,
                Name = "External SSD",
                Description = "1TB USB-C external solid state drive",
                Slug = "external-ssd-1tb",
                Price = 7999.99m,
                CreatedAt = DateTime.Now.AddDays(-2)
            }
        };

    [Route("products/{slug}")]
    public IActionResult Details(string slug)
    {
        var product = products.FirstOrDefault(p => p.Slug == slug);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }
}

