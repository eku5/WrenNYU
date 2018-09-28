using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothTime = 0.3F;
    public float posY;

    //setting the max and min points where camera can go
    public float xMax;
    public float xMin;
    public float yMax;
    public float yMin;


    private Vector3 velocity = Vector3.zero;
    void Update()
    {
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, posY, -10)); //making smooth camera movement to follow player
        Vector3 desiredPosition = transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.position = new Vector3(Mathf.Clamp(desiredPosition.x, xMin, xMax), Mathf.Clamp(desiredPosition.y, yMin, yMax), transform.position.z);
    }
}


