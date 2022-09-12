---
title: "(작성중)Unity 3D_Physics.Overlap 함수 : 충돌체 감지" 

categories:
  - UnityStudy

toc: true
toc_sticky: true

use_math: false

date: 2022-09-12
last_modified_at: 2022-09-12
---

# 충돌체 감지
- 유니티 엔진 내에서 가상으로 충돌처리
- 충돌한 객체'들'을 반환

## 종류

### Physics.Overlap[Box / Capsule / Sphere]
- 설정 범위 내 충돌한 콜라이더들을 배열로 반환

### Physics.Overlap[Box / Capsule / Sphere]NonAlloc
- 설정 범위 내 충돌한 콜라이더들의 수를 반환
  - 메모리 누적이 덜 되므로 부하를 덜 주게 된다.

## 사용법
![00]()

### OverlapBox

```cs

```