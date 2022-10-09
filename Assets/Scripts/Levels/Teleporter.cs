using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : Interactable
{
    public string sceneName;

    public override void Interact()
    {
        base.Interact();
        SceneManager.LoadScene(sceneName);
    }
}
