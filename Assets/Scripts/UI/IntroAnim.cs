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
        text.text = "Stage " + gameManager.currentStage + "\n" + SceneManager.GetActiveScene().name;
        Destroy(text.transform.parent.gameObject, 3);
    }
}
