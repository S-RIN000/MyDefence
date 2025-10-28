using UnityEngine;
using UnityEngine.iOS;
using static UnityEngine.GraphicsBuffer;

namespace MyDefence
{
    public class Rocket : Bullet
    {
        /// <summary>
        /// 미사일 발사체를 관리하는 클래스, bullet을 상속받는다
        /// </summary>

        #region Variables
        //거리안에 있는 적에게 데미지 주는 범위
        public float damageRange = 3.5f;

        #endregion

        #region Unity Event Method

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, damageRange);
        }
        #endregion

        #region Custom Method 
        //미사일을 기준으로 변경 3.5안에 있는 모든 enemy를 데미지입고 kill
        protected override void HitTarget()
        {
            //타격위치에 이펙트를 생성(instiate)한 후 3초뒤에 타격 이펙트 오브젝트 kill
            GameObject effectGo = Instantiate(impactPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 3f);

            //Debug.Log("Hit Enemy!!!");
            //damageRange 안에 있는 모든 적에게 데미지 주는 범위
            Explosion();

            //탄환 킬
            Destroy(this.gameObject);   //현재 이 스크립트가 붙어있는 게임오브젝트를 없애라
        }

        //damageRange 안에 있는 모든 적(enemy)에게 데미지 주는 범위
        private void Explosion()
        {
            //데미지범위 안에 있는 모든 충돌체를 가져오기
            Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, damageRange);  

            //모든 충돌체 중에서 enemy 찾아서 데미지 주기
            foreach (Collider collider in hitColliders)
            {
                
                //enemy 찾기 - tag 검사
                if (collider.tag == "Enemy")
                {
                    
                    Damage(collider.transform);
                }

            }
        }

        #endregion
    }
}
