---
title: "Unity프로그래밍_추상클래스" 

categories:
  - UnityStudy

toc: true
toc_sticky: true

use_math: false

date: 2022-09-19
last_modified_at: 2022-09-19
---

# 추상클래스
- 추상클래스의 사용 방법 숙지
- 추상클래스를 적절히 사용할 줄 안다.

## 추상클래스(abstract class)
- 인스턴스(객체)를 만들 수 없다.
- 상속받은 클래스에서 추상클래스의 함수의 세부내용을 구현한다.
  - 파생클래스에서 상속받아 오버라이딩(Overring) 한다.
  - 메서드에 내용이 추가되지 않는다.
  - 즉, 함수의 껍데기만 구현한다.
  - 컴포넌트로서 오브젝트에 붙일 수 없다.
- 데이터(필드)도 가질 수 있다.
- 추상 클래스를 상속받는 자식 클래스에 접근할 수 있다.

```cs
// Human.cs
// Human 추상클래스
public abstract class Human : MonoBehaviour
{
  public abstract void Eat();
}

// Minsu.cs
// Human 을 상속받는 클래스
public class Minsu : Human
{
  public float HP = 0f;

  private void update()
  {
    Eat();
  }

  // 추상클래스 Human의 함수 오버라이딩
  public override void Eat()
  {
    HP += 50f;
  }
}
```

```cs
// Beast.cs
// Beast 추상클래스
public abstract class Beast : MonoBehaviour
{
  // 데이터(필드)까지 상속 가능
  public float Damage = 10f;

  public void update()
  {
    if(Input.GetKeyDown(KeyCode.Space))
    {
      Bite();
    }
  }

  public abstract void Bite();
}

// Wolf.cs
// 추상클래스 Beast에서 update() 이벤트 함수까지 상속 받는 클래스
public class Wolf : Beast
{
  public override void Bite()
  {
    Debug.Log("Bite!");
  }
}
```


