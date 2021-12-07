using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarPlayer : MonoBehaviour
{
    public Text topText;
    public Text bottomText;

    float speed = 1f;
    float maxSpeed = 10f;
    Quaternion moveRotate;
    Vector3 carRotate;
    Vector2 joystick;
    bool startTrigger = false;

    void Start()
    {
        
    }

    void Update()
    {
        Movement();
        UIController();
    }

    void Movement(){
        startTrigger = OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger);
        moveRotate = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);
        carRotate = moveRotate.eulerAngles;
        joystick = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

        if(startTrigger){
            transform.Translate(Vector3.forward * speed * joystick.y * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, carRotate.y, 0);
            if(maxSpeed <= 10f){
                speed+=0.1f;
            }
        }
        else{
            speed = 1f;
        }
    }

    void UIController(){
        topText.text = "StartTrigger : " + startTrigger + "\n Speed : " + (int)speed;
        bottomText.text = "Joystick Value : " + joystick + "\n MoveRotate : " + carRotate;
    }
}
