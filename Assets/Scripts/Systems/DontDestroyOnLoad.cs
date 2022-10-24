using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public string objTag;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(objTag);

        if(objs.Length > 1)
        {
            Destroy(objs[0].gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
