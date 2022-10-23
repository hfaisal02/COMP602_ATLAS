using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private GameObject gameManager;
    private GameObject uiManager;
    private Player player;
    public Vector2 RawMovementInput {get; private set;}
    
    [HideInInspector]
    public bool dashInput;
    private float inputHoldTime = 0.2f;
    private float dashStartTime;

    public bool ShootInput { get; private set; }
    public bool InteractInput { get; private set; }

    public void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        uiManager = GameObject.FindGameObjectWithTag("UIManager");
        if(uiManager == null)
        {
            Debug.Log("ui manager null");
        }
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();
        //Debug.Log("move input");
    }

    public void OnDashInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            dashInput = true;
            dashStartTime = Time.time;
        }
        //Debug.Log("dash input");
    }

    public void OnShootInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            //ShootInput = true;
            InputManager.shootInput = true;
        }
        else if(context.canceled)
        {
            //ShootInput = false;
            InputManager.shootInput = false;
        }
    }

    public void CheckDashHoldTime()
    {
        if(Time.time >= dashStartTime + inputHoldTime)
        {
            dashInput = false;
        }  
    }

    public void OnPauseInput(InputAction.CallbackContext context)
    {
        uiManager.GetComponent<UIPauseMenu>().Pause();
        //Debug.Log("pause button pressed");
    }

    public void OnMapInput(InputAction.CallbackContext context)
    {
        uiManager.GetComponent<UIMapMenu>().Open();
        //Debug.Log("map button pressed");
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            InputManager.interactInput = true;
            //InteractInput = true;
        }
        else if(context.canceled)
        {
            InputManager.interactInput = false;
            //InteractInput = false;
        }
    }

    public void OnInventoryInput(InputAction.CallbackContext context)
    {
        //gameManager.GetComponent<UIMenuHandler>().OpenMenu();
    }
}
