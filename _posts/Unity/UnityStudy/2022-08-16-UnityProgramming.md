---
title: "(작성중)__Unity Programming" 

categories:
  - UnityStudy

toc: true
toc_sticky: true

date: 2022-08-16
last_modified_at: 2022-08-16
---

# 유니티 프로그래밍

## 개요
- 유니티에서 사용하는 C# 문법을 익히고 사용한다.

## 객체 - 기본 타입
- [정수 타입](https://docs.microsoft.com/ko-kr/dotnet/csharp/language-reference/builtin-types/integral-numeric-types)
- [부동소수점 타입](https://docs.microsoft.com/ko-kr/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types)
- [불리언 타입](https://docs.microsoft.com/ko-kr/dotnet/csharp/language-reference/builtin-types/bool)
- [UTF-16 문자 타입](https://docs.microsoft.com/ko-kr/dotnet/csharp/language-reference/builtin-types/char)
- 선언 및 사용 방법은 C, C++과 같다

## 문자열
- System.String으로 제공.
- 불변타입으로 항상 새로운 인스턴스를 생성하므로 성능에 주의.
- [활용 방법](https://docs.microsoft.com/ko-kr/dotnet/csharp/programming-guide/strings/)
- 문자열 보간을 이용해 편하게 형식화된 문자열을 만들 수 있다.
- ex>

```cs
//C++의 경우 std::string에서 내부적으로 "Hello World!"를 생성한다.
//C#에서는 새로운 문자열 인스턴스를 생성한다.
string s = "Hello"
s += " World!"

//문자열 보간
int num = 10;
string s = $"숫자는 {num}입니다";
```

## 연산
- C, C++과 같은 산술 연산자 제공
- 비트 연산 지원
- 제어문 비교 연산 지원(모두 bool 타입)

## 분기문

### if
- C, C++과 사용방법 동일

### switch
- 문자, 문자열 사용 가능

```cs
int num = 2;

switch(num)
{
  case 2: case 4: case 6: case 8: case 10:
    Debug.Log("짝수");
    break;

  default:
    Debug.Log("홀수");
    break;
}
```

## 반복문
- C, C++과 마찬가지로 whlie, do-while, for, break, continue문 지원

## 배열
- C++보다 [더 많은 기능](https://docs.microsoft.com/ko-kr/dotnet/api/system.array?view=netstandard-2.0) 지원
- C++과는 선언 방식이 다르다.
  - 주의 : C# 가변 배열의 접근 방식과 C++의 다차원 배열 접근 코드가 동일하다. 

```cs
// 1차원 배열 선언
// C++ : int arr[5]
int[] arr = new int[5];

// 초기화
arr = new int[5] { 1, 2, 3, 4, 5 };
arr = { 1, 2, 3, 4, 5 };

// 원소 접근
arr[1];

// 다차원 배열
// C++ : int arr[5][5]
int[,] arr2 = new int[5, 5];

// 초기화
arr2 = new int[5, 5] { { 1, 2, 3 }, { 4, 5, 6 }};
arr2 = { { 1, 2, 3 }, { 4, 5, 6 } };

// 원소 접근
// C++ : arr2[1][2]
arr2[1, 2];

// 가변 배열 : 배열의 배열
int[][] arr3 = new int[3][];

arr3[0] = new int[2] { 1, 2 };
arr3[1] = new int[4] { 1, 2, 3, 4 };
arr3[2] = new int[3] { 1, 2, 3 };

// 원소 접근
arr[1][2];
```

## 함수
- C++의 문법과 동일하며, 기본 인자와 오버로딩도 가능

## 간접 참조
- 높은 가독성을 위해 여러 문법 지원.
- 매개변수 한정자(Parameter Specifier)라고 한다.
  
### ref
- 인자가 반드시 초기화 되어 있어야 한다.
  - 초기화하지 않으면 컴파일오류 발생

```cs
// C++
void Swap(int& a, int& b)
{
  int temp = a;
  a = b;
  b = temp;
}

// C#
void Swap(ref int a, ref int b)
{
  int temp = a;
  a = b;
  b = temp;
}

int a = 10;
int b = 20;

// 호출시 꼭 ref 키워드를 적는다.
Swap(ref a, ref b); 
```

### in
- 인자가 반드시 초기화 되어 있어야 한다.
  - 초기화하지 않으면 컴파일오류 발생

```cs
// C++
void Foo(const int& a, const int& b)
{
  // ...
}

// C#
void Foo(in int a, in int b)
{
 // ...
}
```

