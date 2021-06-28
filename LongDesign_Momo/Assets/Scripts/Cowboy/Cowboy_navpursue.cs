using System.Collections;
using System.Collections.Generic;
using MalbersAnimations;
using MalbersAnimations.Controller;
using MalbersAnimations.HAP;
using UnityEngine;
using UnityEngine.AI;

public class Cowboy_navpursue : MonoBehaviour
{
    private Cowboy_master cowboyMaster;
    private NavMeshAgent myNavMeshAgent;
    public MAnimalAIControl AIControl;
    private float checkRate;
    private float nextCheck;
    public Transform Horse;
    public MRider mRider;
    public IAITarget IsAITarget { get; set; }

    void OnEnable()
    {
        SetinitialRefrence();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextCheck)
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
        if(cowboyMaster.myTarget != null && myNavMeshAgent != null && !cowboyMaster.isNavPaused)
        {
            //Debug.Log(myNavMeshAgent.remainingDistance);
            myNavMeshAgent.SetDestination(Horse.position);

            if(mRider.IsOnHorse)
            {
                if(AIControl.IsAITarget == null)
                {
                    //Debug.Log("null");
                    AIControl.SetTarget(cowboyMaster.myTarget);
                }
                AIControl.SetTarget(cowboyMaster.myTarget);

            }

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
