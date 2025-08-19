using Microsoft.AspNetCore.Mvc;
using mvc_demo_1.Models;

public class ProductsController : Controller
{
    // static list shared across requests
    private static List<Product> products = new List<Product>
    {
        new Product { id = 1, name = "Laptop", price = 999.00M },
        new Product { id = 2, name = "Mouse", price = 250.00M },
        new Product { id = 3, name = "Printer", price = 550.00M }
    };

    public IActionResult Index()
    {
        return View(products);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        if (ModelState.IsValid)
        {
            products.Add(product); // ✅ now it adds to list
            return RedirectToAction("Index");
        }
        return View(product);
    }
}
