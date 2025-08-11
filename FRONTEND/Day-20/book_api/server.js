const express = require('express');
const app = express();

app.use(express.json());

app.get('/', (req, res) => {
  res.json({ message: 'Welcome to Book Management API' });
});

const { readBooks, addBook, updateBook, deleteBook } = require('./data_services/bookService');


app.get('/books', async (req, res) => {
  try {
    const books = await readBooks();
    res.json(books);
  } catch (err) {
    console.error("Error reading books:", err);
    res.status(500).json({ error: 'Failed to read books' });
  }
});

// Add a new book
app.post('/books', async (req, res) => {
  const { title, author } = req.body;

  if (!title || !author) {
    return res.status(400).json({ error: 'Title and Author are required' });
  }

  try {
    const newBook = await addBook({ title, author });
    res.status(201).json(newBook);
  } catch (err) {
    console.error("Error adding book:", err);
    res.status(500).json({ error: 'Failed to add book' });
  }
});

// Update a book by ID
app.put('/books/:id', async (req, res) => {
  const bookId = req.params.id;
  const { title, author } = req.body;

  if (!title && !author) {
    return res.status(400).json({ error: 'At least one of Title or Author is required to update' });
  }

  try {
    const updatedBook = await updateBook(bookId, { title, author });
    if (!updatedBook) {
      return res.status(404).json({ error: 'Book not found' });
    }
    res.json(updatedBook);
  } catch (err) {
    console.error("Error updating book:", err);
    res.status(500).json({ error: 'Failed to update book' });
  }
});

// Delete a book by ID
app.delete('/books/:id', async (req, res) => {
  const bookId = req.params.id;

  try {
    const deleted = await deleteBook(bookId);
    if (!deleted) {
      return res.status(404).json({ error: 'Book not found' });
    }
    res.json({ message: 'Book deleted successfully' });
  } catch (err) {
    console.error("Error deleting book:", err);
    res.status(500).json({ error: 'Failed to delete book' });
  }
});

app.listen(3000, () => {
  console.log('🚀 Server running on http://localhost:3000');
});
