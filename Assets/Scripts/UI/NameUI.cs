using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public GameObject interactText;

    private void OnEnable()
    {
        InteractPrompt.DisplayInteractPrompt += DisplayInteractPrompt;
    }

    void Update()
    {
        nameText.text = PlayerData.playerName;
    }

    void DisplayInteractPrompt()
    {
        if(!interactText.activeSelf)
        {
            interactText.SetActive(true);
        }
        else
        {
            interactText.SetActive(false);
        }
    }
}
