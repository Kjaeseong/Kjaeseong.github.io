---
title: "(작성중)STL_std::forward_list / std::list" 

categories:
  - DataStructure

toc: true
toc_sticky: true

date: 2022-08-15
last_modified_at: 2022-08-15
---

# 개요
- forward_list 및 list의 특징과 구현 방법을 알아본다.

## std::list
- 동적 배열을 쉽게 관리하기 위해 C++ STL에서 지원하는 자료구조
- 메모리 할당은 런타임(실행중)에 일어난다.
  - 프로그램 실행 중에도 동적으로 메모리를 할당한다.
  - 배열의 크기를 변경하기 쉽다.
  - 범위(scope)를 벗어나는 경우 자동으로 메모리를 할당 해제한다.
    - 직접 할당하는 방식보다 안전하게 사용 가능하다.
- 연속된 메모리 할당으로 원하는 위치에 있는 데이터에 쉽게 접근할 수 있다.
- vector 헤더의 std 네임스페이스 내부에 정의

### 구현

```cpp
#include <vector>

int main()
{
	//벡터(동적배열) 선언
	std::vector<int> vec1;
	std::vector<int> vec2 = { 1, 2, 3 };
	std::vector<int> vec3 { 4, 5, 6, 7 };

	//배열 원소 접근 및 at()함수 지원
	vec2[2] = 8;
	vec3.at(1) = 9;

	//초기화 리스트를 사용해 vector에 추가 메모리 할당
	//원소에 접근하는 방식으로는 잘못된 주소에 접근한다.
	vec2[3] = 10;				// -> 런타임 에러
	vec2 = { 10, 11, 12, 13 };	// -> 메모리 할당 성공

	//벡터의 길이(크기)를 반환한다.
	vec3.size();

	//벡터의 크기를 조절한다.
	//작아지는 경우 뒤쪽의 데이터는 소멸한다.
	vec2.resize(1);
}
```

