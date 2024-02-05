using UnityEngine.InputSystem;
using System;
using UnityEngine;

public class InputHandler : MonoSingleton<InputHandler>
{
    private InputReciever inputReciever;

    public Action OnTouch;

    public override void Init()
    {
        inputReciever = new InputReciever();
        inputReciever.TouchInput.Touch.started += Touch;
    }

    public void ActivateReciever()
    {
        inputReciever.Enable();
    }

    public void DeactivateReciever()
    {
        inputReciever.Disable();
    }

    public void Touch(InputAction.CallbackContext context)
    {
        OnTouch?.Invoke();
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 300, 150), "Start"))
        {
            GameManager.Instance.GameStart();
        }
    }
}
