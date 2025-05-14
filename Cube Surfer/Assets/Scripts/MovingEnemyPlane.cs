using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemyPlane : MonoBehaviour
{
    public int velocityx;
    public int velocityy;
    public GameObject plane;
    private bool movingAlready = false;

    public void Fly()
    {
        movingAlready = true;
        Destroy(plane,5f);
        //Invoke(nameof(PlaneDestroyer),5f);
    }

    void Update()
    {
        if (movingAlready)
        {
            transform.position += new Vector3(velocityx * Time.deltaTime, velocityy * Time.deltaTime, 0);
        }
        
    }
    
}
