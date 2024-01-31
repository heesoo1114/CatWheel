using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Camera myCam;

    private Vector3 camInitPosition;  // 카메라 시작 위치
    private Vector3 targetPosition;   // 타겟의 위치
    private Vector3 smoothedPosition; // 보간을 위한 변수

    [SerializeField] private Transform targetTransform;

    [SerializeField] private float smoothSpeed;

    [Header("Offset")]
    [SerializeField] private float screenX = 1.5f;
    [SerializeField] private float screenY = 1.5f;

    private bool isCamFollow = true;

    private void Awake()
    {
        myCam = Camera.main;
        camInitPosition = transform.position;
    }

    private void Start()
    {
        transform.position = camInitPosition;
    }

    private void LateUpdate()
    {
        if (isCamFollow)
        {
            targetPosition.x = targetTransform.position.x + screenX;
            targetPosition.y = camInitPosition.y + screenY;
            targetPosition.z = camInitPosition.z;

            smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
            myCam.transform.position = smoothedPosition;
        }
    }

    public void ActivateFollow()
    {
        isCamFollow = true;
    }

    public void DeactivateFollow()
    {
        isCamFollow = false;
    }
}
