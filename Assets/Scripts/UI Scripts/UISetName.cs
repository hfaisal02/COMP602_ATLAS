using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISetName : MonoBehaviour
{
    public Text object_text;
    public InputField nameDisplay;

    // Start is called before the first frame update
    void Start()
    {
        //object_text.text = PlayerData.playerName;
    }

    public void SetName()
    {
        PlayerData.playerName = object_text.text;
    }

    // Update is called once per frame
    void Update()
    {
        object_text = nameDisplay.text;
    }
}
