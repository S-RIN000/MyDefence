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
        protected GameObject target;

        //회전 
        public Transform partToRotate ;      //회전을 관리하는 오브젝트
        public float rotateSpeed = 10f;     //회전 속도

        //공격 범위
        public float attackRange = 5f;

        //찾기 타이머
        public float searchTimer = 0.2f;
        protected float countdown = 0;        //타이머를 구현하고자 한다면 변수 2개가 기본이다~

        //발사 타이머
        public float fireTimer = 1f;
        private float fireCountdown = 0f;

        //총알 프리팹 오브젝트
        public GameObject bulletPrefab;
        public Transform firePoint;

        #endregion

        #region Unity Event Method

        protected virtual void Start()
        {
            //필드 초기화
            countdown = searchTimer;     
        }

        protected virtual void Update()
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

            //가장 가까운 적을 못 찾았으면
            //NULL이면 RETURN 밑을 실행하지 말라
            if (target == null) return;

            LockOn();

            
            //가장 가까운 적에게 1초마다 총알을 발사
            fireCountdown += Time.deltaTime;
            if ( fireCountdown >= fireTimer )
            {

                //타이머 기능
                //Debug.Log("발사");
                Shoot();

                //타이머 초기화
                fireCountdown = 0f;
            }

            
        }

        private void OnDrawGizmosSelected()
        {
            //타워 중심으로부터 attackRange 범위 확인
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, attackRange);

           
        }

        #endregion

        #region Custom Method
        //타워에서 가장 가까운 적 찾기
        protected void UpdateTarget()
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

        //타겟을 향해 터렛 헤드 돌리기
        protected void LockOn()
        {
            //타겟을 향해서 partToRocate 회전
            //타겟위치 - 현재위치
            Vector3 dir = target.transform.position - this.transform.position;
            Quaternion lookRocation = Quaternion.LookRotation(dir);
            Quaternion lerpRotation = Quaternion.Lerp(partToRotate.rotation, lookRocation, Time.deltaTime * rotateSpeed);
            Vector3 eulerValue = lerpRotation.eulerAngles;

            //y축으로만 회전하기
            partToRotate.rotation = Quaternion.Euler(0f, eulerValue.y, 0f);
        }

        //발사 
        void Shoot()
        {

            //총구 위치(firePoint)에 탄환객체 생성(instiate)하기
            GameObject bullotGo = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);  //총알은 총구의 앞부분으로 나아가야 하기 때문에 쿼터니언 사용x

            Bullet bullet = bullotGo.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.SetTarget(target.transform); //target은 게임오브젝트, 매개변수는 트랜스폼
            }

            //지금처럼 유도탄이 아닌, 직선으로 발사되는 탄환이라면 이 식이 들어가야한다 (노리던 타겟이 사라져서 탄환 잉여가 남아있는 것 방지용)
            //Destroy(bullotGo, 3f);
            
        }

        #endregion

    }
}
