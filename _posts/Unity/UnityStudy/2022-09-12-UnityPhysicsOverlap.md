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
- 모든 충돌체를 배열로 반환하므로 동적할당.

### Physics.Overlap[Box / Capsule / Sphere]NonAlloc
- 설정 범위 내 충돌한 콜라이더들의 수를 반환(정적할당)
  - 특정 수만 반환하고 싶을 때 사용한다.
  - 메모리 누적이 덜 되므로 부하를 덜 주게 된다.

## 사용법
- ![00](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/2022-09-12-UnityPhysicsOverlap_00.png?raw=true)
- 해당 사진에서 캡슐을 Player, 큐브를 Enemy로 가정

### Physics.OverlapBox
- Physics.OverlapBox(Vector3 Center, Vector3 halfExtents, Quaternion Rotation, int layerMask, queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
  - Centor : Box의 중심
  - halfExtents : Box의 크기의 절반
  - orientation : 방향(회전)
  - layerMask : 레이어마스크(해당 layer에 해당하는 Collider들만 반환)
  - QueryTriggerInteraction : 트리거와 충돌할지 결정

```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private void Update() 
    {
       PlayerBox();
    }

    void PlayerBox()
    {
        Collider[] arr = Physics.OverlapBox(transform.position, transform.localScale * 5f, Quaternion.identity);
        
        for(int i = 0; i < 5; i++)
        {
            Debug.Log(arr[i]);
        } 
    }
}
```

- ![01](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/2022-09-12-UnityPhysicsOverlap_01.png?raw=true)
- 실행 시 Player를 포함한 모든 Enemy 감지 및 배열 반환 확인

### Physics.OverlapCapsule
- Physics.OverlapCapsule(Vector3 point0, Vector3 point1, float radius, int layerMask, QueryTriggerInteraction)
  - Point0 : 캡슐 상단 구면의 최상단지점
  - Point1 : 캡슐 하단 구면의 최하단지점
  - radius : 캡슐의 반경
  - layerMask : 레이어마스크(해당 layer에 해당하는 Collider들만 반환)
  - QueryTriggerInteraction : 트리거와 충돌할지 결정

```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CapsuleCollider _collider;

    private void Start() 
    {
        _collider = GetComponent<CapsuleCollider>();
    }

    private void Update() 
    {
       PlayerCapsule();
    }

    void PlayerCapsule()
    {
        Vector3 Point0 = new Vector3(transform.position.x, transform.position.y + _collider.height / 2, transform.position.z);
        Vector3 Point1 = new Vector3(transform.position.x, transform.position.y - _collider.height / 2, transform.position.z);

        Collider[] arr = Physics.OverlapCapsule(Point0, Point1, 5f);
        
        for(int i = 0; i < 5; i++)
        {
            Debug.Log(arr[i]);
        } 
    }
}
```

- ![02](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/2022-09-12-UnityPhysicsOverlap_02.png?raw=true)
- 실행 시 Player를 포함한 모든 Enemy 감지 및 배열 반환 확인

### Physics.OverlapSphere
- Physics.OverlapSphere(Vector3 position, float radius, int layerMask, QueryTriggerInteraction)
  - position : Sphere의 위치
  - radius : 반경
  - layerMask : 레이어마스크(해당 layer에 해당하는 Collider들만 반환)
  - QueryTriggerInteraction : 트리거와 충돌할지 결정

```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Update() 
    {
       PlayerSphere();
    }

    void PlayerSphere()
    {
        Collider[] arr = Physics.OverlapSphere(transform.position, 5f);
        
        for(int i = 0; i < 5; i++)
        {
            Debug.Log(arr[i]);
        } 
    }
}
```

- ![03](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/2022-09-12-UnityPhysicsOverlap_03.png?raw=true)
- 실행 시 Player를 포함한 모든 Enemy 감지 및 배열 반환 확인

### Physics.Overlap[Box / Capsule / Sphere]NonAlloc
- 사용방법은 모두 비슷하므로, Sphere로 예시 작성
- Physics.OverlapSphereNonAlloc(Vector3 position, float radius, Collider[] results, int layerMask, QueryTriggerInteraction)
  - 

```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Update() 
    {
       PlayerSphere();
    }

    void PlayerSphere()
    {
        Collider[] hitColliders = new Collider[5];
        int numColliders = Physics.OverlapSphereNonAlloc(transform.position, 5f, hitColliders);
        
        for(int i = 0; i < 5; i++)
        {
            Debug.Log($"감지항목 {i} : {hitColliders[i]}");
        }
        Debug.Log($"감지 항목 수 : {numColliders}");
    }
}
```

- ![04](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/2022-09-12-UnityPhysicsOverlap_03.png?raw=true)
- 실행 시 Player를 포함한 모든 Enemy 감지 및 배열 반환 확인
- 