using UnityEngine;
using TMPro;

namespace Sample
{
    /// <summary>
    /// Old Input 테스트
    /// </summary>
    public class InputTest : MonoBehaviour
    {
        #region Variables
        float centerX;      //화면 중앙 위치 x좌표
        float centerY;      //화면 중앙 위치 y좌표

        public TextMeshProUGUI positionText;
        #endregion

        #region Unity Event Method
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //스크린의 크기
            Debug.Log($"Screen Width: {Screen.width}");
            Debug.Log($"Screen Height : {Screen.height}");

            centerX = Screen.width/2;
            centerY = Screen.height/2;
            Debug.Log($"Screen Center : {centerX}, {centerY}");
        }

        // Update is called once per frame
        void Update()
        {
/*            //GetKey 
            if (Input.GetKey("w"))  //이때 중요한건 소문자 문자열 (대문자는 안됨)
            {
                Debug.Log("w키를 누르고 있습니다");
            }
            if (Input.GetKeyDown(KeyCode.W))    //이때는 대문자,,
            {
                Debug.Log("w키를 눌렀습니다");
            }
            if (Input.GetKeyUp(KeyCode.W))      //다운이 있어야 업이 존재함
            {
                Debug.Log("w키를 눌렀다가 떼었습니다");
            }

            //GetBotton - InputManager 정의된 Axes(버튼) 이름을 가져와서 사용한다
            if(Input.GetButton("Jump"))
            {
                Debug.Log("점프 버튼(스페이스바)를 누르고 있습니다");
            }
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("점프 버튼(스페이스바)를 눌렀습니다");
            }
            if (Input.GetButtonUp("Jump"))
            {
                Debug.Log("점프 버튼(스페이스바)를 눌렀다가 떼었습니다");
            }
*/

            //GetAxis - InputManager 정의된 Axis(버튼) 이름을 가져와서 사용한다
            //if (Input.GetButton("Horizontal"))    //Axis 할때는 버튼을 하지 않아도 됨
            {
                //a, left  : -1 ~ 0  
                //d, right : 0 ~ 1
                //입력이 없으면 0
                //float hValue = Input.GetAxis("Horizontal");
                //Debug.Log($"Horizontal GetAxis : {hValue}");

                float hValue = Input.GetAxisRaw("Horizontal");
                Debug.Log($"Horizontal GetAxisRaw : {hValue}");
            }
            //if(Input.GetButton("Vertical"))
            {
                //s, down : -1 ~ 0  
                //w, up   : 0 ~ 1
                //입력이 없으면 0
                //float vValue = Input.GetAxis("Vertical");
                //Debug.Log($"Vertical GetAxis : {vValue}");

                float vValue = Input.GetAxisRaw("Vertical");
                Debug.Log($"Vertical GetAxisRaw : {vValue}");
            }

            //스크린상에서 마우스 위치값 가져오기
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;
            //Debug.Log($"Mouse Position: {mouseX},{mouseY}");
            positionText.text = $"{(int)mouseX},{(int)mouseY}";
            positionText.rectTransform.position = new Vector2(mouseX, mouseY);
            

        }
        #endregion
    }
}