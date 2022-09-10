---
title: "게임기초수학_행렬" 

categories:
  - Etc

toc: true
toc_sticky: true

use_math: true

date: 2022-09-08
last_modified_at: 2022-09-09
---

# 게임 기초 수학

## 행렬
- $m*n$ 행렬은 $m$행과 $n$열을 가지는 일반적인 수 배열
- 행과 열의 수는 행렬의 차원을 결정
- 첫 번째 아래첨자는 행, 두번째 아래첨자는 열을 뜻한다.
- 일반적으로 굵은 대문자 사용
  - 3 * 3 행렬 $M = \begin{bmatrix}m_{11}&m_{12}&m_{13} \\\\ m_{21}&m_{22}&m_{23} \\\\ m_{31}&m_{32}&m_{33}\end{bmatrix}$ <br/>
  - 2 * 4 행렬 $B = \begin{bmatrix} b_{11} & b_{12} & b_{13} & b_{14} \\\\  b_{21} & b_{22} & b_{23} & b_{24}  \end{bmatrix}$<br/>
  - 3 * 2 행렬 $C = \begin{bmatrix} c_{11} & c_{12} \\\\ c_{21} & c_{22} \\\\ c_{31} & c_{32} \end{bmatrix}$
- 행 벡터 : 한 개의 행을 가지는 행렬
  - V = $\begin{bmatrix} v_1 & v_2 & v_3 & v_4 \end{bmatrix}$
- 열 벡터 : 한 개의 열을 가지는 행렬
  - U = $\begin{bmatrix} u_x \\\\ u_y \\\\ u_z \end{bmatrix}$

## 상등, 스칼라 곱, 더하기
$A = \begin{bmatrix} a_{11} & a_{12} \\\\ a_{21} & a_{22} \end{bmatrix}$   $B = \begin{bmatrix} b_{11} & b_{12} \\\\ b_{21} & b_{22} \end{bmatrix}$<br/><br/>$C = \begin{bmatrix} c_{11} & c_{12} \\\\ c_{21} & c_{22} \end{bmatrix}$ $D = \begin{bmatrix} d_{11} & d_{12} & d_{13} & d_{14} \\\\ d_{21} & d_{22} & d_{23} & d_{24} \end{bmatrix}$
- 동일한 차원을 가지고, 각 대응 항목이 같은 두 행렬은 같다
  - Ex> $A = C$, $A \ne B$ , $A \ne D$
 - 행렬의 각 항목을 스칼라로 곱하는 방법으로 행렬을 스칼라로 곱할 수 있다.
  - Ex> $k = 2$일 때,<br/>$kD = \begin{bmatrix} k\cdot d_{11} & k\cdot d_{12} & k\cdot d_{13} & k\cdot d_{14} \\\\ k\cdot d_{21} & k\cdot d_{22} & k\cdot d_{23} & k\cdot d_{24} \end{bmatrix}$
- 행렬이 동일한 차원을 가지는 경우 더할 수 있다.
  - 각 행렬의 동일한 항목을 더한다.
  - Ex> <br/> $A + B = \begin{bmatrix} a_{11} + b_{11} & a_{12} + b_{12} \\\\ a_{21} + b_{21} & a_{22} + b_{22} \end{bmatrix}$
- 행렬이 동일한 차원을 가지는 경우 뺄 수 있다.
  - Ex> <br/> $A - B = \begin{bmatrix} a_{11} - b_{11} & a_{12} - b_{12} \\\\ a_{21} - b_{21} & a_{22} - b_{22} \end{bmatrix}$

### 곱
- 3D 컴퓨터 그래픽에서 행렬을 이용하기 위한 가장 중요한 연산
- 벡터의 변환을 수행하거나 몇 가지의 변환을 조합하는데 이용
- 행렬 곱 AB를 얻기 위해
  - A의 열, B의 행 수가 반드시 같아야 한다.
  - 위 조건이 만족되면 곱이 정의될 수 있다.
- A * B와 B * A의 결과는 다르다.
- Ex> <br/> $A = \begin{bmatrix} a_{11} & a_{12} & a_{13} \\\\ a_{21} & a_{22} & a_{23} \end{bmatrix} B = \begin{bmatrix}  b_{11} & b_{12} & b_{13} \\\\ b_{21} & b_{22} & b_{23} \\\\ b_{31} & b_{32} & b_{33} \end{bmatrix}$ <br/>
  - $A \times B = R \begin{bmatrix} r_{11} & r_{12} & r_{13} \\\\ r_{21} & r_{22} & r_{23} \end{bmatrix}$ <br/> 
  $ r_{11} = (a_{11} \cdot b_{11})+(a_{12} \cdot b_{21})+(a_{13} \cdot b_{31})$ <br/> 
  $ r_{12} = (a_{11} \cdot b_{12})+(a_{12} \cdot b_{22})+(a_{13} \cdot b_{32})$ <br/> 
  $ r_{13} = (a_{11} \cdot b_{31})+(a_{12} \cdot b_{32})+(a_{13} \cdot b_{33})$ <br/> 
  $ r_{21} = (a_{21} \cdot b_{11})+(a_{22} \cdot b_{21})+(a_{23} \cdot b_{31})$ <br/> 
  $ r_{22} = (a_{21} \cdot b_{12})+(a_{22} \cdot b_{22})+(a_{23} \cdot b_{32})$ <br/> 
  $ r_{23} = (a_{21} \cdot b_{13})+(a_{22} \cdot b_{23})+(a_{23} \cdot b_{33})$ <br/> 

