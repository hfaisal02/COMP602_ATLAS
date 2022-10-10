using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour, Interactable
{
    public string sceneName;

    public void Interact()
    {
        SceneManager.LoadScene(sceneName);
    }
}
