//adding data annotation for validation purpose
using System.ComponentModel.DataAnnotations;
namespace mvc_demo_1.Models
{
    public class Product
    {
        public int id { get; set; }

        [Required(ErrorMessage ="Name is required")]

        public string name { get; set; }

        [Range(0.01,10000.00,ErrorMessage="Price must be betweern 0.01 and 10000.00")]
        public decimal price { get; set; }
    }
}
