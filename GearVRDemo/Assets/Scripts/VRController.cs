using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRController : MonoBehaviour
{
    public Text board;

    string boardText;

    void Update()
    {
        InputCheck();
        InputMovement();
    }

    void InputMovement(){
        // 리모트 컨트롤러의 회전값을 반영
        transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);
    }

    void InputCheck(){
        
        // 트리거 버튼의 클릭 여부 확인
        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)){
            boardText = "Pulled Trigger Button";
        }

        // 터치패드의 터치했는지 여부 확인
        if(OVRInput.Get(OVRInput.Touch.PrimaryTouchpad)){
            // 터치패드의 터치한 2D 좌푯값
            Vector2 touchPos = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
            boardText = "Touch Position : " + touchPos;
        }

        board.text = boardText;
    }
}
