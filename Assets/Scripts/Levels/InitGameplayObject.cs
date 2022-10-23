using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGameplayObject : MonoBehaviour
{
    public GameObject gameplayObject;

    public void SpawnGameplayObject()
    {
        Instantiate(gameplayObject);
    }
}
