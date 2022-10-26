using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chest : MonoBehaviour, Interactable
{
    GameManager gm;
    public float price;
    //public float force;
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
            FindObjectOfType<AudioManager>().PlayOneShot("Unlock");

            gm.currency -= (int)price;

            int rand = Random.Range(0, items.Length);
            GameObject obj = Instantiate(items[rand], transform.position, Quaternion.identity);
            Vector2 dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

            //obj.GetComponent<Rigidbody2D>().AddForce(dir * force, ForceMode2D.Impulse);
            Destroy(gameObject);
        }        
    }
}
