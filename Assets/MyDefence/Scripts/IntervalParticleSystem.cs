using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 인터벌 시간 간격으로 파티클 이펙트를 플레이 시켜주는 클래스
    /// </summary>
    public class IntervalParticleSystem : MonoBehaviour
    {
        #region Variables
        //연출 파티클
        public ParticleSystem particleToPlay;

        //플레이 타이머
        [SerializeField]
        private float playTimer = 5f;
        private float countdown = 0f;
        #endregion

        #region Unity Event Method

        private void Start()
        {
            //일정시간 (5초)마다 한번씩 지정하는 함수를 호출
            InvokeRepeating("PlayParticleSystem", 0f, playTimer);  //("무엇을" , 처음부터 지체되는 시간, 반복되는 시간)
        }

        private void Update()
        {
            //파티클 플레이 타이머
            /*
            countdown += Time.deltaTime;
            if (countdown >= playTimer)
            {
                //타이머 기능
                PlayParticleSystem();

                //타이머 초기화
                countdown = 0f;     //~마다 라는 표현이 있다면 초기화를 반드시 해야한다
            }
            */
        }
        #endregion

        #region Custom Method
        private void PlayParticleSystem()
        {
            if (particleToPlay == null)
            {
                return;
            }

            particleToPlay.Play();
        }


        #endregion
    }
}
