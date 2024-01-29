using UnityEngine;

public class VerticalWaveMovement : MonoBehaviour
{
    [SerializeField] private float yMoveSpeed; // ���� �̵��ӵ�
    [SerializeField] private float yDelta = 2; // �̵� ����
    private float yStartPosition; // x ���� ��ġ

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
