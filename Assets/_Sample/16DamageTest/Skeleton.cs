using UnityEngine;
using MyDefence;

namespace Sample
{
    /// <summary>
    /// IDamageable 을 상속받는 몬스터 클래스
    /// </summary>
    public class Skeleton : MonoBehaviour, IDamageable
    {
        #region Variables
        //체력
        protected float health;

        [SerializeField]
        protected float startHealth = 1f;    //체력 초기값

        //죽음 체크
        protected bool isDeath = false;
        #endregion

        #region Unity Event Method
        protected virtual void Start()
        {
            //초기화
            health = startHealth;
        }

        #endregion

        #region Custom Method
        public virtual void TakeDamage(float damage)
        {
            health -= damage;

            //죽음 체크
            if (health <= 0f && isDeath == false)
            {
                Die();
            }
        }

        protected virtual void Die()
        {
            isDeath = true;

            //
            Destroy(gameObject);
        }

        #endregion
    }
}
