using UnityEngine;
using UnityEngine.InputSystem;

public class Crosshair : MonoBehaviour
{
    private GameObject player;
    private PlayerInput playerInput;

    private SpriteRenderer sprite;
    private Color opacity;
    
    private Vector2 mousePos;
    private Vector2 crosshairPos;

    public float scale;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerInput = FindObjectOfType<PlayerInput>();

        sprite = GetComponent<SpriteRenderer>();
        opacity = sprite.color;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    void Update()
    {
        mousePos = playerInput.actions["Aim"].ReadValue<Vector2>();        

        if(playerInput.currentControlScheme == "Gamepad")
        {
            crosshairPos = (mousePos.normalized * scale) + (Vector2)player.transform.position;
        }
        else if(playerInput.currentControlScheme == "Keyboard")
        {
            crosshairPos = Camera.main.ScreenToWorldPoint(mousePos);   
        }
        transform.position = new Vector2(crosshairPos.x, crosshairPos.y);

        UpdateVisibility();
    }

    private void UpdateVisibility()
    {
        if(playerInput.currentControlScheme == "Gamepad")
        {
            if(mousePos == Vector2.zero)
            {
                sprite.enabled = false;
            }
            else
            {
                sprite.enabled = true;
            }
            opacity.a = 0.5f;
            GetComponent<SpriteRenderer>().color = opacity;            
        }
        else if(playerInput.currentControlScheme == "Keyboard")
        {
            sprite.enabled = true;       
        }   
        opacity.a = 0.5f;
        GetComponent<SpriteRenderer>().color = opacity; 
    }
}
