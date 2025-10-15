using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 타워 건설을 관리하는 싱글톤 클래스
    /// </summary>
    
    public class BuildManager : MonoBehaviour
    {
        #region Singleton
        private static BuildManager instance;

        public static BuildManager Instance
        {
            get
            {
                return instance;
            }
        }

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(this.gameObject);
                return;
            }

            instance = this;

            //DontDestroyOnLoad(this.gameObject);
        }

        #endregion


        #region Variables
        //타일에 설치할 타워 blueprint(프리팹, 가격, 위치정보, ...)를 저장하는 변수
        //여러개의 타워 blueprint 중 선택된 blueprint를 저장하는 변수
        private GameObject turretToBuild;
        private int buildCost;

        private TowerBlueprint towerToBuild;

        #region Property
        //건설 불가능 여부 체크
        public bool CannotBuild
        {
            get { return towerToBuild == null; }   
        }

        //건설 비용 부족 체크
        public bool HasBuildCost
        {
            get
            {
                if (towerToBuild == null)
                    return false;
                return PlayerStats.HasMoney(towerToBuild.cost);
            }
        }

        #endregion

        #endregion

        #region Unity Event Method
        private void Start()
        {
            //초기화 - 임시
            //turretToBuild = machineGunPrefab;
        }
        #endregion

        #region Custom Method
        public TowerBlueprint GetTurretToBuild()
        {
            return towerToBuild;
        }
/*
        public void SetTurretToBuild(GameObject turret, int cost)
        {
            turretToBuild = turret;
            buildCost = cost;
        }
*/      // ↓ 아래로 요약됨
        public void SetTurretToBuild(TowerBlueprint tower)
        {
            towerToBuild = tower;
        }

 /*       public int GetBuildCost()
        {
            return buildCost;
        }*/

        #endregion
    }
}
