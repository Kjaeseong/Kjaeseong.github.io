---
title: "Unity GoogleAR컨텐츠 개발_환경 구축" 

categories:
  - UnityStudy

toc: true
toc_sticky: true

use_math: false

date: 2022-09-21
last_modified_at: 2022-09-21
---

# Unity GoogleAR 컨텐츠 개발_환경 구축
- [공식문서 링크](https://developers.google.com/ar/develop)

## AR Foundation 설치
- ![00](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/2022-09-21-UnityGoogleAR01_00.png?raw=true)
- Create Unity Project
  - 내장, 범용 렌더링 파이프라인 모두 AR Foundation 호환
  - 단, URP 구성하려면 [추가단계](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@4.2/manual/ar-camera-background-with-scriptable-render-pipeline.html) 구성 필요.
- Package Manager 실행
- Unity Registry 목록 조회
- AR Foundation 조회 및 설치

## 플랫폼별 플러그인 패키지 설치/설정
- AR Foundation패키지는 개발자 사용 인터페이스는 제공하지만 AR기능 자체를 구현하지는 않는다.
- 별도 패키지 설치 및 해당 플러그인 사용설정 필요.

### Android
- ![01](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/2022-09-21-UnityGoogleAR01_01.png?raw=true)
- ![02](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/2022-09-21-UnityGoogleAR01_02.png?raw=true)
- Package Manager 실행
- Unity Registry 목록 조회
- ARCore XR 플러그인 조회 및 설치
- Edit -> Project Settings -> XR Plug-in Management -> Android Tab
  - ARCore Check

## AR 세션 구성, 기초 구성요소 추가
- ![03](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/2022-09-21-UnityGoogleAR01_03.png?raw=true)
- AR Session : AR환경의 수명 주기 제어
- AR Session Origin : AR 좌표를 Unity World 좌표로 변환
- Main Camera 삭제
- Hierarchy Window -> 우클릭 -> XR -> AR Session, AR Session Origin 객체 추가

## 플레이어 설정 구성

### Android
![04]()
![05]()
- File -> Build Settings -> Platform -> Android -> Switch Platform 클릭
- Player
  - Other Settings ->
    - Rendering -> Auto Graphics API 선택 해제 -> Vulkan이 표시되어있으면 삭제
    - Package Name -> 자바 패키지 이름 형식 사용. 고유 앱ID 생성
      - Ex> com.example.helloAR
    - Minimum API Level -> 
      - AR필수 앱의 경우 Android 7.0 'Nougat(API Level 24) or higher 지정
      - AR선택 앱의 경우 Android API Level 19 or higher 지정
    - Scripting Backend ->
      - ARM64 지원시 IL2CPP 선택
    - Target Architectures ->
      - Google Play 64비트 요구사항 충족하려면 ARM64(64비트 ARM) 사용 설정. 
      - 32비트 기기를 지원시 ARMv7 (32비트 ARM) 사용 설정
