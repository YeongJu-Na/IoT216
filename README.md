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
