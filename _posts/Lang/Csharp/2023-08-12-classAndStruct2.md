---
title: "클래스와 구조체 - 2" 

categories:
  - Csharp

toc: true
toc_sticky: true

use_math: true

date: 2023-08-12
last_modified_at: 2023-08-12
---

# 개요
- [`클래스와 구조체 - 1`](https://kjaeseong.github.io/csharp/classAndStruct/) 강의에서는 클래스에 대해서 다뤘다. 이번 포스팅에서는 `구조체(Struct)`에 대해서 본격적으로 다뤄보겠다.

# 이번에는 구조체에 대해 알아보자.
- 지난 포스팅에서 클래스와 구조체는 `객체`를 표현하기 위한 설계도의 개념인 것으로 설명했다. 구조체 또한 클래스와 사용 방법이 비슷하지만 몇 가지 유의할 점이 있으므로, 구조체의 간단한 특징과 사용 예제를 살펴보자

# 구조체
- 구조체의 특징은 다음과 같다
  - 구조체의 변수와 인스턴스 모두 일반적으로는 스택에 할당되는 `값 타입`이다
    - 단, 구조체가 클래스의 필드나 프로퍼티로 사용되는 경우 구조체 클래스 인스턴스의 일부로서 힙에 할당될 수 있다.
  - 구조체의 상속은 불가능하다
    - 다른 클래스나 구조체를 상속받을 수 없지만 인터페이스의 구현은 가능하다.
  - 구조체의 필드(변수, 프로퍼티)와 메서드(함수)를 가질 수 있다
  - 사용자 정의 생성자를 통해 인스턴스화 할 때, 모든 필드를 초기화해야 한다.
    - 

## 구조체 선언과 인스턴스 생성
- 클래스와 같은 방법으로 인스턴스를 생성할 수 있다.

```cs
class Program
{
    static void Main(string[] args)
    {
        MyStruct a = new MyStruct();

        a.PrintText();
    }
}

public struct MyStruct
{
    public int num;

    public MyStruct()
    {
        // 생성자를 명시적으로 사용할 때, 
        // 필드가 초기화되어있지 않은 경우 반드시 수행해야 한다.
        num = 10;
    }

    public void PrintText()
    {
        Console.WriteLine(num);
    }
}
```

- 결과 : 
  - ![classAndStruct2_01](/assets/image/classAndStruct2_01.png)

- 클래스와 마찬가지로 간단한 과정을 거쳐 구조체의 인스턴스를 생성할 수 있다. <br> 다만 클래스와는 달리 `값 타입` 이기 때문에 아래와 같은 차이점이 발생한다

## 이런 경우는 어떻게 동작할까?
- 아래의 코드를 보고, 실행결과를 보기 전 어떤 결과가 출력될 지 유추해보자

```cs
class Program
{
    static void Main(string[] args)
    {
        MyClass ClassA = new MyClass();
        MyClass ClassB = ClassA;
        ClassB.Num = 100;

        Console.WriteLine($"A Class의 변수 데이터 : {ClassA.Num}");
        Console.WriteLine($"B Class의 변수 데이터 : {ClassB.Num}");
        Console.WriteLine("----------------------------------");

        MyStruct StructA = new MyStruct();
        MyStruct StructB = StructA;
        StructB.Num = 100;

        Console.WriteLine($"A Struct의 변수 데이터 : {StructA.Num}");
        Console.WriteLine($"B Struct의 변수 데이터 : {StructB.Num}");
    }
}

public struct MyStruct
{
    public int Num; // 0
}

public class MyClass
{
    public int Num; // 0
}
```

- 어떤 결과가 출력될 것 같은가. 먼저 설명을 덧붙이자면, <br>클래스는 참조타입이기 때문에 변수는 스택에 할당되지만 결국 `ClassA`, `ClassB`는 같은 힙 메모리의 주소를 가리키는 변수가 된다. 그렇기에 `ClassB`의 데이터를 변화하면 `ClassA의 데이터도 변한다` <br><br>하지만 구조체는 값 타입이므로 스택에 저장된다. `MyStruct StructB = StructA;`는 같은 메모리 주소를 가리키는 주소값이 아니라 개별적으로 존재하는 하나의 인스턴스가 된다. 즉, `StructB`가 인스턴스화 되는 시점에 `StructA`의 데이터를 복사해 완전히 별개의 인스턴스로서 존재한다는 뜻이다. 그러므로 `StructB`의 데이터를 바꾸더라도 `StructA`의 데이터는 변하지 않는다. <br>

- 결과 : 
  - ![classAndStruct2_02](/assets/image/classAndStruct2_02.png)


# 구조체는 무조건 스택에만 할당되는가?
- 그렇지만도 않다. 다음의 예시들을 확인해보자.

## 구조체의 크기가 16바이트 초과일 때, 힙에 할당되는가?
- **결과부터 말하자면 아니다. 정확히 말하면..상황마다 다르긴 한데...최소한 16바이트를 초과한다는 이유로 힙에 할당되는 것은 아니다.**
  16바이트를 초과했을 때, 힙에 할당되는 것인지 코드를 작성해 증명할 수 있는데, 아래의 코드를 예시로 16바이트를 초과하는 구조체가 어디에 할당되는지 생각해보자.

```cs
using System;
using System.Runtime.InteropServices;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"구조체 크기 : {Marshal.SizeOf(typeof(MyStruct))}");

        // 콘솔에서의 멀티스레드 구동
        // 멀티 스레드에서 StructGenerate 함수를 백그라운드로 실행
        Thread th = new Thread(StructGenerate);
        th.IsBackground = true;
        th.Start();

        for(int i = 0; i < 10; i++)
        {
            // 0 ~ 2 세대별 가비지컬렉션이 수행된 수를 모두 더해 출력한다.
            // 즉, 현재까지 가비지 컬렉션이 수행된 누적 횟수
            int GarbageCollectionCount = GC.CollectionCount(0) + GC.CollectionCount(1) + GC.CollectionCount(2);
            Console.WriteLine(GarbageCollectionCount);

            // 메인 스레드를 1초 지연시킨다
            Thread.Sleep(1000);
        }
    }

    static void StructGenerate()
    {
        while (true)
        {
            // 인스턴스 생성, 블록 범위가 지나면 할당이 해제되므로
            // 힙에 할당된다면 가비지컬렉션이 발생해야 한다
            MyStruct a = new MyStruct();

            // MyClass b = new MyClass();
        }
    }
}

public class MyClass
{
    public long Num1;
    public long Num2;
    public long Num3;
}

public struct MyStruct
{
    public long Num1;
    public long Num2;
    public long Num3;
}
```

- 결과 : 
  - ![classAndStruct2_03](/assets/image/classAndStruct2_03.png)

- 구조체의 인스턴스를 지속적으로 멀티스레드에서 생성하고 있음에도, 가비지컬렉션은 한번도 일어나지 않았다. 가비지컬렉션의 개념은 추후 포스팅 할 개념으로, 현재는 `힙 메모리에서 사용하지 않는 객체를 자동으로 할당 해제하는 프로세스`정도로 정의하겠다. <br>그렇다면, 그냥 원래 가비지컬렉션이 일어나지 않는 것 아니냐..생각할 수 있지만, 친히 준비해놓은 Class 인스턴스를 생성하는 코드의 주석을 풀고, 다시 테스트를 진행하면 <br>

- 결과 : 
  - ![classAndStruct2_04](/assets/image/classAndStruct2_04.png)

- 위와 같이 ~~폭팔적으로~~ 가비지 컬렉션이 수행되는것을 확인할 수 있다.

- 이로서 구조체의 크기가 16바이트 이상일 때, 힙에 할당되지 않는다는 것이 증명되었다.

## 언제 힙에 할당될까
- 포스팅 위쪽 구조체의 정의 부분에서 설명했듯, 클래스의 멤버로서 구조체가 인스턴스화 될 때 힙에 할당된다. 아래는 클래스 필드로 구조체를 갖는 간단한 예시이다.

```cs
class Program
{
    static void Main(string[] args)
    {
        MyClass myClass = new MyClass();
    }
}

public class MyClass
{
    MyStruct myStruct = new MyStruct();
}

public struct MyStruct
{
    public int Num1;
}
```

- 위 예시의 경우 구조체라 하더라도 힙에 할당된다. 클래스가 힙에 할당되기 때문에, 그 필드 멤버로 있는 구조체 또한 클래스가 인스턴스화 될 때 힙에 할당되는 것이다.