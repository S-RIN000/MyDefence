using UnityEngine;

public class Move2 : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float moveDistance = 5f; // 위로 이동할 최대 거리
    private Vector3 startPosition;
    private bool movingUp = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (movingUp)
        {
            // 위로 이동
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

            // 최대 거리에 도달하면 방향 전환
            if (Vector3.Distance(startPosition, transform.position) >= moveDistance)
            {
                movingUp = false;
            }
        }
        else
        {
            // 아래로 이동
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

            // 시작 지점으로 돌아오면 방향 전환
            if (Vector3.Distance(startPosition, transform.position) <= 0.1f)
            {
                movingUp = true;
            }
        }
    }
}
