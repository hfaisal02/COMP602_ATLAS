using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageHandler : MonoBehaviour
{
    public static event HandleStageChange OnStageChanged;
    public delegate void HandleStageChange();

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void LoadNextStage()
    {
        OnStageChanged?.Invoke();

        if (gameManager.stagesList.Count <= 0)
        {
            SceneManager.LoadScene(gameManager.bossStage);
            return;
        }

        int rand = Random.Range(0, gameManager.stagesList.Count);
        
        SceneManager.LoadScene(gameManager.stagesList[rand]);
        gameManager.stagesList.RemoveAt(rand);
        
        Debug.Log(gameManager.stagesList);
    }
}
