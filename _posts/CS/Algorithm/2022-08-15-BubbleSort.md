---
title: "버블 정렬(bubble sort)" 

categories:
  - Algorithm

toc: true
toc_sticky: true

date: 2022-08-15
last_modified_at: 2022-08-15
---

# 버블소트

## 개념
- 서로 인접한 두 원소를 검사, 정렬한다(오름차순/내림차순 선택 가능)
- 과정
  - 1, 2번째 원소를 비교해 정렬하고자 하는 크기 순으로 나열되어있지 않으면 두 원소를 바꿔 배치한다.
  - 2, 3번째 원소를 동일한 방법으로 비교/배치한다.
  - 마지막 원소까지 반복한다.
  - 다시 첫번째 원소부터 정렬이 끝난 원소를 제외하고 순회한다.
  - 정렬 종료시까지 반복한다.
- 구현 난이도는 단순하지만 효율적이지 못하다.
  - 연산 수가 많다.

### 구현 예시
- 실행시 오름차순, 내림차순 여부를 0 혹은 1로 입력받아 정렬 진행
- 코드에서 알 수 있듯 연산 수 자체가 많기 때문에 시간복잡도에서 손해를 보는 정렬 알고리즘이다.

```cpp
#include <iostream>
using namespace std;

enum SORTMETHOD
{
	Ascending,
	Descending
};

int main()
{
	int arr[10] = { 3, 10, 22, 19, 16, 15, 1, 7, 17, 25 };
	int arrSize = 10;

	int SortingMethod;
	cin >> SortingMethod;

	for (int i = arrSize - 1; i >= 0; i--)
	{
		for (int j = 0; j < i; j++)
		{
			if (SortingMethod == Ascending)
			{
				if (arr[j] > arr[j + 1])
				{
					swap(arr[j], arr[j + 1]);
				}
			}
			if (SortingMethod == Descending)
			{
				if (arr[j] < arr[j + 1])
				{
					swap(arr[j], arr[j + 1]);
				}
			}
		}
	}

	for (int i = 0; i < arrSize; i++)
	{
		cout << arr[i] << " ";
	}
}
```
  