using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenUI : ScreenUI
{
    public override void OnShow()
    {

    }

    public override void OnHide()
    {
        
    }

    private void TouchEvent()
    {
        GameManager.Instance.GameStart();
    }
}
