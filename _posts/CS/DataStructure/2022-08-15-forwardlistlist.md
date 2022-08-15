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

## 연결 리스트
- 노드라는 메모리 청크에 데이터를 저장, 연결하는 방식
  - 메모리 할당은 비연속적
  - 각 노드는 이전/다음의 주소값을 가지는 방식
  - 임의 접근 불가능.
- 시간복잡도
  - 읽기 : O(n)
  - 검색 : O(n)
  - 삽입 : 맨 앞/맨 뒤일 경우 O(1), 중간일 경우 O(n)
  - 삭제 : 맨 앞/맨 뒤일 경우 O(1), 중간일 경우 O(n)

### 연결 리스트 종류
- 단일 연결 리스트(Singly Linked List) : 다음 원소로만 이동 가능.
  
![이미지1](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/%EB%8B%A8%EC%9D%BC%20%EC%97%B0%EA%B2%B0%20%EB%A6%AC%EC%8A%A4%ED%8A%B8.png?raw=true)

- 이중 연결 리스트(Doubly Linked List) : 양쪽으로 이동 가능
  
![이미지2](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/%EC%9D%B4%EC%A4%91%20%EC%97%B0%EA%B2%B0%20%EB%A6%AC%EC%8A%A4%ED%8A%B8.png?raw=true)

- 단일 원형(Circular Singly Linked List) : 마지막 원소와 첫 번째 원소를 연결, 다음 원소로만 이동 가능

![이미지3](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/%EB%8B%A8%EC%9D%BC%20%EC%9B%90%ED%98%95%20%EC%97%B0%EA%B2%B0%EB%A6%AC%EC%8A%A4%ED%8A%B8.png?raw=true)

- 이중 원형 연결 리스트(Doubly Circular Linked List) : 마지막 원소와 첫 번째 원소를 연결, 양쪽으로 이동 가능.

![이미지4](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/%EC%9D%B4%EC%A4%91%20%EC%9B%90%ED%98%95%20%EC%97%B0%EA%B2%B0%EB%A6%AC%EC%8A%A4%ED%8A%B8.png?raw=true)

-  forward_list : 단일 연결리스트
-  list : 원형 연결리스트

#### std::forward_list
- forward_list 헤더의 std 네임스페이스 내부에 정의

```cpp
#include <forward_list>

int main()
{
    std::forward_list<int> flist;

    // 맨 앞에 삽입
    flist.push_front(1);

    // insert_after(pos, value) : pos 뒤에 value를 삽입
    // begin() -> 첫 번째 위치
    flist.insert_after(flist.begin(), 2);

    // 반복자 생성
    std::forward_list<int>::iterator iter;

    // [ ]->[3]->[1]->[2]->[ ]
    //  ↑
    iter = flist.before_begin();

    // [ ]->[3]->[1]->[2]->[ ]
    //       ↑
    iter = flist.begin();

    // [ ]->[3]->[1]->[2]->[ ]
    //                      ↑
    iter = flist.end();

    // 첫 번째 원소 삭제
    flist.pop_front();

    // erase_after(pos) : pos 다음 원소를 삭제한다.
    flist.erase_after(flist.begin());

    // clear() : 컨테이너 전부 삭제(원소 전부 삭제)
    flist.clear();

    // 컨테이너가 비었는지 확인한다
    flist.empty();
}
```

#### std::list
- list 헤더의 std 네임스페이스 내부에 정의

```cpp
#include <list>

int main()
{
    std::list<int> list;

    // 맨 앞에 삽입
    list.push_front(1);

    // 맨 뒤에 삽입
    list.push_back(2);

    // insert(pos, value) : pos 전에 value를 삽입한다.
    list.insert(list.begin(), 9);


    // 반복자 생성
    std::list<int>::iterator iter;

    // [9]<->[1]<->[2]<->[5]<->[ ]
    //  ↑
    iter = list.begin();

    // [9]<->[1]<->[2]<->[5]<->[ ]
    //                          ↑
    iter = list.end();

    //리버스의 경우 rbegin이 마지막 원소, rend가 첫번째 원소 이전 
    std::list<int>::reverse_iterator riter;

    // [ ]<->[9]<->[1]<->[2]<->[5]
    //                          ↑
    riter = list.rbegin();

    // [ ]<->[9]<->[1]<->[2]<->[5]
    //  ↑
    riter = list.rend();

    // 첫 번째 원소 삭제
    list.pop_front();

    // 마지막 원소 삭제
    list.pop_back();

    // erase(pos) : pos를 삭제한다.
    list.erase(list.begin());

    // 컨테이너를 전부 비운다.
    list.clear();

    //컨테이너가 비었는지 확인
    list.empty();
}
```