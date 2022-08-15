---
title:  "CLR C#과 Unity C#의 차이"

categories:
  - Cs

toc: true
toc_sticky: true

date: 2022-08-15
last_modified_at: 2022-08-15
---

# CLR C#과 Unity C#의 차이

## 개요
- C#의 동작 원리를 이해한다.
- Unity C#의 동작 원리를 이해한다.
- 둘의 차이점에 대해서 설명할 수 있다.

## C#
- MicroSoft개발.
- 완전 객체지향 프로그래밍 언어
  - 반드시 클래스가 하나는 있어야 한다.(최근엔 아니다)
- 강건하고 유지보수를 위한 여러 기능 제공
  - 가비지컬렉션 : 메모리 자동 정리
  - 람다 식 : 함수형 프로그래밍을 위함
  - 비동기 프로그래밍

### .NET 아키텍처

![이미지1](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/%EC%9E%90%EB%B0%94%EC%BB%B4%ED%8C%8C%EC%9D%BC.png?raw=true)

- 하나의 언어로 다양한 플랫폼을 지원하기 위함.
- 운영체제 > .NET > 프로그래밍 언어
- 공용 언어 런타임(CLR : Common Language Runtime)과 클래스 라이브러리 세트
- C#은 .NET 위에서 동작하는 언어 중 하나
  - 그 외 F#, Visual Basic 등 있음.

### 빌드

![이미지2](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/%EC%96%B4%EC%85%88%EB%B8%94%EB%A6%AC%EA%B5%AC%EC%84%B1.png?raw=true)

- C#은 컴파일시 
  - CLI 사양을 준수하는 중간 언어(IL - Intermediate Language)로 컴파일
  - IL코드와 프로그램에 사용되는 리소스*가 함께 패키징되어 어셈블리(Assembly)가 된다
    - C/C++를 컴파일 시 생성되는 어셈블리 언어와는 다른 개념.
  - 어셈블리 : 서로 함께 사용되어 논리적 기능 단위를 형성하도록 빌드되는 타입 및 리소스의 컬렉션을 의미
  - 어셈블리는 실행 파일(.exe) 또는 동적 연결 라이브러리(.dll)의 형태를 가진다
  - .NET 기반 애플리케이션에 대한 배포, 버전 제어, 재사용, 활성화 범위 및 보안 권한의 기본 단위 형성'
- C#프로그램 실행시
  - 어셈블리가 CLR에 로드
  - CLR은 IL 코드를 플랫폼에 따라 JIT(Just In TIme)컴파일 혹은 AOT(Ahead Of Time) 컴파일 수행. 네이티브 명령어로 변환

> 리소스 : 아이콘, 마우스 커서, 메뉴 등

### 공용 타입 시스템(CTS - Common Type System)

![이미지3](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/CS%EA%B3%84%EC%B8%B5.png?raw=true)

- 여러 .NET언어를 지원하기 위함
- .NET의 형식
  - 값 타임(Value Time)
  - 참조 타입(Reference Type)
  - 모든 타입은 기본 타입인 System.Object에서 파생
  - C#에서는 위 그림과 같은 계층을 가진다

### 값 타입
- C#에서 값 타입은 구조체 / 얼거형 / 기본 제공 타입으로 구성
- 특징
  - 구조체를 제외한 모든 타입은 System.ValueType에서 파생된다.
  - 스택 메모리에 직접 값이 포함된다. 다시 말해 복사가 일어난다.
  - 상속이 불가능하다.
  - 구조체 멤버 중에 참조 타입이 있다면 메모리 주소가 복사된다.
    - 얕은 복사(Shallow Copy)라고 한다.

### 참조 타입
- C#에서 참조 타입은 클래스 / 대리자 / 배열 / 인터페이스가 있다.
- 특징
  - 힙 메모리에 인스턴스 할당
  - 참조 타입의 변수는 인스턴스의 주소에 대한 참조를 가진다.
  - 널(Null) 할당 가능.

