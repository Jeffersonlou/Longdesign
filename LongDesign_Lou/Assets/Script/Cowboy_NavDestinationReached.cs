using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cowboy_NavDestinationReached : MonoBehaviour
{
    private Cowboy_master cowboyMaster;
    private NavMeshAgent myNavMeshAgent;
    private float checkRate;
    private float nextCheck;

    void OnEnable() 
    {
        SetinitialRefrence();
    }


    void OnDisable()
    {
        
    }

    void Update() 
    {
        if(Time.time > checkRate)
        {
            nextCheck = Time.time + checkRate;
            CheckifReachedDestination();
        }
    }

    void SetinitialRefrence()
    {
       cowboyMaster = GetComponent<Cowboy_master>();
        if(GetComponent<NavMeshAgent>() != null)
        {
            myNavMeshAgent = GetComponent<NavMeshAgent>();
        }
        checkRate = Random.Range(0.3f,0.4f); 
    }

    void CheckifReachedDestination()
    {
        if(cowboyMaster.isOnRoute)
        {
            if(myNavMeshAgent.remainingDistance < myNavMeshAgent.stoppingDistance)
            {
                cowboyMaster.isOnRoute = false;
                cowboyMaster.CallEventCowboyReachedTarget();
            }

        }
    }

    void DisableThis()
    {
        this.enabled = false;
    }
}
