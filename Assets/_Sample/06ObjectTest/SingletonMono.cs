using UnityEngine;

namespace Sample
{
    //MonoBehaviour를 상속받은 클래스 싱글톤 패턴 디자인
    //유니티에서 게임오브젝트에 부착되는 클래스의 싱글톤 패턴 디자인
    public class SingletonMono : MonoBehaviour
    {
        //클래스의 인스턴스(객체)를 정적(static) 변수 선언
        private static SingletonMono instance;

        //public한 속성으로 instance에 전역적으로 접근하기
        public static SingletonMono Instance
        { 
            get
            {
                return instance;
            }
        }

        //
        private void Awake()
        {
            //instance가 존재하면 this 오브젝트를 킬한다
            if (instance != null)   //다른 오브젝트에서 이 인스턴스가 있는지 확인용   
            {
                Destroy(this.gameObject);   //1번기준으로 1번은 null이 아니므로 삭제되고 2만 남음
                return;
            }

            instance = this;  //new 대신 this

            //씬 종료시 이 스크립트가 부착되어 있는 오브젝트는 삭제하지 않는다
            //DontDestroyOnLoad(this.gameObject);
        }
            //필드
            public int number;
        
    }

}