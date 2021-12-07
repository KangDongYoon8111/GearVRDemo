using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool opened;
    public Vector3 openPosition, closePosition;

    void Start()
    {
        opened = false;
        closePosition = transform.position;
    }

    void Update()
    {
        if(!opened) transform.position = Vector3.Lerp(transform.position, closePosition, Time.deltaTime * 5f);
        if(opened) transform.position = Vector3.Lerp(transform.position, openPosition, Time.deltaTime * 5f);
    }

    void OnVRTriggerDown(){
        opened = true;
    }
}
