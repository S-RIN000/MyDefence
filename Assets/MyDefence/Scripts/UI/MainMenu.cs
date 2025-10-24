using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    public class MainMenu : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        private string loadToScene = "PlayScene";
        #endregion

        #region Unity Event Method
        #endregion

        #region Custom Method
        //플레이 버튼 클릭시 호출
        public void Play()
        {
            Debug.Log("Go to PlayScene");

            //자기 자신이 아니라 다른 씬으로 변경
            SceneManager.LoadScene(loadToScene);    
        }

        //quit버튼 클릭시 호출
        public void Quit()
        {
            Debug.Log("Game Quit!!");

            //어플리케이션 종료 명령
            Application.Quit();     //에디터에서는 명령 무시, 실행 파일에서는 명령 실행
        }
        #endregion
    }
}
