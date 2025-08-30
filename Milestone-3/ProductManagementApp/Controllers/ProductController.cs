using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagementApp.Data;
using ProductManagementApp.Models;
using System.Linq;

namespace ProductManagementApp.Controllers
{
    [Authorize] // Only logged-in users can access
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Product List
        public IActionResult ProductList()
        {
            return View(_context.Products.ToList());
        }

        // Create (Admin only)
        [Authorize(Roles = "Admin")]
        public IActionResult CreateProduct() => View();

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                TempData["Message"] = $"Product \"{product.Name}\" has been successfully created!";
                return RedirectToAction("ProductList");
            }
            return View(product);
        }

        // Edit (Admin + Manager)
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult EditProduct(int id)
        {
            var product = _context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ValidateAntiForgeryToken]
        public IActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                TempData["Message"] = $"Product \"{product.Name}\" has been successfully updated!";
                return RedirectToAction("ProductList");
            }
            return View(product);
        }

        // Delete (Admin only)
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                TempData["Message"] = $"Product \"{product.Name}\" has been successfully deleted!";
            }
            return RedirectToAction("ProductList");
        }
    }
}
