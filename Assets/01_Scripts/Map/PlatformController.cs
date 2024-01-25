using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private PlatformWaveMovement movement;

    private float temp;
    private float targetValue;
    private bool isPlus = true;

    private void Awake()
    {
        movement = GetComponent<PlatformWaveMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isPlus = !isPlus;

            if (isPlus)
            {
                // 음수로
                targetValue = -1f;
            }
            else
            {
                // 양수로
                targetValue = 1f;
            }
        }

        temp = movement.Amplitude + (targetValue * Time.deltaTime);
        movement.SetAmplitude(temp);
    }

}
