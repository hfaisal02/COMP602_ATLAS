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

    private void Start()
    {
        health = maxHealth;
    }

    private void OnEnable()
    {
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
}
