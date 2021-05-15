using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Normalboy_navflee : MonoBehaviour
{
    private Normalboy_Master normalboyMaster;
    private NavMeshAgent myNavMeshAgent;
    private float checkRate;
    private float nextCheck;

    void OnEnable()
    {
        SetinitialRefrence();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            TryToFleeFormTarget();
        }
        
    }

    void SetinitialRefrence()
    {
        normalboyMaster = GetComponent<Normalboy_Master>();
        if(GetComponent<NavMeshAgent>() != null)
        {
            myNavMeshAgent = GetComponent<NavMeshAgent>();
        }
        checkRate = Random.Range(0.1f,0.2f);
    }

    void TryToFleeFormTarget()
    {
        if(normalboyMaster.myTarget != null && myNavMeshAgent != null && !normalboyMaster.isNavPaused)
        {
            Vector3 dirToTarget = transform.position - normalboyMaster.myTarget.position;
            Vector3 fleeTarget = transform.position + dirToTarget;
            myNavMeshAgent.SetDestination(fleeTarget);

            if(myNavMeshAgent.remainingDistance > myNavMeshAgent.stoppingDistance)
            {
                normalboyMaster.CallEventNormalboyFlee();
                normalboyMaster.isOnRoute = true;
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
