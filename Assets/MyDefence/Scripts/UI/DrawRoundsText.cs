using TMPro;
using UnityEngine;
using System.Collections;

namespace MyDefence
{
    /// <summary>
    /// 라운드 넘버 텍스트를 카운팅 애니메이션 연출
    /// 라운드 숫자를 15, 0~15 까지 카운팅하는 애니메이션 연출 (코루틴)
    /// </summary>
    public class DrawRoundsText : MonoBehaviour
    {
        #region Variables
        //라운드 넘버 텍스트
        public TextMeshProUGUI roundText;
        #endregion

        #region Unity Event Method
        private void OnEnable()
        {
            StartCoroutine(AnimationNumberText(PlayerStats.Rounds));
        }
        #endregion

        #region Custom Method
        //매개변수로 입력받은 숫자 카운팅 애니메이션
        IEnumerator AnimationNumberText(int targetNumber)
        {
            //yield return new WaitForSeconds(0.5f);

            int number = 0;
            roundText.text = number.ToString();
            yield return new WaitForSeconds(0.2f);

            while (number < targetNumber)
            {
                number++;
                roundText.text = number.ToString();

                yield return new WaitForSeconds(0.1f);
            }
        }

        #endregion
    }
}
