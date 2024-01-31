using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private PlatformMovement movement;

    private float targetValue;
    private bool isPlus = true;

    [SerializeField] private float changeAnimSpeed = 5f;

    private float initAmplitude;

    private void Awake()
    {
        // ��ġ �� �̺�Ʈ ����
        InputHandler.Instance.OnTouch += ChangeAmplitude;

        movement = GetComponent<PlatformMovement>();
        initAmplitude = movement.Amplitude;
    }

    // ���� ����
    private void Update()
    {
        float temp = movement.Amplitude + (targetValue * Time.deltaTime * changeAnimSpeed);       
        movement.SetAmplitude(temp);
    }

    private void ChangeAmplitude()
    {
        isPlus = !isPlus;

        if (isPlus)
        {
            targetValue = -initAmplitude;
        }
        else
        {
            targetValue = initAmplitude;
        }
    }
}
