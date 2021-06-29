using UnityEngine;
using UnityEngine.AI;

public class Arthur_NavDestinationReached : MonoBehaviour
{
    private Arthur_Master _arthurMaster;
    private NavMeshAgent _myNavMeshAgent;
    private float _checkRate;
    private float _nextCheck;

    void OnEnable() 
    {
        SetinitialRefrence();
    }

    void Update() 
    {
        if(Time.time > _nextCheck)
        {
            _nextCheck = Time.time + _checkRate;
            CheckifReachedDestination();
        }
    }

    void SetinitialRefrence()
    {
        _arthurMaster = GetComponent<Arthur_Master>();
        if(GetComponent<NavMeshAgent>() != null)
        {
            _myNavMeshAgent = GetComponent<NavMeshAgent>();
        }
        _checkRate = Random.Range(0.3f,0.4f); 
    }

    void CheckifReachedDestination()
    {
        if(_arthurMaster.isOnRoute)
        {
            if(_myNavMeshAgent.remainingDistance <= _myNavMeshAgent.stoppingDistance)
            {
                _arthurMaster.isOnRoute = false;
                _arthurMaster.CallEventArthurReachedTarget();
            }

        }
    }

    void DisableThis()
    {
        this.enabled = false;
    }
}

