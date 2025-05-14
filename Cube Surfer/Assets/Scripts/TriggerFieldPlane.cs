using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFieldPlane : MonoBehaviour
{
    public MovingEnemyPlane Plane;
    public FrontPropeller rotatingPropeller;
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.CompareTag("Player"))
        {
            Plane.Fly();
            rotatingPropeller.FlyAndRotate();
        }
        //Debug.Log("hangi objeye çarpıyor");
    }
}
