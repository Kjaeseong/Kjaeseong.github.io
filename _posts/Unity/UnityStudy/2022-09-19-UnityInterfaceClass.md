---
title: "Unity프로그래밍_인터페이스" 

categories:
  - UnityStudy

toc: true
toc_sticky: true

use_math: false

date: 2022-09-19
last_modified_at: 2022-09-19
---

# 인터페이스
- 인터페이스의 사용 방법 숙지
- 인터페이스를 적절히 사용할 줄 안다.

## 인터페이스(abstract class)
- 코드 재사용을 위해 사용
- 상속받는 클래스들이 필수로 가지고 있어야 하고, 이름은 같지만 다른 기능이 구현되어야 할 때 사용
- 자식 클래스는 인터페이스의 함수나 프로퍼티를 ***반드시 재정의*** 해야 한다.
  - 반드시 재정의 하므로 함수는 선언만 한다.
  - 컴포넌트로서 오브젝트에 붙일 수 없다.
  - 자식 클래스에서 반드시 재정의하고, 이 함수를 가지도록 강제한다.
  - 재정의 하지 않으면 에러 발생
- 멤버 변수는 가질 수 없다.
- 다중상속 가능
  - C#은 기본적으로 다중상속을 지원하지 않는다.
- 클래스명 앞에 기본적으로 I를 붙인다.

```cs
// IAnimal.cs
public interface IAnimal
{
  void Eat();

  void Sleep();
}


// Human.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// IAnimal을 상속받는 Human Class
// MonoBehaviour와 다중상속
public class Human : MonoBehaviour, IAnimal
{
  // 인터페이스에 정의된 함수 및 프로퍼티 '반드시' 재정의
  public override void Eat()
  {
    Debug.Log("밥");
  }

  public override void Sleep()
  {
    Debug.Log("8시간 잠");
  }
}

// Dog.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour, IAnamal
{
  public override void Eat()
  {
    Debug.Log("사료");
  }

  public override void Sleep()
  {
    Debug.Log("2시간 잠");
  }
}

```