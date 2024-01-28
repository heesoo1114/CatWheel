using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEditor.Rendering;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Camera myCam;

    private Vector3 camInitPosition;  // ī�޶� ���� ��ġ
    private Vector3 startPosition;    // Ÿ���� ���� ��ġ
    private Vector3 targetPosition;   // Ÿ���� ��ġ
    private Vector3 smoothedPosition; // ������ ���� ����

    [SerializeField] private Transform targetTransform;

    [SerializeField] private float smoothSpeed;

    [Header("Offset")]
    [SerializeField] private float screenX = 1.5f;
    [SerializeField] private float screenY = 1.5f;

    private void Awake()
    {
        myCam = Camera.main;
        camInitPosition = transform.position;
        startPosition = targetTransform.position;
    }

    private void Start()
    {
        myCam.transform.position = targetTransform.position;
    }

    private void LateUpdate()
    {
        targetPosition.x = targetTransform.position.x + screenX;
        targetPosition.y = startPosition.y + screenY;
        targetPosition.z = camInitPosition.z;

        smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        myCam.transform.position = smoothedPosition;
    }
}
