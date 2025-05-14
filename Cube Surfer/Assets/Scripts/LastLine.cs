using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastLine : MonoBehaviour
{
    public bool openParachute=false;
    private void OnCollisionEnter(Collision other)
    {
        openParachute=true;
    }
}
