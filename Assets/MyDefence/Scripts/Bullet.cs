using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 탄환 발사체를 관리하는 클래스
    /// </summary>
    public class Bullet : MonoBehaviour
    {
        #region Variables
        //타겟 오브젝트
        private Transform target;   //생성되는 이너미중 가장 가까운 놈을 쏴야해서 public으로 해도 끌어올 타겟이 없음

        //탄환의 이동 속도
        public float moveSpeed = 70f;

        //타격 이펙트 프리팹 오브젝트
        public GameObject impactPrefab;
        #endregion

        #region Unity Event Method

        

        private void Update()
        {
            //타겟이 없으면 이동하지 않음, 노리는 타겟이 앞서 킬 되면 뷸렛도 킬 
            if (target == null)
            {
                Destroy(gameObject);
                return;
            }

            //타겟까지 이동하기
            Vector3 dir = target.position - transform.position;
            //남은 거리
            float distance = Vector3.Distance(target.position, transform.position);
            //이번 프레임에 이동한 거리
            float distanceThisFrame = Time.deltaTime * moveSpeed;
            if (dir.magnitude <= distanceThisFrame)     //distance 대신 dir.magnitude 가능 (두 벡터간의 거리와 같아서)
            {
                HitTarget();
                return;
            }

            transform.Translate(dir.normalized * Time.deltaTime *  moveSpeed, Space.World);

            //타겟 방향으로 바라보기
            transform.LookAt(target);

        }
        #endregion

        #region Custom Method

        //매개변수로 들어온 타겟으로 저장
        public void SetTarget(Transform _target)
        {
            target = _target;
        }

        //타겟 명중 (이너미와 탄환 삭제)
        protected virtual void HitTarget()      //자식클래스 rocket이 이 함수를 사용하기 위해 접근제한자를 재정의
        {
            //타격위치에 이펙트를 생성(instiate)한 후 3초뒤에 타격 이펙트 오브젝트 kill
            GameObject effectGo = Instantiate(impactPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 3f);

            //Debug.Log("Hit Enemy!!!");
            //타격당한 적에게 데미지 주기
            Damage(target);

            //탄환 킬
            Destroy(this.gameObject);   //현재 이 스크립트가 붙어있는 게임오브젝트를 없애라
        }

        //타격당한 적에게 데미지 주기
        protected void Damage(Transform enemy)
        {
            //타겟 킬
            Destroy(enemy.gameObject);
        }

        #endregion 
    }
}