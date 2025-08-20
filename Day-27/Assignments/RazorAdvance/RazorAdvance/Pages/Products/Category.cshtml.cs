using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAdvance.Data;
using RazorAdvance.Models;

namespace RazorAdvance.Pages.Products
{
    public class CategoryModel : PageModel
    {
        private readonly IProductRepository _repo;
        public CategoryModel(IProductRepository repo) => _repo = repo;

        public string CategoryName { get; set; } = string.Empty;
        public List<Product> Products { get; set; } = new();

        public void OnGet(string categoryName)
        {
            CategoryName = categoryName;
            Products = _repo.GetByCategory(categoryName).ToList();
        }
    }
}
