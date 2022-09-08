---
title: "(작성중)게임기초수학_벡터" 

categories:
  - UnityStudy

toc: true
toc_sticky: true

use_math: true

date: 2022-09-08
last_modified_at: 2022-09-08
---

# 게임기초수학_벡터

## 공간의 벡터
![00](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/220908_vector00.png?raw=true)
- 벡터 : 
  - 기하학적으로 바향을 가진 선분으로 표현
  - 길이, 가리키는 방향(크기와 놈(norm)으로도 불린다)을 가진다.
- 물리적 양을 모델링하는데 유용하다
- 때로 방향만을 모델링하기 위해 사용
  - ex> 빛이 비추는 방향, 다각형의 방향, 카메라 방향 등
- '위치'는 벡터의 속성이 아니다
  - 다른 위치라도 동일한 길이와 방향을 가리키는 두 개의 벡터는 동일
- 표준점 내 위치한 벡터의 머리 좌표를 이용해 벡터 기술 가능
  - 포인트와 벡터를 혼동하는 일이 있을 수 있다.
    > 포인트 : 좌표 시스템 내 한 위치를 나타낸다
    > 벡터 : 크기와 방향을 가진다
- 표현법
  - 2차원 : $u = (u_x, u_y)$
  - 3차원 : $n = (n_x, n_y, n_z)$
  - 4차원 : $c = (cx, cy, cz, \sqrt a+cw)$
  
![01](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/220908_vector01.png?raw=true)
- 왼손 좌표계는 왼쪽, 오른손 좌표계는 오른쪽 기준


### 4가지의 특별한 벡터
- 영 벡터 : 
  - 모든 성분에 0을 가진다.
  - 굵은 0으로 표시
  - $0 = (0, 0, 0)$
- -3의 표준 기저 벡터. 각 i, j, k로 표기
  - $i = (1, 0, 0)$
  - $j = (0, 1, 0)$
  - $k = (0, 0, 1)$
  - 좌표 시스템의 $x-$, $y-$, $z-$ 축을 따라 진행. 모두 1의 크기를 가진다.
  - 크기가 1인 벡터이므로, 단위벡터로 부르기도 한다.
  
![02](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/220908_vector02.png?raw=true)

### 벡터 상등
- 대수적으로 벡터가 동일한 차원이고 대응되는 성분이 같은 경우 동일한 것으로 본다.
  - Ex><br/>$u_x = v_x$ , $u_y = v_y$ , $u_z = v_z$ <br/>일 때<br/>$(u_x, u_y, u_z) = (v_x, v_y, v_z)$<br/>
  
### 벡터의 크기 계산
- 기하학적으로 벡터의 크기는 방향을 가진 선분의 길이
- 벡터의 성분이 주어졌다면, 크기를 대수학적으로 계산할 수 있다.
  - Ex><br/>
  문제 : $u = (1, 2, 3)$과 $v = (1, 1)$ 벡터의 크기를 구하라.<br/>$||u|| = \sqrt {u_x^2 + u_y^2 + u_z^2} $<br/>
  답 : <br/>$||u|| = \sqrt {1^2+2^2+3^2} = \sqrt {1+4+9} = \sqrt {14}$<br/>$||v|| = \sqrt {1^2+1^2} = \sqrt 2$<br/>

### 벡터의 정규화
- 벡터의 크기를 1로 만들어 단위 벡터가 되도록 한다.
- 벡터의 각 성분을 벡터의 크기로 나누면 정규화된다.
  - Ex1> 예시
    $\hat u = \frac {u}{||u||} = (\frac {u_x}{||u||}. \frac {u_y}{||u||}, \frac {u_z}{||u||})$
  - Ex2><br/>문제 : $u = (1, 2, 3)$ 과 $v = (1, 1)$ 벡터를 정규화하라.
    - 답 : <br/>방정식에서 $||y|| = \sqrt {14}$ 와 $||v|| = \sqrt 2$를 얻는다. 따라서, <br/>$\hat u = \frac {u}{\sqrt {14}} = (\frac {1}{\sqrt {14}}, \frac {2}{\sqrt {14}}, \frac {3}{\sqrt {14}})$<br/>$\hat v = \frac {v}{\sqrt 2} = (\frac {1}{\sqrt 2}, \frac {1}{\sqrt 2})$

### 벡터 더하기
- ![03](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/220908_vector03.png?raw=true)
- 대응되는 성분을 더하면 두 벡터를 더할 수 있다
- 반드시 동일한 차원을 가져야 한다.
- Ex> $u + v = (u_x + v_x , u_y + v_y, u_z + v_z)$
  - 순서를 다르게 해도 값은 동일하다.

### 벡터 빼기
- ![04](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/220908_vector04.png?raw=true)
- 벡터의 대응되는 성분을 뺀다
- 반드시 동일한 차원을 가져야 한다.
- 바라보고 있는 방향 벡터를 구할때 많이 쓴다.(중요)
  - 플레이어 방향 = 목표 - 플레이어;
- Ex> $u - v = u + ( -v ) = ( u_x - v_x, u_y - v_y, u_z - v_z)$

### 스칼라 곱
- 벡터는 스칼라로 곱하는 것이 가능
- 벡터의 배율 변경
- 음수로 곱하지 않는 이상 벡터의 방향은 변하지 않는다
- 음수를 이용하는 경우 벡터의 방향이 뒤집힌다.
- Ex> $k$u$=(ku_x, ku_y, ku_z)$

### 내적
- 벡터 수학에서 정의하는 두 가지 곱셈 중 하나.  <br/> u * v = $u_xv_x + u_yv_y + u_zv_z = s$ <br/>
- 코사인의 법칙을 이용하면 U * V = ||U||||V||의 관계를 발견할 수 있다.
- 두 벡터 간의 내적이 벡터 크기배율을 가진 벡터 간 각도의 코사인이다.
  - U와 V가 모두 단위 벡터일 경우 U * V는 두 벡터 간 각도의 코사인이 된다.
- 내적의 몇가지 특징
  - u * v = 0 이면, u와 v는 직각이다.
  - u * v > 0 이면, 두 벡터 간의 각도는 90도보다 작다
  - u * v < 0 이면, 두 벡터 간의 각도는 90도보다 크다

### 외적
- 벡터 수학에서 정의하는 두 가지 곱셈 중 하나
- u와 v 두 벡터의 외적을 수행하면 다른 벡터인 p를 얻으며, 이는 u와 v에 서로 직각을 이룬다.
  - p는 u에 직각이다
  - p는 v에 직각이다. <br/> p = u * v = $[(u_yv_z - u_zv_y), (u_zv_x - u_xv_z), (u_xv_y - u_yv_x)]$ <br/>
- 성분 형식
  - $p_x = (u_yv_z - u_zv_y)$
  - $p_y = (u_zv_x - u_xv_z)$
  - $p_z = (u_xv_y - u_yv_x)$
- ![05](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/220908_vector05.png?raw=true)
  - 수식 순서에 따라 그래프 방향이 달라질 수 있다.
  - 외적이 교환적이지 않다.
  - 왼손 / 오른손 규칙에 따라 각 손의 좌표시스템으로 이용해야 한다.
  - 손 좌표시스템 참고자료

