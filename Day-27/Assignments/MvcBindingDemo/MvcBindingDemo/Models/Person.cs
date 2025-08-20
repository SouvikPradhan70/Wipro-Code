using System.ComponentModel.DataAnnotations;

namespace MvcBindingDemo.Models
{
    public class Person
    {
        [Required] public string FirstName { get; set; } = string.Empty;
        [Required] public string LastName { get; set; } = string.Empty;
        [Range(0, 130)] public int Age { get; set; }
        [Required] public Address Address { get; set; } = new();
    }
}
