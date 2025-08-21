using System.ComponentModel.DataAnnotations;
namespace RegistrationValidation.Models
{
    public class UserRegistration
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be 3-20 characters long")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
