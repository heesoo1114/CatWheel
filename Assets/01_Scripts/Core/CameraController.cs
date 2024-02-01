using UnityEngine;

public class CameraController : Observer<GameController>
{
    private Camera myCam;

    private Vector3 camInitPosition;  // ī�޶� ���� ��ġ
    private Vector3 targetPosition;   // Ÿ���� ��ġ
    private Vector3 smoothedPosition; // ������ ���� ����

    [SerializeField] private Transform targetTransform;

    [SerializeField] private float smoothSpeed;

    [Header("Offset")]
    [SerializeField] private float screenX = 1.5f;
    [SerializeField] private float screenY = 1.5f;

    private bool isCamFollow;

    public override void Notify()
    {
        isCamFollow = mySubject.IsPlaying;
    }

    private void Awake()
    {
        SetUp();
        
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
}
