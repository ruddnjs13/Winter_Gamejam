using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, Controls.IPlayerActions
{
    private Controls _controls;

    public Action ReversePosEvent;
    public Action AttackEvent;
    
    public Vector2  MoveDir {get; private set;}
    public Vector2  MousePos {get; private set;}

    private void OnEnable()
    {
        if (_controls == null)
        {
            _controls = new Controls();
            _controls.Player.SetCallbacks(this);
        }
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

   
    public void OnMove(InputAction.CallbackContext context)
    {
        MoveDir = context.ReadValue<Vector2>().normalized;
    }

    public void OnReversePos(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ReversePosEvent?.Invoke();
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            AttackEvent?.Invoke();
        }
    }

    public void OnMoveMouse(InputAction.CallbackContext context)
    {
        MousePos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }
}
