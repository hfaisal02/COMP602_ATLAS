using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    public Weapon weapon;
    public Transform aim, tip;

    private PlayerInput playerInput;

    private Vector3 mousePosition, mouseVector, aimVector;
    private float cooldown, startCooldown;
    
    void Start()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        startCooldown = weapon.fireRate;
        cooldown = 0;
    }
    
    void Update()
    {
        GetMouseInput();
        WeaponAnimation();
        ShootProjectile();
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
                Vector3 deviationAmount = new Vector3(Random.Range(-weapon.deviation, weapon.deviation), Random.Range(-weapon.deviation, weapon.deviation), 0);

                var proj = Instantiate(weapon.bulletPrefab, tip.position, aim.rotation).GetComponent<Projectile>();
                proj.Setup(mouseVector + deviationAmount, weapon.damage);
                cooldown = startCooldown;
            }
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }
}
