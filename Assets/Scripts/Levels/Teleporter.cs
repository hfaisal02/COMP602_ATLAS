using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour, Interactable
{
    private StageHandler stageHandler;
    private bool interacted = false;

    public void Start()
    {
        stageHandler = GetComponent<StageHandler>();
    }

    public void Interact()
    {
        if(!interacted)
        {
            stageHandler.LoadNextStage();
            interacted = true;
        }
    }
}
