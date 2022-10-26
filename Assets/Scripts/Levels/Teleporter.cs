using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour, Interactable
{
    private StageHandler stageHandler;
    private InteractPrompt ip;

    private bool interacted = false;

    public void Awake()
    {
        stageHandler = GetComponent<StageHandler>();
        ip = GetComponent<InteractPrompt>();
    }

    public void Interact()
    {
        if(!interacted)
        {
            ip.InvokeEvent();
            stageHandler.LoadNextStage();

            interacted = true;
        }
    }
}
