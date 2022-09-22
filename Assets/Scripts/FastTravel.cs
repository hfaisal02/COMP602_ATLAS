using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FastTravel : MonoBehaviour
{
    public Transform newLocation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            //collider.gameObject.transform.position = newLocation.position;
            SceneManager.LoadScene("test");
        }
        else
        {
            Debug.Log("nah bruv");
        }

    }
}
