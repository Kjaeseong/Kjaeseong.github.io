---
title: "조건문 - switch" 

categories:
  - C
  - Cpp
  - Csharp

toc: true
toc_sticky: true

use_math: true

date: 2023-07-23
last_modified_at: 2023-07-23
---

# 조건문 - switch
![switchStatement_01](https://github.com/Kjaeseong/Kjaeseong.github.io/assets/103081763/fb9824be-34ec-455d-8c95-add2e42bfe02)

## switch는 어떤 문법일까
- 지난 `조건문 - if`에서는 특정 상황에 어떤 데이터가 가진 값, 혹은 연산의 결과에 따라 다른 동작을 하도록 했었다. if문을 직접 작성해보며 느낀 바 이지만, 분기가 많을 경우 전부 else if를 쓰기엔 다소 무리가 있을 수 있다. 정확히 말하면 쓸 수는 있겠지만 코드가 쓸 데 없이 길어질 수 있다. switch는 해당 상황에 요긴하게 쓰일 수 있는 문법으로, 디테일한 사용법은 차이가 있을 수 있으나, 많은 프로그래밍 언어에서 공통적으로 사용되는 문법 중 하나이다.

## if와는 어떤 차이가 있을까
- 위에서 언급했듯이 `if`는 특정 시점에, 지정한 데이터 혹은 연산의 결과에 따라 다른 행동 분기를 제시하는 것이라 했다. switch도 비슷하지만 조금은 다른 사용법과 형태를 가진다. 아래의 예시는 같은 결과를 나타내는 코드를 각각 if와 switch를 사용해 출력한 예시이다


```cpp
int main()
{
    int Num = 5;

    if (Num == 4)
    {
        std::cout << "Num은 4이다" << std::endl;
    }
    else if (Num == 5)
    {
        std::cout << "Num은 5이다" << std::endl;
    }
    else if (Num == 6)
    {
        std::cout << "Num은 6이다" << std::endl;
    }
    else
    {
        std::cout << "어떤 조건에도 포함되지 않는다" << std::endl;
    }
}
```

```cpp
int main()
{
    int Num = 5;

    switch (Num)
    {
    case 4:
        std::cout << "Num은 4이다" << std::endl;
        break;
    case 5:
        std::cout << "Num은 5이다" << std::endl;
        break;
    case 6:
        std::cout << "Num은 6이다" << std::endl;
        break;
    default:
        std::cout << "어떤 조건에도 포함되지 않는다" << std::endl;
    }
}
```

- 당연하게도 위 두 예시에서는 모두 `Num은 5이다`라는 결과가 출력된다. 다만 형태적인 차이점으로는 switch 내부에서 `case`라는 키워드를 통해 각 상태별로 어떤 동작을 해야 할 지에 대한 동작을 정의해줬다는 점이겠다

## 사용 시 주의점
- 위의 예시 코드에서 봤듯 여러 `case`마다 `break`를 통해 문법을 중단시킨다는 공통점을 봤을것이다. 그렇다면 `break`가 없다면 어떻게 될까?

```cpp
int main()
{
	int Num = 5;

	switch (Num)
	{
	case 4:
		std::cout << "Num은 4이다" << std::endl;
	case 5:
		std::cout << "Num은 5이다" << std::endl;
	case 6:
		std::cout << "Num은 6이다" << std::endl;
	default:
		std::cout << "어떤 조건에도 포함되지 않는다" << std::endl;
	}
}
```

- 결과 :
  - ![switchStatement_02](https://github.com/Kjaeseong/Kjaeseong.github.io/assets/103081763/2aa59d88-2df0-412c-8e51-a656762553f2)
- 특이하게도 첫 번째 조건인 `4`를 제외하고 모든 결과가 출력된다. 이로서 알 수 있는 것은 `switch`에 선언되어 있는 `case`들 중에서 해당되는 가장 첫 번째 조건 이후로 모두 실행한다는 것을 알 수 있는데, 여기서 원하는 하나의 조건만 출력하기 위해 해당 코드 아래의 코드들이 실행되지 않도록 `break`를 사용해 막는다는 것이다.