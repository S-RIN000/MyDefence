using UnityEngine;
using UnityEngine.UI;

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
        [SerializeField]
        private float speed = 5f;

        //이동 속도 초기화
        [SerializeField]
        private float startSpeed = 4f;

        //체력
        private float health;
        //체력 초기값
        [SerializeField]
        private float startHealth = 100f; 

        //죽음 체크
        private bool isDeath = false;

        //죽음 효과
        public GameObject deathEffectPrefab;

        //죽음 보상
        [SerializeField]
        private int rewardMoney = 50;

        //UI
        public Image hpBarImage;

        #endregion

        #region Unity Event Method
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //초기화 
            health = startHealth;
            speed = startSpeed;

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
            
            //이동 속도를 초기 속도로 복원
            speed = startSpeed;
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
            //Debug.Log($"Enemy Health: {health}");

            //UI 적용
            hpBarImage.fillAmount = health / startHealth;
            
            //죽음 체크
            if (health <= 0 && isDeath == false) // && isDeath == false <- 두번 보상받는 것 방지용
            {
                health = 0;
                Die();
            }
        }

        //죽음 처리
        private void Die()
        {
            //죽음 체크     <- 두번 보상받는 것 방지용
            isDeath = true;

            Debug.Log("Enemy kill");
            //죽음 처리 (all)
            //effect 효과 (vfx, sfx...)
            GameObject effectGo = Instantiate(deathEffectPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);

            //보상 처리 (골드, 경험치, 아이템...)
            //enemy를 해치울때마다 50씩 리워드
            //Debug.Log("50골드 GET");
            PlayerStats.AddMoney(rewardMoney);

            //Enemy Kill
            Destroy(this.gameObject);
        }

        //이동속도 느리게 하기
        public void Slow(float rate)    //40% 감속
        {
            speed = startSpeed * (1 -rate);   // 감속일때 바로 곱하는거 아님 speed * rate => X 
        }
        #endregion
    }
}
