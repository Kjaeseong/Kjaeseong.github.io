---
title: "반복문 - while" 

categories:
  - C
  - Cpp
  - Csharp

toc: true
toc_sticky: true

use_math: true

date: 2023-07-29
last_modified_at: 2023-07-29
---

# 반복문 - while

## 반복문은 왜 필요하지?
- 프로그래밍에서는 고정적인 동작을 반복적으로 수행해야 하는 경우가 있다. 원하는 결과가 나올때까지 검사를 반복한다거나, 결과를 원하는 만큼 반복적으로 출력하는 상황이 좋은 예가 될 수 있다. 아래처럼 반복된 작업을 여러 번 수행해야 하는 경우를 생각해 보자.

```cpp
int main()
{
    int num = 0;

    std::cout << "콘솔 출력" << num << std::endl;
    ++num;

    std::cout << "콘솔 출력" << num << std::endl;
    ++num;

    std::cout << "콘솔 출력" << num << std::endl;
    ++num;

    std::cout << "콘솔 출력" << num << std::endl;
    ++num;

    // num이 1500이 될 때까지 반복하라.
}
```

- 위 코드와 같은 상황이라면 출력 코드와 연산 코드를 1500회 반복해야 한다는 뜻이다. 물론 실제로 1500줄을 적는 기행을 벌일 수도 있겠지만 ~~웬만하면 그러지 말자~~ 컴퓨터에게 어떻게 반복작업을 지시할 수 있는지 아래 반복문의 사용법을 살펴보며 알아보자.

## 사용법
- 반복문도 조건문과 같이 조건식을 사용해 반복 여부를 제어한다. 다음의 코드를 살펴보자

```cpp
int main()
{
    int value = 0;

    // value의 값이 10 미만이라면 반복
    // value가 10이 되는 순간 조건식이 'false'가 되므로 중단된다.
    // 즉, 0부터 9까지만 출력될 것이다.
    while (value < 10)
    {
        std::cout << "출력" << value << std::endl;
        ++value;
    }
}
```

