---
title: "이벤트 함수" 

categories:
  - UnityStudy

toc: true
toc_sticky: true

use_math: false

date: 2022-09-12
last_modified_at: 2022-09-12
---

# 이벤트 함수

## 1. 이벤트 함수 실행 순서
- [Unity Documentation](https://docs.unity3d.com/kr/2021.3/Manual/ExecutionOrder.html)참조
- 각 이벤트 함수의 실행 순서를 숙지하고 있어야 버그 방지가 가능하다.

### 1.1. 첫 번째 씬 로드(Initialization)
- 씬 시작 시 한번 호출

#### 1.1.1. Awake
- Start 함수 전 호출.
- 프리팹이 인스턴스화 된 직후 호출
- 게임 오브젝트 시작시 비활성 상태인 경우 활성화될 때 호출된다.

#### 1.1.2. OnEnable
- 오브젝트 활성화 직후 호출
- 레벨 로드, 스크립트를 포함한 게임오브젝트가 인스턴스화될 때와 같이 MonoBehaviour를 생성할때 호출

### 1.2. 에디터(Editor)

#### 1.2.1. Reset
- 오브젝트에 처음 연결하거나 Reset 커맨스 사용시 스크립트 프로퍼티 초기화를 위해 호출

#### 1.2.2. OnValidate
- 스크립트 프로퍼티가 설정될 때마하 호출(오브젝트 역직렬화될 때 포함)
- 씬을 열 때와 도메인을 다시 로드한 후와 같이 다양한 시기에 발생

### 1.3. 첫 번째 프레임 업데이트 전(Initialization)