### 박싱과 언박싱
- 박싱
  - 값 타입을 object타입 또는 값 타입에서 구현된 임의의 인터페이스 타입으로 변환
  - object타입의 새로운 인스턴스 생성, 스택의 데이터를 힙으로 복사
- 언박싱
  - 박싱된 인스턴스에서 값 타입을 추출
  - 힙의 데이터를 스택으로 복사
- 구현시 무조건 피해야 할 요소
  
```cs
// Value type
int i = 10;

//Reference tupe => Boxing
object o = i;

//UnBoxing, 10
int a = (int)o;
```

### 가비지컬렉션(Garbage Collection)
- 기존 C++에서 메모리를 프로그래머가 직접 관리를 하므로서 생기는 문제점
  - 메모리 누수(Memory Leak)
  - 이중 해제(Double Free)
  - 섣부른 해제(Premature Free)
- C#에서는 자동 메모리 관리(Automatic Memory Management) 기술인 가비지 컬렉션(Garbage Collection)을 이용한다.
- 동작 원리
  - 가비지 컬렉터(Gabage Collector)가 더 이상 사용하지 않는 메모리를 재사용
  - 객체의 사용유무를 가정(Liveness)한다.

![이미지4](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/%EC%B6%94%EC%A0%81%EA%B0%80%EB%B9%84%EC%A7%80%EC%BB%AC%EB%A0%89%EC%85%98.png?raw=true)

  - 추적 가비지 컬렉션(Tracing Garbage Collection) : 적 방식에서는 도달 가능성(Reachability)으로 생존을 가정하는데 루트(Root)를 사용하여 해당 메모리까지 도달할 수 있는지 보고, 도달되지 못한 메모리는 가비지로 가정한다.
  
![이미지5](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/%EC%B0%B8%EC%A1%B0%EC%B9%B4%EC%9A%B4%ED%8C%85.png?raw=true)

  - 참조 카운팅(Reference Couting) : 해당 메모리에 참조하는 것이 없을 때  가비지로 가정. 참조 카운팅 방법은 순환 참조(Circular Reference)를 주의해야 하는데, 이를 방지하기 위해 약한 참조(Week Reference)라는 개념을 사용한다
- 가비지컬렉션 종류
  - 보수적 가비지 컬렉션(Conservative Garbage Collection)
  - 복제 가비지 컬렉션(Copying Garbage Collection)
  - 분산 가비지 컬렉션(Disributed Garbage Collection)
  - 증분 가비지 컬렉션(Incremental Garbage Collection)
  - 세대별 가비지 수집(Generational Garbage Collection) : C# 사용방식

### 세대(Generation)
- 매니지드 힙(Managed Heap) : 가비지 컬렉터가 관리하는 메모리를 3세대로 나눠 관리
  - 메모리를 재사용하기 용이함
  - 가비지 컬렉션이 일어날 때 파편화를 방지하기 위해 메모리를 압축하는 데, 힙 전체를 대상으로 하기보다 일부분에서만 수행 하는 게 더 빠르다.
  - 최근에 만들어진 객체일 수록 수명이 짧고 오래 사용된 객체일 수록 수명이 길어 재사용할 메모리를 빠르게 분류할 수 있다.
  - 메모리 할당은 0세대에서만 일어나는데 최근에 만들어진 객체끼리 서로 연관되는 경향이 있어 캐싱 측면에서 좋다.
  
![이미지5](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/%EB%A7%A4%EB%8B%88%EC%A7%80%EB%93%9C%ED%9E%99%ED%8F%AC%EC%9D%B8%ED%84%B0.png?raw=true)

### 메모리 할당
- C#에서 모든 참조 타입 객체는 매니지드 힙의 0세대 할당
- 주소공간이 허락하는 한 인접한 곳에 위치
- 메모리를 미리 시스템으로부터 할당 받는다.
- 스택에서 메모리를 할당하는 속도만큼 빠르게 할당 가능, 접근도 빠르다.
- 단, 85KB 이상의 큰 객체는 LOH(Large Object Heap)라는 2세대 메모리에 할당.

