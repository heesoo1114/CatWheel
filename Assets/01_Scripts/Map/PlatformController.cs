using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private PlatformMovement movement;

    private float targetValue;
    private bool isPlus = true;

    [SerializeField] private float changeAnimSpeed = 5f;

    private void Awake()
    {
        movement = GetComponent<PlatformMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isPlus = !isPlus;

            if (isPlus)
            {
                // ������
                targetValue = -2f;
            }
            else
            {
                // �����
                targetValue = 2f;
            }
        }

        float temp = movement.Amplitude + (targetValue * Time.deltaTime * changeAnimSpeed);       
        movement.SetAmplitude(temp);
    }

}
