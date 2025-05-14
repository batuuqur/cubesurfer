using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFieldTank : MonoBehaviour
{
    public MovingEnemy Tank;

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.CompareTag("Player"))
        {
            Tank.Move();
        }
        //Debug.Log("hangi objeye çarpýyor");
    }
}
