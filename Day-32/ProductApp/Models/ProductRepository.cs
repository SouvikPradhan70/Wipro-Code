using Microsoft.EntityFrameworkCore;
using ProductApp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductApp.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()=>await _context.Products.ToListAsync(); //select * from Products

        public async Task<Product> GetByIdAsync(int id) => await _context.Products.FindAsync(id); //select * from Products where Id = id

        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product); //Insert Into Products
            await _context.SaveChangesAsync(); //Commit to DB
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product); //Update Products SET
            await _context.SaveChangesAsync(); //Commit to DB
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product); //DELETE FROM Products WHERE Id = id
                await _context.SaveChangesAsync(); //Commit to DB
            }
        }
    }
}