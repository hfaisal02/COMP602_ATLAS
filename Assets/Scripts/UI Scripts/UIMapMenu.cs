using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMapMenu : MonoBehaviour
{
    public GameObject mapObject;

    public void Open()
    {
        if (mapObject.activeSelf)
        {
            mapObject.SetActive(false);
            PlayerData.menuActive = false;
        }
        else if(!PlayerData.menuActive)
        {
            mapObject.SetActive(true);
            PlayerData.menuActive = true;
        }
    }
}
