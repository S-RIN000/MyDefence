using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Sample
{
    public class ImageTest : MonoBehaviour
    {
        #region Variables
        public Button skillButton;
        public Image skillButtonImage;

        //쿨 타이머
        public float coolTimer = 5f;
        public float countdown = 0f;

        //스킬버튼 사용가능 여부 체크
        private bool isCharge = false;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //초기화
            isCharge = true;    //시작하자마자 버튼 사용 1번 사용 가능
            

        }
        private void Update()
        {
            //스킬버튼 쿨 타이머
            if(isCharge == false)
            {
                countdown += Time.deltaTime;
                if(countdown >= coolTimer)
                {
                    //타이머기능 - 스킬 활성화
                    isCharge = true;
                    skillButton.interactable = true;

                    //타이머 초기화
                    //countdown = 0f;
                }

                //쿨타임에 맞게 image filled 보여주기
                //0 -> 1, countdown : 0 -> 5(coolTimer)
                // % : 현재값 / 총값량
                skillButtonImage.fillAmount = countdown / coolTimer;
            }
          
        }
        #endregion

        #region Custom Method
        public void Skill()
        {
            if(isCharge == false)
            {
                return;
            }
            Debug.Log("스킬 사용");

            //스킬 UI 르게기능 초기화
            isCharge = false;   //한 번 사용하면 막기
            skillButton.interactable = false;   //버튼 비활성화

            //타이머 초기화
            countdown = 0f;
        }

        #endregion
    }
}
