using UnityEngine;

public class CoverScreenUI : ScreenUI
{
    private Animator animator;

    private int isOnHash = Animator.StringToHash("isOn");

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponentInChildren<Animator>();
    }

    public override void OnShow()
    {
        PlayTransitionEffect();
        Debug.Log("OnShow");
    }

    public override void OnHide()
    {
        
    }

    private void PlayTransitionEffect()
    {
        animator.SetTrigger(isOnHash);
    }
}
