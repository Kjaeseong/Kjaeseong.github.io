const string = 'abc';
const number = 1;
const boolean = true;
const obj = {
  outside: {
    inside: {
      key: 'value',
    },
  },
};

// 전체 시간 측정 시작
console.time('전체 시간');

// 로그 출력, 여러 내용 출력 가능
console.log('로그 출력');
console.log(string, number, boolean);

// 에러메세지 출력
console.error('에러 메세지 출력');

// 객체의 속성들을 테이블 형식으로 출력
console.table([{ name: 'kim', birth: 1995 }, { name: 'lee', birth: 1997}]);

// 객체 표시
// 출력 : { outside: { inside: { key: 'value' } } }
console.dir(obj, { colors: true, depth: 2});

// for문의 동작시간 측정
console.time('시간 측정');
for(let i = 0; i < 100000; i++) {}
console.timeEnd('시간 측정');

// 에러 위치 추적
function b() {
  console.trace('에러 위치 추적');
}
function a() {
  b();
}
a();

// 전체 시간 측정 종료, 출력
console.timeEnd('전체 시간');

