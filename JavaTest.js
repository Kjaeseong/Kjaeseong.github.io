const fs = require('fs').promise;

fs.writeFile('./test.txt', 'WRITE TEXT')
  .then(() => {
    return fs.readFile('./test.txt');
  })
  .then((data) => {
    console.log(data.toString());
  })
  .catch((err) => {
    console.error(err);
  });