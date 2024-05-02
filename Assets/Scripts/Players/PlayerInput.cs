using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour, Actions.IPlayerActions
{

    public Vector2 MovementValue { get; private set; }
    private Actions controls;

    private void Start()
    {
        controls = new Actions();
        controls.Player.SetCallbacks(this);
        controls.Player.Enable();
    }
    private void OnDestroy()
    {
        controls.Player.Disable();
    }
    public void OnMove(InputAction.CallbackContext context)
    {

        MovementValue = context.ReadValue<Vector2>();
    }
}
