using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Normalboy_NavDestinationReached : MonoBehaviour
{
    private Normalboy_Master normalboyMaster;
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
        if(Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            CheckifReachedDestination();
        }
    }

    void SetinitialRefrence()
    {
       normalboyMaster = GetComponent<Normalboy_Master>();
        if(GetComponent<NavMeshAgent>() != null)
        {
            myNavMeshAgent = GetComponent<NavMeshAgent>();
        }
        checkRate = Random.Range(0.3f,0.4f); 
    }

    void CheckifReachedDestination()
    {
        if(normalboyMaster.isOnRoute)
        {
            if(myNavMeshAgent.remainingDistance <= myNavMeshAgent.stoppingDistance)
            {
                normalboyMaster.isOnRoute = false;
                normalboyMaster.CallEventNormalboyReachedTarget();
            }

        }
    }

    void DisableThis()
    {
        this.enabled = false;
    }
}
