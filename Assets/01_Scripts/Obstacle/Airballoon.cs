using UnityEngine;

public class Airballoon : MovementObstacle
{
    [SerializeField] private float destroyPositionY = 15f;

    protected override void DestroyCheck()
    {
        if (transform.position.y >= destroyPositionY)
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
