using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Models
{
    public class Book
    {
        public int Id { get; set; }   // Unique Id
        public string Title { get; set; }   // Book Title
        public string Author { get; set; }  // Author Name
        public string Genre { get; set; }   // Genre (Fiction, Tech, etc.)
        public DateTime PublishedDate { get; set; }  // Published Date
        public decimal Price { get; set; }  // Book Price
    }
}


