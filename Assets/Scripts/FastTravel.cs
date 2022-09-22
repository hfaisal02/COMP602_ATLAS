using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FastTravel : MonoBehaviour
{
    public Transform newLocation;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            collider.gameObject.transform.position = newLocation.position;
            //SceneManager.LoadScene("test"); //if the entire scene has to be changed on collision instead
        }
        else
        {
            Debug.Log("not the player");
        }

    }
}
