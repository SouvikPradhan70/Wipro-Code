using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    // Book class
    public class Book
    {
        public string Title { get; }
        public string Author { get; }
        public string ISBN { get; }
        public bool IsBorrowed { get; private set; }

        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            IsBorrowed = false;
        }

        public void Borrow()
        {
            IsBorrowed = true;
        }

        public void Return()
        {
            IsBorrowed = false;
        }
    }

    // Borrower class
    public class Borrower
    {
        public string Name { get; }
        public string LibraryCardNumber { get; }
        public List<Book> BorrowedBooks { get; }

        public Borrower(string name, string cardNumber)
        {
            Name = name;
            LibraryCardNumber = cardNumber;
            BorrowedBooks = new List<Book>();
        }

        public void BorrowBook(Book book)
        {
            book.Borrow();
            BorrowedBooks.Add(book);
        }

        public void ReturnBook(Book book)
        {
            book.Return();
            BorrowedBooks.Remove(book);
        }
    }

    // Library class
    public class Library
    {
        public List<Book> Books { get; }
        public List<Borrower> Borrowers { get; }

        public Library()
        {
            Books = new List<Book>();
            Borrowers = new List<Borrower>();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
            Console.WriteLine("Book added successfully.");
        }

        public void RegisterBorrower(Borrower borrower)
        {
            Borrowers.Add(borrower);
            Console.WriteLine("Borrower registered successfully.");
        }

        public void BorrowBook(string isbn, string libraryCardNumber)
        {
            Book book = Books.FirstOrDefault(b => b.ISBN == isbn && !b.IsBorrowed);
            Borrower borrower = Borrowers.FirstOrDefault(b => b.LibraryCardNumber == libraryCardNumber);

            if (book != null && borrower != null)
            {
                borrower.BorrowBook(book);
                Console.WriteLine($"Book '{book.Title}' borrowed by {borrower.Name}");
            }
            else
            {
                Console.WriteLine("Book unavailable or borrower not found.");
            }
        }

        public void ReturnBook(string isbn, string libraryCardNumber)
        {
            Borrower borrower = Borrowers.FirstOrDefault(b => b.LibraryCardNumber == libraryCardNumber);
            if (borrower != null)
            {
                Book book = borrower.BorrowedBooks.FirstOrDefault(b => b.ISBN == isbn);
                if (book != null)
                {
                    borrower.ReturnBook(book);
                    Console.WriteLine($"Book '{book.Title}' returned by {borrower.Name}");
                    return;
                }
            }
            Console.WriteLine("Borrower or book not found.");
        }

        public void ViewBooks()
        {
            Console.WriteLine("\nBooks in Library:");
            foreach (var book in Books)
            {
                string status = book.IsBorrowed ? "Borrowed" : "Available";
                Console.WriteLine($"{book.Title} by {book.Author} - ISBN: {book.ISBN} - Status: {status}");
            }
        }

        public void ViewBorrowers()
        {
            Console.WriteLine("\nBorrowers:");
            foreach (var borrower in Borrowers)
            {
                Console.WriteLine($"{borrower.Name} - Card: {borrower.LibraryCardNumber}");
                if (borrower.BorrowedBooks.Count > 0)
                {
                    Console.WriteLine("  Borrowed books:");
                    foreach (var book in borrower.BorrowedBooks)
                    {
                        Console.WriteLine($"    {book.Title} (ISBN: {book.ISBN})");
                    }
                }
                else
                {
                    Console.WriteLine("  No books borrowed.");
                }
            }
        }
    }

    // Program demo
    class Program
    {
        static void Main()
        {
            Library library = new Library();

            // Add books
            library.AddBook(new Book("C# Basics", "John Doe", "111"));
            library.AddBook(new Book("Advanced C#", "Jane Smith", "222"));

            // Register borrowers
            library.RegisterBorrower(new Borrower("Alice", "CARD1001"));
            library.RegisterBorrower(new Borrower("Bob", "CARD1002"));

            // Borrow books
            library.BorrowBook("111", "CARD1001");

            // View current status
            library.ViewBooks();
            library.ViewBorrowers();

            // Return books
            library.ReturnBook("111", "CARD1001");

            // View after return
            library.ViewBooks();
            library.ViewBorrowers();
        }
    }
}
