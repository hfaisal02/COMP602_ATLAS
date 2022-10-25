using UnityEngine;
using TMPro;

public class UIPlayer : MonoBehaviour
{
    GameManager gm;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI healthText;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        nameText.text = "[" + PlayerData.playerName + "]";
        healthText.text = gm.health + " / " + gm.maxHealth;
    }
}
