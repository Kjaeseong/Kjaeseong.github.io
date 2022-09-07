// condition true이면 resolve , false면 reject
const condition = true;

//프로미스 생성 - a, b를 매개변수로 갖는 콜백함수를 가진다.
const promise = new Promise((resolve, reject) => {
  if(condition) {
    resolve('성공');
  } else {
    reject('실패');
  }
});

promise
  .then((message) => {
    return new Promise((resolve, reject) => {
      resolve(message);
    });
  })
  .then((message2) => {
    return new Promise((resolve, reject) => {
      resolve(message2);
    });
  })
  .then((message3) => {
    console.log(message3);
  })
  .catch((error) => {
    console.error(error);
  });