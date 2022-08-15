---
title: "오브젝트풀(ObjectPool) 패턴 With.Unity" 

categories:
  - DesignPattern

toc: true
toc_sticky: true

date: 2022-08-15
last_modified_at: 2022-08-15
---

# 오브젝트풀(ObjectPool) 패턴

## 개요
- 빈번하게 재사용 되는 객체들을 미리 배열에 모아둔다.
- 풀 클래스에 들어가는 객체는 현재 자신이 사용중인지 알 수 있어야 한다.
  - 초기화될 때 사용할 객체 ('비활성' 상태로)미리 생성
  - 객체가 필요하면 풀에 요청
  - 사용 가능한 객체를 찾아 '활성'으로 바꾼 뒤 반환
  - 객체를 더 이상 아용하지 않는다면 '비활성' 상태로 교체
- 장점
  - 메모리 문제를 덜 신경쓸 수 있다.
  - 자주 사용되는 객체를 '미리' 생성하므로 플레이 도중 성능상의 이점이 있다.
- 단점
  - 사용하지 않을 때도 메모리를 사용하고 있다.

## 구현
- 총과 탄환을 예시로 구현
##### Gun
- 총의 Start() 함수에서 탄환 미리 생성(Bullet.SetActive(false))
- 발사 명령시 탄환은 총의 위치로 설정, 활성(Bullet.SetActive(true))
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //프리팹
    public GameObject Bullet;
    //오브젝트풀 사이즈(배열)
    public int ObjectPoolSize = 30;
    //오브젝트풀 배열(프리팹 로딩/보관)
    GameObject[] BulletPool; 

    void Start()
    {
        //배열에 오브젝트를 생성, 보관
        //배열 생성
        BulletPool = new GameObject[ObjectPoolSize];
        for(int i = 0; i < ObjectPoolSize; ++i)
        {
            //Bullet 인스턴스화 및 배열 보관
            BulletPool[i] = Instantiate(bullet) as GameObject;
            //비활성 상태 설정
            BulletPool[i].SetActive(false);
            //이름 부여(생략가능)
            BulletPool[i].name = "Bullet" + i;
        }
    }

    void Update()
    {
        Shooting();
    }

    void Shooting()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            for(int i = 0; i < ObjectPoolSize; ++i)
            {
                //비활성 상태일때만 동작.
                if(BulletPool[i].activeSelf == false)
                {   
                    //발사 위치 지정
                    BulletPool[i].transform.position = transform.position;
                    //활성상태로 교체
                    BulletPool[i].SetActive(true);

                    break;
                }
            }
        }
    }
}
```

##### Bullet
- 탄환 활성시 설정 시간만큼 이동 후 비활성(Bullet.SetActive(false))
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBhaviour
{
    //이동 속도
    [SerializeField]private float _moveSpeed = 1f;
    //활성 유지 시간
    [SerializeField]private float _activeTime = 5f; 
    //누적 시간
    private float CumulativeTime = 0f;

    void Update()
    {
        //활성시 이동속도로 이동
        transform.Translate(0f, 0f, _moveSpeed);
        RemoveBullet();
    }

    void RemoveBullet()
    {
        CumulativeTime += Time.deltaTime;
        
        //유지시간 초과시
        if(CumulativeTime >= _activeTime)
        {
            //누적시간 초기화
            CumulativeTime = 0f;
            //비활성 상태로 교체
            gameObject.SetActive(false);
        }
    }

}
```