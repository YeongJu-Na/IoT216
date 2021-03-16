// CDlgTest.cpp: 구현 파일
//

#include "pch.h"
#include "MFCApplication3.h"
#include "CDlgTest.h"
#include "afxdialogex.h"


// CDlgTest 대화 상자

IMPLEMENT_DYNAMIC(CDlgTest, CDialogEx)

CDlgTest::CDlgTest(CWnd* pParent /*=nullptr*/)
	: CDialogEx(IDD_DLG_Test1, pParent)
{

}

CDlgTest::~CDlgTest()
{
}

void CDlgTest::DoDataExchange(CDataExchange* pDX)	//내부 가상함수
{
	CDialogEx::DoDataExchange(pDX);
}


BEGIN_MESSAGE_MAP(CDlgTest, CDialogEx)
	ON_BN_CLICKED(IDC_BUTTON1, &CDlgTest::OnBnClickedButton1)
	ON_BN_CLICKED(IDC_BUTTON2, &CDlgTest::OnBnClickedButton2)
	ON_BN_CLICKED(IDC_BUTTON4, &CDlgTest::OnBnClickedButton4)
	ON_BN_CLICKED(IDC_BUTTON3, &CDlgTest::OnBnClickedButton3)
END_MESSAGE_MAP()

int btnStatus = 0;
// CDlgTest 메시지 처리기
void CDlgTest::OnBnClickedButton1()
{
	// TODO: 여기에 컨트롤 알림 처리기 코드를 추가합니다.
	CButton* btn = (CButton*)GetDlgItem(IDC_BUTTON1);	
	// 클릭마다 버튼의 캡션이 바뀌도록
	if (btnStatus) {
		btn->SetWindowTextW(L"버튼 문자열 2");
		btnStatus = 0;
	}
	else {
		btn->SetWindowTextW(L"버튼 문자열 1");
		btnStatus = 1;
	}
}


void CDlgTest::OnBnClickedButton2()		//파일 불러오기 
{
	// TODO: 여기에 컨트롤 알림 처리기 코드를 추가합니다.
	CFileDialog dlgFile(TRUE);	//CFileDialog 개체생성
								//read flag
	OPENFILENAME& ofn = dlgFile.GetOFN();	//OpenFileName(OFN)
	ofn.Flags |= OFN_ALLOWMULTISELECT;

	if (dlgFile.DoModal() == IDCANCEL) return;	//취소 누른 경우
	CString fPath = dlgFile.GetPathName();		//full path 전체 경로
	CFile f;
	f.Open(fPath, CFile::modeRead);	//파일 경로 받아 읽기모드로 접근
	int n = f.GetLength();
	char *buf = new char[n];
	WCHAR *wBuf=new WCHAR[n];
	f.Read(buf, n);
	f.Close();
	MultiByteToWideChar(CP_ACP, 0, buf, n, wBuf, n);	//buf(char*) --> wBuf(WCHAR)
	GetDlgItem(IDC_EDIT1)->SetWindowTextW(wBuf);
	delete wBuf;		//new - delete
	delete buf;

}

void CDlgTest::OnBnClickedButton3()
{
	// TODO: 여기에 컨트롤 알림 처리기 코드를 추가합니다.
	EndDialog(IDOK);
}

void CDlgTest::OnBnClickedButton4()
{
	// TODO: 여기에 컨트롤 알림 처리기 코드를 추가합니다.
	EndDialog(IDCANCEL);
}