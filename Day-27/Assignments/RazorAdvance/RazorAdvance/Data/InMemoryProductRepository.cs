using System.Collections.Generic;
using System.Linq;
using RazorAdvance.Models;

namespace RazorAdvance.Data
{
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new();
        private int _nextId = 1;

        public InMemoryProductRepository()
        {
            // seed one product
            Add(new Product
            {
                Name = "Sample Phone",
                Description = "Entry-level smartphone",
                Categories = new List<Category>
                {
                    new Category { Name = "Electronics" },
                    new Category { Name = "Mobile" }
                }
            });
        }

        public IEnumerable<Product> GetAll() => _products.OrderBy(p => p.ProductID);

        public Product? GetById(int id) => _products.FirstOrDefault(p => p.ProductID == id);

        public IEnumerable<Product> GetByCategory(string categoryName) =>
            _products.Where(p => p.Categories.Any(c => c.Name.Equals(categoryName, System.StringComparison.OrdinalIgnoreCase)));

        public void Add(Product product)
        {
            product.ProductID = _nextId++;
            _products.Add(product);
        }
    }
}
