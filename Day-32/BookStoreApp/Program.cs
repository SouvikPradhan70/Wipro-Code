using BookStoreApp;
using BookStoreApp.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using var db = new AppDbContext();

// 🔥 CLEAR the table first and reset identity
db.Books.RemoveRange(db.Books);
db.SaveChanges();
db.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Books', RESEED, 0)");
Console.WriteLine("🧹 Cleared old books and reset Ids!");


// 1. CREATE (Insert new books)
var newBook = new Book { Title = "C# Basics", Author = "Souvik", Price = 299 };
var newBook2 = new Book { Title = "C# Advanced", Author = "Souvik", Price = 399 };
db.Books.Add(newBook);
db.Books.Add(newBook2);
db.SaveChanges();
Console.WriteLine("✅ Books inserted!");

// 2. READ (Fetch all books)
Console.WriteLine("\n📚 All Books:");
foreach (var book in db.Books)
{
    Console.WriteLine($"{book.Id}: {book.Title} by {book.Author} - ₹{book.Price}");
}

// 3. UPDATE (Change book price)
var bookToUpdate = db.Books.FirstOrDefault(b => b.Title == "C# Basics");
if (bookToUpdate != null)
{
    bookToUpdate.Price = 350;
    db.SaveChanges();
    Console.WriteLine($"\n✏️ Updated price of '{bookToUpdate.Title}' to ₹{bookToUpdate.Price}");
}

// Show final list
Console.WriteLine("\n📚 Final Books List:");
foreach (var book in db.Books)
{
    Console.WriteLine($"{book.Id}: {book.Title} by {book.Author} - ₹{book.Price}");
}

// 4. DELETE (Remove book)
var bookToDelete = db.Books.FirstOrDefault(b => b.Title == "C# Basics");
if (bookToDelete != null)
{
    db.Books.Remove(bookToDelete);
    db.SaveChanges();
    Console.WriteLine($"\n🗑️ Deleted book '{bookToDelete.Title}'");
}

// Show final list
Console.WriteLine("\n📚 Final Books List:");
foreach (var book in db.Books)
{
    Console.WriteLine($"{book.Id}: {book.Title} by {book.Author} - ₹{book.Price}");
}
