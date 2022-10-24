using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class IntroAnim : MonoBehaviour
{
    public TextMeshProUGUI text;
    private GameManager gameManager;
    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        if(gameManager.currentStage == 5)
            text.text = "Final Stage\n" + SceneManager.GetActiveScene().name;
        else
            text.text = "Stage " + gameManager.currentStage + "\n" + SceneManager.GetActiveScene().name;

        Destroy(text.transform.parent.gameObject, 3);
    }
}
