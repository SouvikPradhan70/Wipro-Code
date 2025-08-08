// http_demo.js
const http = require('http');

const server = http.createServer((req, res) => {
    res.writeHead(200, {'Content-Type': 'text/plain'}); //      it defines the type
    res.end('Hello World from HTTP Server!'); //sends the respose body to the client and ends teh request response cycle.
});

server.listen(3000, () => {
    console.log("Server running at http://localhost:3000/");
});
