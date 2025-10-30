using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    /// <summary>
    /// Paused UI를 관리하는 클래스
    /// Paused UI 활성화, 비활성화, X, 메인메뉴, 재시작 버튼 기능
    /// </summary>
    public class Paused : MonoBehaviour
    {
        #region Variables
        public GameObject paused;

        //씬 페이더
        public SceneFader fader;
        //메뉴 씬 이름
        [SerializeField]
        private string loadToScene = "MainMenu";
        #endregion

        #region Unity Event Method
        private void Update()
        {
            //게임오버 체크
            if (GameManager.IsGameOver)
            {
                return;
            }

            //ESC키를 누르면 pause 활성화, 다시 ESC키 입력시 비활성화
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Toggle();
            }
        }
        #endregion

        #region Custom Method

        public void Toggle()
        {

            //현재 상태의 반대로 세팅하라 
            paused.SetActive(!paused.activeSelf);

            //창이 열려있는가?
            if (paused.activeSelf)
            {
                Time.timeScale = 0f;
            }
            else //창이 닫혀있는가?
            {
                Time.timeScale = 1f;
            }

     
        }

        //메인메뉴를 누르면 호출
        public void MainMenu()
        {
            //Debug.Log("Go To Menu");
            fader.FadeTo(loadToScene);
            Time.timeScale = 1f;
        }

        //게임 재시작을 누르면 호출
        //씬 재시작
        public void ReStart()
        {
            //Debug.Log("Run RESTART");

            string nowSceneName = SceneManager.GetActiveScene().name;
            //SceneManager.LoadScene(nowSceneName);
            fader.FadeTo(nowSceneName);

            Time.timeScale = 1f;
        }

        #endregion
    }
}
