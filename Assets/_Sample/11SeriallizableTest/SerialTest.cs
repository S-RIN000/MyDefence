using UnityEngine;

namespace Sample
{
    //직렬화된 구조체
    [System.Serializable]
    public struct TestStruct
    {
        public float value1;
        public int value2;
    }

    /// <summary>
    /// 직렬화 예제, unity에서 직렬화: 인스펙터 창에서 편집 가능하게 한다
    /// </summary>
    public class SerialTest : MonoBehaviour
    {
        public int number = 10;

        [SerializeField]    //이걸 붙이면 private지만 인스펙터 창에 나타날 수 있음(=public처럼 사용가능 그러나 다른 클래스에서는 읽고 쓸 수 없음)
        private string name = "홍길동"; 


        public TestStruct testStruct;   // 앞선 구조체 선언에 [System.Serializable] 를 붙여야 편집 가능


    }
}
