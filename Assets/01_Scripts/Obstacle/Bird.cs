using UnityEngine;

public class Bird : MovementObstacle
{
    [SerializeField] private float destroyPositionX = -2f; 

    protected override void DestroyCheck()
    {
        if (transform.position.x <= destroyPositionX)
        {
            PoolManager.Instance.Push(this);
        }
    }

    public sealed override void OnPop()
    {
        base.OnPop();
    }

    public sealed override void OnPush()
    {
        base.OnPush();
    }
}
