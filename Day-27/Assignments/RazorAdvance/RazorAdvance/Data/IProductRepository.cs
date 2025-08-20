using System.Collections.Generic;
using RazorAdvance.Models;

namespace RazorAdvance.Data
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
        IEnumerable<Product> GetByCategory(string categoryName);
        void Add(Product product);
    }
}
