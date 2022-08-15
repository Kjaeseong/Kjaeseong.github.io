[싱글톤이미지]: ./img/SingletonPattern.png

# 싱글톤(Singleton) 패턴

## 개요
![이미지1][싱글톤이미지]
- 단일의 인스턴스(Static) 보장, 이에 대한 전역적인 접근점 제공
  - '어디서든' 접근할 수 있다.
- 구현방법
  - MonoBehaviour 상속
  - MonoBehaviour 비상속
- 단점 :
  - 싱글톤 객체의 변경 시점, 변경 주제, 호출 시점을 모두 알기 어렵다.
  - 여러 클래스와의 결합도가 높다
    - 하나의 코드 수정 시, 싱글톤과 연결된 곳들에서 다양한 문제 발생
  - 멀티스레드 환경에서 코드의 성능이 떨어진다
    - Race Condition : 둘 이상의 코드의 순서가 다르게 동작하면 예상과 다른 결과가 나올 수도 있다
- 비상속의 경우 C#의 방법과 크게 다르지 않고 해당 문서는 Unity 적용을 위해 상속받는 부분만 다룬다.
  
---
## 구현
- 싱글톤 추상 클래스를 만들어 컴포넌트에서 해당 클래스를 상속받아 싱글톤으로 만드는 구조로 구현.
```cs
    public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    // Unity의 제어를 받기 위해 MonoBehaviour를 상속.
    // 컴포넌트에 대해서만 동작하기 때문에 아래와 같은 
    // where 제약을 작성한다.
    {   
        // 정적 멤버로 인스턴스를 갖는다.    
        private static T _instance;  
          
        // 전역적인 접근점을 제공한다.    
        public static T Instance { get { return _instance }}
    }
```
- Unity 컴포넌트의 경우 생성자 초기화 금지.
- 스크립트 객체 생성은 Unity 엔진이 알아서 생성하고 관리한다.
- 스크립트 컴포넌트에 대한 생성자를 정의하려고 하면 Unity의 정상적인 작동을 방해  
  - 컴포넌트 작성 시 생성자를 만들어 줄 필요 없음
- 스크립트 내 멤버 초기화는 이벤트 함수 실행 순서에 따라 Awake, OnEnable, Start중에서 한다.
  - 이 중 초기화 시점에 적절한 것은 Awake, 따라서 코드는 다음과 같다
```cs
public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{    
  private static T _instance;    
  public static T Instance { get { return _instance; }}       
  void Awake()    
  {        
    // 인스턴스가 할당된 경우 다른 게임 오브젝트가 있는 것.        
    if (_instance != null)        
    {            
      // 씬에 단일 게임 오브젝트만 남도록 삭제            
      Destroy(gameObject);            
      return;        
    }        

    // 인스턴스 할당        
    _instance = GetComponent<T>();   
         
    // 씬이 전환될 때에도 파괴가 되지 않도록 한다.        
    DontDestroyOnLoad(gameObject);    
  }
}
```
- 코드의 정상동작을 위해 SingletonBehaviour 상속 받으면 다른 오브젝트보다 Awake를 처리해야 하지만 강제할 수 있는 코드를 작성할 수 없으므로 아래와 같이 코드 수정

```cs
public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{    
  private static T _instance;     
  public static T Instance    
  {        
    get        
    {            
      // SingletonBehaviour가 초기화 되기 전이라면            
      if (_instance == null)            
      {                
        // 해당 오브젝트를 찾아 할당                
        _instance = FindObjectOfType<T>();                
        DontDestroyOnLoad(_instance.gameObject);            
      }            
      return _instance;        
    }    
  }       
  
  void Awake()    
  {                
    if (_instance != null)        
    {            
      // (1) 다른 게임 오브젝트가 있다면            
      if (_instance != this)            
      {                
        // 하나의 게임 오브젝트만 남도록 삭제              
        Destroy(gameObject);            
      }            
      // (2) Awake() 호출 전 할당된 인스턴스가 자기 자신이라면 아무것도 하지 않는다.                                  
      return;        
    }         
    // 아래의 경우는 SingletonBahaviour가 운 좋게 Instance 참조 전 Awake()가 실행되는 경우      
    _instance = GetComponent<T>();        
    DontDestroyOnLoad(gameObject);    
  }
}
```
---
## GameManager에서 SingletonBehaviour 상속
- 위 추상클래스를 통해 이제부터 SingletonBehaviour를 상속받는 클래스는 싱글톤으로 동작
- ex> 
```cs
public class GameManager : SingletonBehaviour<GameManager>
{    
  void Awake()    
  {        
    base.Awake();        
    Debug.Log("GameManager Awake");    
  }

  public void Foo()
  {
    // 생략
  }
}
```
---
## 다른 클래스에서 싱글톤 호출
- 위 GameManager를 싱글톤으로 동작 설정
- MonoBehaviour를 상속받는 클래스는 GameManager 클래스를 통해 인스턴스에 접근 가능
- ex>
```cs
public class Player01 : MonoBehaviour
{
  void Update()
  {
    //MonoBehaviour를 상속받았으므로, 싱글톤 호출 가능
    GameManager.Instance.Foo();
  }
}
```