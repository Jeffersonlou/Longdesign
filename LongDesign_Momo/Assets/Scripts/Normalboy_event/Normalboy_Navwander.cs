using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Normalboy_Navwander : MonoBehaviour
{
    private Normalboy_Master normalboyMaster;
    private NavMeshAgent myNavMeshAgent;
    private float checkRate;
    private float nextCheck;
    private float wanderRange = 10;
    private Transform myTransform;
    private NavMeshHit navHit;
    private Vector3 wanderTarget;

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
            CheckIfIShouldwander();  
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
        myTransform = transform; 
    }

    void CheckIfIShouldwander()
    {
        if(normalboyMaster.myTarget == null && !normalboyMaster.isOnRoute && !normalboyMaster.isNavPaused)
        {
            if(RandomWanderTarget(myTransform.position,wanderRange,out wanderTarget))
            {
                myNavMeshAgent.SetDestination(wanderTarget);
                //Debug.Log(wanderTarget);
                normalboyMaster.isOnRoute = true;
                normalboyMaster.CallEventNormalboyWander();
            }
        }

    }

    bool RandomWanderTarget(Vector3 center,float range,out Vector3 result)
    {
        Vector3 randompoint = center + Random.insideUnitSphere * wanderRange;
        if(NavMesh.SamplePosition(randompoint,out navHit,1.0f,NavMesh.AllAreas))
        {
            result = navHit.position;
            return true;
        }
        else
        {
            result = center;
            return false;
        }

    }

    void DisableThis()
    {
        this.enabled = false;
    }

}
