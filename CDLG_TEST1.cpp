// CDLG_TEST1.cpp: 구현 파일
//

#include "pch.h"
#include "MFCApplication1.h"
#include "CDLG_TEST1.h"
#include "afxdialogex.h"


// CDLG_TEST1 대화 상자

IMPLEMENT_DYNAMIC(CDLG_TEST1, CDialogEx)

CDLG_TEST1::CDLG_TEST1(CWnd* pParent /*=nullptr*/)
	: CDialogEx(IDD_CDLG_TEST1, pParent)
{

}

CDLG_TEST1::~CDLG_TEST1()
{
}

void CDLG_TEST1::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}


BEGIN_MESSAGE_MAP(CDLG_TEST1, CDialogEx)
	ON_BN_CLICKED(IDC_BUTTON1, &CDLG_TEST1::OnBnClickedButton2)
END_MESSAGE_MAP()


// CDLG_TEST1 메시지 처리기


BOOL CDLG_TEST1::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// TODO:  여기에 추가 초기화 작업을 추가합니다.
	CFont cf;
	cf.CreateFontW(36, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, L"Arial");
	GetDlgItem(IDC_EDIT1)->SetWindowTextW(L"아녕하세여");
	GetDlgItem(IDC_EDIT1)->SetFont(&cf);


	return TRUE;  // return TRUE unless you set the focus to a control
				  // 예외: OCX 속성 페이지는 FALSE를 반환해야 합니다.
}

void CDLG_TEST1::OnBnClickedButton2()
{
	// TODO: 여기에 컨트롤 알림 처리기 코드를 추가합니다.
//	CEdit 
	CString buf;
	GetDlgItem(IDC_EDIT2)->GetWindowTextW(buf);			//edit2에 입력한 문자열 받아오기
	GetDlgItem(IDC_EDIT3)->SetWindowTextW(buf.MakeUpper());		//buf가 upper로 바뀌는게 아니라 upper로 바꾼 복사본이 반환됨
	
	int n = buf.GetLength();
	CString s;
	s.Format(L"%d", n);
	GetDlgItem(IDC_EDIT4)->SetWindowTextW(s);
	
}
