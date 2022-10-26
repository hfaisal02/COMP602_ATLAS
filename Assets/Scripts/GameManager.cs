using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        PlayerBehaviour.OnHealthChanged += UpdateHealth;
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

    public void UpdateHealth(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Gameplay"));
            Destroy(gameObject);
            SceneManager.LoadScene("Game Over");
            Debug.Log("game over");
        }
    }
}