## 항등 행렬
- $ \begin{bmatrix} 1 & 0 & 0 \\\\ 0 & 1 & 0 \\\\ 0 & 0 & 1   \end{bmatrix} $
- 모든 항목이 0인 정방 행렬, 중심 대각선의 항목들은 모두 1
- 하나의 행렬을 항등 행렬로 곱해도 행렬이 변하지 않는다.
- 항등 행렬로의 곱은 행렬 곱이 교환적인 하나의 특별한 예로 꼽힌다.
  - 항등 행렬은 행렬에 있어 숫자 '1'이라 생각하자.

## 역행렬
- 곱하기와 반대의 의미를 가지는 역 연산(나누기와 다르다)
- 규칙 :
  - 정방 행렬만이 역행렬을 가진다. (역행렬에 대한 얘기는 정방 행렬에 대한 얘기다) 
  - $n \times n$ 행렬 $M$의 역행렬은 $M^{-1}$로 표기할 수 있다
  - 모든 정방 행렬이 역행렬을 가지지는 않는다
  - 행렬 * 역행렬은 항등 행렬이다
    - $MM^{-1} = M^{-1}M = I$
    - 행렬을 자신의 역행렬과 곱할때는 상호 교환적이다.

## 행렬의 전치
- $A = \begin{bmatrix} a_{11} & a_{12} & a_{13} \\\\ a_{21} & a_{22} & a_{23} \end{bmatrix}$ , $A^T = \begin{bmatrix} a_{11} & a_{21}\\\\ a_{12} & a_{22} \\\\ a_{13} & a_{23} \end{bmatrix}$
- 행렬의 열과 행을 교환하면 행렬의 전치(tarnspose)를 수행할 수 있다.
- $m \times n$행렬의 전치는 $n \times m$ 행렬.
  - 행렬 $M$ 의 전치는 $M^T$ 로 표기

## D3DX 행렬
- Direct3D 애플리캐이션 프로그래밍 시 4*4 행렬과 1*4행 벡터만을 사용
- 다음과 같은 행렬 곱이 정의 된다는 뜻
  - 벡터-행렬 곱 : v가 $1\times4$ 행 벡터, T가 $4\times4$ 행렬이면 곱 vT정의, 결과는 $1\times4$ 행 벡터가 된다. 
  - 행렬-행렬 곱 : R, T가 $4\times4$ 행렬이면 TR, RT가 정의, 두 경우 모두 $4\times4$ 행렬이 된다.
    - 단, 항상 TR = RT 는 아니다.

## 기본적인 변환
-  Direct3D 이용 프로그래밍에서 변환 표현을 위해 4*4 행렬을 사용한다.
-  4*4 행렬을 통해 원하는 모든 변환을 표현할 수 있다.

### 이동 행렬
- ![00](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/220909_Matrix00.png?raw=true)
- $T(p) = \begin{bmatrix} 1 & 0 & 0 & 0 \\\\ 0 & 1 & 0 & 0 \\\\ 0 & 0 & 1 & 0 \\\\ p_x & p_y & p_z & 1 \end{bmatrix}$
- 그래프 상 $(x, y, z, 1)$ 벡터를 $T(p)$ 행렬로 곱하는 경우
  - $x$축 $p_x$ 이동
  - $y$축 $p_y$ 이동
  - $z$축 $p_z$ 이동

### 회전 행렬
- ![01](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/220909_Matrix01.png?raw=true)
- 행렬 이용시 $x-,y-,z-$ 축에서 벡터 라디안 회전 가능
  - 각도는 회전축을 내려다 볼 때 시계 방향으로 측정
- $x-$ 축 회전 행렬 $X(\vartheta) = \begin{bmatrix} 1 & 0 & 0 & 0 \\\\ 0 & cos\theta & sin\theta & 0 \\\\ 0 & -sin\theta & cos\theta & 0 \\\\ 0 & 0 & 0 & 1 \end{bmatrix}$
- $y-$ 축 회전 행렬 $Y(\vartheta) = \begin{bmatrix} cos\theta & 0 & -sin\theta & 0 \\\\ 0 & 1 & 0 & 0 \\\\ sin\theta & 0 & cos\theta & 0 \\\\ 0 & 0 & 0 & 1 \end{bmatrix}$
- $z-$ 축 회전 행렬 $Z(\vartheta) = \begin{bmatrix} cos\theta & sin\theta & 0 & 0 \\\\ -sin\theta & cos\theta & 0 & 0 \\\\ 0 & 0 & 1 & 0 \\\\ 0 & 0 & 0 & 1 \end{bmatrix}$
- 행렬 $R$ 의 역은 전치 $R^{T} = R^{-1}$ 이다.
  - 이와 같은 행렬은 직각이라 할 수 있다.

### 크기 변형 행렬
- ![02](https://github.com/Kjaeseong/Kjaeseong.github.io/blob/main/_posts/img/220909_Matrix02.png?raw=true)
- $S(q) = \begin{bmatrix} q_x & 0 & 0 & 0 \\\\ 0 & q_y & 0 & 0 \\\\ 0 & 0 & q_z & 0 \\\\ 0 & 0 & 0 & 1 \end{bmatrix}$
- 위 행렬을 벡터와 곱하는 경우 크기 변경
  - $x-$ 축으로 $q_x$ 만큼
  - $y-$ 축으로 $q_y$ 만큼
  - $z-$ 축으로 $q_z$ 만큼
- 크기 변형 행렬의 역은 각 크기 변형 인자의 역으로 얻어진다.
  - $S^{-1} = S(\frac{1}{q_x},\frac{1}{q_y},\frac{1}{q_z}) = \begin{bmatrix} \frac{1}{q_x} & 0 & 0 & 0 \\\\ 0 & \frac{1}{q_y} & 0 & 0 \\\\ 0 & 0 & \frac{1}{q_z} & 0 \\\\ 0 & 0 & 0 & 1 \end{bmatrix} $
