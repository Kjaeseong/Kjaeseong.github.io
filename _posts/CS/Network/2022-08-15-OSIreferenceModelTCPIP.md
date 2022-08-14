---
title: "(작성중)Network - OSI 참조 모델(OSI reference model)과 TCP/IP" 

categories:
  - Network

toc: true
toc_sticky: true

date: 2022-08-15
last_modified_at: 2022-08-15
---

# Network - OSI 참조 모델(OSI reference model)과 TCP/IP
## OSI 참조 모델
- 국제 표준기구(ISO)에서 제정
- 컴퓨터 사이의 통신 단계를 7개 계층 분류/기능 정의
- OSI 7계층이라고도 부른다.
  
| 계층 | 이름        | 역할                         | 주요 프로토콜            |
|----|-----------|----------------------------|--------------------|
| 7  | 응용 계층     | 응용 프로그램과 통신 프로그램간 인터페이스 제공 | HTTP, FTP          |
| 6  | 표현 계층     | 데이터의 표현 및 암호화 방식           | ASCII, MPEG, SSL   |
| 5  | 세션 계층     | 세션의 시작 및 종료 제어             | TCP session setup  |
| 4  | 전송 계층     | 종단 프로그램 간의 데이터 전달          | TCP, UDP           |
| 3  | 네트워크 계층   | 종단 장비 간의 데이터 전달            | IP, ICMP           |
| 2  | 데이터 링크 계층 | 인접 장비와 연결을 위한 논리적 사양       | Ethernet, PPP, ARP |
| 1  | 물리 계층     | 인접 장비와 연결을 위한 물리적 사양       | 100Base-TX, V.35   |

#
### 1. 물리 계층(physical layer)
- 두 인접 장비 간 통신 신호 전송
- 구성품들의 기계적(mechanical), 기능적(functional), 전기적(electrical) 사양 정의
  - ex> RJ45(랜케이블 커넥터) 크기/모양/케이블접속/신호처리 등
- 물리 계층의 표준을 이용해 한쪽에서 전송하는 비트를 상대측에서 수신, 구분 가능
#
### 2. 데이터 링크 계층(data link layer)
- 링크 계층 이라고도 한다.
- 라우터(router)로 구분된 구간에서 프레임(frame)이라는 데이터의 묶음(PDU, Protocol Data Unit)의 전달 관리
- 링크 계층 프로토콜 :
  - 용도에 따른 프레임의 종류를 정의
  - 프레임 내 각 필드(field)의 길이, 의미 지정
  - 링크 계층에서 사용하는 주소를 정의
  - 에러 발생 확인 및 에러 복구 절차 등 지정
  - Ethernet, PPP, 프레임 릴레이(frame relay), HDLC(High-level Data Link Control)
#
### 3. 네트워크 계층(network layer)
- 통신의 종단장비(종단장치, end system)간에 패킷(packet)이라는 데이터의 묶음 전달
- 장비를 구분하기 위한 주소 정의
- 네트워크 계층 프로토콜 :
  - IP, ICMP(Internet Control Message Protocol), IPv6, ICMPv6
#
### 4. 전송 계층(transport layer)
- 종단장비에서 동작 중인 '응용 계층' 간 세그먼트(segment)라는 데이터의 묶음 전달
- 전송 계층의 프로토콜 : 
  - TCP, UDP
#
### 5. 세션 계층(session layer)
- 종단장비 간 세션(통신)의 시작, 종료 및 관리 절차 등 정의
- 세션 계층 이상에서 송수신하는 데이터의 단위를 메시지(message)라고 한다.
- 세션 계층의 프로토콜 : 
  - NetBIOS, TCP 세션 관리 절차
#
### 6. 표현 계층(presentation layer)
- '응용 계층'에 대해 데이터 표현 방식 변환, 암호화 등의 서비스를 제공
- 대표적인 표현 계층의 서비스 : ASCII 문자 -> EBCDIC 문자 변환
#
### 7. 응용 계층(application layer)
- 응용 프로그램 ~ 통신 프로그램 간 인터페이스를 제공
- 대표적인 응용 계층 프로토콜 : 
  - 원격 접속을 위한 텔넷(telnet), 파일 전송을 위한 FTP, 도메인 이름을 IP 주소로 변환하는 DNS, 메일 전송을 위한 SMTP 등
#
#
### 인캡슐레이션과 디캡슐레이션
- 인캡슐레이션(encapsulation) : 송신 측에서 상위 계층 정보에 자신의 헤더 추가
- 디캡슐레이션(decapsulation) : 수신 측에서 자신의 헤더 제거
- 트레일러(trailer) : '링크 계층'에서 에러를 확인하기 위해 프레임의 꼬리에 추가하는 필드
![이미지1][인/디캡슐레이션]
OSI참조 모델과 인캡슐레이션, 디캡슐레이션
출처 : https://www.technologyuk.net/telecommunications/telecom-principles/osi-reference-model.shtml

## TCP/IP
- TCP/IP는 인터넷에서 사용되는 여러 가지 프로토콜을 통틀어 지칭하는 단어
- 4계층으로 분류.

| 계층 | 이름     | 주요 프로토콜                      |
|----|--------|------------------------------|
| 5  | 응용 계층  | HTTP, FTP, telnet, SMTP, DNS |
| 4  | 전송 계층  | TCP, UDP                     |
| 3  | 인터넷 계층 | IP, ICMP                     |
| 2  | 링크 계층  | ARP                          |

