using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponRotation : MonoBehaviour
{
    private Vector3 mousePosition;
    private Vector3 mouseVector;
    private PlayerInput playerInput;
    public Transform aim;

    void Start()
    {
        playerInput = FindObjectOfType<PlayerInput>();
    }
    void Update()
    {
        if(!PlayerData.menuActive)
        {
            GetMouseInput();
            WeaponAnimation();
        }
    }

    void GetMouseInput()
    {        
        if(playerInput.currentControlScheme == "Gamepad")
        {
            mouseVector = (playerInput.actions["Aim"].ReadValue<Vector2>()).normalized;            
        }
        else
        {
            mousePosition = Camera.main.ScreenToWorldPoint(playerInput.actions["Aim"].ReadValue<Vector2>());
            mouseVector = (mousePosition - transform.position).normalized;
        }        
    }
    void WeaponAnimation()
    {
        float weaponAngle = Mathf.Atan2(mouseVector.y, mouseVector.x) * Mathf.Rad2Deg;
        aim.eulerAngles = new Vector3(0, 0, weaponAngle);
    }
}
