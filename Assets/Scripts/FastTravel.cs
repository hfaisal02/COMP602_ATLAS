using UnityEngine;
using UnityEngine.SceneManagement;

public class FastTravel : MonoBehaviour
{
    public Transform newLocation;
    public bool sceneChange;
    public string sceneName;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            if(sceneChange)
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                collider.gameObject.transform.position = newLocation.position;
            }
        }
        else
        {
            Debug.Log("not the player");
        }

    }
}
