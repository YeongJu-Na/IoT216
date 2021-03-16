# IoT216
### C++ 1강
* Object Oriented Programming
* IDE - Editor, Compiler, Linking + Debugging
* C++표준 헤더: c를 더하고, .h뺀 형태 ex) <math.h> → <cmath>
  * 기본 헤더 파일: stdio.h → iostream
    * std::cout<<’출력대상’;	//std클래스의 cout이라는 요소
    * c++을 이용한 콘솔프로그램에만 많이 사용 
  * key
    * ctrl + k + c: (해당 블록) 주석처리 / ctrl + k + u: 주석 처리 해제
  * 내장함수(?)
    * sqrt()    
  * namespace
    * 이름의 충돌을 막는 목적, 존재하는 namespace다르면 같은 이름의 함수 및 변수 선언O
    * 보통 프로젝트명으로 
    * ::(범위 지정 연산자)기호로 구분,  중첩가능(계층 구조)
    * using을 이용한 namespace: “이름::”명시 없이 사용 가능
* 함수
  * 함수 오버로딩(Function Overloading)
    * 함수 호출 시, 함수이름과 전달되는 인자의 정보로 함수 결정 → 매개변수 선언 달리해서 같은 이름의 함수 정의 가능
    * 반환형만 다른 경우는 안됨
  * 매개변수의 디폴트 값
    * int func(int a=1, int b=2, int c)	//이런 경우는 x ⇒ 오른쪽 부터 값 채워주는건 가능
    * 함수의 선언에서만
  * inline키워드: 컴파일러에 의해 처리되며 매크로 함수의 장점은 취하고 단점 보완한 것
* class(C++) ← struct(C) 
    * 구조체 등장 배경: 연관있는 데이터 하나로 묶으면 프로그램의 구현 및 관리 용이
    * 구조체 vs 클래스 : 매번 typedef 필요 → 필요x해짐 / 내부에 함수 삽입 불가→ 가능
  * 접근 권한 ⇒ 정보 은닉(capsulation) 
    * public: 멤버변수에 public해야 클래스 외부에서 참조(dot(.)사용) 가능
    * private(default)
    * protected: 상속관계에 놓여있을 때, 유도 클래스에서의 접근 허용
  * 생성자와 소멸자 - 클래스명과 동일, 리턴타입 없음
    * 생성자: 멤버변수가 public이라면 직접 대입 가능하지만? 그렇지 않은 경우가 많음
    * 소멸자: ~클래스명()	//메모리 할당(malloc), new키워드 사용 시 → 자원 반환 필요
    * > ex) pp=(int*) malloc(1000); return pp; →  ~Point(){ delete pp; }
* Reference :참조형 변수,다른 객체나 값의 별칭
    * 변수명 앞에 &연산자→ 참조형 변수, int &num2 = num1; // num1과 같은 주소, 값 가짐
    * 선언과 동시에 초기화 필요하며, 다른 참조값으로 변경 불가
    * 포인터변수와 비슷하지만 기존 변수처럼 사용 가능 → 단일변수, 클래스 등에 유용 / 배열에는 포인터가 더 편함
### C++ 2강
* 생성자 & 멤버 변수 초기화
* new / delete 키워드 : 메모리 동적 할당 
* 상속
  * 클래스 내부 함수(private)로 멤버변수에 접근하기 위한 get, set 함수 필요 
  * 상속하는 클래스의 생성자는 상속받는 클래스의 멤버변수에 대해서도 초기화(?)해줘야
    * >ex) Rect 상속받는 RectEx의 생성자 : RectEx(Point pp1, Point pp2):Rect(pp1,pp2){ } 
* 연산자 오버로딩
ex) Point p1(10,10); p1+3;   // error!
### 3강 MFC
* MFC(microsoft foundation class): microsoft Foundation Class: 윈도우 os가 제공하는 다양한 기능의 API함수들을 기능별로 클래스화 한 형태로 만든 것
  * 진입점: wWinMain(C++도스 프로그램의 시작점: main함수)
    * hInstance: 현재 실행되고 있는 프로그램의 핸들		/ hPrevinstance
    * nCmdShow: 윈도우를 보여주는 형태의 플래그	/ IpCmdLine
  * 윈도우즈 프로그래밍에서 event driven → message라는 표현
  * 무한루프로 메세지계속 받음 
  * 리소스 파일 .rc
    * string table → App_Title의 캡션으로 창 타이틀 이름 바꿀 수 o(전역문자열)
* SDK 프로그램 : sw development kit, 라이브러리
  * sdk프로그램 동작 원리
    * 시스템 영역: 이벤트 발생(마우스,키보드, 네트워크(웨이팅), 타이머 등) 내용들을 시스템 메시지큐에 저장→ 여러 개의 메세지 큐에 나눠저장
    * 프로그래머: 메시지 처리
* CString
: c++에서 제공하는 문자열 처리 클래스
MakeUpper()
* MSDN사이트에서 모르는거 찾아보면서 하기 → 모르느거 드래그 후 F1키
→ 어떤 함수로 활용할 지 모를 때도!(Ex) 입력란의 문자열 가져오기-> 입력란 클릭후f1
* ctrl+F: 문자열찾기
### 4강 MFC
* MFC
    * 클래스 뷰: 클래스 파일, 솔루션탐색기와는 다름
    * .rc: resource file  / accelerator: 핫키들 / Icon:
  * CFile클래스: CObject상속 받는 MFC파일 클래스의 기본 클래스
    * CFile경로 또는 파일 핸들에서 개체 생성
    * Open(): 오류테스트 옵션을 사용하여 파일을 안전하게 엶
    * Read(): 현재 파일 위치에서 버퍼링 되지않은 데이터 읽기
    * >ex) f.Read(buf,f.GetLength());
    * Close(): 파일 닫고 개체 삭제
    * GetLength(): 파일 길이 검색
    * 기본 파일 액세스 모드: CFile::modeRead(읽기 전용)
  * CFileDialog: 파일 열기 또는 저장작업에 사용되는 일반 대화 상자를 캡슐화

* 다이얼로그 클래스 생성 및 메뉴로 연결
    * dialog클래스에서 이벤트에 대한 처리 루틴들 정의
    * 가상함수 중 OnInitDialog 에서 초기화  → 이 함수에서 폰트만들고 적용하면 됨
    * GetDlgItem(ID) ⇒ 반환 타입: CWnd → 클래스 포인터로 반환 → 하위 클래스인 대화상자나 컨트롤바 등으로 강제형변환 가능 → SetFont부터해서 거의 대부분 활용 가능
    * SetWindowTextW:(L“문자열”): 캡션?을 문자열로 

* 그림 그리기
  * 다이얼로그에서 클래스 마법사 만들기의 메시지 이용
    * LBUTTONDBLCLK- 마우스 왼쪽 더블 클릭 / LBUTTONDOWN 왼쪽 누름/ LBUTTONUP
  * CStatic포인터: 윈도우즈 정적 컨트롤의 기능 제공
  * CDC(): Device Context Pointer
