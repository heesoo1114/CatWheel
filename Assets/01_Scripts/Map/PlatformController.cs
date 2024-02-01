using UnityEngine;

public class PlatformController : Observer<GameController>
{
    private PlatformMovement movement;
    private PlatformCollision collision;

    private float targetValue;
    private bool isPlus = true;

    [SerializeField] private float changeAnimSpeed = 5f;

    private float initAmplitude;

    public override void Notify()
    {
        if (mySubject.IsPlaying)
        {
            movement.ActivateDraw();
            collision.OnCollider();
        }
        else if (mySubject.IsReady)
        {
            collision.OffCollider();
            movement.DeactivateDraw();
        }
    }

    private void Awake()
    {
        SetUp();

        // ��ġ �� �̺�Ʈ ����
        InputHandler.Instance.OnTouch += ChangeAmplitude;

        collision = GetComponentInChildren<PlatformCollision>();
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
