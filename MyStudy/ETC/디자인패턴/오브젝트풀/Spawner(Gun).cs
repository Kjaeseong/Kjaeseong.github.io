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