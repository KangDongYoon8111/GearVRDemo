using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject gameObject;

    void Start()
    {
        gameObject = new GameObject();
    }

    void Update()
    {
        RaycastHit hit;
        transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);

        if(Physics.Raycast(transform.position, transform.forward, out hit)){
            if(hit.collider != null){
                if(gameObject != hit.collider.gameObject){
                    gameObject.SendMessage("OnVRExit");
                    gameObject = hit.transform.gameObject;
                    gameObject.SendMessage("OnVREnter");
                    Debug.Log("On VR Raycast Enter");
                }
                if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)){
                    gameObject.SendMessage("OnVRTriggerDown");
                }
            }
        }
        else{
            if(gameObject != null){
                gameObject.SendMessage("OnVRExit");
                gameObject = new GameObject();
            }
        }
    }
}
