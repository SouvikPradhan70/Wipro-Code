using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAdvance.Data;
using RazorAdvance.Models;

namespace RazorAdvance.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _repo;

        public IndexModel(IProductRepository repo) => _repo = repo;

        public List<Product> Products { get; set; } = new();

        [BindProperty]
        public Product Input { get; set; } = new()
        {
            Categories = new List<Category> { new(), new(), new() }
        };

        public void OnGet()
        {
            Products = _repo.GetAll().ToList();
        }

        public IActionResult OnPostAdd()
        {
            if (!ModelState.IsValid) { OnGet(); return Page(); }

            Input.Categories = Input.Categories
                .Where(c => c != null && !string.IsNullOrWhiteSpace(c.Name))
                .Select(c => new Category { Name = c.Name.Trim() })
                .ToList();

            _repo.Add(Input);
            return RedirectToPage("/Products/Index");
        }
    }
}
