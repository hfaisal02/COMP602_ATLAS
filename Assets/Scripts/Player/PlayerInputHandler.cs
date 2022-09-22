using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private GameObject gameManager;
    public Vector2 rawMovementInput {get; private set;}

    public void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        rawMovementInput = context.ReadValue<Vector2>();
        Debug.Log("move input");
    }

    public void OnDashInput(InputAction.CallbackContext context)
    {
        Debug.Log("dash input");
    }

    public void OnPauseInput(InputAction.CallbackContext context)
    {
        gameManager.GetComponent<UIPauseMenu>().Pause();
        Debug.Log("pause button pressed");
    }

    public void OnMapInput(InputAction.CallbackContext context)
    {
        gameManager.GetComponent<UIMapMenu>().Open();
        Debug.Log("pause button pressed");
    }
}
