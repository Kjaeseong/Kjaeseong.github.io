---
title: "추상클래스 ( abstract class )" 

categories:
  - Csharp

toc: true
toc_sticky: true

use_math: true

date: 2023-08-26
last_modified_at: 2023-08-26
---

# 개요
- 인터페이스와 추상클래스는 기능적이나 개념적으로 엮이는 경우가 많다. 그도 그럴 것이 인터페이스든 추상클래스든 이를 상속받은 하위 클래스에서 세부구현 한다는 개념 때문인데, 이번 시간은 추상클래스에 대해 알아보고 이는 인터페이스와 어떤 차이가 있을지 생각해 보면 좋을것이다.

# 추상클래스란 뭘까
- 먼저 '추상적'이란 말부터 알아보자, 

> [국어사전]
> 추상적 (抽象的)
> - 어떤 사물이 직접 경험하거나 지각할 수 있는 일정한 형태와 성질을 갖추고 있지 않은 것.
> - 구체성이 없이 사실이나 현실에서 멀어져 막연하고 일반적인. 또는 그런 것.
> - 어떤 사물이 직접 경험하거나 지각할 수 있는 일정한 형태와 성질을 갖추고 있지 않은.

- 우리 실생활에서 '추상적'이라는 표현은 대부분 `뭔가 제시하긴 했는데 구체적인 설명 없이 막연한 상태` 라는 의미로 사용되곤 한다. 대부분의 네이밍이 그러하듯(...) 추상 클래스 또한 이 의미를 정확하게 관통하는 `클래스`이다. <br/> 즉, 뭔가 구체적이지 않은 걸 클래스 내부에 일단 선언해둔다는 의미이다. 그리고 그 구체적이지 않은 점은 ~~불쌍한~~ 자식 클래스가 구현해야 한다.

# 추상클래스 사용해보기
- 추상클래스 또한 고유의 특징을 가지고 있긴 하나, 인터페이스나 클래스와 희석돼 조금 애매하게 느껴질 수 있다. 아래의 특징과 사용방법을 보고 어떻게 사용하면 좋을지 생각해보자. <br/><br/>

## 특징
- 추상클래스는 다음과 같은 특징들이 존재한다.
  - 일반 클래스처럼 자신의 필드와 메서드를 가질 수 있다.
  - `추상메서드`를 선언해 자식 객체에서 구현을 강제할 수 있다.
    - 자식 객체는 상속받은 추상클래스의 추상메서드를 `오버라이드(override)`해서 사용한다.
  - 추상클래스 자체의 인스턴스를 생성할 수 없다.
    - 하지만 추상클래스 타입으로 이를 상속받은 객체를 참조할 수 있다.
  - 일반 클래스와 같이 다중상속은 할 수 없다


## 사용해보자!
- 위의 특징에서 살펴봤듯, 일반 클래스처럼 자신의 필드와 메서드를 가질 수 있다. 그리고 자식 객체에서 세부구현을 강제할 추상메서드를 선언할 수 있는데, 사용방법은 아래와 같다.

```cs
using System;

class Program
{
    static void Main(string[] args)
    {
        MyClass myClass = new MyClass();
        MyClassBase myClassBase = myClass;

        Console.WriteLine("myClass에서 함수 호출----------");
        myClass.PrintMyFloatValue();
        myClass.PrintMyIntValue();

        // 자식 객체에서 세부구현된 내용으로 출력된다.

        Console.WriteLine("myClassBase에서 함수 호출----------");
        myClassBase.PrintMyFloatValue();
        myClassBase.PrintMyIntValue();
    }
}

public abstract class MyClassBase
{
    // 필드를 가질 수 있고
    public int IntValue = 5;
    public float FloatValue { get; set; } = 7.5f;

    public MyClassBase()
    {
        Console.WriteLine("추상 클래스 생성자");
    }

    // 메서드도 가질 수 있다
    public void PrintMyIntValue()
    {
        Console.WriteLine(IntValue);
    }

    // 추상 메서드를 추가할 수 있다.
    public abstract void PrintMyFloatValue();
}

public class MyClass : MyClassBase
{
    public MyClass()
    {
        Console.WriteLine("클래스 생성자");
    }

    public override void PrintMyFloatValue()
    {
        Console.WriteLine($"자식 클래스에서 세부구현 : {FloatValue}");
    }
}
```

