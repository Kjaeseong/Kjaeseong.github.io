---
title: "옵저버(Observer) 패턴 With.Unity" 

categories:
  - DesignPattern

toc: true
toc_sticky: true

date: 2022-08-15
last_modified_at: 2022-08-15
---

# 옵저버(Observer) 패턴
![이미지1](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/ObserverPattern.png?raw=true)

## 개요
- 1:1의존성 정의
- Subject 객체의 상태가 바뀌면 그 객체에 의존하는 Observer 객체들에게 알리는 방식
- 각 Observer 객체들의 Update함수에서 감지/동작 수행
- 서브젝트가 옵저버에 대해서 아는 것은 특정 인터페이스를 구현한다는 것 뿐
  - ex>옵저버 객체는 Update함수를 가지며 이에서 변화 감지
- 옵저버는 언제든 추가 가능
  - 옵저버 추가 시 서브젝트는 변경할 필요 없음
- 서브젝트, 옵저버가 바뀌어도 서로 영향을 주지 않는다.
  - 서로 독립적인 재사용 가능
- 서브젝트에서 옵저버를 리스트(List)로 관리, 순회하며 옵저버들의 함수를 실행
  - ex>
  `
  버튼 이벤트 발생 → 서브젝트 A()실행 → A()가 옵저버 B()함수 일괄 실행
  `

## 구현

### 옵저버 추상클래스
- 옵저버들이 구현해야 할 인터페이스 메서드
  
```cs
public abstract class observer
{
    //상태 Update 메서드
    public abstract void OnNotify();
}
```

### 옵저버 구현클래스
- 대상 타입의 클래스에서 메서드 실행
  
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteObserver1 : Observer
{
    public override void OnNotify()
    {
        //옵저버 클래스 메서드
    }
}
```

### 서브젝트 인터페이스
- 옵저버 관리, 활용에 관한 타입 정의
  
```cs
public interface I_Subject
{
    //옵저버 추가
    void AddObserver(Observer o);

    //옵저버 삭제
    void RemoveObserver(Observer o);

    //옵저버에 연락
    void Notify();
}
```

### 서브젝트
- 대상 인터페이스를 구현한 클래스
  
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteSubject : MonoBehaviour, I_Subject
{
    //옵저버 관리 List 생성
    List<Observer> observers = new List<Observer>();

    //옵저버 등록
    public void AddObserver(Observer observer)
    {
        observers.Add(observer);
    }

    //옵저버 삭제
    public void RemoveObserver(Observer observer)
    {
        if(observer.IndexOf(observer > 0))
        {
            observers.Remove(observer);
        }
    }

    //옵저버에 연락
    public void Notify()
    {
        foreach (Observer o in observers)
        {
            o.OnNotify();
        }
        /*
        혹은
        for (int i = 0; i < observers.Count; ++i)
        {
            observers[i].OnNotiry();
        }
        */
    }

    void Start()
    {
        Observer observer_1 = new ConcreteObserver1();
        Observer observer_2 = new ConcreteObserver1();

        AddObserver(observer_1);
        AddObserver(observer_2);
    }
}
```

- 위 코드 적용시 Unity 버튼 이벤트에 Notify() 함수 추가로, 버튼이 눌리면 옵저버들의 OnNotify()함수가 실행되도록 한다.
