---
title: "Unity GoogleAR컨텐츠 개발_앵커" 

categories:
  - UnityStudy

toc: true
toc_sticky: true

use_math: false

date: 2022-09-23
last_modified_at: 2022-09-23
---

# Unity GoogleAR 컨텐츠 개발_앵커
- [공식문서 링크](https://developers.google.com/ar/develop/anchors)

## 앵커
- 가상 객체의 위치를 고정하는 틀
- 가상 객체가 공간 내 동일한 위치와 방향을 유지하도록 한다.

### 첫 사용시 검토할 사항
- 월드 스페이스
  - 카메라와 객체 배치 포지션
  - 카메라와 객체 위치는 월드 내에서 프레임 단위 업데이트
- 포즈
  - 월드 스페이스에서 객체의 위치와 방향
  - IOS에서는 Transform이라고 한다.
- 앵커 생성 시 현재 프레임의 월드스페이스 좌표를 기준으로 방향을 나타내는 포즈 사용.
- 앵커에 하나 이상의 객체 연결하면 현존 위치에 표시
- 프레임 단위 업데이트에 따라 포즈가 조정되므로, 앵커가 객체를 업데이트한다.

## Scene 내 앵커 사용
- 앵커를 사용하기 위해 코드해서 실행할 사항
  - Trackable(Ex> Plane) 또는 ARCore 세션의 컨텍스트에서 앵커 생성
  - 앵커에 객체를 연결

### 앵커 컨텍스트 선택

| 객체 생성 시                                                                                         | .                 |
|-------------------------------------------------------------------------------------------------|-------------------|
| 추적 가능'으로 표시. Trackable과 동일한 회전 효과 적용<br><br>Plane 표면과 붙은채로 고정하기 위함<br>Trackable 위치를 기준으로 한 위치 유지 | 추적 장치에 앵커 부착      |
| 월드 스페이스에서 동일한 포즈를 유지                                                                            | 앵커를 ARCore 세션에 부착 |

### 앵커에 객체 연결
- 앵커에 연결된 객체의 일반적인 공간 관계
  - 객체끼리
  - 추적 가능한 요소
  - 월드스페이스에서의 포지션

## 앵커 가이드라인
- 앵커에 연결된 객체들은 서로 상대적인 위치를 유지한다
- 필요한 앵커만 사용시 CPU효율을 높일 수 있다.

### 앵커 재사용
- 각 객체에 대응해 새로운 앵커를 만드는 대신, 주변 객체에 동일한 앵커를 사용해야 한다.
- 객체가 월드스페이스나 Trackable 위치에 고정된 공간 관계를 유지해야 하는 경우, 객체에 새 앵커를 사용
- 각 객체마다 앵커가 사용되는 경우, 앵커마다 프레임 업데이트 시 개별적으로 객체 포즈를 조정한다.
- 개별적인 앵커와 객체는 상대적으로 이동, 회전할 수 있어 위치가 어긋나는 등 AR 일루전이 깨질 수 있다.

### 객체를 앵커에 가깝게 유지
- 앵커에 객체 고정 시 앵커에 가까이 있어야 한다.
  - 8M(26ft.) 이상 떨어뜨리지 않는다.
  - 위 범위에서 벗어나야 하는 경우 새 앵커를 생성한다.

### 미사용 앵커 분리
- 더 이상 필요하지 않는 앵커를 분리한다.
  - 연산을 줄여 성능 상승을 기대할 수 있다.
  - 앱 내 Trackable은 CPU 연산 발생.
  - ARCore는 앵커가 부착된 Trackable을 해제하지 않는다.

## 앵커 유형

| 앵커                                    | 설명                                                                                                                          |
|---------------------------------------|-----------------------------------------------------------------------------------------------------------------------------|
| 로컬 앵커<br/>(Local anchor)              | 로컬에 앱과 함게 저장<br/>앰의 해당 인스턴스에서만 유효<br/>유저가 앵커를 배치한 위치에 있어야 한다"                                                               |
| <br/>클라우드 앵커<br/>(Cloud Anchor)      | 구글 클라우드에 저장<br/>앱 인스턴스간 공유될 수 있다<br/>유저가 앵커를 배치한 위치에 있어야 한다.                                                               |
| <br/>지리정보 앵커<br/>(Geospatial anchor) | 위도,경도,고도 및 구글의 VPS데이터 기반<br/>전 세계의 정확한 위치 제공<br/>앵커가 앱 인스턴스간 공유<br/>앱 사용시 인터넷에 연결되어 있고, VPS를 사용할 수 있다면 유저가 원격 위치에 앵커 배치 가능  |