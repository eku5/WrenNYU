using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingLoop : MonoBehaviour
{

    //Scales to screen

    float leftConstraint = Screen.width;
    float rightConstraint = Screen.width;

    float buffer = 1.0f;
    Camera cam;
    float distanceZ;

    void Start()
    {
        cam = Camera.main;
        distanceZ = Mathf.Abs(cam.transform.position.z + transform.position.z);

        leftConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
        rightConstraint = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;
    }

    void FixedUpdate()
    {
        if (transform.position.x < leftConstraint - buffer)
        {
            transform.position = new Vector3(rightConstraint + buffer, transform.position.y, transform.position.z);
        }
        if (transform.position.x > rightConstraint + buffer)
        {
            transform.position = new Vector3(leftConstraint - buffer, transform.position.y, transform.position.z);
        }
    }

}