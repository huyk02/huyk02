var express = require('express');
var router = express.Router();

/* GET users listing. */
router.get('/', function(req, res, next) {
  res.send('respond with a resource');
});
/* POST to /users/send */
router.post('/send', function(req, res, next) {
  console.log(req.body); // 받은 데이터를 로그로 출력
  if (req.body && req.body.body) {
    res.json({ message: "Received: " + req.body.body });
  } else {
    res.status(400).json({ error: "Invalid request body" });
  }
});

module.exports = router;