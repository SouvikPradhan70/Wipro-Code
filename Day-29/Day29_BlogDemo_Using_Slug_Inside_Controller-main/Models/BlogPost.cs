using Microsoft.AspNetCore.Routing;
namespace BlogDemo.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Slug { get; set; }// Url -friendly version of the title/Url
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}