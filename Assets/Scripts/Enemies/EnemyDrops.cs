using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrops : MonoBehaviour
{
    public GameObject currency;
    public int minAmount, maxAmount;
    public float maxX, maxY;

    public void DropLoot()
    {
        float amount = Random.Range(minAmount, maxAmount);

        for (int i = 0; i < amount; i++)
        {
            float randX = Random.Range(0, maxX);
            float randY = Random.Range(0, maxY);

            Instantiate(currency, transform.position + new Vector3(randX, randY), Quaternion.identity);
        }
    }
}
