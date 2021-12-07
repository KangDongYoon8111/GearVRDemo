using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public Text doorText;
    public Text subText;

    public string doorString;
    public string tooltipString;

    void Start()
    {
        doorText = GameObject.Find("DoorText").GetComponent<Text>();
        subText = GameObject.Find("SubText").GetComponent<Text>();
    }

    void Update()
    {
        
    }

    void OnVREnter(){
        doorText.text = doorString;
        subText.text = tooltipString;
    }

    void OnVRExit(){
        doorText.text = "";
        subText.text = "";
    }
}
