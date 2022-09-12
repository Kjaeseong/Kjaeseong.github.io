---
title: "(작성중)이벤트 함수" 

categories:
  - UnityStudy

toc: true
toc_sticky: true

use_math: false

date: 2022-09-12
last_modified_at: 2022-09-12
---

# 이벤트 함수

## 1. 이벤트 함수 실행 순서
- [Unity Documentation](https://docs.unity3d.com/kr/2021.3/Manual/ExecutionOrder.html)참조
- 각 이벤트 함수의 실행 순서를 숙지하고 있어야 버그 방지가 가능하다.

### 1.1. 첫 번째 씬 로드
- 씬 시작 시 한번 호출

#### Awake()
- Start 함수 전 호출.
- 프리팹이 인스턴스화 된 직후 호출
- 게임 오브젝트 시작시 비활성 상태인 경우 활성화될 때 호출된다.
  - 스크립트(컴포넌트)가 비활성 상태에서도 실행.
  - Ex>
    - 오브젝트 활성, 컴포넌트 비활성 -> 실행
    - 오브젝트 비활성, 컴포넌트 비활성 -> 실행하지 않음

#### OnEnable()
- 해당 컴포넌트, 혹은 오브젝트가 활성화 될 때마다 실행
- 레벨 로드, 스크립트를 포함한 게임오브젝트가 인스턴스화될 때와 같이 MonoBehaviour를 생성할때 호출

### 1.2. 에디터

#### Reset()
- 오브젝트에 처음 연결하거나 Reset 커맨드 사용시 스크립트 프로퍼티 초기화를 위해 호출

#### OnValidate()
- 스크립트 프로퍼티가 설정될 때마하 호출(오브젝트 역직렬화될 때 포함)
- 씬을 열 때와 도메인을 다시 로드한 후와 같이 다양한 시기에 발생

### 1.3. 첫 번째 프레임 업데이트 전

#### Start()
- 인스턴스 활성화시 첫 번재 프레임 업데이트 전 호출
- 스크립트(컴포넌트)가 활성화 된 상태에서만 실행

### 1.4. 업데이트 순서

#### FixedUpdate()
- 프레임에 기반하지 않고 고정적이고 동일한 시간에 기반해 실행
  - 환경에 상관없이 물리처리 실행 가능
- Default 0.02초(초당 50회) 마다 실행

#### Update()
- 프레임당 1회 호출
- 일반적인 작업은 여기서 이뤄진다.

#### LateUpdate()
- 프레임당 1회 호출(Update 함수 종료 직후)
- 일반적으로 3인칭 카메라에 사용
  - 케릭터를 Update로 움직이는 경우 여기에서 카메라의 움직임 수행
  - 카메라가 케릭터 포지션 추적 전 완전히 움직였는지 확인 가능
- Ex>
  - 카메라와 케릭터는 각 스크립트로 나눠져 있고, 양쪽 다 Update로 처리하는 경우
  - 카메라의 Update가 먼저 실행되는 경우도 있다.

### 1.5. 애니메이션 업데이트 루프 - 내용 추가 요.

#### OnStateMachineEnter()
- State Machine Update 단계 중 

#### OnStateMachineExit()

#### Fire Animation Events

#### StateMachineBehaviour (OnStateEnter/OnStateUpdate/OnStateExit)

#### OnAnimatorMove

#### StateMachineBehaviour(OnStateMove)

#### OnAnimatorIK

#### StateMachineBehaviour(OnStateIK)

#### WriteProperties

### 1.6. 충돌 관련

#### OnTrigger[Enter / Exit / Stay] (Collider other)
- Enter : 충돌이 시작되는 순간
- Exit : 충돌이 종료되는 순간(범위 밖으로 벗어나는 순간)
- Stay : 충돌이 지속되는 동안
- 충돌한 상대 오브젝트 정보는 other가 참조한다.
  - 상대 오브젝트의 물리적인 정보를 담지 않는다.
- 자신, 상대중 하나는 반드시 Rigidbody 컴포넌트를 지녀야 한다.
  - IsKinematic 여부는 상관 없음
- 나와 상대방 모두 Collider 컴포넌트를 지녀야 한다.
  - 단, 둘 중 하나는 반드시 IsTrigger로 설정해야 한다.

#### OnCollisionEnter(Collision other)
- 상대 오브젝트에 대한 정보를 많이 담고 있다.
  - Transform
  - Collider
  - GameObject
  - Rigidbody
  - 상대속도..?
- 자신, 상대중 하나는 반드시 Rigidbody컴포넌트를 지녀야 한다.
  - IsKinematic이 꺼져 있어야 한다.
- 나와 상대방 모두 Collider 컴포넌트를 지녀야 한다.

### 1.7. 기즈모

#### OnDrawGizmos()
- 에디터 내 씬 화면에서 기즈모를 그린다.
  - 게임 화면에서는 보이지 않는다.
- 해당 스크립트가 붙은 오브젝트의 기즈모는 항상 그린다.

#### OnDrawGizmosSelected()
- 에디터 내 씬 화면에서 기즈모를 그린다.
  - 게임 화면에서는 보이지 않는다.
- 해당 스크립트가 붙은 오브젝트를 선택했을 때만 그린다.

### 1.8. 비활성 / 파괴

#### OnDisable()
- 해당 스크립트가 붙어 있는 오브젝트가 비활성화 될 때마다 실행
  - '컴포넌트'가 켜져 있다가 꺼지는 상황에 실행

#### OnDestroy()
- 오브젝트가 파괴(Destroy)될 때 실행