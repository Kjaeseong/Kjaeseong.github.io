---
title: "Unity GoogleAR컨텐츠 개발_제원" 

categories:
  - UnityStudy

toc: true
toc_sticky: true

use_math: false

date: 2022-09-21
last_modified_at: 2022-09-21
---

# Unity GoogleAR 컨텐츠 개발_제원

## 지원 기능
- 모션 추적 : 디바이스 위치 확인
- 주변 환경 이해 : 지형지물/평면 특징점 감지
  - 흰색 벽 같은 평평한 표면은 인식률이 낮을 수 있음
- 조명 추정 : 카메라 이미지 평균 강도/색상보정

## 지원 사양(갤럭시, 아이폰 기준)
- Android 7.0(Nougat) 이상
- Samsung Galaxy A3(2017) 이상
- Apple Iphone 6S 이상
  - 단, 6S는 Geospatial API 미지원

## Unity Version
- 2019.4.3f1 이상

## 작동 방식
- 디바이스 위치 추적 및 실제 세계 이해
  - 지형지물 인식
  - 지형지물 지점이동 추적
  - 디바이스 입력센서 판독값 결합
  - 디바이스 위치 및 방향 결정
- 평평한 표면 감지
  - 주변 영역 광원 추정
- 오브젝트 배치