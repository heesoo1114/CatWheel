using UnityEngine;

public abstract class ScreenUI : PoolableMono
{
    private Transform canvasTransform;

    private bool isActive;
    public bool IsActive => isActive;

    protected virtual void Awake()
    {
        canvasTransform = FindObjectOfType<Canvas>().transform.GetChild(0);
    }

    public void Show()
    {
        if (false == isActive)
        {
            isActive = true;
            transform.SetParent(canvasTransform);
            transform.position = canvasTransform.position;
            transform.localScale = Vector3.one;
            OnShow();
        }
    }

    public void Hide()
    {
        if (isActive)
        {
            OnHide();
            PoolManager.Instance.Push(this);
            isActive = false;
        }
    }

    public abstract void OnShow();
    public abstract void OnHide();  

    public override void OnPop()
    {
        
    }

    public override void OnPush()
    {
        
    }
}
