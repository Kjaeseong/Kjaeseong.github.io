---
title: "자료구조 이론" 

categories:
  - DataStructure

toc: true
toc_sticky: true

date: 2022-08-15
last_modified_at: 2022-08-15
---

# 자료구조

## 학습목표
- 자료구조에 대한 이해
- 프로그래밍 능력 증진

## 개요
- 데이터 조직방법에 따라 더 빠르거나 느려질 수 있다.
- 데이터를 조직하는 방법을 '자료구조'라고 한다.
- 더 빠르고 강건한 프로그램 설계를 위해 각 자료구조의 특성을 이해하고 알맞는 알고리즘을 적절히 활용할 필요가 있다.

## 자료구조
- 선형 구조 : list, stack, queue
- 비선형 구조 : graph, tree
- 자료구조 연산
  - 읽기 : 자료구조 내 특정 위치를 찾는다.
  - 검색 : 자료구조 내 특정 값을 찾는다
  - 삽입 : 자료구조에 새로운 값 추가
  - 삭제 : 자료구조 내 특정 값 삭제
- 구현 방법
  - 순차 자료구조(contiguous data structure) : 메모리 할당이 연속적
  - 연결 자료구조(linked data structure) : 노드라는 메모리 청크에 데이터를 저장, 연결하는 방식
  - 특징
  
| 순차 자료구조                                | 연결 자료구조                                 |
|----------------------------------------|-----------------------------------------|
| 모든 데이터가 메모리에 연속적으로 저장된다.               | 데이터는 노드에 저장되고, 노드는 메모리 곳곳에 흩어져 있을 수 있다. |
| 임의 원소에 즉각적으로 접근할 수 있다.                 | 임의 원소에 접근하는 것은 선형 시간 복잡도를 가지며 느린 편이다.   |
| 캐시 지역성 효과로 인해 모든 데이터를 순회하는 것이 매우 빠르다. | 캐시 지역성 효과가 없어 모든 데이터를 순회하는 것이 느리다.     |
| 데이터 저장을 위해 정확하게 데이터 크기만큼 메모리를 사용한다.    | 각 노드에서 포인터 저장을 위해 여분의 메모리를 사용한다.        |

## 알고리즘의 분석
- 알고리즘(Algorithm) : 문제를 해결하기 위한 절차
- 알고리즘 분석 : 알고리즘의 자원(resource)의 사용량을 분석하는것
  - 자원을 적게 사용할수록 효율적인 알고리즘이라 할 수 있다.
  - 자원 : 실행 시간, 메모리 사용량

### 시간복잡도
- 시간복잡도(Time complexity) : 알고리즘을 수행하는 데 필요한 연산이 몇 번 실행하는지 표기한 것
- 하드웨어와 소프트웨어 환경을 배제한 객관적인 지표
- ex>
  
```cpp
int a = n * n;

```

```cpp
int a = 0;
for(int i = 0; i < n; i++)
{
  a += n;
}
```

```cpp
int a = 0;
for(int i = 0; i < n; i++)
{
  for(int j = 0; j < n; j++)
  {
    a += 1;
  }
}
```

- 다항식의 시간 복잡도 함수에서 입력값이 커지면 결과값에 관여하는 정도가 커진다.
  - 이를 실행 시간의 성장률(rate of growth)라 한다.

#### Big-O 표기법
- 점근적 표기법(asymptotic notation)을 사용해 시간 복잡도를 표기한다.
  - Big-O : 가장 많이 사용되며 점근적 상한선을 제공한다.
  - Big-θ
  - Big-Ω
  - 
> O(1) < O(logn) < O(n) < O(nlogn) < O(n2) < O(n3) < O(2n) < O(n!)

- 한 알고리즘이 다른 알고리즘보다 빨라도 같은 수치로 표기될 수 있다.
  - 면밀한 분석이 필요할 때도 있다.
  - 표기법상 시간복잡도가 적다고 해도 모든 경우에 프로그램의 속도가 빠른 것은 아니다.
  - 아래 그림에서 확인할 수 있다
![이미지1](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/Big_O.jpg?raw=true)


### 공간복잡도(space complexity)
- 알고리즘을 수행하는데 필요한 자원 공간의 양
- 시간복잡도와는 반비례적인 경향이 있다.
- 시간 복잡도를 위해 공간 복잡도를 희생하는 경우가 많다.

## STL - 표준 템플릿 라이브러리(Standard Template Library)
- C++에서 프로그래머의 편의를 위해 여러 자료구조와 알고리즘을 템플릿을 이용해 제공
- 구현 코드의 수를 줄이기 위해 아래와 같이 나눈다.
  - 컨테이너 라이브러리(Container Library) : 임의 타입의 객체를 보관, 자료구조의 구현체
  - 반복자 라이브러리(Iterator Library) : 컨테이너에 보관된 원소에 접근, 요소에 접근하는 포인터
  - 알고리즘 라이브러리(Algorithm Library) : 반복자로 일련의 작업 수행
  - 기존 : 컨테이너 * 알고리즘
  - 반복자 패턴 : 컨테이너 + 알고리즘