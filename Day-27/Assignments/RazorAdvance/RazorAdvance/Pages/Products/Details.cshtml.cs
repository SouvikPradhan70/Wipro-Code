using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAdvance.Data;
using RazorAdvance.Models;

namespace RazorAdvance.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly IProductRepository _repo;
        public DetailsModel(IProductRepository repo) => _repo = repo;

        public Product? Product { get; set; }

        public IActionResult OnGet(int id)
        {
            Product = _repo.GetById(id);
            return Product == null ? NotFound() : Page();
        }
    }
}
