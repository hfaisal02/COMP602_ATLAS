using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Currency : MonoBehaviour, ICollectable
{
    public static event HandleCurrencyCollection OnCurrencyCollected;
    public delegate void HandleCurrencyCollection(int amount);

    public int amount; 

    public void Collect()
    {
        OnCurrencyCollected?.Invoke(amount);
        Destroy(gameObject);
    }
}
