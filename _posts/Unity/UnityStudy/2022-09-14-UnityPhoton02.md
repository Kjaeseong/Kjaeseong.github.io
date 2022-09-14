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

# Photon을 이용한 Unity게임 서버 구축_02 : Photon Network 동기화

## PhotonVeiew
- 포톤 네트워크 환경에서 PhotonView 컴포넌트를 통해 동기화 진행
- PhotonView는 자신의 오브젝트를 관측. 다른 클라이언트에 전달한다.
- PhotonView로 상대 클라이언트의 정보를 전달받는다.
- ![00](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/2022-09-14-UnityPhoton00.png?raw=true)
  - P2P서버 예시의 PhotonView

### PhotonView Component
- ![01](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/2022-09-14-UnityPhoton01.png?raw=true)
- Syncronization : 데이터 동기화 방식
  - Off : 동기화 하지 않는다.
  - Reliable Delta Compressed : 받은 데이터를 비교해 같으면 보내지 않음
  - Unreliable : 계속 보냄, 손실 가능성 있음.
  - Unreliable On Change : 변경이 있을 때 계속 보냄.
- Observed Components :
  - 동기화 할 컴포넌트 입력
  - 동기화 할 데이터들을 관찰. 다른 클라이언트로 보낸다

### RPC(Remote Procedure Calls)
- 원격으로 함수 호출시 사용
- 같은 PhotonView 컴포넌트를 지닌 객체의 함수를 실행할 수 있다.
- 원격으로 호출할 함수 선언시 [PunRPC] 를 붙인다.
- 호출시 두번째 변수(RpcTarget)로 대상 지정 가능

| 대상 지정                | 설명                                                                                                    |
|----------------------|-------------------------------------------------------------------------------------------------------|
| All                  | 자신 포함 모두에게 전송<br/>(나중에 참여한 플레이어 제외)                                                                   |
| Others               | 자신 제외 모두에게 전송 <br/>(나중에 참여한 클라이언트 제외)                                                                 |
| MasterClient         | 마스터 클라이언트에게 전송<br/>주의 : M.C는 RPC 수행 전 연결해제가 되어 RPC가 없어지는 원인이 될 수 있다.                                  |
| AllBuffered          | 자신 포함 모두에게 전송<br/>버퍼로 기록되어 나중에 참여한 플레이어 포함(지연된 실행)                                                    |
| OthersBuffered       | 자신 제외 모두에게 전송<br/>버퍼로 기록되어 나중에 참여한 플레이어 포함(지연된 실행)                                                    |
| AllViaServer         | 자신 포함 모두에게 전송<br/>서버에서 수신 받았을 때 RPC 실행<br/>장점 : 서버의 RPC 전송 순서는 모든 클라이언트에 동일                           |
| AllBufferedViaServer | 자신 포함 모두에게 전송<br/>나중에 참여할 클라이언트를 위해 버퍼화<br/>서버에서 수신 받았을 때 RPC 실행<br/>장점 : 서버의 RPC 전송 순서는 모든 클라이언트에 동일 |

```cs
// B Client - class Player

[PunRPC]
void Yeah()
{
  // 함수 선언
}
```

```cs
// A Client - class Player

public PhotonView Pv;

void Say()
{
  Pv.RPC("Yeah", RpcTarget.All);
}
```

#### RPC()

```cs
void RPC(string mathodName, Player targetPlayer, params object[] parameters)
```

- 특정 플레이어에게만 전송
- 귓속말 등에 사용

### Destroy()

```cs
PhotonNetwork.Destroy(gameObject);
```

- 오브젝트의 파괴(삭제)는 모든 클라이언트에서 동기화되어야 한다.

### Instantiate

```cs
public GameObject Item; 

void CreateItem()
{
  PhotonNetwork.Instantiate(Item.name, Position, Quaternion.identity);
}
```

- 오브젝트의 생성은 모든 클라이언트에서 동기화되어야 한다.

## 직렬화
- `PhotonPeer.RegisterType()`
- 직렬화 기본 지원 타입
  - 포톤
    - Byte
    - bool
    - short
    - int
    - long
    - float
    - double
    - string
    - Object[]
    - byte[]
    - array(array of type T, T[])
    - Hashtable
    - Dictionary<Object, Object>
    - Dictionary<Object, V>
    - Dictionary<K, Object>
    - Dictionary<K, V>
  - 유니티 자체지원
    - Vector2
    - Vector3
    - Quaternion
    - Photon.Realtime.Player
- 직렬화 지원 타입에 포함되지 않는 경우 직접 구현해야 한다