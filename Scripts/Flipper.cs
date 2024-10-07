using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    public bool isRightFlipper; 

    private HingeJoint2D hingeJoint;

    void Start()
    {
        hingeJoint = GetComponent<HingeJoint2D>(); 
    }

    void Update()
    {
        if ((isRightFlipper && Input.GetKey(KeyCode.RightControl)) ||
            (!isRightFlipper && Input.GetKey(KeyCode.LeftControl)))
        {
            JointMotor2D motor = hingeJoint.motor;
            motor.motorSpeed = isRightFlipper ? -500f : 500f; 
            hingeJoint.motor = motor;
            hingeJoint.useMotor = true; 
        }
        else
        {
            hingeJoint.useMotor = false; 
        }
    }
}
