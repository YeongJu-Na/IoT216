namespace myLibrary
{

    class myLib
    {
        //static: 인스턴스 메서드와 달리 클래스로부터 객체를 생성하지 않고 직접 [클래스명.메서드명] 형식으로 호출하는 메서드
        static public int Count(char deli, string str)    //str을 deli로 split했을 때 구분자의 개수 반환
        {
            return str.Split(deli).Length - 1;
        }

        static public string GetToken(int idx, char deli, string str) //delimiter: 구분문자, str을 deli로 split 후 idx에 있는 문자열 반환
        {
            return str.Split(deli)[idx];
        }
    }
}