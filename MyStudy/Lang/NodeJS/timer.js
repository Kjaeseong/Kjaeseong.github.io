//1
const timeout = setTimeout(() => {
    console.log('1.5초 후 실행');
}, 1500);

//2
const interval = setInterval(() => {
    console.log('1초마다 실행');
}, 1000);

//3
const timeout2 = setTimeout(() => {
    console.log('실행되지 않음');
}, 3000);

setTimeout(() => {
    clearTimeout(timeout2);
    clearInterval(interval);
}, 2500);

//4
const immediate = setImmediate(() => {
    console.log('즉시 실행');
});

//5
const immediate2 = setImmediate(() => {
    console.log('실행되지 않음');
});

clearImmediate(immediate2);

/*
실행 순서
4 -> 2 -> 1 -> 2
*/