using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuHandler : MonoBehaviour
{
    public GameObject obj;

    public void OpenMenu()
    {
        if (obj.activeSelf)
        {
            obj.SetActive(false);
            PlayerData.menuActive = false;
        }
        else if (!PlayerData.menuActive)
        {
            obj.SetActive(true);
            PlayerData.menuActive = true;
        }
    }
}
