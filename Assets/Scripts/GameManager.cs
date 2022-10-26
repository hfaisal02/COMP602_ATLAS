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

    public Weapon chosenWeapon;

    public int currency;
    [HideInInspector]
    public int currentStage;

    [Header("Stages")]
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
        BossBehaviour.OnBossDefeated += CompleteGame;
        Currency.OnCurrencyCollected += AddCurrency;
    }

    private void OnDisable()
    {
        Currency.OnCurrencyCollected -= AddCurrency;
    }

    void AddCurrency(int amount)
    {
        FindObjectOfType<AudioManager>().PlayOneShot("Select");

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
        FindObjectOfType<AudioManager>().PlayOneShot("Player Hit");

        health -= amount;

        if(health <= 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Gameplay"));
            Destroy(gameObject);
            SceneManager.LoadScene("Game Over");
        }
    }

    public void CompleteGame()
    {
        Destroy(GameObject.FindGameObjectWithTag("Gameplay"));
        Destroy(gameObject);
        SceneManager.LoadScene("Game Won");
    }
}
