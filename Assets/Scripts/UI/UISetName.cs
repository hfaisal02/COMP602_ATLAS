using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISetName : MonoBehaviour
{
    public TMP_InputField object_text;
    
    public void SetName()
    {
        PlayerData.playerName = object_text.text;
        Debug.Log(PlayerData.playerName);
    }
}
