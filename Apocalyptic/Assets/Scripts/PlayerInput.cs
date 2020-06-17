using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public Vector2 Move;
    public Vector2 MouseScreenPosition;
    
    public void SetMoveValue(InputAction.CallbackContext context)
    {
        Move = context.ReadValue<Vector2>();
    }
    
    private void Update()
    {
        MouseScreenPosition = Mouse.current.position.ReadValue();
    }

}
