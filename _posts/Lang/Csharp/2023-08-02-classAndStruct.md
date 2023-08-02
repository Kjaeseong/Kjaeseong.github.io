---
title: "클래스와 구조체 - 1" 

categories:
  - Csharp

toc: true
toc_sticky: true

use_math: true

date: 2023-08-02
last_modified_at: 2023-08-02
---

# 개요
- `객체지향 프로그래밍`에서는 프로그램을 코드 단위로만 보지 않고 프로그램 내에 존재하는 요소들을 `객체`로 구성하고, 객체들간의 상호작용을 통해 프로그램이 구현된다. `클래스(Class)`와 `구조체(struct)`는 이를 강력하게 지원하는 기능 중 하나이며, C#은 객체지향 프로그래밍 언어기 때문에 이번 포스팅에서 다뤄질 두 가지 개념은 필수적이고 중요한 요소다.

# 본격적으로 알아보기 전, 클래스와 구조체는 뭘까?
- 두 가지 개념 모두, `객체`를 표현하기 위한 설계도의 개념으로 생각하면 된다. 클래스/구조체로 설계도를 미리 작성하고, 프로그램에서는 설계도를 기반으로 객체를 생성(`인스턴스`)해 프로그램 내에서 객체가 존재하도록 만든다. <br>이 설계도 안에는 크게 다음과 같은 요소들이 포함된다.
  1. 객체가 가지는 성질 : 필드(변수, 프로퍼티 등 객체가 가지는 데이터)
  2. 객체가 하는 행동 : 함수(메서드)
- 클래스와 구조체 모두 객체에 대한 정보를 정의해 두는 `설계도`와 같지만 각 특징에 따라 사용도에서 차이가 있을 수 있다. 두 개념의 특징과 차이점을 알아보도록 하자. 

# 클래스
- 클래스의 특징을 나열하면 다음과 같다
  - 클래스의 변수는 스택에 할당되고, 인스턴스가 힙에 할당되는 `참조 타입이다`
    - 스택에 할당되는 변수는 힙 메모리에 할당되는 인스턴스의 메모리 주소를 가진다
  - `상속`이 가능하지만, `다중상속`은 불가능하다.
  - 클래스의 필드(변수, 프로퍼티)와 메서드(함수)를 가질 수 있다.
  - 생성자와 소멸자를 통해 인스턴스화 할때와 메모리에서 할당 해제될 때의 동작을 정의할 수 있다.

## 클래스 선언과 인스턴스 생성

```cs
public class ParentClass
{
    // 상속받는 자식에서 재사용 가능하다.
    public string Name;
}

// 'ParentClass'를 상속받은 'MyClass'
public class MyClass : ParentClass
{
    // 필드
    public int Value;

    // 메서드
    public void PrintData()
    {
        Console.WriteLine($"{Name}, {Value}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Aclass 인스턴스 생성
        // 스택 메모리에는 'a'라는 변수가 만들어진다.
        // new 할당을 사용해 힙 메모리에 클래스의 정보대로 인스턴스를 만든다
        // 스택 메모리의 'a'라는 변수는 힙 메모리의 Aclass 클래스의 메모리 주소를 가진다
        MyClass A = new MyClass();
        A.Name = "JaCo";
        A.Value = 30;
        A.PrintData();

        // 'b' 변수는 'a' 변수가 가리키는 힙 메모리의 주소를 가진다
        // 즉, b의 내용을 바꾸면 a의 정보가 바뀔것이다.
        MyClass B = A;
        B.Name = "Lee";
        B.Value = 20;
        B.PrintData();

        A.PrintData();
    }
}
```

- 결과 : 
  - ![classAndStruct_01](/assets/image/classAndStruct_01.png)

- 결과에서 확인할 수 있듯이 A를 참조하고 있는 B 변수의 데이터를 변경하면 A 변수가 가진 클래스의 데이터가 변화한다. 이 과정을 그림으로 알아보자면 다음과 같다.
- ![classAndStruct_02](/assets/image/classAndStruct_02.png)
- `B`변수에는 `A`의 값을 대입했으므로, `A`가 가진 메모리의 주소를 `B`도 동일하게 가지고 있는 것이다. 즉, `A`와 `B`는 같은 메모리 주소를 가진 변수가 되므로 `B`의 데이터를 변경하면 `A`의 데이터 또한 변경되는 것이다.

## 생성자와 소멸자
- 클래스에는 생성자와 소멸자라는 특수한 메서드가 있다. 말 그대로 인스턴스가 생성되거나 소멸(할당 해제)될 때 자동으로 호출되는 함수이다. 일반적으로 C#의 언어 특성상 소멸자를 명시적으로 호출하는것은 권장되지 않는 방법으로, 아래 예시 코드에서는 IDisposable을 상속받아 소멸자를 대체하겠다.

```cs
// 'IDisposable'을 상속받은 'MyClass'
public class MyClass : IDisposable
{
    public MyClass()
    {
        Console.WriteLine("생성자 호출");
    }

    ~MyClass()
    {
        // 소멸자.
        // 명시적으로 호출할 수 없고, 호출 시점을 사용자가 알 수 없다.
        // 객체가 메모리에서 할당 해제될 때 자동으로 호출된다.
        Console.WriteLine("소멸자 호출");
    }

    public void Dispose() 
    {
        Console.WriteLine("Dispose() 호출");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--메인함수 시작!");

        // using = 해당 블럭이 끝나면 A 인스턴스의 
        using (MyClass A = new MyClass())
        {
            Console.WriteLine("--using문 로직 동작");
        }
        Console.WriteLine("--메인함수 종료");
    }
}
```

- 결과 : 
  - ![classAndStruct_03](/assets/image/classAndStruct_03.png)

- 결과에서 확인할 수 있듯 생성자는 클래스의 인스턴스가 메모리 할당(생성)될 때 호출되었다. C# 언어의 특성상 소멸자를 `명시적으로 호출할 수 없고`, 설령 가능하다 한들 그것은 C# 언어에서 추구하는 방향과 다르다. 대신 추후에 포스팅 할 `인터페이스`중에서 `IDisposable`을 상속 받는 방법을 사용했다. using문의 블럭이 종료되었을 때, 인스턴스가 할당 해제되며 `IDisposable` 인터페이스의 `Dispose()` 함수를 호출한다.

# `클래스와 구조체 - 2` 게시글에서 계속..