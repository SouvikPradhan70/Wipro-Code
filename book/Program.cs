using System;

namespace book
{
    internal class Program
    {
        public class Book
        {
            public string Title{get;set;}
            public string Author{get;set;}
            public int Year{get;set;}
            
            public Book(string title, string author, int year)
            {
                Title = title;
                Author = author;
                Year = year;
            }
            
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter book's title:");
            string bName = Console.ReadLine();
            Console.WriteLine("Enter book's author:");
            string aName = Console.ReadLine();
            Console.WriteLine("Enter book's year:");
            int year = Convert.ToInt32(Console.ReadLine());

            Book book = new Book(bName, aName, year);
            Console.WriteLine($"Book Title:{book.Title}");
            Console.WriteLine($"Book Author:{book.Author}");
            Console.WriteLine($"Book Year:{book.Year}");

        }
    }
}
