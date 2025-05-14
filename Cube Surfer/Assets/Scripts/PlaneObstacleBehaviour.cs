using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlaneObstacleBehaviour : MonoBehaviour
{
    public bool available = true;
    private int x;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject[] cubesChild = GameObject.FindGameObjectsWithTag("AfterCollection");
            
            int parentCount = other.gameObject.GetComponentsInChildren<MeshRenderer>().Length;
            x = other.gameObject.transform.childCount;
            for (int i =0;i<x-parentCount;i++)
            {
                
            }

            Debug.Log(x+"x budur");
            Debug.Log(parentCount+"parentcount budur");
        }
    }
}
