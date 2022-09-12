---
title: "(작성중)Unity3D_Physics.Overlap 함수 : 충돌체 감지" 

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
- 오브젝트에 직접 Collider 컴포넌트를 추가하는 방법도 있으나, 단 한번만 사용하려는 경우 성능상 부적절 할 수 있다.

## 종류

### Physics.Overlap[Box / Capsule / Sphere]
- 설정 범위 내 충돌한 콜라이더들을 배열로 반환

### Physics.Overlap[Box / Capsule / Sphere]NonAlloc
- 설정 범위 내 충돌한 콜라이더들의 수를 반환
  - 메모리 누적이 덜 되므로 부하를 덜 주게 된다.

## 사용법
- ![00]()
- 해당 사진에서 캡슐을 Player, 큐브를 Enemy로 가정

### OverlapBox
- Physics.OverlapBox(Vector3 Center, Vector3 halfExtents, Quaternion Rotation, int layerMask, queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
  - Centor : Box의 중심
  - halfExtents : Box의 크기의 절반
  - orientation : 방향(회전)
  - layerMask : 레이어마스크(해당 layer에 해당하는 Collider들만 반환한다)
  - QueryTriggerInteraction : 트리거와 충돌할지 결정

```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private void Update() 
    {
       PlayerCollision();
    }

    void PlayerCollision()
    {
        Collider[] arr = Physics.OverlapBox(transform.position, transform.localScale * 5f, Quaternion.identity);
        
        for(int i = 0; i < 5; i++)
        {
            Debug.Log(arr[i]);
        } 
    }
}
```

- ![01]()
- 실행 시 Player를 포함한 모든 Enemy 감지 확인