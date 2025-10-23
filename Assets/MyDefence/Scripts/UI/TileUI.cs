using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace MyDefence
{
    /// <summary>
    /// 타일 UI를 관리하는 클래스 (버튼, 오브젝트 온오프...)
    /// </summary>
    public class TileUI : MonoBehaviour
    {
        #region Variables
        //타일 UI 오브젝트
        public GameObject ui;

        //선택된 타일 저장
        private Tile targetTile;

        //업그레이드 가격 text
        public TextMeshProUGUI upgradeCostText;

        //업그레이드 버튼
        public Button upgradeButton;

        //판매가격 text
        public TextMeshProUGUI sellCostText;
        #endregion

        #region Unity Event Method
        #endregion

        #region Custom Method
        //타일 UI 보여주기 (매개 변수로 선택된 타일 정보를 가져온다)
        public void ShowTileUI(Tile tile)
        {
            //내가 선택된 타일 위치에서 보여주기
            targetTile = tile;
            this.transform.position = tile.transform.position;

            //타일 UI value세팅
            if (targetTile.isUpgradeCompleted)
            {
                upgradeCostText.text = "DONE";
                upgradeButton.interactable = false;
            }
            else
            {
                upgradeCostText.text = targetTile.blueprint.upgradeCost.ToString() + " G";
                upgradeButton.interactable = true;
            }

            //반값으로 판매
            sellCostText.text = targetTile.blueprint.GetSellCost().ToString() + " G"; 

            ui.SetActive(true);
        }

        //타일 UI 숨기기
        public void HideTileUI()
        {
            targetTile = null;
            ui.SetActive(false);
        }

        //업그레이드 버튼을 선택했습니다
        public void UpgradeTower()
        {
            Debug.Log("설치된 타워를 업그레이드 합니다");
            targetTile.UpgradeTower();  
        }

        //SELL 버튼을 선택했습니다
        public void SellTower()
        {
            targetTile.SellTower();
        }

        
        #endregion
    }
}
