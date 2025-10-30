using UnityEditor.PackageManager;
using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 게임의 전체를 관리하는 클래스
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        #region Variables
        //게임오버 체크 변수
        private static bool isGameOver = false;

        //레벨 클리어 체크 변수
        private static bool isLevelClear = false;

        //게임오버 UI
        public GameObject gameOverUI;
        //레벨 클리어 UI
        public GameObject levelClearUI;

        //현재 플레이 씬의 레벨
        [SerializeField]
        private int nowLevel = 1;

        //치트 체크 변수
        [SerializeField]
        private bool isCheating = false;
        #endregion

        #region Porperty
        //읽기전용
        public static bool IsGameOver
        {
            get { return isGameOver; }
            private set { isGameOver = value; }
        }
        //읽고 쓰기
        public static bool IsLevelClear
        {
            get { return isLevelClear; }
            set { isLevelClear = value; }
        }
        #endregion

        #region Unity Event Method

        private void Start()
        {
            //초기화
            IsGameOver = false;
            IsLevelClear = false;
        }
        private void Update()
        {
            if (isGameOver)
                return;
               
            //게임 종료 체크
            if (PlayerStats.Lives <=0)
            {
                GameOver();
            }

            //레벨 클리어 체크
            if(isLevelClear)
            {
                LevelClear();
            }

            //치트키
            if(Input.GetKeyDown(KeyCode.M))
            {
                ShowMeTheMoney();
            }

            if(Input.GetKeyDown(KeyCode.O))
            {
                ShowGameUI();
            }

        }
        #endregion

        #region Custom Method

        //게임오버 처리
        private void GameOver()
        {
            //Debug.Log("Game Over");
            isGameOver = true;

            //효과 : vfx, sfx ...
            //패널티 적용

            gameOverUI.SetActive(true);

        }

        //레벨 클리어 처리
        public void LevelClear()
        {
            IsGameOver = true;

            //Debug.Log("Level Clear");

            //게임 데이터 저장
            int saveLevel = PlayerPrefs.GetInt("ClearLevel", 0);
            if (saveLevel < nowLevel)
            {
                PlayerPrefs.SetInt("ClearLevel", nowLevel);
                Debug.Log($"Save clear level : {nowLevel}");
            }

            //UI창 열기
            levelClearUI.SetActive(true);
        }

        //치트키
        void ShowMeTheMoney()
        {
            //치트 체크
            if(isCheating ==  false)
            {
                return;
            }

            //10만 골드 지급
            PlayerStats.AddMoney(100000);
        }

        void ShowGameUI()
        {
            //치트 체크
            if (isCheating == false)
            {
                return;
            }

            GameOver();
        }

        void LevelCheat()
        {
            //level++; 
        }
   
        #endregion
    }
}
