using UnityEngine;

namespace Sample
{
    /// <summary>
    /// 랜덤 애니메이션 구현
    /// </summary>
    public class TorchFlameAnimation : MonoBehaviour
    {
        #region Variables
        //참조
        private Animator animator;

        //애니메이션 파라미터 변수 값
        private int flame = 0;

        //랜덤 애니메이션 타이머
        [SerializeField]
        private float animTimer = 1f;
        //카운트다운
        private float countdown;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //참조
            animator = GetComponent<Animator>();

            //초기화
            flame = 0;
        }
        private void Update()
        {
            //타이머 - 1초에 1번씩 랜덤 애니메이션(1,2,3 중 하나 플레이)
            countdown += Time.deltaTime;
            if (countdown >= animTimer)
            {
                //타이머 기능 - 랜덤 애니 플레이 (1,2,3)
                flame = Random.Range(1, 4); //1은 포함되고 4는 포함 안됨
                animator.SetInteger("Flame", flame);

                //타이머 초기화
                countdown = 0f;
            }
        }
        #endregion

        #region Custom Method
        #endregion
    }
}
