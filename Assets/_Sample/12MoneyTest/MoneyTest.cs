using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Sample
{
    /// <summary>
    /// 소지금 연산 예제, 원래 함수에 숫자는 안쓰는데 이 예제만 쓰는거임
    /// </summary>
    public class MoneyTest : MonoBehaviour
    {
        #region Variables
        //소지금
        private int gold;

        //초기 소지금을 밸런스 조정 외에 외부에서 사용할 일이 없기 때문에
        [SerializeField]
        //초기 소지금 
        private int startGold = 1000;

        //소지금 UI Text
        public TextMeshProUGUI goldText;

        //구매버튼 UI
        public Button button1000;
        public Button button9000;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //초기화
            startGold = 2000;
            //게임을 진행했으면 저장된 데이터를 가져와서 소지금을 초기화 

            //게임을 다운로드 받고 처음 시작하면 지급
            gold = startGold;    //초기 소지금 지급 
            
        }

        private void Update()
        {
            //소지금 체크하여 버튼 색 변경
            if (HasGold(1000))
            {
                //button1000.image.color = Color.white;
                //button1000.enabled = true;      //색 뿐만 아니라 기능 자체를 비활성화 하겠다 
                button1000.interactable = true;   //위로 진행하면 비활성화 구분이 잘 안가기 때문에 버튼 비활성화는 버튼 자체를 끄기보다 이런식으로 수정한다 (비활성화 색 수정은 Disable color)
            }
            else
            {
                //button1000.image.color = Color.red;
                //button1000.enabled = false;
                button1000.interactable = false;
            }

            if (HasGold(9000))
            {
                //button9000.image.color = Color.white;
                //button9000.enabled = true;
                button9000.interactable = true;
            }
            else
            {
                //button9000.image.color = Color.red;
                //button9000.enabled = false;
                button9000.interactable = false;
            }

            //소지금(not 초기소지금)과 UI Text 연결
            goldText.text = gold.ToString() + " GOLD";

        }

        #endregion

        #region Custom Method
        public void Save()
        {

            //Debug.Log("1000 Gold Save");
            AddGold(1000);
        }

        public void Purchase1()
        {
            if (UseGold(1000) == true)  //함수값이 true일때만 아이템 구매 가능
            {
                Debug.Log("1000 Item Purchase");
            }
        }

        public void Purchase2()
        {
            if (UseGold(9000) == true)  //함수값이 true일때만 아이템 구매 가능
            {
                Debug.Log("9000 Item Purchase");
            }
        }

        //돈, gold
        //돈을 번다 : 사냥, 퀘스트, 캐쉬, 초기 소지금, 선물받기...
        public void AddGold(int amount)
        {
            gold += amount;     //위의 예시들로 돈을 번다
        }

        //돈을 쓴다 : 아이템 구매, 기구 사용, 건설비용, 선물하기...
        //돈이 부족하면 돈을 사용하지 않고 return false;
        //돈이 충분하면 돈을 사용하고 return true;
        public bool UseGold(int amount)
        {
            //소지금 체크
            if(gold < amount)
            {
                Debug.Log("소지금이 부족합니다");
                return false;
            }

            gold -= amount;
            return true;
        }

        //소지금 체크, 잔고 확인
        public bool HasGold(int amount)
        {
            return gold >= amount;
        }

        #endregion
    }
}

/*
멤버 변수값 초기화

1. 변수 선언과 동시에 초기값을 설정한다 1000
2. 인스펙터 창에서 초기값을 직접 입력한다 3000
3. Awake, Start 함수에서 초기값을 설정한다 2000
 
 */