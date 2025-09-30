using System.Xml.Serialization;
using Unity.Profiling.Editor;
using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 타워를 관리하는 클래스
    /// </summary>
    /// 
    public class Tower : MonoBehaviour
    {
        #region Variables
        //공격 타겟 Enemy - 가장 가까운 적
        private GameObject target;

        //회전 
        public Transform partToRotate ;      //회전을 관리하는 오브젝트
        public float rotateSpeed = 10f;     //회전 속도

        //공격 범위
        public float attackRange = 5f;

        //찾기 타이머
        public float searchTimer = 0.2f;
        private float countdown = 0;        //타이머를 구현하고자 한다면 변수 2개가 기본이다~

        #endregion

        #region Unity Event Method

        private void Start()
        {
            //필드 초기화
            countdown = searchTimer;     
        }

        private void Update()
        {
            //0.2초 마다 가까운 적 찾기
            if ( countdown <= 0f)
            {
                //타이머 기능 (= 가장 가까운 적 찾기)
                UpdateTarget();
                //타이머 초기화     //마이너스 누적은 초기화를 해주는게 좋다
                countdown = searchTimer;
            }
            countdown -= Time.deltaTime;

            


            //NULL이면 RETURN 밑을 실행하지 말라
            if (target == null) return;
            
                //타겟을 향해서 partToRocate 회전
                //타겟위치 - 현재위치
                Vector3 dir = target.transform.position - this.transform.position;
                Quaternion lookRocation = Quaternion.LookRotation(dir);
                Quaternion lerpRotation = Quaternion.Lerp(partToRotate.rotation, lookRocation, Time.deltaTime * rotateSpeed);
                Vector3 eulerValue = lerpRotation.eulerAngles;

                //y축으로만 회전하기
                partToRotate.rotation = Quaternion.Euler(0f, eulerValue.y, 0f);
            
        }

        private void OnDrawGizmosSelected()
        {
            //타워중심으로부터 attackRange 범위 확인
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, attackRange);
        }



        #endregion

        #region Custom Method
        //타워에서 가장 가까운 적 찾기
        void UpdateTarget()
        {
            //맵에 있는 모든 오브젝트 가져오기
            //FindGameObjectsWithTag => s 붙어있는지 확인!
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            //최소거리 변수 초기화
            float minDistance = float.MaxValue;
            //최소거리에 있는 게임오브젝트 변수
            GameObject nearEnemy = null;
            
            foreach (GameObject enemy in enemies)
            {
                //enemy들과의 거리 구하기 
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if(distance < minDistance)
                {
                    minDistance = distance;
                    nearEnemy = enemy;
                }

            }
            //가장 가까운 적을 찾았다
            if (nearEnemy != null && minDistance <= attackRange)
            {
                target = nearEnemy;
            }
            else
            {
                target = null;
            }

        }



        #endregion

    }
}
