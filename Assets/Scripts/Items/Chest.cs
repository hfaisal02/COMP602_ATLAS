using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, Interactable
{
    public GameObject[] items;

    public void Interact()
    {
        int rand = Random.Range(0, items.Length);

        Instantiate(items[rand], transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
