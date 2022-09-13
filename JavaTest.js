const crypto = require('crypto');

console.log('base64: ', crypto.createHash('sha512').update('PW').digest('base64'));
console.log('hex: ', crypto.createHash('sha512').update('PW').digest('hex'));
console.log('base64: ', crypto.createHash('sha512').update('AnotherPW').digest('base64'));