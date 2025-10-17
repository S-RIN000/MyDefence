using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// Enermy를 관리하는 클래스
    /// </summary>
    public class Enemy : MonoBehaviour
    {
        #region 필드 선언부
        //이동 목표 지점 변수 선언 및 초기화
        //private Vector3 targetPosition = new Vector3(-2f, 1f, -17f);

        //이동 목표 위치를 가지고 있는 오브젝트 
        public Transform target;   

        //이동 속도를 저장하는 변수를 선언
        public float speed = 5f;

        //체력
        private float health;

        [SerializeField]
        private float startHealth = 100f;    //체력 초기값

        //죽음 효과
        public GameObject deathEffectPrefab;

        //죽음 보상
        [SerializeField]
        private int rewardMoney = 50;

        #endregion

        #region Unity Event Method
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //초기화 
            health = startHealth;
            target = WayPoints.points[0];

        }

        // Update is called once per frame
        void Update()
        {
            //타겟을 향해 이동
            //이동 방향 구하기 : (목표지점 - 현재지점) OR (도착위치 - 현재위치)
            Vector3 dir = target.position - this.transform.position;

            this.transform.Translate(dir.normalized * Time.deltaTime * speed);

            //도착판정 - public static float Distance 이용
            //타겟과 Enermy의 거리를 구해서 일정거리 안에 들어오면 도착이라고 판정한다
            float distance = Vector3.Distance(target.position, this.transform.position);
            if (distance <= 0.5f)
            {
                Arrive();
            }

        }
        #endregion

        #region Custom Method
        //종점 도착
        private void Arrive()
        {
            //생명 사용
            PlayerStats.UseLives(1);

            //Enemy Kill
            Destroy(this.gameObject);
            //Debug.Log("도착했다");
        }

        //매개변수로 들어온 만큼 데미지를 입는다 (외부에서 공격받음)
        public void TakeDamage(float damage)
        {
            health -= damage;
            Debug.Log($"Enemy Health: {health}");
            
            //죽음 체크
            if (health <= 0)
            {
                health = 0;
                Die();
            }
        }

        //죽음 처리
        private void Die()
        {
            Debug.Log("Enemy kill");
            //죽음 처리 (all)
            //effect 효과 (vfx, sfx...)
            GameObject effectGo = Instantiate(deathEffectPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);

            //보상 처리
            //enemy를 해치울때마다 50씩 리워드
            PlayerStats.AddMoney(rewardMoney);

            //Enemy Kill
            Destroy(this.gameObject);
            
          
        }
        #endregion
    }
}