- 결과 : 
  - ![whileStatement_01](https://github.com/Kjaeseong/Kjaeseong.github.io/assets/103081763/8365a590-7b2c-46f9-bb5c-9dce524350e9)

### 조건식을 사용하지 않고 반복문 제어하기
- 반복문을 선언할 당시의 조건식만 가지고 `생략`, `정지`등을 제어하기란 굉장히 비효율적이고 어려운 방법일 것이다. 이럴 때는 `continue`, `break` 등을 사용해 반복문을 제어할 수 있다.

```cpp
int main()
{
    int value = 0;

    while (true)
    {
        ++value;

        // value나누기 2의 나머지가 0이라면
        // 즉, value가 짝수라면
        if (value % 2 == 0)
        {
            // 이번 루틴은 생략하고 다음 루틴을 실행한다.
            continue;
        }

        std::cout << "출력" << value << std::endl;

        // value가 10 초과라면
        if (value > 10)
        {
            // 반복문 정지(탈출)
            break;
        }
    }
}
```

- 결과 :
  - ![whileStatement_02](https://github.com/Kjaeseong/Kjaeseong.github.io/assets/103081763/2eb2d0c2-35ee-423a-8575-8e33ef85e870)

- C, C++, C# 모두 동일한 while을 사용해 로직을 반복수행 할 수 있고, 조건식 안의 결과가 참일 때 결과를 수행하며, 여기서 말하는 `조건식이 참`이라는 개념은 `C, C++` 및 `C#`의 사용법에 차이가 있다.

### C, C++

```cs
int main()
{
    int value = 10;

    // 조건식이 'false나 0'이 아니라면 전부 'true'로 인식하고 실행된다.
    while (value)
    {
        std::cout << "출력" << value << std::endl;
        --value;
    }
}
```

### C#

```cs
class Program
{
    static void Main(string[] args)
    {
        int value = 0;

        // 조건식의 결과가 true, false. 즉 bool타입이라면 실행된다.
        while (value < 10)
        {
            Console.WriteLine($"출력{value}");
            ++value;
        }
        
        // 아래와 같이 bool타입이 아니라면 에러가 발생한다.
        while (5)   // 에러!
        {
            Console.WriteLine("출력");
        }
    }
}
```

## while과 do-while
- 가장 기초적인 반복문인 `while`은 사용법에 따라 일반적인 `while`과 `do-while`로 나뉜다. 가장 극명한 차이점은 아래와 같다.
  - `while` : 조건식을 판별하고 내부의 로직을 수행한다.
  - `do-while` : 내부의 로직을 수행한 후 조건식을 판별한다.
- 위와 같은 차이점이 있기 때문에, `do-while`은 한 번은 반드시 실행되어야 하는 반복 로직에서 쓰일 수 있고, 이 둘의 차이점에 따라 다양한 용도로 활용할 수 있다. 아래는 `while`과 `do-while`의 예시 코드이다.

```cpp
int main()
{
    int firstValue = 0;
    int secondValue = 0;

    while (firstValue > 0)
    {
        // 조건식의 결과가 false이기 때문에 실행되지 않는다.
        std::cout << "while 출력" << firstValue << std::endl;
    }

    do
    {
        // 로직부터 수행
        std::cout << "do-while 출력" << secondValue << std::endl;

        // 로직 이후 조건식을 판별하므로, 1회는 반드시 실행된다.
    } while (secondValue > 0);
}
```

- 결과 : 
  - ![whileStatement_03](https://github.com/Kjaeseong/Kjaeseong.github.io/assets/103081763/5e83bba4-353b-4380-b3e2-de5314b91ea7)


## 주의점

### 반복문을 꼭 사용해야 하는 상황인지 생각해볼 것
- 분명 반복문은 프로그래밍을 위해 없어서는 안 될 개념이고, 자주 쓰이는 것은 맞지만, 지금이 반복문을 써야만 하는 상황인지 한번쯤은 고민해볼 필요가 있다. 겉보기엔 코드가 함축적이고 가독성이 좋다보니 잘 모를 수 있지만, 결국 지정된 횟수만큼 로직이 반복되기 때문에 필요 이상의 반복문을 남용하게 된다면 성능에서 큰 손해를 볼 수가 있다. 아래의 예시의 경우를 예로 들어볼 수 있다.

```cpp
#include <iostream>
#include <ctime>

// 1부터 100000000까지의 모든 자연수의 합을 구하는 코드를 작성하라.
int main()
{
    // 시간 측정 시작
    std::clock_t start = std::clock(); 

    int value = 1;
    int max = 100000000;
    long long result = 0;

    while (value <= max)
    {
        result += value;
        value++;
    }

    std::cout << "결과 : " << result << std::endl;

    // 시간 측정 종료 및 출력
    double duration = (std::clock() - start) / (double)CLOCKS_PER_SEC;
    std::cout << "소요시간 : " << duration << "초";
}
```

- 결과 : ![whileStatement_04](https://github.com/Kjaeseong/Kjaeseong.github.io/assets/103081763/a1de53f3-a464-41c7-b16b-b39eea5d7d37)
  - 

```cpp
#include <iostream>
#include <ctime>

// 1부터 100000000까지의 모든 자연수의 합을 구하는 코드를 작성하라.
int main()
{
    // 시간 측정 시작
    std::clock_t start = std::clock();

    int max = 100000000;
    long long result = 0;

    // 가우스의 덧셈 공식 사용.
    // n*(n+1)/2
    result = (long long)max * (max + 1) / 2;

    std::cout << "결과 : " << result << std::endl;

    // 시간 측정 종료 및 출력
    double duration = (std::clock() - start) / (double)CLOCKS_PER_SEC;
    std::cout << "소요시간 : " << duration << "초";
}
```

- 결과 : ![whileStatement_05](https://github.com/Kjaeseong/Kjaeseong.github.io/assets/103081763/253030ee-5f34-4928-acd8-ce1a98955faa)
  - 

- 프로그램을 실행하는 PC의 사양 등 여러 요소가 고려되어야 하겠지만, 수치상으로는 `70배`의 차이가 난다. 물론 극단적인 상황을 표현하기 위한 예시에 불과하지만 게임과 같이 프레임 단위로 연산을 해야하는 상황이라면 최적화를 위해 한번쯤은 고려해봐야 할 연산량의 차이인 것이다.

### 반복문이 다중으로 등장한다면 뭔가 잘못되고 있는건 아닌지 생각해보자
- 위의 예시와 마찬가지로 원하는 연산을 수행해서 결과를 반환받기까지의 시간을 고려해봐야 할 필요가 있다. 물론 다중 반복문을 사용해야 하는 상황도 당연히 있지만, 깊이가 깊어질 수록 층마다 `시간복잡도`가 제곱으로 뻥튀기되는 기적을 확인할 수 있다.
  
```cpp
#include <iostream>
#include <ctime>

int main()
{
    // 시간 측정 시작
    std::clock_t start = std::clock();

    int result = 0;

    int firstCount = 1000;
    while (firstCount > 0)
    {
        int secondCount = 1000;
        while (secondCount > 0)
        {
            int thirdCount = 1000;
            while (thirdCount > 0)
            {
                result++;
                thirdCount--;
            }
            secondCount--;
        }
        firstCount--;
    }

    std::cout << result << std::endl;
    // 시간 측정 종료 및 출력
    double duration = (std::clock() - start) / (double)CLOCKS_PER_SEC;
    std::cout << "소요시간 : " << duration << "초";
}
```

- 결과 : 
  - ![whileStatement_06](https://github.com/Kjaeseong/Kjaeseong.github.io/assets/103081763/d6b9f675-dbc7-4e24-9a36-64ede1b6bbdf)