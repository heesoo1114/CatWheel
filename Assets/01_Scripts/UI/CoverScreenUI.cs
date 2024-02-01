using System.Collections;
using UnityEngine;

public class CoverScreenUI : Observer<GameController>
{
    private Animator animator;

    private int isOnHash = Animator.StringToHash("isOn");

    private void Awake()
    {
        SetUp();

        animator = GetComponent<Animator>();
    }

    public override void Notify()
    {
        if (mySubject.IsOver || mySubject.IsClear)
        {
            PlayTransitionEffect();
        }
    }

    private void PlayTransitionEffect()
    {
        animator.SetTrigger(isOnHash);
    }
}
