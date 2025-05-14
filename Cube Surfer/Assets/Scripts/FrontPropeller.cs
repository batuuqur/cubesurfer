using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class FrontPropeller : MonoBehaviour
{
    private bool rotateAlready = false;
    public float speed;

    public void FlyAndRotate()
    {
        rotateAlready = true;
    }

    private void Update()
    {
        if (rotateAlready)
        {
            /*
            var euler = transform.localEulerAngles;
            euler.x += speed * Time.deltaTime;
            transform.localEulerAngles = euler;
            */
            transform.Rotate(speed*Time.deltaTime,0,0);
        }
    }
}

