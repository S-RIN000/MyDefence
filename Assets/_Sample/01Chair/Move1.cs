using UnityEngine;

public class Move1 : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float moveDistance = 5f; // 앞으로 이동할 최대 거리
    private Vector3 startPosition;
    private bool movingForward = true;

    void Start()
    {
        startPosition = transform.position;
        Debug.Log("앞으로 이동하기");
    }

    void Update()
    {
        if (movingForward)
        {
            // 앞으로 이동
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            // 최대 거리에 도달하면 방향 전환
            if (Vector3.Distance(startPosition, transform.position) >= moveDistance)
            {
                movingForward = false;
            }
        }
        else
        {
            // 뒤로 이동
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

            // 시작 지점으로 돌아오면 방향 전환
            if (Vector3.Distance(startPosition, transform.position) <= 0.1f)
            {
                movingForward = true;
            }
        }
    }
}
