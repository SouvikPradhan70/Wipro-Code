using Microsoft.AspNetCore.Identity;

namespace ProductManagementApp.Models
{
    // Custom user model extending IdentityUser
    public class ApplicationUser : IdentityUser
    {
        public string Role { get; set; }
    }
}
