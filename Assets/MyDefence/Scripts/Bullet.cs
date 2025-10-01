using UnityEngine;

namespace MyDefence
{
    public class Bullet : MonoBehaviour
    {
        #region Variables
        //타겟 오브젝트
        private Transform target;   //생성되는 이너미중 가장 가까운 놈을 쏴야해서 public으로 해도 끌어올 타겟이 없음

        //탄환의 이동 속도
        public float moveSpeed = 70f;

        //타격 이펙트 프리팹 오브젝트
        public GameObject ImpactPrefab;
        #endregion

        #region Unity Event Method

        

        private void Update()
        {
            //타겟이 없으면 이동하지 않음
            if (target == null)
            {
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


        }
        #endregion

        #region Custom Method

        //매개변수로 들어온 타겟으로 저장
        public void SetTarget(Transform _target)
        {
            target = _target;
        }

        //타겟 명중 (이너미와 탄환 삭제)
        private void HitTarget()
        {
            //타격위치에 이펙트를 생성(instiate)한 후 3초뒤에 타격 이펙트 오브젝트 kill
            GameObject effectGo = Instantiate(ImpactPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 3f);

            //Debug.Log("Hit Enemy!!!");
            //타겟 킬
            Destroy(target.gameObject);
            //탄환 킬
            Destroy(this.gameObject);   //현재 이 스크립트가 붙어있는 게임오브젝트를 없애라
        }

        #endregion 
    }
}