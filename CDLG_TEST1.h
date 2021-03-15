#pragma once


// CDLG_TEST1 대화 상자

class CDLG_TEST1 : public CDialogEx
{
	DECLARE_DYNAMIC(CDLG_TEST1)

public:
	CDLG_TEST1(CWnd* pParent = nullptr);   // 표준 생성자입니다.
	virtual ~CDLG_TEST1();

// 대화 상자 데이터입니다.
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_CDLG_TEST1 };
#endif

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 지원입니다.

	DECLARE_MESSAGE_MAP()
public:
	virtual BOOL OnInitDialog();
	afx_msg void OnBnClickedButton2();
};