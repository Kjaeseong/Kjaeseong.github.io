---
title:  "C#으로 파일 다루기"

categories:
  - Cs

toc: true
toc_sticky: true

date: 2022-08-15
last_modified_at: 2022-08-15
---

# C#으로 파일 다루기

## 개요
- C# 언어를 사용해 파일에 액세스 하는 방법을 알아본다.

### 핵심 개념
- C#에서 파일 정보와 디렉토리 정보를 다루는 방법을 익힘
- 이진 파이로가 텍스트 파일을 읽고 쓰는 방법을 익힘
- 직렬화를 통해 C#의 객체를 손쉽게 파일에 읽고 쓰는 방법을 이해

##  파일 정보와 디렉토리 정보 다루기
- 파일 : 저장 매체에 기록되는 데이터의 묶음
- 디렉토리 : 파일이 위치하는 주소, ( = 폴더 )
- System.IO 네임스페이스 아래 제공 클래스
  - File : 파일 생성, 복사, 삭제, 이동, 조회 처리 정적 메서드
  - FileInfo : File과 하는 일은 동일하지만 정적 메서드 대신 인스턴스 메서드 제공
  - Directory : 디렉토리 생성, 삭제, 이동, 조회 처리 정적 메서드
  - DirectoryInfo : Directory와 하는 일은 동일하지만 정적 메서드 대신 인스턴스 메서드 제공

## 파일을 읽고 쓰기 위해 알아야 할 것들
- 스트림(Stream) : 데이터가 흐르는 통로
  - 데이터 이동 시 디스크와 메모리 사이에 스트림을 놓은 후 파일에 담긴 데이터를 Byte 단위로 옮긴다.
  - 네트워크를 향해 데이터를 흘려보낼 수 있다
  - 네트워크에서 들어오는 데이터를 읽을 수도 있다
- 순차 접근 : 처음부터 끝까지 순서대로 접근(스트림은 보통 순차접근)
- 임의 접근 : 임의의 주소에 있는 데이터에 접근

## System.IO.Stream 클래스
- 자체로 입력 스트림, 출력 스트림의 역할을 모두 할 수 있다
- 추상클래스이므로 인스턴스를 직접 만들어 사용할 수 없다
  - 다양한 매체나 장치들에 대한 파일 입출력을 모델 하나로 다룰 수 있기 위함
- Stream ↔ 파생클래스 계보
  - Stream
    - FileStream : 디스크 파일에 데이터 기록
    - NetworkStream : 네트워크 피어에 데이터 전송
    - GZipStream : 데이터를 Gzip(GNU ZIP)형식으로 압축
    - BufferedStream : 데이터를 파일이나 네트워크에 즉시 기록하는 대신 메모리 버퍼에 담아뒀다 일정량이 쌓일 때마다 기록하게 해준다.
- ex>
  
```cs
Stream stream1 = new FileStream("a.dat", FileMode.Create);  
```


## 실수를 줄여주는 using선언
- using선언은 파일이나 소켓을 비롯한 자원을 다룰때도 유용
- using 선언으로 생성된 객체는 코드블록이 끝나면 outStream.Dispose() 호출

## 이진 데이터 / 텍스트 데이터 읽기/쓰기
- FileStream은 파일 처리를 위한 모든 걸 갖지만 반드시 Byte형식 혹은 Byte배열 형식으로 변환해야 함
- BinaryWriter/BinaryReader : 이진 데이터를 쓰기/읽기 위한 클래스
- StreamWriter/StreamReader : 텍스트 데이터를 쓰기/읽기 위한 클래스
- Stream으로부터 파생된 클래스의 인스턴스가 있어야 한다.

## 객체 직렬화(Serializable)
- 복합적인 데이터 형식을 쉽게 스트림에 쓰기/읽기 하기 위한 메커니즘
- 객체의 상태(필드에 저장된 값) 메모리나 영구 저장 장치에 저장이 가능한 0, 1의 순서로 바꿈
- 클래스 선언시 앞에 [Serializable]을 붙인다
- 직렬화하고 싶지 않은 필드는 앞에 [NonSerialized]를 붙인다
- ex>
  
```cs
[Serializable]
class MyClass
{
  [NonSerialized]
  public int Field;
}
```