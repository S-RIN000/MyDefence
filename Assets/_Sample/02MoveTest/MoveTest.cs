using UnityEngine;


namespace Sample
{
    public class MoveTest : MonoBehaviour
    {
        //이동 목표 지점 변수 선언 및 초기화
        private Vector3 targetPosition = new Vector3(7f, 1f, 8f);

        //이동 목표 위치에 있는 오브젝트의 트랜스폼 인스턴스
        public Transform target;    //인스펙터 창에서 세팅할 수 있게 함

        //이동 속도를 저장하는 변수를 선언
        public float speed = 5f;   //1초에 가는 거리, 5가 너무 느려서 속도를 늘리고 싶으면 private -> public 으로 수정하고, 인스펙터 창에서 지정하자
                                   //직접 게임을 하면서 조정하고 싶어서 접근제한자를 수정한 경우

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //포지션 바꾸는 식 (위치 이동) 원래있던자리 -> 식에 표시된 자리 (워프)
            //this.gameObject.transform
            //this.transform.gameObject
            //this.transform.position = new Vector3(7f, 1f, 8f);
            //Debug.Log(this.transform.position);

            //this.transform.position = targetPosition;

            //target오브젝트의 포지션값
            //Debug.Log (target.position);
            //this.transform.position = target.position;
        }

        // Update is called once per frame
        void Update()
        {
            //플레이어의 위치를 앞으로 계속(!) 이동 : z축 값이 증가한다 => 앞으로 이동, 위치가 누적됨
            //this.transform.position 연산으로 구현 - Vecto3
            //this.transform.position.z += 1;     //z값이 계속 누적됨, 반환값을 수정할 수 없다는 에러 발생
            //this.transform.position = this.transform.position + new Vector3(0f, 0f, 1f);    //xy는 고정, z값만 증가하길 원한다면 이렇게 수정해야함

            //this.transform.position += new Vector3(1f, 0f, 0f);    //오른쪽으로 이동

            //this.transform.position += Vector3.forward;

            //앞 방향으로 1초에 1unit 만큼씩 이동
            //this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime;
            //this.transform.position += Vector3.forward * Time.deltaTime;

            //앞 방향으로 1초에 5만큼씩 이동
            //this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * speed;    //초속 5만큼씩 이동

            //Translate
            //dir(방향) : 이동할 방향 - Vector3.forward (단위 : Vector3)
            //Time.deltaTime : 동일한 시간에 동일한 거리를 이동하게 해준다 (단위 : float)
            //speed(속도) : 이동의 빠르기 지정 (단위 : float)
            //dir * Time.deltaTime * speed => 연산의 결과 (단위) : Vector3
            //transform.Translate(Vector3.forward * Time.deltaTime * speed);  //누적식과 기능은 똑같음

            //이동 방향 구하기 : (목표지점 - 현재지점) OR (도착위치 - 현재위치)
            //dir.normalized : 단위백터, 길이가 1인 백터, 정규화된 백터
            //dir.magnitude : 백터의 (실제)길이, 크기, 두 백터간의 거리
            //Vector3 dir = target.position - this.transform.position;
            //this.transform.Translate(dir.normalized * Time.deltaTime * speed, Space.Self);  //dir.normalized :이게 내가 갈 방향

            //Space.Self, Space.World (글로벌, 로컬 축 차이)
            //transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
            transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);      //space이용하면 도착시 흔들리지 않음
        }
    }
}
/*
VECTOR3 스크립팅 API에 예시 정적변수가 있다 (ex. left (-1, 0, 0)) 앞으로는 숫자를 쓰지 않고 이걸 씀

<앞>
this.transform.position += new Vector3(0f, 0f, 0.1f);
this.transform.position += Vector3.forward; 
(0,0,1)

<뒤>
this.transform.position += new Vector3(0f, 0f, -0.1f);
this.transform.position += Vector3.back;
(0,0,-1)

<좌>
this.transform.position += new Vector3(-0.1f, 0f, 0f);
this.transform.position += Vector3.left;
(-1,0,0)

<우>
this.transform.position += new Vector3(0.1f, 0f, 0f);
this.transform.position += Vector3.right;
(1,0,0)

<위>
this.transform.position += new Vector3(0f, 0.1f, 0f);
this.transform.position += Vector3.up;
(0,1,0)

<아래>
this.transform.position += new Vector3(0f, -0.1f, 0f);
this.transform.position += Vector3.down;
(0,-1,0)

Vector3(1f, 1f, 1f); Vector3.one; - 단위백터
Vector3(0f, 0f, 0f); Vector3.zero;
*/

/*

n프레임 : 1초당 n번 실행, 호출
20프레임

this.transform.position += new Vector3(0f, 0f, 1f);

Time.deltaTime : 한프레임 돌아오는데 걸리는 시간 (=한바퀴 도는데 걸리는 시간)

성능 좋은 컴퓨터
10프레임 - 1초에 10 unit(m) 이동 (Time.deltaTime 을 고려하지 않음)
Time.deltaTime : 0.1초 (1프레임)
10프레임 - 1초에 1 unit(m) 이동 (Time.deltaTime 을 고려 ↓ )

this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; // (1*0.1) 0.1씩 증가 
...10번 누적, 한번 돌릴때마다 0.1씩 증가...


 
성능 나쁜 컴퓨터
2프레임 - 1초에 2 unit(m) 이동 (Time.deltaTime 을 고려하지 않음)
Time.deltaTime : 0.5초 (1프레임)
2프레임 - 1초에 1 unit(m) 이동 (Time.deltaTime 을 고려 ↓ )
 
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; //(1*0.5) 0.5씩 증가

이렇게 Time.deltaTime을 적용하면 성능이 좋은 컴퓨터도 나쁜 컴퓨터도 같은 성능을 낼 수 있게 해준다
(유저끼리 성능차이가 날 수 없게 해야하기 때문에 필수)

 */