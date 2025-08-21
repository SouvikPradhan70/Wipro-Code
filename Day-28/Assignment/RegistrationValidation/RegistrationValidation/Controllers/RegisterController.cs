using Microsoft.AspNetCore.Mvc;
using RegistrationValidation.Models;

namespace RegistrationValidation.Controllers
{
    public class RegisterController : Controller
    {
        // Show empty form (GET)
        public IActionResult Register()
        {
            return View();
        }

        // Handle form submission (POST)
        [HttpPost]
        public IActionResult Register(UserRegistration user)
        {
            if (ModelState.IsValid)
            {
                // Normally we would save user to database
                // For assignment, just show success page
                return RedirectToAction("Success");
            }
            return View(user);
        }

        // Success page
        public IActionResult Success()
        {
            return View();
        }
    }
}
