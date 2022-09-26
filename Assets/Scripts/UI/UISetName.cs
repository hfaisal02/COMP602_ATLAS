using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UISetName : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public GameObject sceneEssentials;
    
    public void SetName()
    {
        PlayerData.playerName = nameInputField.text;
        sceneEssentials.SetActive(true);
        SceneManager.LoadScene("TownTest");
    }
}
