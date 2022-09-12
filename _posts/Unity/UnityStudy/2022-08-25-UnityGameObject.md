---
title: "게임 오브젝트(GameObject)" 

categories:
  - UnityStudy

toc: true
toc_sticky: true

date: 2022-08-25
last_modified_at: 2022-09-12
---

# 게임 오브젝트(GameObject)

## 개요
- 유니티에서 GameObject 클래스에 대한 공부

## GameObject
- 게임 내 씬(Scene)에 존재하는 모든 물체/광원/카메라/특수효과 등 모든 요소가 오브젝트이다.
- 오브젝트만으로는 독자적으로 기능이 구현되지 않는다.
- 컴포넌트 추가로 기능 구현
- 기본적으로 Transform 컴포넌트를 가지며 이는 제거할 수 없다.
- 각 요소에 대한 설명은 [Unity Documentation](https://docs.unity3d.com/kr/2022.1/Manual/class-GameObject.html) 참조

### GameObject에 접근하기
- A 오브젝트에서 B오브젝트가 가진 정보에 접근하기 위해 [GetComponent](https://docs.unity3d.com/kr/2022.1/ScriptReference/Component.GetComponent.html) 메서드를 사용한다.
- 해당 오브젝트에 접근함으로서, 오브젝트에 포함된 컴포넌트에도 접근이 가능해진다.
- 자기 자신 오브젝트에도 접근해 다른 컴포넌트에 접근 가능
- Ex>

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObject_A : MonoBehaviour
{
    //선언
    private rigidbody _rigidbody;
    private GameObject _object_B;
    private Script_B _script_B;

    void Start()
    {
        //자신 오브젝트에 포함된 'Rigidbody'컴포넌트를 로드한다.
        _rigidbody = GetComponent<Rigidbody>();

        //대상을 이름으로 찾기
        _object_B = Find("GameObject_B").GetComponent<GameObject>();

        //대상을 태그로 찾기
        _object_B = FindWithTag("Player").GetComponent<GameObject>();

        //얻어온 대상에 포함된 스크립트 불러오기
        _script_B = _object_B.GetComponent<Script_B>();
    }
}
```

