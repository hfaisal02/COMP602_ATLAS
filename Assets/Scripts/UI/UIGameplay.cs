using UnityEngine;
using TMPro;

public class UIGameplay : MonoBehaviour
{
    public TextMeshProUGUI currencyText;
    private GameManager gameManager;

    void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }
    
    void Update()
    {
        currencyText.text = "Gold: " + gameManager.currency;
    }
}
