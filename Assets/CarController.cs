using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    void UpdateWheelTransform(WheelCollider wheel)

    {

        // Get the Transform we want to move and rotate

        var wheelModel = wheel.transform.GetChild(0);



        // Declare variables to store the position and rotation in

        Vector3 position;

        Quaternion rotation;



        // Find out where the wheel should be, and how it should be rotated

        wheel.GetWorldPose(out position, out rotation);



        // Update the wheel position and rotation

        wheelModel.position = position;

        wheelModel.rotation = rotation;

    }

    public float maxTorque = 2000f;
    public float maxSteerAngle = 30f;

    public List<WheelCollider> rearWheels;
    public List<WheelCollider> frontWheels;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var accel = Input.GetAxis( "Vertical" );
        var steer = Input.GetAxis( "Horizontal" );
        foreach ( var wheel in rearWheels )
        {
            wheel.motorTorque = maxTorque * accel;
            UpdateWheelTransform(wheel);
        }
        foreach ( var wheel in frontWheels )
        {
            wheel.steerAngle = maxSteerAngle * steer;
            UpdateWheelTransform(wheel);
        }
    }
}