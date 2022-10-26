using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chest : MonoBehaviour, Interactable
{
    GameManager gm;
    public float price;
    public GameObject[] items;
    public TextMeshProUGUI priceText;

    public void Start()
    {
        gm = FindObjectOfType<GameManager>();
        price *= gm.currentStage;
        priceText.text = price + " Gold";
    }

    public void Interact()
    {
        if(gm.currency >= price)
        {
            gm.currency -= (int)price;

            int rand = Random.Range(0, items.Length);
            FindObjectOfType<AudioManager>().PlayOneShot("Unlock");
            Instantiate(items[rand], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }        
    }
}
