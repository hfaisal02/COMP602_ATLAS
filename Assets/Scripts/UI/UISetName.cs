using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UISetName : MonoBehaviour
{
    public TMP_InputField object_text;
    
    public void SetName()
    {
        PlayerData.playerName = object_text.text;
        Debug.Log(PlayerData.playerName);
        SceneManager.LoadScene("TownTest");
    }
}
