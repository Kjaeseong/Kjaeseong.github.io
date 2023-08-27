---
title: "인터페이스 ( interface )" 

categories:
  - Csharp

toc: true
toc_sticky: true

use_math: true

date: 2023-08-19
last_modified_at: 2023-08-19
---

# 개요
- C#은 객체지향 프로그래밍 기반의 언어이다. 그만큼 객체지향 프로그래밍에 적합한 여러 가지 기능들이 있는데, 이번 포스팅은 그 중 인터페이스(interface)에 대해 살펴보겠다.

# 인터페이스란 뭘까
- 일반적으로 `인터페이스`라고 하면 어떤 의미가 떠오를까? 아마 프로그래밍을 입문하는 입장에서는 다음과 같은 의미로서 먼저 다가올 것이다
  - `인터페이스` : 사물 간 또는 사물과 인간 간의 의사소통이 가능하도록 일시적 혹은 영속적인 접근을 목적으로 만들어진 물리적, 가상적 매개체
- C# 언어에서의 인터페이스도 크게 다르지 않다. C# 언어에서의 인터페이스는 `어떤 객체를 구성하는 표현적인 정보만 선언해놓고, 인터페이스를 상속받는 객체에서 세부내용을 구현한다`라는 의미에 가깝다. 우리는 이것을 활용할 것이기 때문에 이제부터 인터페이스란 어떤 것인지 살펴볼 필요가 있다.

# 인터페이스 사용해보기
- 인터페이스를 처음 접한다면 `이게 대체 왜 필요한가`싶은 생각이 들 수 있다. 하지만 이 의문은 프로그래밍에 익숙해 진다면 저절로 사라지는 의문일 테니(~~오히려 이거 없으면 힘들어지는 순간들이 온다~~) 일단 살펴보자 <br/><br/>

## 특징
- 인터페이스에는 다음과 같은 특징들이 존재한다.
  - 내부의 필드로 변수를 가질 수 없지만, 프로퍼티는 가질 수 있다.
  - 인터페이스를 상속받은 클래스에서 인터페이스에 선언된 public 형식의 메서드를 강제로 세부구현(재정의) 하도록 할 수 있다
  - C# 8.0 부터는 인터페이스 내부적으로 메서드를 구현할 수 있다.
  - 개별적인 인스턴스를 생성할 수 없다
    - 생성자도 사용할 수 없다.
    - (중요)하지만 인터페이스 형식으로 생성된 변수로 인터페이스를 상속받는 클래스의 인스턴스를 참조할 수 있다
  - 인터페이스는 다중 상속이 가능하다

## 사용해보자!
- 인터페이스를 선언할 때는 암시적으로 이름 앞에 `대문자 I`를 붙이는 관습이 있다. 물론 안 붙여도 동작은 하지만 Visual Studio에서는 붙일 것을 권장한다.(블로그 주인장이 Visual Studio에서 I를 붙일것을 권장한다는게 아니다. 진짜로 Visual Sutudio가 I를 붙이는것을 추천한다는 메세지를 출력한다.)

```cs
using System;

class Program
{
    static void Main(string[] args)
    {
        MyClass a = new MyClass();

        // a 인스턴스는 인터페이스를 상속받은 클래스
        // 인터페이스 형식의 변수에 참조로 등록할 수 있다
        IMyInterface b = a;

        // 클래스에서 재정의한 인터페이스의 메서드 호출
        a.InterfaceMethod();

        // b는 인터페이스 형이기 때문에
        // 인터페이스 내부의 메서드를 사용할 수 있다.
        b.Method();
    }
}

public interface IMyInterface
{
    public int Num { get; set; }

    // 세부구현 되지 않은 메서드는 하위 클래스에서 재정의 해야 한다.
    public void InterfaceMethod();
    
    // 세부구현된 메서드는 하위클래스에서 재정의할 필요가 없다.
    public void Method()
    {
        PrivateMethod();
    }
    private void PrivateMethod()
    {
        Console.WriteLine("인터페이스 내부의 구현된 private 메서드");
    }
}

public class MyClass : IMyInterface
{
    // 인터페이스에 정의된 프로퍼티와 메서드는
    // 상속받는 클래스에서 강제로 구현하도록 할 수 있다.
    public int Num { get; set; }
    public void InterfaceMethod()
    {
        Console.WriteLine("인터페이스의 메서드 재정의");
    }
}
```

- 결과 : 
  - ![interface_01](/assets/image/interface_01.png)

- 여기서 주목할 점은, 인터페이스 형으로 선언된 변수가 인터페이스를 상속받은 클래스의 인스턴스를 참조하도록 할 수 있다는 점이다. 이 점이 인터페이스의 강력한 기능 중 하나인데, 아래와 같이 사용할 수도 있겠다.

## 이렇게도 사용할 수 있다!

```cs
using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<IAnimal> animals = new List<IAnimal>();
        animals.Add(new Dog());
        animals.Add(new Cat());
        animals.Add(new Monkey()); 

        foreach (var animal in animals)
        {
            animal.Work();
        }
    }
}

public interface IAnimal
{
    public void Walk();
}

public class Dog : IAnimal
{
    public void Walk()
    {
        Console.WriteLine("강아지가 걸어용");
    }
}

public class Cat : IAnimal
{
    public void Walk()
    {
        Console.WriteLine("고양이가 걸어용");
    }
}

public class Monkey : IAnimal
{
    public void Walk()
    {
        Console.WriteLine("원숭이가 걸어용");
    }
}
```

- 결과 : 
  - ![interface_02](/assets/image/interface_02.png)

- 재밌는 결과가 나왔다. 분명 다른 클래스들인데 하나의 List<T>로 묶어서 다룰 수 있게 되었다. 코드를 풀어서 설명하면 <br/> 강아지, 고양이, 원숭이는 다른 객체이지만 '동물'이라는 공통 분모를 엮어 코드로 표현한 것이고, 이것이 객체지향 프로그래밍의 `다형성`을 구현한 간단한 예시이다. 이와 같이 인터페이스는 활용도가 다양하고, 인터페이스는 코드의 재활용성을 높이면서도 다양한 프로그램의 설계를 다양하게 하는데 큰 도움을 준다.

# 마치며..
- 이번 포스팅은 인터페이스에 대해 알아보았다. <br> 인터페이스의 특징은 추후 포스팅 될 `추상 클래스 (abstract class)`와 비슷하고, 자주 비교되는 개념이면서 객체지향 프로그래밍을 지원하는 강력한 기능 중 하나이다. 인터페이스 활용에 익숙해진다면 프로그램을 더 효과적으로 구성할 수 있겠다.