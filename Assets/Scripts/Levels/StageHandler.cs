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
        int rand = Random.Range(0, gameManager.stagesList.Count);

        SceneManager.LoadScene(gameManager.stagesList[rand]);
        gameManager.stagesList.RemoveAt(rand);
        
        Debug.Log(gameManager.stagesList);

        OnStageChanged?.Invoke();
    }
}
