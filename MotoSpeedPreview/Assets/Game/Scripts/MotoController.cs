using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotoController : MonoBehaviour
{
    public WheelJoint2D [] wheelJoint;

    private bool isTouchingLeft;
    private bool isTouchingRight;
    private int activeTouchIndex;

    
    
    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        { 
        Touch touch = Input.GetTouch(i);
            if (touch.position.x < Screen.width / 2)
            {
                isTouchingLeft = true;
                isTouchingRight = false;
                activeTouchIndex = i;
              
            }
            else
            {
                isTouchingLeft =false;
                isTouchingRight = true;
                activeTouchIndex = i;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                OnTouchEnd();
            }
        }
        if (isTouchingLeft)
        {
            var motor = new JointMotor2D { motorSpeed = 1200, maxMotorTorque = 1500f };
            wheelJoint[0].motor = motor;
            wheelJoint[1].motor = motor;
        }
        else if (isTouchingRight)
        {
            var motor = new JointMotor2D { motorSpeed = -1200, maxMotorTorque = 1500f };
            wheelJoint[0].motor = motor;
            wheelJoint[1].motor = motor;
        }
       
    }
    
    void OnTouchEnd()
    {
        isTouchingLeft = false;
        isTouchingRight = false;
        activeTouchIndex = -1;
        var motor = new JointMotor2D { motorSpeed = 0, maxMotorTorque = 1000f };
        wheelJoint[0].motor = motor;
        wheelJoint[1].motor = motor;
    }
}
