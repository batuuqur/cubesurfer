using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovingEnemySoldier : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform[] waypoints;
    private int waypointIndex;
    private Vector3 target;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }
    
    private void Update()
    {
        if (Vector3.Distance(transform.position, target) < 0.5f)
        {
            IterateWayPointIndex();
            UpdateDestination();
        }
    }

    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
        //transform.LookAt(target);
    }

    void IterateWayPointIndex()
    {
        transform.LookAt(target);
        waypointIndex++;
        if (waypointIndex==waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

}
/*
   public Transform[] waypoints;
   public int speed;
   public int velocity;
   private int waypointindex;
   private float dist;

   private bool movingAlready = false;
   //private IEnumerator coroutine;

   void Update()
   {
       if (movingAlready)
       {
           transform.position += new Vector3(velocity * Time.deltaTime, 0, Mathf.Sin(Time.time));
           Debug.Log("hello soldier");
       }
       
   }

   public void OnTriggerEnter(Collider other)
   {
       if (other.transform.parent.CompareTag("Player"))
       {
           movingAlready=true;
       }
       //Debug.Log("hangi objeye çarpıyor");
   }

   public void OnTriggerExit(Collider other)
   {
       if (other.transform.parent.CompareTag("Player"))
       {
           movingAlready=false;
           //Destroy();
       }
   }
   */