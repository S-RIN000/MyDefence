using UnityEngine;

namespace Sample
{
    //MonoBehaviour 클래스의 이벤트 함수 예제
    public class EventTest : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("[1] Awake 실행");            //1회 실행
        }

        private void OnEnable()
        {
            Debug.Log("[7-1] OnEnable 실행");       //활성화 할 때 마다 1회 실행 (게임 오브젝트의 활성화/비활성화, 유니티에서 체크표시) - 켜지면 호출
        }

        private void Start()
        {
            Debug.Log("[2] Start 실행");            //1회 실행
        }

        private void FixedUpdate()
        {
            Debug.Log("[3] FixedUpdate 실행");      //1초에 50번 호출, 고정
        }

        private void Update()
        {
            Debug.Log("[4] Update 실행");           //매 프레임마다 호출, 1초에 60 or 30 or 300번 등등 프로그램 짜는것에 따라 변함
        }

        private void LateUpdate()
        {
            Debug.Log("[5] LateUpdate 실행");       //Update() 실행 뒤에 바로 따라서 실행 (=매 프레임마다 호출 =Update()화 횟수 동일)
        }

        private void OnDisable()
        {
            Debug.Log("[7-2] OnDisable 실행");      //비활성화 할 때 마다 1회 실행 (게임 오브젝트의 활성화/비활성화, 유니티에서 체크표시) - 꺼지면 호출
        }

        private void OnDestroy()
        {
            Debug.Log("[6] OnDestory 실행");        //메모리에서 사라질 때 1회 실행 - 소멸자와 같은 기능 = 하이라키 창에서 삭제될 때 1회 실행 ≒ 적이 사라질떄 KILL
        }
    }
}
