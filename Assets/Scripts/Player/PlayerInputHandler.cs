using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 rawMovementInput {get; private set;}

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        //rawMovementInput = context.ReadValue<Vector2>();
        Debug.Log("move input");
    }

    public void OnDashInput(InputAction.CallbackContext context)
    {
        Debug.Log("dash input");
    }
}
