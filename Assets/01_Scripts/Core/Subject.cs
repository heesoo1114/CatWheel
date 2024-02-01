using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
    private readonly List<ObserverBase> observers = new ();

    public void AttachObserver(ObserverBase observer)
    {
        if (null == observer) return;

        if (false == observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }

    public void DetachObserver(ObserverBase observer)
    {
        if (null == observer) return;

        if (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }

    protected void ClearObservers()
    {
        if (observers.Count > 0)
        {
            observers.Clear();
        }
    }

    protected void NotifyObservers()
    {
        foreach (ObserverBase observer in observers)
        {
            observer.Notify();
        }
    }
}
