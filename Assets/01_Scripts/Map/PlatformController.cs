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
                // 음수로
                targetValue = -2f;
            }
            else
            {
                // 양수로
                targetValue = 2f;
            }
        }

        float temp = movement.Amplitude + (targetValue * Time.deltaTime * changeAnimSpeed);       
        movement.SetAmplitude(temp);
    }

}
