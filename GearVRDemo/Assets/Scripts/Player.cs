using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Vector2 joystick;
    public GameObject centerEye;
    public GameObject pObject;

    void Start()
    {
        
    }

    void Update()
    {
        joystick = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
        //joystick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        transform.eulerAngles = new Vector3(0, centerEye.transform.localEulerAngles.y,0);
        transform.Translate(Vector3.forward * speed * joystick.y * Time.deltaTime);
        transform.Translate(Vector3.right * speed * joystick.x*Time.deltaTime);

        pObject.transform.position = Vector3.Lerp(pObject.transform.position, transform.position, 10f*Time.deltaTime);
    }
}
