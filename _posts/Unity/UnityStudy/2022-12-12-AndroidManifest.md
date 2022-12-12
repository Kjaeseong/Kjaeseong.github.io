---
title: "안드로이드 권한 요청과 매니페스트" 

categories:
  - UnityStudy

toc: true
toc_sticky: true

use_math: false

date: 2022-12-12
last_modified_at: 2022-12-12
---

# 안드로이드 매니페스트
- 애플리케이션에 대한 필수적인 정보를 안드로이드 플랫폼에 전달한다.
- 패키지 이름, 액티비티 이름, 메인 작업(앱 엔트리 포인트), 설정, Android 버전 지원, 하드웨어 기능 지원 및 권한이 포함되어 있다
- 권한 요청을 위해선 필수적으로 확인해야 한다.

## 원본 파일과 오버라이드
- 원본 파일 경로
  - 프로젝트 실행 중 `프로젝트 폴더 최상단/Temp/gradleOut/unityLibrary/src/main/AndroidManifest.xml`
- 오버라이드
  - 원본 파일을 `Assets/Plugins/Android/AndroidManifest.xml`로 복사한다.
    - `Plugins/Android` 폴더가 존재하지 않으면 생성하면 된다.

```xml
<manifest xmlns:android="http://schemas.android.com/apk/res/android" package="com.unity3d.player" xmlns:tools="http://schemas.android.com/tools">
  <application>
    <activity android:name="com.unity3d.player.UnityPlayerActivity"
    .
    .
    .
    </activity>
    <meta-data android:name="unity.splash-mode" android:value="0" />
    .
    .
    .
  </application>
  <uses-feature android:glEsVersion="0x00030000" />
  .
  .
  .
  [Add Permission]
</manifest>
```

- `[Add permission]`위치에 권한요청을 위한 스크립트를 추가한다.
  - 카메라 : `<uses-permission android:name="android.permission.CAMERA"/>`
  - 마이크 : `<uses-permission android:name="android.permission.RECORD_AUDIO"/>`
  - 외부 저장소 쓰기 : `<uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE"/>`
  - 외부 저장소 읽기 : `<uses-permission android:name="android.permission.READ_EXTERNAL_STORAGE"/>`
  - 위치 정보(정확) : `<uses-permission android:name="android.permission.ACCESS_FINE_LOCATION"/>`
  - 위치 정보(덜 정확) : `<uses-permission android:name="android.permission.ACCESS_COARSE_LOCATION"/>`
  - 위치 정보(가상) : `<uses-permission android:name="android.permission.ACCESS_MOCK_LOCATION"/>`
  - 인터넷 : `<uses-permission android:name="android.permission.INTERNET"/>`
  - 네트워크 연결 상태 확인 : `<uses-permission android:name="android.ACCESS_NETWORK_STATE"/>`
- Android 6 이상 버전부터 런타임에서 스크립트로 권한을 요청한다.

```cs
using UnityEngine.Android;

public class PermissionTest : MonoBehaviour 
{
  private void Start()
  {
    // 카메라 권한 요청을 위한 예시

    // 카메라 사용권한이 수락되어 있지 않다면
    if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
    {
        //카메라 권한 요청
        Permission.RequestUserPermission(Permission.Camera);
    }
  }
}
```

