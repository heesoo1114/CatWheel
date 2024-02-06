using UnityEngine;

public abstract class MovementObstacle : PoolableMono
{
    private NotifyComponent notifyComponent;

    private Transform playerTransform;

    private float distance;
    private bool isNotified = false;

    [Header("Effect")]
    [SerializeField] private float blinkTime = 0.6f;
    [SerializeField] private float startBlinkDistance = 20f;
    [SerializeField] private float stopBlinkDistance = 10f;

    protected virtual void Awake()
    {
        notifyComponent = GetComponentInChildren<NotifyComponent>();
    }

    protected virtual void Update()
    {
        // distance = Vector2.Distance(transform.position, playerTransform.position);
        distance = Mathf.Abs(transform.position.x - playerTransform.position.x);

        if ((distance <= stopBlinkDistance) && isNotified)
        {
            notifyComponent.StopBlink();
        }
        else if ((distance <= startBlinkDistance) && (false == isNotified))
        {
            isNotified = true;
            notifyComponent.PlayBlink(blinkTime);
        }

        DestroyCheck();
    }

    protected abstract void DestroyCheck();

    public override void OnPop()
    {
        playerTransform = GameManager.Instance.Player.transform;
    }

    public override void OnPush()
    {
        isNotified = false;
        notifyComponent.Reset();
    }
}
