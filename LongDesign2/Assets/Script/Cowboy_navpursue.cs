using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cowboy_navpursue : MonoBehaviour
{
    private Cowboy_master cowboyMaster;
    private NavMeshAgent myNavMeshAgent;
    private float checkRate;
    private float nextCheck;

    void OnEnable()
    {
        SetinitialRefrence();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > checkRate)
        {
            nextCheck = Time.time + checkRate;
            TryToChaseTarget();
        }
        
    }

    void SetinitialRefrence()
    {
        cowboyMaster = GetComponent<Cowboy_master>();
        if(GetComponent<NavMeshAgent>() != null)
        {
            myNavMeshAgent = GetComponent<NavMeshAgent>();
        }
        checkRate = Random.Range(0.1f,0.2f);
    }

    void TryToChaseTarget()
    {
        if(cowboyMaster.myTarget != null && myNavMeshAgent != null)
        {
            myNavMeshAgent.SetDestination(cowboyMaster.myTarget.position);

            if(myNavMeshAgent.remainingDistance > myNavMeshAgent.stoppingDistance)
            {
                cowboyMaster.CallEventCowboyChase();
                cowboyMaster.isOnRoute = true;
            }
        }
    }

    void DisableThis()
    {
        if(myNavMeshAgent != null)
        {
            myNavMeshAgent.enabled = false;
        }

        this.enabled = false;
    }
}
