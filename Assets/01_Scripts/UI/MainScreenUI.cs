using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenUI : ScreenUI
{
    public override void OnShow()
    {
        InputHandler.Instance.OnTouch += TouchEvent;
    }

    public override void OnHide()
    {
        InputHandler.Instance.OnTouch -= TouchEvent;
    }

    private void TouchEvent()
    {
        GameManager.Instance.GameStart();
    }
}
