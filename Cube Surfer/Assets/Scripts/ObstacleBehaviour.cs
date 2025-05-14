using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    public int height;
    public bool available=true;
   
    private void OnCollisionEnter(Collision other)
    {
        if (available)
        {
            var cubeMechanic = other.gameObject.GetComponent<cubeMechanic>();
            cubeMechanic.Remove(height);
            available = false;
        }
    }

}
