using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    public int velocityx;
    public GameObject Tank;
    private bool movingAlready = false;

    public void Move()
    {
        movingAlready = true;
        Destroy(Tank, 5f);
    }

    void Update()
    {
        if (movingAlready)
        {
            transform.position += new Vector3(velocityx * Time.deltaTime, 0, 0);
        }

    }
}
