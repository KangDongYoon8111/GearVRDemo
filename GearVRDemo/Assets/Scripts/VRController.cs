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
        // ����Ʈ ��Ʈ�ѷ��� ȸ������ �ݿ�
        transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);
    }

    void InputCheck(){
        
        // Ʈ���� ��ư�� Ŭ�� ���� Ȯ��
        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)){
            boardText = "Pulled Trigger Button";
        }

        // ��ġ�е��� ��ġ�ߴ��� ���� Ȯ��
        if(OVRInput.Get(OVRInput.Touch.PrimaryTouchpad)){
            // ��ġ�е��� ��ġ�� 2D ��ǩ��
            Vector2 touchPos = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
            boardText = "Touch Position : " + touchPos;
        }

        board.text = boardText;
    }
}
