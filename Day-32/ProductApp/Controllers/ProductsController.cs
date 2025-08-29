using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;
using System.Threading.Tasks;

namespace ProductApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _repo;

        // Inject repository into controller
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        // Show all products
        public async Task<IActionResult> Index()
        {
            var products = await _repo.GetAllAsync();
            return View(products); // Pass data to Index.cshtml
        }

        // AJAX method → returns only partial view (small piece of HTML)
        public async Task<IActionResult> GetAll()
        {
            var products = await _repo.GetAllAsync();
            return PartialView("_ProductList", products); // Load into page dynamically
        }
    }
}
