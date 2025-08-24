const fs = require('fs').promises;
const path = require('path');
const EventEmitter = require('events');

// Event emitter for logging
class BookEmitter extends EventEmitter {}
const bookEmitter = new BookEmitter();

// Path to books.json (absolute path)
const filePath = path.join(__dirname, 'books.json');
console.log("Looking for books.json at:", filePath);

// Read all books safely
async function readBooks() {
  try {
    const data = await fs.readFile(filePath, 'utf8');
    console.log("📂 Raw file content:", data);
    return JSON.parse(data || '[]');
  } catch (err) {
    console.error("❌ Read error:", err);
    if (err.code === 'ENOENT') {
      await writeBooks([]);
      return [];
    }
    throw err;
  }
}

// Write books array to file
async function writeBooks(books) {
  await fs.writeFile(filePath, JSON.stringify(books, null, 2));
}

// Add a new book
async function addBook(book) {
  const books = await readBooks();
  const maxId = books.reduce((m, b) => Math.max(m, b.id || 0), 0);
  book.id = maxId + 1;
  books.push(book);
  await writeBooks(books);
  bookEmitter.emit('bookAdded', book);
  return book;
}

// Update a book
async function updateBook(id, updatedData) {
  const books = await readBooks();
  const bookId = Number(id);  // Convert string to number for comparison
  const index = books.findIndex(b => b.id === bookId);
  if (index === -1) return null;
  books[index] = { ...books[index], ...updatedData };
  await writeBooks(books);
  bookEmitter.emit('bookUpdated', books[index]);
  return books[index];
}

// Delete a book
async function deleteBook(id) {
  const books = await readBooks();
  const bookId = Number(id);  // Convert string to number for comparison
  const index = books.findIndex(b => b.id === bookId);
  if (index === -1) return null;
  const deleted = books.splice(index, 1)[0];
  await writeBooks(books);
  bookEmitter.emit('bookDeleted', deleted);
  return deleted;
}

module.exports = {
  readBooks,
  writeBooks,
  addBook,
  updateBook,
  deleteBook,
  bookEmitter
};



