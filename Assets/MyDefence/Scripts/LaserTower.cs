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
                //레이저를 그리지 않는다
                if(lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
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
            //라인 렌더를 그린다(타겟이 범위 안에 있으면)
            if (lineRenderer.enabled == false)
            {
                lineRenderer.enabled = true;
            }

            //라인 렌더러의 시작, 끝 지점 지정
            lineRenderer.SetPosition(0, firePoint.position);        //시점
            lineRenderer.SetPosition(1, target.transform.position); //종점
        }


        #endregion
    }
}
