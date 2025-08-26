namespace BookStoreApp.Models
{
    public class Book
    {
        public int Id { get; set; } //primary key 
        public string? Title { get; set; }
        public string? Author { get; set; }
        public decimal Price { get; set; }
    }
}