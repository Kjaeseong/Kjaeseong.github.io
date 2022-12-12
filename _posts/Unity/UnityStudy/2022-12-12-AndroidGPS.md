---
title: "안드로이드 디바이스 GPS 스크립트" 

categories:
  - UnityStudy

toc: true
toc_sticky: true

use_math: false

date: 2022-12-12
last_modified_at: 2022-12-12
---

# 안드로이드 디바이스 GPS
- GPS센서에서 위도/경도/고도 반환 가능
- 프로젝트 진행 시 `AR Foundation` / `AR Core`와 접목해 실시간으로 사용자의 위치를 반환받기 위해 사용하였음.
- `GetDistAtoB()` 함수를 사용해 구면 좌표계를 기준으로 한 지구상의 실제 거리 반환 가능

```cs
using System.Collections;
using UnityEngine;
using System;

public class PositionSensor : MonoBehaviour
{
    private double lat;
    private double lng;
    private bool _isGpsStarted = false;

    private WaitForSeconds _retry;
    private LocationInfo _location;
    [SerializeField] private float _retryTime;

    private void Start()
    {
        _retry = new WaitForSeconds(_retryTime);

        StartCoroutine(GpsStart());
    }

    private IEnumerator GpsStart()
    {
        // 유저가 GPS 사용중인지 최초 체크
        if (!Input.location.isEnabledByUser)
        {
            yield break;
        }

        //GPS 서비스 시작
        Input.location.Start();

        //활성화될 때 까지 대기
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return _retry;
            maxWait -= 1;
        }

        //20초 지날경우 활성화 중단
        if (maxWait < 1)
        {
            yield break;
        }

        //연결 실패
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            yield break;

        }
        else
        {
            //접근 허가, 현재 위치 갱신
            _isGpsStarted = true;

            while (_isGpsStarted)
            {
                PositionSet();
                yield return _retry;
            }
        }
    }

    private void PositionSet()
    {
        _location = Input.location.lastData;
        lat = _location.latitude * 1.0d;
        lng = _location.longitude * 1.0d;
    }

    //위치 서비스 종료
    public void GpsStop()
    {
        if (Input.location.isEnabledByUser)
        {
            _isGpsStarted = false;
            Input.location.Stop();
            StopCoroutine(GpsStart());
        }
    }

    public double GetLat()
    {
        return lat;
    }

    public double GetLong()
    {
        return lng;
    }   

    public Vector2 GetEarthPos()
    {
        return new Vector2((float)GetLat(), (float)GetLong());
    }

    // public double GetAzimuth()
    // {
    //     return _pose.Heading;
    // }

    public bool GetIsGpsStart()
    {
        return _isGpsStarted;
    }

    /// <summary>
    /// A에서 B까지의 거리 반환(구면좌표계, 미터(M) 기준)
    /// </summary>
    /// <param name="A_Lat">시작점 위도</param>
    /// <param name="A_Long">시작점 경도</param>
    /// <param name="B_Lat">목표지점 위도</param>
    /// <param name="B_Long">목표지점 경도</param>
    /// <returns></returns>
    public double GetDistAtoB(double A_Lat, double A_Long, double B_Lat, double B_Long)
    {
        double Theta;
        double Distance;

        Theta = A_Long - B_Long;

        Distance = Math.Sin(deg2rad(A_Lat)) * Math.Sin(deg2rad(B_Lat)) + Math.Cos(deg2rad(A_Lat)) * Math.Cos(deg2rad(B_Lat)) * Math.Cos(deg2rad(Theta));
        Distance = Math.Acos(Distance);
        Distance = rad2deg(Distance);

        Distance = Distance * 60 * 1.1515;
        Distance = Distance * 1.609344;
        Distance = Distance * 1000.0;

        return Distance;
    }

    private double deg2rad(double deg)
    {
        return (double) (deg* Math.PI / (double)180d);
    }
    private double rad2deg(double rad)
    {
        return (double)(rad * (double)180d / Math.PI);
    }
}
```