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

### out
- 함수가 끝나기 전 반드시 값이 할당되어야 한다.
- 호출시 반드시 out 키워드를 적는다.

```cs
// C++
void Foo(int a, int b, int& result)
{
  result = a + b;
}

// C#
void Foo(int a, int b, out int result)
{
  result = a + b;
}

int r;
Foo(10, 20, out r);
```

## 클래스
- C++과 동일하게 필드와 메서드를 가지지만 문법이 다르다.
- 접근 한정자를 매번 적어야 한다.
  - [한정자의 종류](https://docs.microsoft.com/ko-kr/dotnet/csharp/language-reference/keywords/accessibility-levels)가 다르다.

```cs
public class Temp
{
  private int a = 0;
  private int b = 0;
  public Temp() => Debug.Log("기본 생성자");
  
  // 초기자 리스트가 없다.
  public Temp(int a, int b)
  {
    // C#에는 포인터라는 게 없어서 -> 연산자는 없다.
    this.a = a;
    this.b = b;
  }
  
  // 복사 생성자는 매우 드물게 작성한다.
  public Temp(Temp temp)
  {
    a = temp.a;
    b = temp.b;
    // 얕은 복사인 경우 아래와 같은 메서드를 이용할 수 있다.
    // this = temp.MemberwiseClone();
  }
  
  public void Print() => Debug.Log($"{a}, {b}");
}

Temp temp = new Temp(1, 2);
```

## 속성(Property)
- 필드의 확장 버전
- 더 적은 코드로 필드와 관련된 메서드 작성 가능
- [자세한 정보](https://docs.microsoft.com/ko-kr/dotnet/csharp/properties)

```cs
class Person
{
  //외부에서 FirstName 필드 데이터 읽기(get), 쓰기(set) 가능
  public string FirstName { get; set; }

  //외부에서 SecondName 필드 데이터 읽기(get) 가능, 쓰기(set) 불가능
  public string SecondName { get; private set; }

  public string FullName
  {
    get { return $"{FirstName} + {SecondName}"; }
  }
}
```

## 상속과 다형성
- 방식은 비슷하지만 접근 한정자를 쓰지 않아도 된다.
- C#에서는 다중 상속을 지원하지 않는다.

```cs
class Base
{
};

// C++
class Derived : public Base
{
};

// C#
class Derived : Base
{
}
```

## 확장 메서드(Extension Method)
- [확장 메서드](https://docs.microsoft.com/ko-kr/dotnet/csharp/programming-guide/classes-and-structs/extension-methods)는 기존 타입을 수정하지 않고 메서드를 추가할 수 있다.
  - [사용 예제](http://www.csharpstudy.com/CSharp/CSharp-extension-method.aspx)
- 아래는 Unity엔진에서 문자열 사용시 좀 더 성능이 좋은 커스터마이징 버전의 메서드다.
  - [EndsWith()](https://docs.microsoft.com/ko-kr/dotnet/api/system.string.endswith?view=netstandard-2.0) : 문자열 인스턴의 끝 부분과 지정한 문자열이 일치하는지 확인
  - [StartsWith()](https://docs.microsoft.com/ko-kr/dotnet/api/system.string.startswith?view=netstandard-2.0) : 문자열 인스턴스의 시작 부분과 지정한 문자열이 일치하는지 확인

```cs
public static class Extensions
{
  public static bool CustomEndsWith(this string a, string b)
  {
    int ap = a.Length - 1;
    int bp = b.Length - 1;

    while (ap >= 0 && bp >= 0 && a [ap] == b [bp])
    {
      ap--;
      bp--;
    }

    return (bp < 0);
  }

  public static bool CustomStartsWith(this string a, string b)
  {
    int aLen = a.Length;
    int bLen = b.Length;
    int ap = 0; int bp = 0;
    
    while (ap < aLen && bp < bLen && a [ap] == b [bp])
    {
      ap++;
      bp++;
    }

    return (bp == bLen);
  }
}
```

## 제네릭(Generic)
- 일반화(C++의 템플릿)
- [사용 방법](http://www.csharpstudy.com/CSharp/CSharp-generics.aspx)
