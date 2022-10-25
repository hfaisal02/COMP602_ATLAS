using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGameplay : MonoBehaviour
{
    private GameManager gm;
    private Weapon weapon;

    public TextMeshProUGUI currencyText;
    public TextMeshProUGUI weaponText;

    public Slider healthBar;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        weapon = FindObjectOfType<WeaponController>().weapon;
    }
    
    void Update()
    {
        currencyText.text = "[Gold] " + gm.currency;
        weaponText.text = "[" + weapon.name + "]";

        healthBar.value = (float) gm.health / gm.maxHealth;
    }
}
