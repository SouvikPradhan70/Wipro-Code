using System.Collections.Generic;
using System.Threading.Tasks;
namespace ProductApp.Models
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync(); // get all products
        Task<Product> GetByIdAsync(int id); // get product by id
        Task AddAsync(Product product); // add a new product
        Task UpdateAsync(Product product); // update an existing product
        Task DeleteAsync(int id); // delete a product by id
    }
}