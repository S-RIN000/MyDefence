using UnityEngine;

namespace Sample
{
    /// <summary>
    /// UI 버튼 호출 함수 구현
    /// </summary>
    public class UiTest : MonoBehaviour
    {

        #region Custom Method
        //Fire 버튼 클릭시 호출되는 함수 (접근제한자는 public)
        // = Fire 버튼에 등록되는 함수
        public void Fire()
        {
            Debug.Log("발사 하였습니다");
        }

        public void Jump()
        {
            Debug.Log("플레이어가 점프하였습니다");
        }

        #endregion
    }
}
