using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheelScripts : MonoBehaviour {
        public int turnSpeed;
        public GameObject wheel;
        float rotations = 0;
    Quaternion defaultRotation;

    void Start()
    {
        defaultRotation = wheel.transform.localRotation;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {

            wheel.transform.Rotate(-Vector3.up * Time.deltaTime * turnSpeed);
            rotations -= turnSpeed;
        }

        else if (Input.GetKey(KeyCode.D))
        {

            wheel.transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);
            rotations += turnSpeed;
        }
     else    //rotate to default
     {
            if (rotations < -1)
            {
                wheel.transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);
                rotations += turnSpeed;
            }
            else if (rotations > 1)
            {
                wheel.transform.Rotate(-Vector3.up * Time.deltaTime * turnSpeed);
                rotations -= turnSpeed;
            }
            else if (rotations != 0)
            {
                wheel.transform.localRotation = defaultRotation;
                rotations = 0;
            }
        }
    }
}
