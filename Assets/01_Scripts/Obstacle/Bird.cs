using UnityEngine;

public class Bird : PoolableMono
{
    private HorizontalMovement movement;
    private NotifyComponent notifyComponent;

    private GameObject player;

    private float distance;
    private bool isNotified = false;

    [SerializeField] private float blinkTime = 0.6f;

    private void Awake()
    {
        movement = GetComponent<HorizontalMovement>();
        notifyComponent = GetComponentInChildren<NotifyComponent>();
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance <= 5f && (true == isNotified))
        {
            notifyComponent.StopBlink();
        }
        else if ((distance <= 15f) && (false == isNotified))
        {
            isNotified = true;
            notifyComponent.PlayBlink(blinkTime);
        }
    }

    public override void OnPop()
    {
        player = GameManager.Instance.Player;
    }

    public override void OnPush()
    {
        notifyComponent.Reset();
    }
}
