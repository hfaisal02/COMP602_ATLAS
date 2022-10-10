using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    [Header("Info")]
    public string weaponName;
    [TextArea(5, 10)]
    public string description;

    [Header("Stats")]
    public float damage;
    public float fireRate;
    public float deviation;
    
    public GameObject bulletPrefab;
    public bool semiAuto;

    [Header("Sprite")]
    public Sprite sprite;
    public float scaleX, scaleY;
}
