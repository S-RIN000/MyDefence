using UnityEngine;

public class ChairMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //이쪽에 호출하면 1회만 실행이됨, 계속 이동하고 싶으면 Update()에서 호출해야함
    }

    // Update is called once per frame
    void Update()
    {
        //의자를 이동하라
        //Debug.Log("의자를 이동하라");
        transform.Translate(Vector3.forward * Time.deltaTime);  //실제 이동 명령 (콘솔에 출력은 x)
    }
}
