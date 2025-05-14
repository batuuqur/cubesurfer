using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class EndOfTheLine : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<cubeMechanic>())
        {
            other.gameObject.GetComponent<cubeMechanic>().onTheLine = false;  
            other.gameObject.GetComponent<cubeMechanic>().isFinished = true;
        }
    }

}
