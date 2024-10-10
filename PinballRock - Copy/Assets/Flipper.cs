using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    public bool isRightFlipper;

    private HingeJoint2D hingeJoint;
    public float flipSpeed = 1000f; // Speed when this thing actually works
    public float returnSpeed = 500f; // Speed when it decides to chill out

    void Start()
    {
        hingeJoint = GetComponent<HingeJoint2D>();

        // Set limits so the flipper doesn't lose its damn mind
        JointAngleLimits2D limits = hingeJoint.limits;
        limits.min = isRightFlipper ? -45f : -45f; // Min limit
        limits.max = isRightFlipper ? 45f : 45f; // Max flex
        hingeJoint.limits = limits;
        hingeJoint.useLimits = true;
    }

    void Update()
    {
        // Motor control
        if ((isRightFlipper && Input.GetKey(KeyCode.W)) ||
            (!isRightFlipper && Input.GetKey(KeyCode.S)))
        {
            JointMotor2D motor = hingeJoint.motor;
            motor.motorSpeed = isRightFlipper ? -flipSpeed : flipSpeed; // Flip like it means it
            hingeJoint.motor = motor;
            hingeJoint.useMotor = true;
        }
        else
        {
            // Now return to mediocrity after all that effort
            JointMotor2D motor = hingeJoint.motor;
            motor.motorSpeed = isRightFlipper ? returnSpeed : -returnSpeed; // Reverse because life is meaningless
            hingeJoint.motor = motor;
            hingeJoint.useMotor = true;
        }
    }
}
