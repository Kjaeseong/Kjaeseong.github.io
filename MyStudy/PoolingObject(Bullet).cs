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