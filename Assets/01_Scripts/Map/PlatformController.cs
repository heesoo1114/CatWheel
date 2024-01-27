using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private PlatformWaveMovement movement;

    private float temp;
    private float targetValue;
    private bool isPlus = true;

    [SerializeField] private float changeAnimSpeed = 5f;

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
                // ������
                targetValue = -2f;
            }
            else
            {
                // �����
                targetValue = 2f;
            }
        }

        temp = movement.Amplitude + (targetValue * Time.deltaTime * changeAnimSpeed);       
        movement.SetAmplitude(temp);
    }

}
