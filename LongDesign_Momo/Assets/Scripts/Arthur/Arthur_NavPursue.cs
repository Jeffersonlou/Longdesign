using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Arthur_NavPursue : MonoBehaviour
{
    private Arthur_Master _arthurmaster;
    private NavMeshAgent _myNavMeshAgent;
    private float _checkRate;
    private float _nextCheck;

    void OnEnable()
    {
        SetinitialRefrence();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > _nextCheck)
        {
            _nextCheck = Time.time + _checkRate;
            TryToChaseTarget();
        }
        
    }

    void SetinitialRefrence()
    {
        _arthurmaster = GetComponent<Arthur_Master>();
        if(GetComponent<NavMeshAgent>() != null)
        {
            _myNavMeshAgent = GetComponent<NavMeshAgent>();
        }
        _checkRate = Random.Range(0.1f,0.2f);
    }

    void TryToChaseTarget()
    {
        if(_arthurmaster.myTarget != null && _myNavMeshAgent != null && !_arthurmaster.isNavPaused)
        {
            _myNavMeshAgent.SetDestination(_arthurmaster.myTarget.position);

            if(_myNavMeshAgent.remainingDistance > _myNavMeshAgent.stoppingDistance)
            {
                _arthurmaster.CallEventArthurChase();
                _arthurmaster.isOnRoute = true;
            }
        }
    }

    void DisableThis()
    {
        if(_myNavMeshAgent != null)
        {
            _myNavMeshAgent.enabled = false;
        }

        this.enabled = false;
    }
}
