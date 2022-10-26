using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    public GameObject creditsObject;
    public GameObject playerNameObject;

    public void UseButton(int index)
    {
        PlayButtonSound();

        switch (index)
        {
            case 0: //start game
                GetComponent<StageHandler>().LoadNextStage();
                GetComponent<InitGameplayObject>().SpawnGameplayObject();
                break;
            case 1: //credits 
                if (creditsObject)
                    creditsObject.SetActive(true);
                break;
            case 2: //back
                if (creditsObject)
                    creditsObject.SetActive(false);
                break;
            case 3: //quit
                Application.Quit();
                break;
            case 4: //main menu
                SceneManager.LoadScene("Main Menu");
                break;
            case 5: //player name prompt
                if (playerNameObject)
                    playerNameObject.SetActive(true);
                break;
        }
    }

    public void PlayButtonSound()
    {
        FindObjectOfType<AudioManager>().PlayOneShot("Stone");
    }
}
