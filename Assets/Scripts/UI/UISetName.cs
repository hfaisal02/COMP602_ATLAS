using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UISetName : MonoBehaviour
{
    public TMP_InputField nameInputField;
    
    public void SetName()
    {
        if (nameInputField.text == "")
            PlayerData.playerName = "Player";
        else
            PlayerData.playerName = nameInputField.text;
    }
}
