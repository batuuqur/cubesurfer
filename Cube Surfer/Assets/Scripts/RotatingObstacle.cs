using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{
    public float speed;
    //public ObstacleBehaviour horizontal;
    //public ObstacleBehaviour vertical;

    void Update()
    {
        //transform.Rotate(0, Time.deltaTime * speed,0); 
        var angles = transform.eulerAngles;
        angles.y += Time.deltaTime * speed;
        transform.eulerAngles = angles;
    }

}
