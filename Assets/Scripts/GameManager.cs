using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /*
    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }
    

    private static GameManager instance;
    */

    [Header("Player Stats")]
    public int health;
    public int maxHealth;

    public int currency;
    [HideInInspector]
    public int currentStage;

    [Header("Stages")]
    //[HideInInspector]
    public List<string> stagesList = new List<string>();
    public string bossStage;

    private void Start()
    {
        health = maxHealth;
        currentStage = 0;
    }

    private void OnEnable()
    {
        StageHandler.OnStageChanged += OnStageChanged;
        Currency.OnCurrencyCollected += AddCurrency;
    }

    private void OnDisable()
    {
        Currency.OnCurrencyCollected -= AddCurrency;
    }

    void AddCurrency(int amount)
    {
        currency += amount;
        Debug.Log(currency);
    }

    void OnStageChanged()
    {
        currentStage += 1;
        Debug.Log("GM" + currentStage);
    }
}
