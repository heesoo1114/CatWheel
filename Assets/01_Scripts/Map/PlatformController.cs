using UnityEngine;

public class PlatformController : Observer<GameController>
{
    private PlatformMovement movement;
    private PlatformCollision collision;

    private float targetValue;
    private bool isPlus = true;
    private bool isCanChange = true;

    [SerializeField] private float changeAnimSpeed = 5f;
    [SerializeField] private float changeDelayTime = 0.2f;

    private float initAmplitude;

    private StageData stageData;

    public override void Notify()
    {
        if (mySubject.IsPlaying)
        {
            // ���� ���� �� �̺�Ʈ ����
            InputHandler.Instance.OnTouch += ChangeAmplitude;
            
            SetData();
            collision.OnCollider();
            movement.ActivateDraw();
        }
        else if (mySubject.IsReady)
        {
            // �غ������ ���� ���� ����
            InputHandler.Instance.OnTouch -= ChangeAmplitude;

            collision.OffCollider();
            movement.DeactivateDraw();
        }
    }

    private void Awake()
    {
        SetUp();

        collision = GetComponentInChildren<PlatformCollision>();
        movement = GetComponent<PlatformMovement>();
        initAmplitude = movement.Amplitude;
    }

    private void Start()
    {
        stageData = GameManager.Instance.StageData;
    }

    // ���� ����
    private void Update()
    {
        float temp = movement.Amplitude + (targetValue * Time.deltaTime * changeAnimSpeed);       
        movement.SetAmplitude(temp);
    }

    private void SetData()
    {
        movement.Frequency = stageData.Frequency;
        movement.MoveSpeed = stageData.MoveSpeed; 
    }

    private void ChangeAmplitude()
    {
        if (false == isCanChange) return;
        isCanChange = false;

        isPlus = !isPlus;
        if (isPlus)
        {
            targetValue = -initAmplitude;
        }
        else
        {
            targetValue = initAmplitude;
        }

        StartCoroutine(this.GiveDelayWithAction(changeDelayTime, () =>
        {
            isCanChange = true;
        }));
    }
}
