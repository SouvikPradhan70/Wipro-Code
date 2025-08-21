using System.ComponentModel.DataAnnotations;

namespace FeedBackForm.Models
{
    public class Feedback
    {
        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Raiting should be in 1-5")]
        public int Rating { get; set; }

        [Required]
        public string Comment { get; set; }
    }
}
