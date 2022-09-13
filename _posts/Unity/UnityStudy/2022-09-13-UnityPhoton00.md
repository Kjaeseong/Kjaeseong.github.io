---
title: "(내용 추가 예정)Photon을 이용한 Unity게임 서버 구축_00 : 환경 구축" 

categories:
  - UnityStudy

toc: true
toc_sticky: true

use_math: false

date: 2022-09-13
last_modified_at: 2022-09-13
---

# Unity 게임 서버 구축(Photon) 01 : 로비 구축

## Photon 서비스 가입
- 1. [Photon 홈페이지 가입](https://www.photonengine.com/ko-KR/Photon)
- ![00](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/2022-09-13-UnityPhoton00_00.png?raw=true)
- 2. 가입 후 관리화면 - Photon Cloud - 새 어플리케이션 만들기
- ![01](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/2022-09-13-UnityPhoton00_01.png?raw=true)
- 3. 새 애플리케이션 입력
  - Photon종류 : PUN을 이용하므로 PUN 선택
  - 이름, 어플리케이션 설명 : 프로젝트에 맞게 작성
  - 작성하기 클릭
- ![02](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/2022-09-13-UnityPhoton00_02.png?raw=true)
- 4. 애플리케이션 ID는 미리 복사해둔다.

## 유니티 에셋스토어 - Photon Pun Import
- ![03](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/2022-09-13-UnityPhoton00_03.png?raw=true)
- 유니티 에셋스토어 - PUN2 에셋 추가 및 Import
  - 해당 포스팅에선 Free버전 기준 작성
- 유니티 Import 

## 유니티 내부 설정
- ![04](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/2022-09-13-UnityPhoton00_04.png?raw=true)
- Appld or Email에 복사해둔 애플리케이션ID 붙여넣기 후 Setup Project

