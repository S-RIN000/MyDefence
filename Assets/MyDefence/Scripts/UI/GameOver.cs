using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    /// <summary>
    /// 게임오버 UI를 관리하는 클래스
    /// </summary>
    public class GameOver : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField]
        private string loadToScene = "MainMenu";

        //Rounds 텍스트
        public TextMeshProUGUI roundText;
        #endregion

        #region Unity Event Method
        //게임오버 UI가 활성화 될 때 PlayerStats.Rounds 값을 가져온다 (딱 한번, 누적x)
        private void OnEnable()
        {
            //Round 텍스트에 PlayerStats Round 적용
            roundText.text = PlayerStats.Rounds.ToString() + "ROUNDS SURVIVED";
        }

        //매 프레임 마다 PlayerStats.Rounds 값을 가져온다
        /*
        private void Update()
        {
            //Round 텍스트에 PlayerStats Round 적용
            roundText.text = PlayerStats.Rounds.ToString() + "ROUNDS SURVIVED";
        }
        */
        #endregion

        #region Custom Method
        //메인메뉴 버튼을 눌렀을 때 호출
        public void MainMenu()
        {
            //Debug.Log("Go to Menu");
            fader.FadeTo(loadToScene);
        }

        //게임 재시작 버튼을 눌렀을 때 호출
        public void ReStart()
        {
            //Debug.Log("Run RESTART");

            //웨이브 초기화
            //돈, 라이프 초기화
            //타워 제거 ...   
            //=> (현재 플레이하고 있는) 씬을 다시 호출

            //SceneManager.LoadScene(0);            //씬 빌드번호로 호출
            //SceneManager.LoadScene("PlayScene");  //씬 이름으로 호출
            //=> 이렇게 다른 씬으로 갈때 매번 현재 플레이하고 있는 씬의 이름, 빌드번호를 쓰는 것이 번거로움 

            //해결... (이름과 빌드번호 둘 중 택 1)
            //int nowBuildIndex = SceneManager.GetActiveScene().buildIndex;
            //SceneManager.LoadScene(nowBuildIndex);
            string nowSceneName = SceneManager.GetActiveScene().name;
            fader.FadeTo(nowSceneName);

        }
        #endregion
    }
}
