---
title: "이진 검색(Binary Search)" 

categories:
  - Algorithm

toc: true
toc_sticky: true

date: 2022-09-13
last_modified_at: 2022-09-13
---

# 이진 검색

## 개념
- 정렬이 완료된 선형 리스트에서 사용 가능
- 검색 범위를 절반으로 줄여가며 검색하는 방법
- [STL](https://en.cppreference.com/w/cpp/algorithm#Binary_search_operations_.28on_sorted_ranges.29)에서도 제공한다.
  - #include <algorithm>
  - std::binary_search : 이진 검색으로 주어진 값을 찾는다.
  - std::lower_bound : 이진 검색으로 element >= value 를 만족하는 값을 찾는다.
  - std::upper_bound : 이진 검색으로 element < value 를 만족하는 값을 찾는다.
  - std::equal_range : 이전 검색으로 value와 같은 원소의 범위를 찾는다.

## 구현 예시

```cpp
bool BinarySearch(int* arr, int size, int value)
{
    //초기 범위
    int start = 0;
    int end = size;

    while(start < end)
    {
        // 시작과 끝의 중간점 지정
        int index = (start + end) / 2;

        if(arr[index] == value)
        {
            // 고른 곳이 원하는 데이터라면 true
            return true;
        }
        else if(arr[index] < value)
        {
            // 고른 곳이 원하는 데이터보다 작다면 시작 위치 조정
            start = index + 1;
        }
        else
        {
            // 고른 곳이 원하는 데이터보다 크다면 종료 위치 조정
            end = index;
        }
    }
}
```