using UnityEngine;
using System.Collections;

namespace Sample
{
    public class PrefabTest : MonoBehaviour
    {
        #region Variables
        //프리팹 오브젝트
        public GameObject prefab;

        //맵 타일들의 부모 오브젝트
        //public Transform parent;

        //맵 타일 생성 체크 (코루틴함수는 딱 한번 찍혀야 하기 때문에)
        bool isCreate = false;
        #endregion

        #region Unity Event Method
        private void Start ()
        {
            //[1] Instantiate (prefab);  = > prefab을 무대위(Hierarchy)로 올리는 명령어
            //Instantiate(prefab);

            //위치: (5f, 0f, 8f) 맵타일 생성하기
            //instantiate(prefab, 위치, 방향);
            //Vector3 position = new Vector3(5f, 0f, 8f);
            //Instantiate(prefab, position, Quaternion.identity);
            //Instantiate(prefab, new Vector3(5,0,8), Quaternion.identity);

            //10행*10열 타일맵 찍기
            //GenerateMap(10,10);

            //멥 제네레이터를 부모로 지정하여 맵 타일 찍기
            //GenerateMapTile(10,10);

            //10행(row)*10(column)열 중에 랜덤한 위치에 타일 하나 찍기
            //GenerateRandomMapTile();

            //랜덤 타일을 1초 간격으로 10개 찍는다
            //타일 하나 찍고 -> 1초 쉬었다가 -> 타일 하나 찍고 ...
            //Debug.Log("[0] 코루틴 시작");
            //StartCoroutine(CreateMapTile());
            //Debug.Log("[4] 타일 생성 완료");


        }

        private void Update ()
        {
            if ( isCreate == false )
            {
                //랜덤 타일을 1초 간격으로 10개 찍는다
                //타일 하나 찍고 -> 1초 쉬었다가 -> 타일 하나 찍고 ...
                Debug.Log("[0] 코루틴 시작");
                StartCoroutine(CreateMapTile());

                isCreate = true;
                Debug.Log($"[4] 타일 생성 완료 : {isCreate}");
            }
            Debug.Log($"[99] 업데이트 내용 실행");

        }
        #endregion

        #region Custom Method
        void GenerateMap(int row, int column)
        {
            //10행(row)*10(column)열 타일맵 찍기, 타일간 간격은 1이다
            for (var i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Vector3 position = new Vector3(i * 5f, 0f, j*5f);   //2중 포문, 간격조정
                    Instantiate(prefab, position, Quaternion.identity);
                }
              
              
            }
          
        }

        //위 처럼 맵타일이 많은 경우 하나의 부모를 두는게 더 안정적이므로
        //멥 제네레이터를 부모로 지정하여 맵 타일 찍기

        void GenerateMapTile(int row, int column)
        {
            //10행(row)*10(column)열 타일맵 찍기, 타일간 간격은 1이다
            for (var i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    //인스턴스 생성 시 위치 지정
                    //Vector3 position = new Vector3(i * 5f, 0f, j * 5f);   //2중 포문, 간격조정
                    //Instantiate(prefab, position, Quaternion.identity, parent);     //parent추가
                    //Instantiate(prefab, position, Quaternion.identity, this.transform); //스크립트가 붙어있는 객체의 포지션을 콕 찝어 가져오기 위해

                    //인스턴스 생성 후 위치 지정 - 생성된 게임오브젝트(transform) 객체 가져오기
                    GameObject go =  Instantiate(prefab, this.transform);
                    go.transform.position = new Vector3(i * 5f, 0f, j * 5f);

                }

            }
        }
        //10행(row)*10(column)열 중에 랜덤한 위치에 타일 하나 찍기
        void GenerateRandomMapTile()
        {
/*
            int row = Random.Range(0, 10);
            int column = Random.Range(0, 10);

            Vector3 position = new Vector3(row * 5f, 0f, column * 5f);   
            Instantiate(prefab, position, Quaternion.identity, this.transform);
*/
            
            //0 1 2 3 ... => r:0, c:0~9
            //10 11 12 .. => r:1, c:0~9
            int randNumber = Random.Range(0,100);
            int row = randNumber / 10;
            int column = randNumber % 10;

            Vector3 position = new Vector3(row * 5f, 0f, column * 5f);
            Instantiate(prefab, position, Quaternion.identity, this.transform);
        }

        IEnumerator CreateMapTile()
        {
/*
            GenerateRandomMapTile();
            Debug.Log("[1] 첫번째 타일 생성");
            yield return new WaitForSeconds(1.0f);

            GenerateRandomMapTile();
            Debug.Log("[2] 두번째 타일 생성");
            yield return new WaitForSeconds(1.0f);

            GenerateRandomMapTile();
            Debug.Log("[3] 세번째 타일 생성");
            yield return new WaitForSeconds(1.0f);
*/
            for (int i = 0;i < 10; i++)
            {
                GenerateRandomMapTile();
                Debug.Log($"[{i+1}] 세번째 타일 생성");
                yield return new WaitForSeconds(1.0f);
            }
        }

        #endregion

    }
}

/*
코루틴 함수 : 지연 함수

- 하나 이상의 yield return 문이 꼭 있어야 한다
- yield return 문에서 지연 시간을 지정한다
- 시간(초) 지연 : yield return new WaitForSeconds(지연시간(초));

형식
IEnumerator 함수이름()
{
    //..
    yield return .. //하나 이상의 yield return 문이 꼭 있어야 한다
}

코루틴 함수 호출
StartCoroutine(코루틴함수이름());
 
 */