namespace BlogDemo.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; } // Url-friendly version of the name/Url    
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}