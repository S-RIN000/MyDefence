using UnityEngine;
using TMPro;

namespace MyDefence
{
    public class DrawLife : MonoBehaviour
    {
        #region Variables
        //Life UI
        public TextMeshProUGUI lifeCount;

        #endregion

        #region Unity Event Method
        private void Update()
        {
            //Life 데이터 UI 적용
            lifeCount.text = PlayerStats.Lives.ToString();
        }

        #endregion
    }
}
