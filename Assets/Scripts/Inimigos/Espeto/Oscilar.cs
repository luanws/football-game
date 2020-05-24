using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilar : MonoBehaviour
{
    private SliderJoint2D slider;
    private JointMotor2D motor;
    private float min;
    private float max;

    void Start() {
        slider = GetComponent<SliderJoint2D>();
        motor = slider.motor;
        min = slider.limits.min;
        min = slider.limits.min;
    }

    void Update() {
        if (slider.limitState == JointLimitState2D.UpperLimit) {
            motor.motorSpeed = -Mathf.Abs(motor.motorSpeed);
            slider.motor = motor;
        } else if (slider.limitState == JointLimitState2D.LowerLimit) {
            motor.motorSpeed = Mathf.Abs(motor.motorSpeed);
            slider.motor = motor;
        }
    }
}