### 메모리 해제
- 세대별 가비지 컬렉션
  - 추적 방식 사용.
  - 루트 : 스택 루트, CPU 레지스터, 정적 필드 등
  - 수집 시기 : 가비지 컬렉터가 자동으로 가장 적합한 때에 컬렉션 수행
- 가비지를 찾으면 접근할 수 있는 객체를 압축해 가비지의 공간을 덮는다
  - LOH는 압축되지 않는다
- 순서 : 가비지가 아닌 메모리는 윗 세대로 승격(Promotion)시킴
  - 1. 0세대 
  - 2. 1세대 
  - 3. 2세대 
- 주의사항
  
  ![이미지6](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/%EB%A9%80%ED%8B%B0%EC%8A%A4%EB%A0%88%EB%93%9C%ED%99%98%EA%B2%BD%EA%B0%80%EB%B9%84%EC%A7%80%EC%BB%AC%EB%A0%89%EC%85%98.png?raw=true)

  - 자원을 적게 소모하는 연산이 아니다.
  - 멀티스레드 환경에서 가비지컬렉션 수행되는 동안 다른 스레드가 중단(Suspended)된다.
  - 참조 카운팅 방식으로 가비지 수집이 일어나지 않는다.
  - 빈번한 할당 조심
  - 너무 큰 객체 할당은 피한다.
  - 복잡한 참조 관계 피하기
  - 관리되지 않는 리소스도 있다.
---
## Unity C#

![이미지7](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/%EC%9C%A0%EB%8B%88%ED%8B%B0%EA%B0%80%EB%B9%84%EC%A7%80%EC%BB%AC%EB%A0%89%EC%85%98.png?raw=true)

- 유니티에서 사용하는 .NET은 2가지
  - Mono : 크로스플랫폼 지원 오픈소스
  - IL2CPP : 유니티에서 개발한 .NET
- 가비지 컬렉션
- Boehm GC 사용
- 새대별로 관리되지 않는다
- 메모리의 메모리의 압축도 일어나지 않는다.
  - 메모리 단편화가 일어나 힙이 쉽게 확장, 최적화 이슈가 발생할 수 있다.
- 
---

# 요약

### .NET
- CLR과 클래스 라이브러리 세트를 의미함
- CLR은 C# 코드를 컴파일 한결과물인 IL 코드를 다시 해당 플랫폼에 맞는 코드로 변화하여 하나의 소스코드로 여러 플랫폼 지원
- .NET에는 공용 타입 시스템이 있다.
  - 모든 타입은 값 타입과 참조 타입으로 분류
  - 모든 타입은 System.Object 타입을 상속 받음
  - 이를 명확히 인지 후, 박싱과 언박싱을 피하도록 코드 작성 요망

### 가비지 컬렉션
- 메모리를 수동으로 관리하는 것은 여러 문제점 야기
  - 메모리 누수
  - 이중 해제
  - 섣부른 해제
- 메모리를 자동으로 관리하는 기술
- 가비지로 가정하는 방법
  - 추적 : 도달 가능성으로 가비지 판단
  - 참조 카운팅 : 참조 횟수로 가비지 판단
- 표준 .NET은 세대별 가비지 컬렉션 사용
  - 메모리 할당은 0세대에서만 일어남
  - 메모리 해제 시, 가비지가 아닌 메모리는 윗 세대로 승격됨
- 가비지 컬렉션 실행 중에는 프로그램이 멈추기 때문에 이에 유의하여 코드 작성 요망

### .NET: Unity
- Unity의 스크립트 백엔드(스크립트 환경) => 아래 2가지로 모든 차이 발생
  - Nono
  - IL2CPP
- 세대별로 관리하지 않으며, 메모리 압축 또한 없다
  - 메모리 단편화가 쉽게 일어나고, 힙도 쉽게 확장된다.
  - 최적화 이슈가 발생할 수 있다.
