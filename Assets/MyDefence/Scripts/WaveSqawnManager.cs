using UnityEngine;
using System.Collections;

namespace MyDefence
{
    public class WaveSqawnManager : MonoBehaviour
    {
        /// <summary>
        /// 적 스폰 및 웨이브를 관리하는 클래스
        /// </summary>
        

        #region Variable
        //적 프리팹 오브젝트 - 원본
        public GameObject enermyPrefab;

        //public Transform start; == this.transform

        //스폰 타이머 (5초 타이머 구현)
        public float spawnTimer = 5f;  //타이머 기준 시간
        public float countdown = 0f;   //시간 누적 변수       //추후에 수정하기 쉽게 대부분 타이머의 접근제한자는 public으로 함

        //웨이브 카운트
        private int waveCount = 0;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //EnermySpawn();
        }

        private void Update()
        {

            //스폰 (5초) 타이머
            countdown += Time.deltaTime;
            if(countdown >= spawnTimer )
            {
                //타이머 기능 실행
                StartCoroutine(SpawnWave());

                //타이머 초기화
                countdown = 0f;     //~마다 라는 표현이 있다면 초기화를 반드시 해야한다

            }
        }
        #endregion

        #region Custom Method
        //enermy스폰웨이브
        IEnumerator SpawnWave()
        {
            waveCount++;
            for (int i = 0; i < waveCount; i++)
            {
                EnermySpawn();
                yield return new WaitForSeconds(0.5f);
            }

            //Debug.Log($"웨이브 카운트: {waveCount}");
        }
        
        

        #endregion

        #region Custom Method
        void EnermySpawn()
        {
            //시작점 위치(this.transform)에 enermy 1개 생성
            Instantiate(enermyPrefab, this.transform.position, Quaternion.identity);
        }

        #endregion


    }
}
