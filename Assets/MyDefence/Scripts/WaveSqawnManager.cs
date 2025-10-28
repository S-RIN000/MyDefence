using System.Collections;
using TMPro;
using UnityEngine;

namespace MyDefence
{
    public class WaveSqawnManager : MonoBehaviour
    {
        /// <summary>
        /// 적 스폰 및 웨이브를 관리하는 클래스
        /// </summary>


        #region Variable

        //현재 살아있는 적의 수
        public static int enemyAlive = 0;

        //웨이브 데이터 셋팅 : 프리팹, 생성 갯수, 생성 딜레이 
        public Wave[] waves;        //waves[0] ~ waves[4]

        //적 프리팹 오브젝트 - 원본
        public GameObject enermyPrefab;

        //public Transform start; == this.transform

        //스폰 타이머 (5초 타이머 구현)
        public float spawnTimer = 5f;  //타이머 기준 시간      //추후에 수정하기 쉽게 대부분 타이머의 접근제한자는 public으로 함
        private float countdown = 0f;   //시간 누적 변수       

        //웨이브 카운트
        private int waveCount = 0;

        //이번 웨이브에 생성되는 적의 수
        private int enemyCount = 0;

        //UI - TMP를 지휘하는 인스턴스 생성 (Text)
        //public TextMeshProUGUI countdownText;
        public GameObject startButton;
        public GameObject waveCountUI;

        public TextMeshProUGUI waveCountText;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //EnermySpawn();
        }

        private void Update()
        {
            /*
            //스폰 (5초) 타이머
            countdown += Time.deltaTime;
            if(countdown >= spawnTimer )
            {
                //타이머 기능 실행
                WaveSpawn();

                //타이머 초기화
                countdown = 0f;     //~마다 라는 표현이 있다면 초기화를 반드시 해야한다

            }

            //UI - 카운트다운 텍스트 / countdownText.text => 99가 저장되어있는 변수
            //countdown 특정 범위(min,max) 설정 ( -값이 안되도록 설정)
            countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
            //countdownText.text = string.Format("{0:00.00}", countdown); //실수 (소수점 이하) 출력 => 소수점까지 나올 필요없으니 int형으로 수정 ↓
            countdownText.text = Mathf.Round(countdown).ToString();    //Round = 반올림, 반올림하여 정수형 출력

            //countdownText.text = countdown.ToString();      //float형에서 string으로 변환

            */
            if (enemyAlive <= 0)
            {
                if (startButton.activeSelf == false)
                {
                    WaveReady();
                }
            }
            else
            {
                waveCountText.text = enemyAlive.ToString() + " / " + enemyCount.ToString();
            }
        }
        #endregion

        #region Custom Method
        private void WaveSpawn()
        { 
            StartCoroutine(SpawnWave());
        }

        //enermy스폰웨이브
        IEnumerator SpawnWave()
        {
            //waves[0], waves[1], waves[2], waves[3], waves[4]
            //웨이브 생성 데이터
            Wave wave = waves[waveCount];

            waveCount++;

            //웨이브 카운트 (웨이브에 따라서 라운드가 1씩 증가한다)
            PlayerStats.Rounds++;

            enemyCount = wave.count;
            enemyAlive = enemyCount;

            //wave 데이터로 생성
            for (int i = 0; i < wave.count; i++)
            {
                EnermySpawn(wave.prefab);
                yield return new WaitForSeconds(wave.delayTime);
            }

            //Debug.Log($"웨이브 카운트: {waveCount}");
        }



        #endregion

        #region Custom Method
        void EnermySpawn(GameObject prefab)
        {
            //시작점 위치(this.transform)에 enermy 1개 생성
            Instantiate(prefab, this.transform.position, Quaternion.identity);
        }

        //WaveStart 버큰 클릭시 호출
        public void WaveStart()
        {
            //UI 세팅
            startButton.SetActive(false);
            waveCountUI.SetActive(true);

            //웨이브 시작
            WaveSpawn();
        }

        //웨이브 대기
        private void WaveReady()
        {
            //마지막 웨이브가 끝났는지 체크
            if (waveCount >= waves.Length)
            {
                Debug.Log("Level Clear");
                this.enabled = false;
                return;
            }

            //UI 세팅
            startButton.SetActive(true);
            waveCountUI.SetActive(false);
        }

        #endregion


    }
}
