using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    GameManager gm;

    public Weapon weapon;
    public Transform aim, tip;

    private PlayerInput playerInput;

    private Vector3 mousePosition, mouseVector, aimVector;
    private float cooldown, startCooldown;
    
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        playerInput = FindObjectOfType<PlayerInput>();

        if(gm.chosenWeapon)
            weapon = gm.chosenWeapon;

        startCooldown = weapon.fireRate;
        cooldown = 0;
    }
    
    void Update()
    {
        if(!PlayerData.menuActive)
        {
            GetMouseInput();
            WeaponAnimation();
            ShootProjectile();
        }
    }

    void GetMouseInput()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(playerInput.actions["Aim"].ReadValue<Vector2>());
        mousePosition.z = transform.position.z;

        if(playerInput.currentControlScheme == "Gamepad")
        {
            mouseVector = (playerInput.actions["Aim"].ReadValue<Vector2>()).normalized;
        }
        else
        {
            mouseVector = (mousePosition - transform.position).normalized;
        }

        if (mouseVector == Vector3.zero)
        {
            mouseVector = new Vector3(1, 0, 0);
        }
    }

    void WeaponAnimation()
    {
        float weaponAngle = Mathf.Atan2(mouseVector.y, mouseVector.x) * Mathf.Rad2Deg;
        aim.rotation = Quaternion.Euler(0, 0, weaponAngle);
    }

    void ShootProjectile()
    {
        if (cooldown <= 0)
        {
            if (InputManager.shootInput)
            {
                InputAimTest();

                if(weapon)
                {
                    Vector3 deviationAmount = new Vector3(Random.Range(-weapon.deviation, weapon.deviation), Random.Range(-weapon.deviation, weapon.deviation), 0);

                    var proj = Instantiate(weapon.bulletPrefab, tip.position, aim.rotation).GetComponent<Projectile>();

                    ProjectileTest(proj);

                    proj.Setup(mouseVector + deviationAmount, weapon.damage);
                    cooldown = startCooldown;
                }
            }
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }

    /*
     * Testing
     */

    //Acceptance Test 1
    public void InputAimTest()
    {
        if(InputManager.shootInput) //holds a reference to a boolean that is true or false depending on if the Left Mouse Button has been pressed
        {
            //if the boolean returns true, it confirms the left mouse button/shoot button has been pressed
            Debug.Log("The left mouse button has been pressed."); //print to the console

            //get a reference to the current mouse position as a vector 
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(playerInput.actions["Aim"].ReadValue<Vector2>()); 
                        
            if(mousePosition != null) //check if the mousePosition vector successfully recorded the mouse position
            {
                //get the correct aim direction by taking the normalised (between 0 and 1) difference between the mouse position and weapon position
                Vector3 aimDirection = (mousePosition - transform.position).normalized;

                Debug.Log("Mouse Position: " + mousePosition); //print the mouse position to the console (as a vector)

                if (aimDirection != null && (aimDirection.x <= 1 || aimDirection.y <= 1)) //check if the aimDirection vector successfully recorded the aim direction
                {
                    Debug.Log("Aim Direction: " + aimDirection); //print the aim direction to the console (as a vector)
                    //print final test results to the console
                    Debug.Log("A projectile will be fired in the direction " + aimDirection + " as the left mouse button input returned " + InputManager.shootInput);
                }
                else
                {
                    Debug.Log("Error finding aim direction, check calculation or normalization."); //print error message to console
                }
            }
            else
            {
                Debug.Log("Error finding mouse position."); //print error message to console
            }
        }
    }

    //Acceptance Test 2
    public void ProjectileTest(Projectile projectile) //pass in the projectile object that is to be instantiated when the shoot input is pressed
    {
        if (weapon) //check if the current weapon is not null
        {
            Debug.Log(weapon.toString()); //print the weapons stats to the console
        }
        else
        {
            Debug.Log("Error - no weapon has been set."); //print error message to console
        }

        if (projectile) //check if the projectile is not null
        {
            Debug.Log("[Projectile Stats] Move Speed: " + projectile.moveSpeed + ", Life Time: " + projectile.lifeTime); //print the projectiles stats to the console
        }
        else
        {
            Debug.Log("Error - no projectile object has been set."); //print error message to console
        }
    }
}
