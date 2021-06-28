using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cowboy_navNonAI : MonoBehaviour
{
    private Cowboy_masterNonAI _Cowboymaster;
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
        if (Time.time > _nextCheck)
        {
            _nextCheck = Time.time + _checkRate;
            TryToChaseTarget();
        }

    }

    void SetinitialRefrence()
    {
        _Cowboymaster = GetComponent<Cowboy_masterNonAI>();
        if (GetComponent<NavMeshAgent>() != null)
        {
            _myNavMeshAgent = GetComponent<NavMeshAgent>();
        }
        _checkRate = Random.Range(0.1f, 0.2f);
    }

    void TryToChaseTarget()
    {
        if (_Cowboymaster.myTarget != null && _myNavMeshAgent != null && !_Cowboymaster.isNavPaused)
        {
            _myNavMeshAgent.SetDestination(_Cowboymaster.myTarget.position);

            if (_myNavMeshAgent.remainingDistance > _myNavMeshAgent.stoppingDistance)
            {
                _Cowboymaster.CallEventCowboyChase();
                _Cowboymaster.isOnRoute = true;
            }
        }
    }

    void DisableThis()
    {
        if (_myNavMeshAgent != null)
        {
            _myNavMeshAgent.enabled = false;
        }

        this.enabled = false;
    }
}
