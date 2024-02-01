using System.Collections;
using UnityEngine;
using System;

public static class MonoExtension
{
    public static IEnumerator GiveDelayWithAction(this MonoBehaviour mono, float delayTime, Action action)
    {
        yield return new WaitForSeconds(delayTime);
        action?.Invoke();
    }
}
