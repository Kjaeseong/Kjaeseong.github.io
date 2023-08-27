---
title: "다형성과 업캐스팅/다운캐스팅" 

categories:
  - Csharp

toc: true
toc_sticky: true

use_math: true

date: 2023-08-27
last_modified_at: 2023-08-27
---

# 개요
- 객체지향 프로그래밍은 프로그램에 존재하는 요소들을 `객체`로 표현하고, 각 객체들간의 상호작용을 기반으로 프로그램을 구성한다. 이 때 각 객체들이 자신만의 성질을 가지게 되면, 프로그램 구성 단계에서 모든 객체들에 대한 예외처리가 복잡해지고, 결과적으로 코드에 대한 가독성 / 유지보수성 / 개발 효율성도 떨어지게 된다. 이를 해결하기 위해, 각 객체가 자신만의 형태나 성질을 가지는 것 뿐 아니라 다양한 형태로 존재하고, 많은 객체들을 공통된 성질별로 묶어서 다룰 수 있도록 `다형성`의 개념이 존재한다. 이번 포스팅에서는 `다형성의 구현`과 다형성을 구현하기 위한 `업캐스팅, 다운캐스팅`을 다뤄보겠다. 

# 다형성 (多形性, polymorphism)
- 말 그대로 `다양하고 많은 형태를 가지는 성질`이라는 뜻으로 해석할 수 있다. 데이터~~쪼가리~~가 어떻게 다양한 형태를 갖는다는 것인지 아직 이해가 가지 않을 수 있다. 물론 원시적인 데이터에 모양이란건 존재하지 않는다. <br/> 하지만 객체지향 프로그래밍에서는 프로그램에 존재하는 요소들을 `객체`로 표현한다고 했다. 핵심적인 다형성의 개념은, 이 `객체`라는 것을 다양한 방법과 분류로 다루는 것에 초점을 맞춘다.

## 왜 다양한 형태를 가져야 할까?
- 다음과 같은 상황이 있을 수 있다. `늑대`, `고양이`, `물고기` 라는 객체가 있다고 가정했을 때, 다형성을 구현하지 않는다면 코드가 아래와 같이 작성될 것이다.
  
```cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Wolf wolf = new Wolf();
        Cat cat = new Cat();
        Fish fish = new Fish();

        wolf.Hello();
        cat.Hello();
        fish.Hello();
    }
}

public class Wolf
{
    public void Hello()
    {
        Console.WriteLine("멍멍!");
    }
}

public class Cat
{
    public void Hello()
    {
        Console.WriteLine("므양!");
    }
}

public class Fish
{
    public void Hello()
    {
        Console.WriteLine("뻐끔~");
    }
}
```

- 이 경우는 참조타입인 클래스의 인스턴스를 메인 함수에서 생성하고, 각 인스턴스가 가진 함수를 호출하는 코드의 예시이다. 즉, `늑대`, `고양이`, `물고기`의 형태로 존재하는 객체들이 생성된 것인데, 위 코드에서 메모리에 할당되는 과정은 아래의 그림과 같이 도식화할 수 있다.
  - ![PolymorphismUpcastingDowncasting_01](/assets/image/PolymorphismUpcastingDowncasting_01.png)
- 예시의 경우는 프로그램이 작은 단위이고 각 클래스가 가진 기능도 많지 않기때문에 간단하게 끝났다. <br/> 하지만 각 클래스들에 기능이 많다면..? <br/> 동물이 많다면...? <br/> 이 녀석들의 공통점을 묶어서 한 번에 다룰 수는 없을까..?


## 데이터들이 다양한 형태를 가진다는건?
- 위의 코드는 어떤가. 물론 어떤 객체가 생성되는지 아주 명확한 코드인 건 맞지만, 프로그램이 거대해지고 객체가 많아진다면 언젠가 프로그래머가 감당하기 힘든 수준까지 도달할 것이다. 위 동물들을 공통분야로 묶고, 공통분야를 타입으로 개별적인 동물들을 다룰 수는 없을까?

```cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        IAnimal wolf = new Wolf();
        IAnimal cat = new Cat();
        IAnimal fish = new Fish();

        wolf.Hello();
        cat.Hello();
        fish.Hello();
    }
}

public interface IAnimal
{
    public void Hello();
}

public class Wolf : IAnimal
{
    public void Hello()
    {
        Console.WriteLine("멍멍!");
    }
}

public class Cat : IAnimal
{
    public void Hello()
    {
        Console.WriteLine("므양!");
    }
}

public class Fish : IAnimal
{
    public void Hello()
    {
        Console.WriteLine("뻐끔~");
    }
}
```
- 위 코드의 경우는 어떤가. 기존에는 다른 타입으로 인스턴스가 생성되었지만, 지금은 인터페이스를 상속받아 공통된 타입으로 각 객체의 인스턴스를 생성했다. 그러면 당연히, 배열이나 List<T>, 혹은 다른 컬렉션으로 다룰 수 있겠다.

```cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<IAnimal> animals = new List<IAnimal>();
        animals.Add(new Wolf());
        animals.Add(new Cat());
        animals.Add(new Fish());

        foreach (var ani in animals)
        {
            ani.Hello();
        }
        
    }
}

public interface IAnimal
{
    public void Hello();
}

public class Wolf : IAnimal
{
    public void Hello()
    {
        Console.WriteLine("멍멍!");
    }
}

public class Cat : IAnimal
{
    public void Hello()
    {
        Console.WriteLine("므양!");
    }
}

public class Fish : IAnimal
{
    public void Hello()
    {
        Console.WriteLine("뻐끔~");
    }
}
```

- 코드가 한 층 재미있어졌다. 이 코드 역시 도식화 하게 되면 아래 이미지와 같이 표현할 수 있다.
  - ![PolymorphismUpcastingDowncasting_02](/assets/image/PolymorphismUpcastingDowncasting_02.png)
- 사람의 말로 풀자면, `동물을 관리하는 리스트를 생성하고, 리스트를 순회하면서 동물들에게 인사를 시켰다`(...)정도로 표현할 수 있다. <br/> 주목할 점은, 여기서 각 클래스의 인스턴스를 생성했고 결국 별개의 동물들인데, `IAnimal`이라는 타입으로 변수를 선언했기 때문에, 각 동물의 형태를 가질 수도, `IAnimal`이라는 형태를 가질 수도 있다는 말이다. 여기서 `업캐스팅`과 `다운캐스팅`을 통해 각 동물들이 더 유연하게 동작할 수 있도록 만들어보자.

# 업캐스팅과 다운캐스팅

## 업캐스팅
- 업캐스팅이란, `객체가 상속받고 있는 상위 객체의 타입으로 변환`하는 것이다. 이는 간단한 코드로 예시를 들 수 있다.

```cs
using System;

class Program
{
    static void Main(string[] args)
    {
        FirstClass first = new FirstClass();
        SecondClass second = new SecondClass();

        // 상위 객체 타입으로 '업캐스팅'
        ClassBase classBase = first;
        ClassBase secondClass = second;

        // 아래처럼 간결하게 선언할 수도 있다.
        ClassBase first = new FirstClass();
        ClassBase second = new SecondClass();
    }
}

public class ClassBase
{
    public int Value = 10;
    public void PrintMyValue()
    { 
        Console.WriteLine(Value);
    }
}

public class FirstClass : ClassBase
{
}

public class SecondClass : ClassBase
{ 
}
```

## 다운캐스팅
- 다운 캐스팅은 상위 객체 타입을 상속받고있는 하위 객체의 타입으로 변경하는 것이다.

```cs
using System;

class Program
{
    static void Main(string[] args)
    {
        // 업캐스팅된 인스턴스
        ClassBase first = new FirstClass();
        ClassBase second = new SecondClass();

        // 하위 객체 타입으로 '다운캐스팅'
        FirstClass firstClass = (FirstClass)first;
        SecondClass secondClass = (SecondClass)second;
    }
}

public class ClassBase
{
}

public class FirstClass : ClassBase
{
    public void PrintFirst()
    {
        Console.WriteLine("첫번째 클래스");
    }
}

public class SecondClass : ClassBase
{
    public void PrintSecond()
    {
        Console.WriteLine("두번째 클래스");
    }
}
```

### 주의점
- 다운캐스팅의 경우 주의를 요하게 되는데, 프로그래머의 실수로 인해 다음과 같은 상황이 발생할 수 있다. 결과가 어떻게 될지 생각해보자.

```cs
using System;

class Program
{
    static void Main(string[] args)
    {
        // 업캐스팅된 인스턴스
        ClassBase first = new FirstClass();
        ClassBase second = new SecondClass();

        // 하위 객체 타입으로 '다운캐스팅'
        FirstClass firstClass = (FirstClass)first;

        // ★중요★ SecondClass의 인스턴스를 FirstClass로 잘못 캐스팅할 경우.
        FirstClass secondClass = (FirstClass)second;
    }
}

public class ClassBase
{
}

public class FirstClass : ClassBase
{
    public void PrintFirst()
    {
        Console.WriteLine("첫번째 클래스");
    }
}

public class SecondClass : ClassBase
{
    public void PrintSecond()
    {
        Console.WriteLine("두번째 클래스");
    }
}
```

