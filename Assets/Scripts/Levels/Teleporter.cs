using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour, Interactable
{
    private StageHandler stageHandler;

    public void Start()
    {
        stageHandler = GetComponent<StageHandler>();
    }

    public void Interact()
    {
        stageHandler.LoadNextStage();
    }
}
