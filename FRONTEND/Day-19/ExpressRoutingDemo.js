// Step 1: Import Express and create an app
const express = require('express');  // Importing express module
const app = express();               // Creating express app instance
const PORT = 3000;                   // Setting the server port

// Step 2: Middleware to parse JSON request bodies
app.use(express.json()); // This middleware parses incoming JSON data

// Step 3: GET route for homepage
app.get('/', (req, res) => {
    res.json('Welcome to express'); // Responds with a simple welcome message
});

// Step 4: POST route to receive data
app.post('/data', (req, res) => {
    res.json({
        message: "Data received successfully",
        yourData: req.body   // Responds with the data sent in request body
    });
});

// Step 5: PUT route to update data (Fixed req and res positions)
app.put('/update', (req, res) => {
    res.json({
        message: "Data updated successfully",
        updatedData: req.body // Simulating updated data response
    });
});

// Step 6: DELETE route to delete data (Fixed req and res positions)
app.delete('/delete', (req, res) => {
    res.json({
        message: "Data deleted successfully"
    });
});

// Step 7: Dynamic route with URL parameter
app.get('/users/:id', (req, res) => {
    res.json({
        message: `User ID is ${req.params.id}` // Captures value from URL like /users/123
    });
});

// Step 8: Start the server and listen on PORT
app.listen(PORT, () => {
    console.log(`Server is running at http://localhost:${PORT}`);
});
