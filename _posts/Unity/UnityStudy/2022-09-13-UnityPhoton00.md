---
title: "Photon을 이용한 Unity게임 서버 구축_01 : 로비 구축" 

categories:
  - UnityStudy

toc: true
toc_sticky: true

use_math: false

date: 2022-09-13
last_modified_at: 2022-09-13
---

# Unity 게임 서버 구축(Photon) 01 : 로비 구축

## 참고 링크
- [포톤 AIP 공식문서](https://doc-api.photonengine.com/en/PUN/current/)

## Photon 서비스
- PhotonNetwork : 포톤의 네트워크 서비스를 이용하기 위한 클래스
- 네트워크를 구성하는 다양한 함수 지원.
- 네임스페이스
  - using Photon.Pun : 유니티용 포톤 컴포넌트들
  - using Photon.Realtime : 포톤 서비스 관련 라이브러리
- MonoBehaviourPunCallbacks를 상속받는다.
- 하단 구성 예시에 사용한 함수 외에도 다양한 기능을 지원하므로 공식문서 참조.

## 로비 구성 예시
```cs
using Photon.Pun; 
using Photon.Realtime; 
using UnityEngine;
using UnityEngine.UI;

// 마스터(매치 메이킹) 서버와 룸 접속 담당
// MonoBehaviour기반 PUN기능을 섞은 네트워킹을 위한 클래스
public class LobbyManager : MonoBehaviourPunCallbacks {
    private static readonly string GAME_VERSION = "1"; 
    // 게임 버전
    // 클라이언트에서 게임버전 정보를 서버로 보내고, 업데이트가 필요한지 판단

    public Text ConnectionInfoText; 
    // 네트워크 정보를 표시할 텍스트

    public Button JoinButton; 
    // 룸 접속 버튼

    private void Start() 
    {   // 게임 실행과 동시에 마스터 서버 접속 시도

        PhotonNetwork.GameVersion = GAME_VERSION;
        //접속에 필요한 정보 설정

        PhotonNetwork.ConnectUsingSettings();
        // 마스터 서버로 접속 시도

        JoinButton.interactable = false;
        ConnectionInfoText.text = "서버에 접속중...";
        // UI
    }

    public override void OnConnectedToMaster() 
    {   // 마스터 서버 접속 성공시 자동 실행
        
        JoinButton.interactable = true;
        ConnectionInfoText.text = "온라인 : 서버 접속 완료";
        // UI
    }

    public override void OnDisconnected(DisconnectCause cause) 
    {   // 마스터 서버 접속 실패시 자동 실행

        PhotonNetwork.ConnectUsingSettings();
        // 마스터 서버 접속 시도

        JoinButton.interactable = false;
        ConnectionInfoText.text = "재접속 시도중...";
        // UI
    }

    public void Connect() 
    {   // 룸 접속 시도
        
        JoinButton.interactable = false;
        // 접속 버튼 비활성화
        
        if(PhotonNetwork.IsConnected)
        {   // 서버에 접속중이면

            ConnectionInfoText.text = "룸에 접속합니다";
            // UI표시

            PhotonNetwork.JoinRandomRoom();
            // 룸으로 접속 실행
        }
        else
        {   //서버에 접속중이지 않으면

            ConnectionInfoText.text = "서버 재접속 시도";
            // UI표시

            PhotonNetwork.ConnectUsingSettings();
            // 마스터 서버에 접속
        }
    }

    private static readonly RoomOptions ROOM_OPTIONS = new RoomOptions()
    {
        MaxPlayers = 4
    };
    public override void OnJoinRandomFailed(short returnCode, string message) 
    {   // (빈 방이 없어)랜덤 룸 참가에 실패한 경우 자동 실행
        
        ConnectionInfoText.text = "룸 생성...";
        // UI

        PhotonNetwork.CreateRoom(null, ROOM_OPTIONS);
        // 룸 생성(방제는 알아서 지정 null, 위에 지정해놓은 최대 플레이어수만 설정)
    }

    public override void OnJoinedRoom() 
    {   // 룸에 참가 완료된 경우 자동 실행
        
        ConnectionInfoText.text = "룸 참가";
        // UI   

        PhotonNetwork.LoadLevel("Main");
        // 모든 클라이언트 Main Scene 로드
        // 모든 사람이 동일하게 로드하기 위함
    }
}



```