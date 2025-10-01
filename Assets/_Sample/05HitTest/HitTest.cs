using UnityEngine;

namespace Sample
{
    //사각형 구조체
    struct cBox
    { 
        public float x;         //박스의 x좌표
        public float y;         //박스의 y좌표
        public float w;         //박스의 width
        public float h;         //박스의 height
    }

    //원 구조체
    struct cCircle
    {
        public float x;         //원의 x좌표
        public float y;         //원의 y좌표
        public float r;         //원의 반지름
    }


    public class HitTest : MonoBehaviour
    {
        #region Variables
        public float moveSpeed = 10f;

        #endregion

        #region Unity Event Method
        #endregion

        #region Custom Method
        //매개변수로 받은 두개의 box가 충돌했는지 체크
        //충돌했으면 true, 충돌하지 않았으면 false 반환
        private bool CheckHitBox(cBox a, cBox b)
        {
            float xDistance = (a.x < b.x) ? (b.x - a.x) : (a.x - b.x);   //x사이의 거리는 절댓값이라서
            float yDistance = (a.y < b.y) ? (b.y - a.y) : (a.y - b.y);   //y사이의 거리는 절댓값이라서

            if ((a.w / 2 + b.w / 2) >= xDistance && (a.h/2 + b.h/2) >= yDistance)
            {
                return true;
            }

            return false;
        }


        //매개변수로 받은 두개의 circle이 충돌했는지 체크
        //충돌했으면 true, 충돌하지 않았으면 false 반환

        private bool CheckHitCircle (cCircle a, cCircle b)
        {
            float xDistance = a.x - b.x;
            float yDistance = a.y - b.y;

            //두 원 사이 거리가 두 원의반지름의 합보다 작으면 충돌이라고 판정 
            //Sqrt = 루트
            float distance = Mathf.Sqrt(xDistance * xDistance + yDistance * yDistance);
            if(distance <= (a.r + b.r))
            {
                return true;
            }

            return false;
        }

        //도착 판정으로 충돌체크
        //두 오브젝트의 거리가 일정거리(0.5)안에 있으면 충돌이라 판정

        private bool CheckArrivePosiotion(Transform target)
        {
            float distance = Vector3.Distance(this.transform.position, target.position);

            if(distance < 0.5f)
            {
                return true;
            }

            return false;
        }

        //이동시 타겟까지의 남은 거리가 한 프레임에 이동하는 거리보다 작을 때 충돌이라고 판정
        private bool CheckPassPosition(Transform target)
        {
            //남은 거리 
            float distance = Vector3.Distance(this.transform.position, target.position);

            //한 프레임마다 가는 거리
            float distanceThisFrame = Time.deltaTime * moveSpeed;

            if(distance <= distanceThisFrame)
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
