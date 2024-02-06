using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MovementObstacle
{
    protected override void DestroyCheck()
    {
           
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
