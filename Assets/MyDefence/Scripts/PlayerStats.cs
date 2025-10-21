using Unity.VisualScripting;
using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 플레이어 속성, 게임데이터 변수를 관리하는 클래스
    /// </summary>
    public class PlayerStats : MonoBehaviour
    {
        #region Variables
        //소지금
        public static int money;

        //초기 소지금
        [SerializeField]
        private int startMoney = 400;

        //게임 Life
        private static int lives;

        //초기 소지 생명 갯수
        [SerializeField]
        private int startLife = 10;

        //웨이브 카운트
        private static int rounds;
        #endregion

        #region Property
        //소지금 읽기 전용 속성
        public static int Money
        {
            get { return money; }
        }

        //생명 읽기 전용 속성
        public static int Lives
        {
            get { return lives; }
        }

        //웨이브 카운트 속성
        public static int Rounds
        {
            get { return rounds; }
            set { rounds = value; }
        }

        #endregion

        #region Unity Event Method
        private void Start ()
        {
            //초기화
            //게임을 다운로드 받고 처음 시작하면 초기 소지금 지급
            money = startMoney;     //초기 소지금 지급
            lives = startLife;      //초기 생명 갯수 지급
            rounds = 0;             //웨이브 카운트 초기화

            //Debug.Log($"초기 소지금 {startMoney}골드를 지급하였습니다");
        }
        #endregion

        #region Custom Method
        //돈 벌기
        public static void AddMoney(int amount)
        {
            money += amount;
        }

        //돈 쓰기
        public static bool UseMoney(int amout)
        {
            //소지금 체크
            if(money < amout)
            {
                Debug.Log("돈이 부족합니다");
                return false;
            }

            money -= amout;
            return true;
        }

        //소지금 체크, 잔고 확인
        public static bool HasMoney(int amount)
        {
            return money >= amount;
        }

        //Life 벌기
        public static void AddLives(int amount)
        {
            lives += amount;
        }

        //Life 쓰기
        public static void UseLives(int amount = 1)     //생명은 1씩 깎이니까...
        {
            lives -= amount;

            if (lives <= 0)
            {
                lives = 0;
            }
        }

        #endregion 
    }
}
