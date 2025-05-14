using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deploy : MonoBehaviour
{
    public GameObject parachute;
    public LastLine timeToFly;

    void Update()
    {
        if (timeToFly.openParachute)
        {
            StartCoroutine(OpenNow());
        }
        
        IEnumerator OpenNow()
        {
            yield return new WaitForSeconds(2f);
            parachute.SetActive(true);
            GetComponent<Rigidbody>().drag = 2;
        }
    }
}
