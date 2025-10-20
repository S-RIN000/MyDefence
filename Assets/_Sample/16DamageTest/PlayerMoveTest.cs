using MyDefence;
using UnityEngine;

namespace Sample
{
    /// <summary>
    /// wasd 키 누르면 앞뒤좌우 이동, F키 누르면 뷸렛 발사 구현
    /// </summary>
    public class PlayerMoveTest : MonoBehaviour
    {
        #region Variables
        //플레이어 이동속도
        public float speed = 5f;

        //총알 프리팹 오브젝트
        public GameObject bulletPrefab;
        public Transform firePoint;

        public GameObject target;

        //공격 범위
        public float attackRange = 30f;

        //찾기 타이머
        public float searchTimer = 0.2f;
        protected float countdown = 0;

        #endregion

        #region Unity Event Method


        private void Update()
        {
            //0.2초 마다 가까운 적 찾기
            if (countdown <= 0f)
            {
                //타이머 기능 (= 가장 가까운 적 찾기)
                UpdateTarget();
                //타이머 초기화     //마이너스 누적은 초기화를 해주는게 좋다
                countdown = searchTimer;
            }
            countdown -= Time.deltaTime;

            //WASD 키를 누르면 앞뒤좌우로 이동
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");
            Vector3 dir = Vector3.right * moveX + Vector3.forward * moveY;

            transform.Translate(dir * Time.deltaTime * speed, Space.World);

            //가장 가까운 적을 못 찾았으면  
            //NULL이면 RETURN 밑을 실행하지 말라
            if (target == null) return;

            //회전-> (타겟 방향으로 (총구) 회전)
            //Vector3 dirRotate = target.transform.position - transform.position;
            //transform.rotation = Quaternion.LookRotation(dirRotate);    
            transform.LookAt(target.transform);

            //발사 버튼
            if (Input.GetKeyDown(KeyCode.F))
            {
                Fire();
            }

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
                if (distance < minDistance)
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

        private void Fire()
        {
            //Debug.Log("발사!!!");
            //총구(Fire Point) 위치에 탄환 객체 생성(Instiate)하기
            GameObject bullotGo = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            BulletTest bullet = bullotGo.GetComponent<BulletTest>();
            if (bullet != null)
            {
                bullet.SetTarget(target.transform);
            }

            //일정시간 지나면 자동으로 킬
            Destroy(bullotGo, 3f);
        }

            //지금처럼 유도탄이 아닌, 직선으로 발사되는 탄환이라면 이 식이 들어가야한다 (노리던 타겟이 사라져서 탄환 잉여가 남아있는 것 방지용)
            //Destroy(bullotGo, 3f);

     
            
        
        #endregion
    }
}
