using UnityEngine;

public class VerticalWaveMovement : MonoBehaviour
{
    [SerializeField] private float yMoveSpeed; // 상하 이동속도
    [SerializeField] private float yDelta = 2; // 이동 범위
    private float yStartPosition; // x 시작 위치

    private void Update()
    {
        MoveToY();
    }

    public void MoveToY()
    {
        float y = yStartPosition + yDelta * Mathf.Sin(Time.time * yMoveSpeed);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
