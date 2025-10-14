using UnityEngine;
using UnityEngine.iOS;

namespace MyDefence
{
    /// <summary>
    /// 타워 선택 UI를 관리하는 클래스
    /// </summary>
    public class BuildMenu : MonoBehaviour
    {

        #region Custom Method
        //머신건 버튼 선택시 호출되는 함수
        public void SelectMachineGun()
        {
            //Debug.Log("머신건 타워를 선택하였습니다!!");

            //turretToBuild = machineGunPrefab;
            BuildManager.Instance.SetTurretToBuild(BuildManager.Instance.machineGunPrefab);
        }

        public void RocketTower()
        {
            //Debug.Log("다른 타워 선택하였습니다!");
            BuildManager.Instance.SetTurretToBuild(BuildManager.Instance.rocketTowerPrefab);
        }

        #endregion
    }
}
