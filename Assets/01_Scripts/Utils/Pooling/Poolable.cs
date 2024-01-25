using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poolable : PoolableMono
{
    public override void OnPop()
    {
        print("pop");
    }

    public override void OnPush()
    {
        print("push");
    }
}
