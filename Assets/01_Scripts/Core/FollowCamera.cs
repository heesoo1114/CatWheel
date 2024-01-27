using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Camera myCam;
    private Vector3 camInitPosition;
    
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float screenX = 1.5f;
    
    private Vector3 targetPosition;
    private Vector3 startPosition;

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

    private void Update()
    {
        targetPosition.x = targetTransform.position.x + screenX;
        targetPosition.y = startPosition.y;
        targetPosition.z = camInitPosition.z;
        myCam.transform.position = targetPosition;
    }
}