- 결과 : 
  - ![abstractClass_01](/assets/image/abstractClass_01.png)

- 추상메서드와 인스턴스를 생성할 수 없다는 점을 제외하면 일반 클래스와 크게 다르지 않다. 하위 객체를 추상클래스에 상속시킬 수 있기 때문에 인터페이스와 마찬가지로 `다형성`구현에도 사용할 수 있다.

## 이렇게도 사용할 수 있다!
- 추상클래스는 자신의 필드 및 메서드를 가질 수 있고, 하위 클래스에서 세부구현 할 추상메서드를 선언할 수 있다. 그렇다면 아래처럼도 사용할 수 있지 않을까?

```cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<AnimalBase> animals = new List<AnimalBase>
        {
            new Human("곽두팔", "밥", 175),
            new Dog("멍멍이", "사료", 50),
            new Cat("야옹이", "생선", 30)
        };

        foreach (var animal in animals)
        {
            animal.Hello();
            animal.PrintMyStatus();
        }
    }
}

public abstract class AnimalBase
{
    public string Name { get; }
    public string Food { get; }
    public int Size { get; }

    protected AnimalBase(string name, string food, int size)
    {
        Name = name;
        Food = food;
        Size = size;
    }

    public void PrintMyStatus()
    {
        Console.WriteLine($"이름 : {Name}");
        Console.WriteLine($"먹이 : {Food}");
        Console.WriteLine($"크기 : {Size}\n");
    }

    public abstract void Hello();
}

public class Human : AnimalBase
{
    public Human(string name, string food, int size) : base(name, food, size) 
    { 
    }

    public override void Hello()
    {
        Console.WriteLine("안녕!!");
    }
}

public class Dog : AnimalBase
{
    public Dog(string name, string food, int size) : base(name, food, size)
    {
    }

    public override void Hello()
    {
        Console.WriteLine("멍멍!!");
    }
}

public class Cat : AnimalBase
{
    public Cat(string name, string food, int size) : base(name, food, size) 
    {
    }

    public override void Hello()
    {
        Console.WriteLine("므양!!");
    }
}

```

- 결과 : 
  - ![abstractClass_02](/assets/image/abstractClass_02.png)

- 인터페이스와 마찬가지로 하나의 타입으로 묶어 여러 동물을 다루는 것은 당연하고, 공통된 속성들은 미리 부모 클래스에서 정의했다. <br/> 결과적으로 추상클래스를 상속받은 하위 클래스들에서는 심플하게 필요한 부분만 구현하면 되니 코드가 확실히 간결해지고 가독성도 좋아졌다. 앞으로 새로운 동물을 추가하기도 쉬워진다.

# 마치며..
- 이번 포스팅은 추상클래스에 대해 알아봤다. 인터페이스와 비슷하게  하위 객체에서 반드시 세부구현 해야 할 추상메서드를 선언하기 때문에, 공통된 속성을 여러 객체에서 구현해야 하는 프로그래머의 실수를 줄여줄 수 있고, 인스턴스를 만드는 것 이외에는 일반 클래스처럼 사용할 수 있기 때문에 활용성도 높은 기능 중 하나다. <br/> 하지만 상황에 따라 인터페이스와 추상클래스를 적재적소에 쓰는 것이 가장 이상적인 활용 방법이다. 각각의 기능을 정확하게 숙지하고 다방면으로 프로그램을 설계해보며 어떻게 사용하면 좋을지 생각해보는 자세가 필요하겠다.