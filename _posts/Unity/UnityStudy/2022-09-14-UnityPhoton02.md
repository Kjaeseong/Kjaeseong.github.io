---
title: "(번호미정)Photon을 이용한 Unity게임 서버 구축_02 : Photon Network 동기화" 

categories:
  - UnityStudy

toc: true
toc_sticky: true

use_math: false

date: 2022-09-14
last_modified_at: 2022-09-14
---

# Photon을 이용한 Unity게임 서버 구축_00 : Photon Network 동기화

## PhotonVeiew
- 포톤 네트워크 환경에서 PhotonView 컴포넌트를 통해 동기화 진행
- 클라이언트의 PhotonView는 자신의 오브젝트를 관측. 다른 클라이언트에 전달한다.
- 다른 클라이언트는 각자 자신의 PhotonView로 상대의 정보를 전달받는다.
- ![00]()
  - P2P서버 예시의 PhotonView

## 