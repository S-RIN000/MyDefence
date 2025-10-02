using UnityEngine;

namespace Sample
{
    //싱글톤 패턴 클래스
    public class Singleton
    {
        //클래스의 인스턴스(객체)를 정적(static) 변수 선언
        private static Singleton instance;

        //public한 속성으로 instance에 전역적 접근하기
        public static Singleton Instance
        {
            get
            {
                if (instance == null)   //null => 메모리공간에 인스턴스를 생성하지 않았음 new(x)
                {
                    //인스턴스 생성
                    instance = new Singleton();
                }
                return instance;
            }
        }
/*
        //public한 메서드로 instance에 전역적 접근하기
        public static Singleton Instance()
        {
            if (instance == null)
            {
                //인스턴스 생성
                instance = new Singleton();
            }
            return instance;
        }
*/

        //필드 : 인스턴스이름.number
        public int number;

    }
}
/*
Singleton.instance (x) (원래 정적함수는 이렇게 사용해야 하는데 이건 사용불가(!), private로 막아놔서)
Singleton.Instance (o) (public 함수 이후 이렇게 사용 가능)
 
Singleton.Instance().number = 10;
Debug.Log(Singleton.Instance().number.ToString());



 */