- 결과 : 펑!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
  - ![PolymorphismUpcastingDowncasting_03](/assets/image/PolymorphismUpcastingDowncasting_03.png)

- 이와 같은 상황이 발생할 수 있다. <br/> 그도 그럴 것이, `SecondClass`타입의 인스턴스를 생성해 놓고 `FirstClass` 타입으로 변환하려고 하니 당연히 런타임 에러를 뿜어낸 거다. 이 상황은 프로그래머의 실수로 인해 충분히 일어날 수 있는 상황인데, 이를 최대한 막을 방법은 없을까?

### `is`와 `as`를 사용해 보자.
- 위와 같은 상황에서 `is`와 `as`를 사용해 프로그램의 런타임 에러를 방지할 수 있다.
  - `대상 is 타입` : 대상이 타입과 일치하는지 `bool` 타입으로 반환한다.
  - `대상 as 타입` : 대상을 타입으로 변환(캐스팅)하고 반환한다.

```cs
using System;

class Program
{
    static void Main(string[] args)
    {
        // 업캐스팅된 인스턴스
        ClassBase first = new FirstClass();
        ClassBase second = new SecondClass();

        // 하위 객체 타입으로 '다운캐스팅'
        // 'first'가 'FirstClass'타입의 인스턴스라면
        if(first is FirstClass) 
        {
            // 'first'를 'FirstClass'타입으로 변환하고 PrintFirst() 함수를 호출하라.
            (first as FirstClass).PrintFirst();
        }
        // 'second'가 'FirstClass'타입의 인스턴스라면
        if (second is FirstClass)
        {
            // 'second'를 'FirstClass' 타입으로변환하고 PrintFirst() 함수를 호출하라
            (second as FirstClass).PrintFirst();
        }
    }
}

public class ClassBase
{
}

public class FirstClass : ClassBase
{
    public void PrintFirst()
    {
        Console.WriteLine("첫번째 클래스");
    }
}

public class SecondClass : ClassBase
{
    public void PrintSecond()
    {
        Console.WriteLine("두번째 클래스");
    }
}
```

- 결과 : 
  - ![PolymorphismUpcastingDowncasting_04](/assets/image/PolymorphismUpcastingDowncasting_04.png)
- 이번에는 터지지 않았다. `if`를 사용해 `second`라는 변수가 참조하는 인스턴스가 `FirstClass`가 맞는지 확인하고, 맞을 경우에만 이후 로직을 실행하도록 했기 때문이다. 이처럼 is와 as를 사용해 캐스팅 시의 런타임 에러를 방지할 수 있다.

## 이제 쓸 줄 알겠다. 활용해보자.
- 이제까지 업캐스팅과 다운캐스팅까지 알아보았다. 그렇다면 바로 기출변형으로 가보자!

```cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<IAnimal> animals = new List<IAnimal>()
        {
            new Wolf(),
            new Cat(),
            new Fish()
        };

        // 'animals' List 순회
        foreach (var animal in animals) 
        {
            // 일단 인사부터 시킨다.
            animal.Hello();

            // 'animal'이 'Cat'클래스의 인스턴스인 경우
            if (animal is Cat)
            {
                // (animal을 Cat 타입으로 변환).Grooming() 함수를 호출한다.
                // 다운캐스팅
                (animal as Cat).Grooming();
            }
        }
    }
}

public interface IAnimal
{
    public void Hello();
}

public class Wolf : IAnimal
{
    public void Hello()
    {
        Console.WriteLine("멍멍!");   
    }
    public void Howling()
    {
        Console.WriteLine("아우우우웅~~");
    }
}

public class Cat : IAnimal
{
    public void Hello()
    {
        Console.WriteLine("므양!");
    }
    public void Grooming()
    {
        Console.WriteLine("핥핥핥핥핥핥");
    }
}

public class Fish : IAnimal
{
    public void Hello()
    {
        Console.WriteLine("뻐끔~");
    }
    public void Swimming()
    {
        Console.WriteLine("펄떡펄떡펄떡");
    }
}
```

- 결과 :
  - ![PolymorphismUpcastingDowncasting_05](/assets/image/PolymorphismUpcastingDowncasting_05.png)
- 위 코드의 경우, 인터페이스를 상속 받아 다형성을 구현하고, 동물들이 담겨있는 List를 순회하며 인사를 시킨다, 그 후 고양이가 맞다면 고양이에게 그루밍을 시킨다. <br/> 업캐스팅과 다운 캐스팅은 위와 같이 사용될 수 있다. 분명 조심히 다뤄야 할 개념인 것은 맞지만, 프로그램의 유연함을 증가시켜주는 다형성의 요소이기 때문에 사용법을 숙지하는 것을 추천한다.