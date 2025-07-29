using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManagementSystem;
using System.Linq;

namespace LibraryManagementSystemTests
{
    [TestClass]
    public class LibraryTests
    {
        private Library _library;

        [TestInitialize]
        public void Setup()
        {
            _library = new Library();
        }

        [TestMethod]
        public void AddBook_ShouldAddBookToLibrary()
        {
            var book = new Book("Test Book", "Author A", "123");
            _library.AddBook(book);

            Assert.AreEqual(1, _library.Books.Count);
            Assert.AreEqual("Test Book", _library.Books[0].Title);
        }

        [TestMethod]
        public void RegisterBorrower_ShouldAddBorrowerToLibrary()
        {
            var borrower = new Borrower("Alice", "CARD001");
            _library.RegisterBorrower(borrower);

            Assert.AreEqual(1, _library.Borrowers.Count);
            Assert.AreEqual("Alice", _library.Borrowers[0].Name);
        }

        [TestMethod]
        public void BorrowBook_ShouldMarkBookAsBorrowed_AndAssignToBorrower()
        {
            var book = new Book("Borrowable Book", "Author B", "456");
            var borrower = new Borrower("Bob", "CARD002");

            _library.AddBook(book);
            _library.RegisterBorrower(borrower);

            _library.BorrowBook("456", "CARD002");

            Assert.IsTrue(book.IsBorrowed);
            Assert.AreEqual(1, borrower.BorrowedBooks.Count);
            Assert.AreEqual(book, borrower.BorrowedBooks[0]);
        }

        [TestMethod]
        public void ReturnBook_ShouldMarkBookAsAvailable_AndRemoveFromBorrower()
        {
            var book = new Book("Returnable Book", "Author C", "789");
            var borrower = new Borrower("Charlie", "CARD003");

            _library.AddBook(book);
            _library.RegisterBorrower(borrower);
            _library.BorrowBook("789", "CARD003");

            _library.ReturnBook("789", "CARD003");

            Assert.IsFalse(book.IsBorrowed);
            Assert.AreEqual(0, borrower.BorrowedBooks.Count);
        }

        [TestMethod]
        public void ViewBooks_ShouldContainCorrectBookStatus()
        {
            var book = new Book("Status Book", "Author D", "101");
            _library.AddBook(book);
            book.Borrow();  // Simulate borrow

            Assert.IsTrue(_library.Books.Any(b => b.Title == "Status Book" && b.IsBorrowed));
        }

        [TestMethod]
        public void ViewBorrowers_ShouldContainBorrowedBooks()
        {
            var book = new Book("Borrowed Book", "Author E", "202");
            var borrower = new Borrower("Dave", "CARD004");

            _library.AddBook(book);
            _library.RegisterBorrower(borrower);
            _library.BorrowBook("202", "CARD004");

            var foundBorrower = _library.Borrowers.FirstOrDefault(b => b.LibraryCardNumber == "CARD004");

            Assert.IsNotNull(foundBorrower);
            Assert.AreEqual(1, foundBorrower.BorrowedBooks.Count);
            Assert.AreEqual("Borrowed Book", foundBorrower.BorrowedBooks[0].Title);
        }
    }
}

