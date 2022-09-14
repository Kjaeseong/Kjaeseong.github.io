---
title: "Photon을 이용한 Unity게임 서버 구축_03 : 플레이어 입력과 움직임" 

categories:
  - UnityStudy

toc: true
toc_sticky: true

use_math: false

date: 2022-09-14
last_modified_at: 2022-09-14
---

# Unity 게임 서버 구축(Photon) 00 : 플레이어 입력

## 플레이어 입력
- 입력 관련 스크립트를 공유한다면 서버환경에 대응할 필요 있음.
  - 미대응시 다른 플레이어의 케릭터도 조종 가능해짐
- 자신의 게임 오브젝트가 로컬 플레이어인 경우에만 입력 감지

### Input 구현 예시

```cs
// PlayerInput.cs

using Photon.Pun;
using UnityEngine;

//MonoBehaviourPun 상속 : Photonview 클래스 사용을 위함
public class PlayerInput : MonoBehaviourPun 
{

    public float Move { get; private set; }
    public float Rotate { get; private set; }

    private void Update() 
    {
        
        if (!photonView.IsMine)
        {   // 로컬 플레이어가 아닌 경우 return시켜서 입력을 받지 않음
            return;
        }

        // 게임오버 상태 -> 조작 불가
        if (GameManager.instance != null
            && GameManager.instance.isGameover)
        {
            Move = 0;
            Rotate = 0;
            return;
        }

        Move = Input.GetAxis(moveAxisName);
        Rotate = Input.GetAxis(rotateAxisName);
    }
}
```

### Movement 구현 예시

```cs
//PlayerMovement.cs

using Photon.Pun;
using UnityEngine;

public class PlayerMovement : MonoBehaviourPun 
{
    public float MoveSpeed = 5f;
    public float RotateSpeed = 180f;

    private PlayerInput _playerInput;
    private Rigidbody _rigidbody;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void FixedUpdate() 
    {
        // 로컬 플레이어만 직접 위치와 회전을 변경 가능
        if (!photonView.IsMine)
        {
            return;
        }

        Rotate();
        Move();
    }

    private void Move() 
    {   // 플레이어 이동
        Vector3 moveDistance = playerInput.move * transform.forward * moveSpeed * Time.deltaTime;
        _rigidbody.MovePosition(playerRigidbody.position + moveDistance);
    }

    
    private void Rotate() 
    {   // 플레이어 회전
        float turn = playerInput.rotate * rotateSpeed * Time.deltaTime;
        _r_igidbody.rotation = _r_igidbody.rotation * Quaternion.Euler(0, turn, 0f);
    }
}
```