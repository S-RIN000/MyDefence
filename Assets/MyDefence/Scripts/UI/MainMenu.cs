using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    /// <summary>
    /// 메인메뉴 씬을 관리하는 클래스
    /// </summary>
    public class MainMenu : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;

        [SerializeField]
        private string loadToScene = "PlayScene";
        #endregion

        #region Unity Event Method
        #endregion

        #region Custom Method
        //플레이 버튼 클릭시 호출
        public void Play()
        {
            //Debug.Log("Go to PlayScene");

            //자기 자신이 아니라 다른 씬으로 변경
            fader.FadeTo(loadToScene);    
        }

        //quit버튼 클릭시 호출
        public void Quit()
        {
            //Cheating
            //저장된 데이터 삭제
            PlayerPrefs.DeleteAll();

            Debug.Log("Game Quit!!");

            //어플리케이션 종료 명령
            Application.Quit();     //에디터에서는 명령 무시, 실행 파일에서는 명령 실행
        }
        #endregion
    }
}
