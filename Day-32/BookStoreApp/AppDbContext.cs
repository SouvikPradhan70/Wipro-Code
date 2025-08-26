using Microsoft.EntityFrameworkCore;
using BookStoreApp.Models;

namespace BookStoreApp
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=HUNNY;Database=BookStoreDB;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}