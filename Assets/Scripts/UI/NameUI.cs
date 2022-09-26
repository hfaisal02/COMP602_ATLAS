using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;

    void Update()
    {
        nameText.text = PlayerData.playerName;
    }
}
