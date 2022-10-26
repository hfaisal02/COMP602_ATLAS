using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponChoice : MonoBehaviour
{
    GameManager gm;

    public Weapon choice1;
    public Weapon choice2;
    public Weapon choice3;
    
    public Button button1;
    public Button button2;
    public Button button3;

    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();

        text1.text = choice1.weaponName;
        text2.text = choice2.weaponName;
        text3.text = choice3.weaponName;
    }

    public void SetWeapon(int index)
    {
        switch(index)
        {
            case 0:
                gm.chosenWeapon = choice1;
                button1.Select();
                break;
            case 1:
                gm.chosenWeapon = choice2;
                button2.Select();
                break;
            case 2:
                gm.chosenWeapon = choice3;
                button3.Select();
                break;
        }
    }
}
