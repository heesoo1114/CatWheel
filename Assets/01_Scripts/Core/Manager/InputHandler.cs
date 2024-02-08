using UnityEngine.InputSystem;
using System;

public class InputHandler : MonoSingleton<InputHandler>
{
    private InputReciever inputReciever;

    public Action OnTouch;

    public override void Init()
    {
        inputReciever = new InputReciever();
        inputReciever.TouchInput.Touch.started += Touch;

        ActivateReciever();
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
}
