using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMapMenu : MonoBehaviour
{
    public GameObject canvas;

    public void Open()
    {
        if (canvas.activeSelf)
        {
            canvas.SetActive(false);
            PlayerData.menuActive = false;
        }
        else if(!PlayerData.menuActive)
        {
            canvas.SetActive(true);
            PlayerData.menuActive = true;
        }
    }
}
