const http = require('http');

const server = http.createServer((req, res) => {
    console.log('요청이 들어왔습니다:', req.method, req.url);
    
    res.setHeader('Content-Type', 'text/plain; charset=utf-8');

    if (req.method === 'GET') {
        res.statusCode = 200;
        res.end('curl: GET 요청이 성공적으로 처리되었습니다.');
    } else if (req.method === 'POST') {
        let body = '';
        
        req.on('data', chunk => {
            body += chunk.toString();
        });
        
        req.on('end', () => {
            console.log('curl: 받은 데이터:', body || '없음');
            res.statusCode = 200;
            res.end('curl: POST 요청이 성공적으로 처리되었습니다. 받은 데이터: ' + body);
        });
    } else {
        res.statusCode = 405;
        res.end('curl: 지원하지 않는 메소드입니다.');
    }
});

const PORT = 3000;
server.listen(PORT, '0.0.0.0', () => {
    console.log(`서버가 포트 ${PORT}에서 실행 중입니다.`);
    console.log('curl 명령어로 테스트하려면:');
    console.log('GET 요청: curl http://localhost:3000');
    console.log('POST 요청: Invoke-WebRequest -Uri "http://localhost:3000" -Method POST -Body "Hello World" -ContentType "text/plain" \n 혹은 curl.exe -X POST -d "Hello World" http://localhost:3000');
});

server.on('error', (err) => {
    if (err.code === 'EADDRINUSE') {
        console.error(`포트 ${PORT}가 이미 사용 중입니다.`);
    } else {
        console.error('서버 에러:', err);
    }
});