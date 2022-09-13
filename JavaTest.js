// server1-2.js

const http = require('http');

http.createServer((req, res) => {
    res.writeHead(200, { 'content-Type': 'text/html; charset=utf-8' });
    res.write('<h1>hello Node1!</h1>');
    res.end('<p>Hello Server1!</p>');
})
.listen(8080, () => {
    console.log('8080포트 서버 대기 중');
});

http.createServer((req, res) => {
    res.writeHead(200, { 'content-Type': 'text/html; charset=utf-8' });
    res.write('<h1>hello Node2!</h1>');
    res.end('<p>Hello Server2!</p>');
})
.listen(8081, () => {
    console.log('8081포트 서버 대기 중');
});