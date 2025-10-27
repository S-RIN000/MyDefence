using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 오브젝트(터렛)을 회전(연출) 시켜주는 클래스
    /// </summary>
    public class Rotater : MonoBehaviour
    {
        #region Variables
        //회전 
        [SerializeField]
        private Vector3 rotationSpeed;
        

        #endregion

        #region Unity Event Method
        private void Update()
        {
            transform.localEulerAngles += rotationSpeed;
        }
        #endregion

        #region Custom Method

        #endregion
    }
}
