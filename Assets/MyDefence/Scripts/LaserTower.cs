using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace MyDefence
{
    /// <summary>
    /// 레이저를 쏘는 타워를 관리하는 클래스, Tower를 상속받는다
    /// </summary>
    public class LaserTower : Tower
    {
        #region Variables
        //레이저 빔 
        private LineRenderer lineRenderer;

        //레이저 빔 타격 이펙트
        public ParticleSystem laserImpact;

        //레이저 빔 타격 라이팅
        public Light impactLight;

        //1초당 30 데미지
        [SerializeField]
        private float laserDamage = 30f;

        //타이머
        //private float damageTimer = 1f;
        //private float damageCountdown = 0f;

        //이동속도 40%감속
        [SerializeField]
        private float slowRate = 0.4f;
        #endregion

        #region Unity Event Method
        protected override void Start()
        {
            //부모 클래스(Tower)의 start() 실행
            base.Start();

            //참조
            lineRenderer = this.transform.GetComponent<LineRenderer>();
        }
            
        protected override void Update()
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

            //가장 가까운 적을 못 찾았으면
            //NULL이면 RETURN 밑을 실행하지 말라
            if (target == null)
            {
                //레이저를 그리지 않는다, 타격 이팩트도 정지
                if(lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    laserImpact.Stop();     //레이저를 그리지 않으면 임팩트도 없음
                    impactLight.enabled = false;
                }

                return;
            }


            //타겟을 향해서 회전
            LockOn();

            //레이저 빔 쏘기
            ShootLaser();
        }
      
        #endregion

        #region Custom Method
        private void ShootLaser()
        {
            //데미지 주기
            float frameDamage = Time.deltaTime * laserDamage;   //프레임당 데미지
            Enemy enemy = target.GetComponent<Enemy>();
            if(enemy != null)
            {
                //데미지 주기
                enemy.TakeDamage(frameDamage);

                //이동속도 감속 (0.4f)
                enemy.Slow(slowRate);
            }

            // 1초에 한번씩 데미지 ↓    ↑ 누적 데미지 (ex. 0.5초에는 15데미지)
            /*
            damageCountdown += Time.deltaTime;
            if(damageCountdown >= damageTimer)
            {
               
                //타이머 기능 - 1초마다 30 데미지
                Enemy enemy = target.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(laserDamage);
                }

                //타이머 초기화
                damageCountdown = 0f;
                
            } */

            //라인 렌더를 그린다(타겟이 범위 안에 있으면), 레이저 타격 효과 그리기
            if (lineRenderer.enabled == false)
            {
                lineRenderer.enabled = true;
                laserImpact.Play();
                impactLight.enabled = true;
            }

            //라인 렌더러의 시작, 끝 지점 지정
            lineRenderer.SetPosition(0, firePoint.position);        //시점
            lineRenderer.SetPosition(1, target.transform.position); //종점

            //레이저 타격 이팩트
            Vector3 dir = firePoint.position - laserImpact.transform.position;  //타격 이팩트가 firepoint를 바라보는 방향을 바라본다  → ←
            laserImpact.transform.position = target.transform.position + dir.normalized/2;  //dir.normalized = 1
            laserImpact.transform.rotation = Quaternion .LookRotation(dir);
        }


        #endregion
    }
}
